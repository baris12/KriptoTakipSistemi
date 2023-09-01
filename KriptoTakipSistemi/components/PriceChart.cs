using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class PriceChart : UserControl
    {

        public string Symbol { get; set; }
        public TIME_FRAME TimeFrame { get; set; }
        public int DataLength { get; set; }

        private ChartValues<PricePoint> PricePoints;
        private CancellationTokenSource TokenSource;

        private Button CurrentButton;

        public event Action StreamChanged;

        class PricePoint
        {
            public double Price;
            public long PriceTime;
        }
        public PriceChart()
        {
            InitializeComponent();
            InitializeChart();
            SetStyle();
            EnableButtons(false);
            CreateEventLinks();
        }


        private void CreateEventLinks()
        {
            StreamChanged += OnStreamChanged;
            button6.MouseUp += Button6_Click;
            btn_5m.MouseUp += Btn_5m_Click;
            btn_15m.MouseUp += Btn_15m_Click;
            btn_30m.MouseUp += Btn_30m_Click;
            btn_1h.MouseUp += Btn_1h_Click;
            btn_2h.MouseUp += Btn_2h_Click;
            btn_4h.MouseUp += Btn_4h_Click;
            btn_1D.MouseUp += Btn_1D_Click;
            btn_1W.MouseUp += Btn_1W_Click;
            btn_1M.MouseUp += Btn_1M_Click;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }
        private void InitializeChart()
        {
            LineSeries series = new LineSeries
            {
                Title = "Fiyat",
                Name = "price"
            };
            cartesianChart1.Series.Add(series);
            Charting.For<PricePoint>(Mappers.Xy<PricePoint>()
                .X(point => point.PriceTime) // PriceTime is used for x axis
                .Y(point => point.Price));   // Price is used for y axis

        }


        private void UpdateChart()
        {
            cartesianChart1?.Update();
        }
        private void ClearData()
        {
            cartesianChart1.Series.Clear();
            UpdateChart();
            InitializeChart();
        }

        public void OnChartHeaderUpdate(string data)
        {
            if (data == null)
            {
                return;
            }

            JObject _data = JObject.Parse(data);
            string headerSymbolName = _data["symbol"].ToString().ToUpper();
            double.TryParse(_data["price"].ToString(), out double headerPrice);
            double.TryParse(_data["changePercent"].ToString(), out double headerChangePercent);
            if (this.InvokeRequired)
            {
                lbl_symbolName.Invoke((MethodInvoker)delegate
                {
                    lbl_symbolName.Text = headerSymbolName;
                });
                lbl_lastPrice.Invoke((MethodInvoker)delegate
                {
                    lbl_lastPrice.Text = headerPrice.ToString();
                });
                lbl_pricePercent.Invoke((MethodInvoker)delegate
                {
                    lbl_pricePercent.Text = headerChangePercent.ToString();
                });
            }

            else
            {
                lbl_symbolName.Text = headerSymbolName;
                lbl_lastPrice.Text = headerPrice.ToString();
                lbl_pricePercent.Text = headerChangePercent.ToString();
            }
            return;
        }
        private void OnUpdatePriceData(string priceData)
        {
            JObject newPriceData = JObject.Parse(priceData);
            JObject priceDataObj = newPriceData;
            if (!double.TryParse(priceDataObj["close"].ToString(), out double lastPrice)) { return; }
            if (!long.TryParse(priceDataObj["openTime"].ToString(), out long openTime)) { return; }
            MergePriceData(new PricePoint { Price = lastPrice, PriceTime = openTime });
        }

        private void MergePriceData(PricePoint price)
        {
            int length = PricePoints.Count;

            if (length == 0)
            {
                PricePoints.Add(price);
            }
            else if (length > 0)
            {
                PricePoint lastCandle = PricePoints?.Last<PricePoint>();
                if (lastCandle?.PriceTime == price.PriceTime)
                {
                    if (lastCandle.Price != price.Price)
                    {
                        PricePoints.Remove(lastCandle);
                        PricePoints.Add(price);
                    }
                }
                else if (lastCandle?.PriceTime < price.PriceTime)
                {
                    PricePoints.Add(price);
                    if (length >= DataLength)
                    {
                        PricePoints.Remove(PricePoints.First<PricePoint>());
                    }
                }
            }
        }

        private async Task LoadPriceData()
        {

            Task<string> headerTask = ExchangeClient.Instance.GetSingleSymbolTicker(Symbol);
            Task<JArray> priceTask = ExchangeClient.Instance.GetPriceData(Symbol, TimeFrame, DataLength);
            await Task.WhenAll(priceTask, headerTask);

            string newHeaderData = headerTask.Result;
            OnChartHeaderUpdate(newHeaderData); // getting header data is finished
            JArray newPriceData = priceTask.Result; // getting price data is finished
            for (int i = 0; newPriceData.Count > i; i++)// by starting the nextIndex, process the new price data and push them to the series
            {
                JObject priceDataObj = newPriceData[i] as JObject;
                if (!double.TryParse(priceDataObj["close"].ToString(), out double lastPrice)) { return; }
                if (!long.TryParse(priceDataObj["openTime"].ToString(), out long openTime)) { return; }
                MergePriceData(new PricePoint { Price = lastPrice, PriceTime = openTime });
            }
            StreamChanged?.Invoke();
        }
        private async Task StopStream()
        {
            await ExchangeClient.Instance.webSocketClient.UnsubscribeSingleTickerStream(Symbol, OnChartHeaderUpdate);
            await ExchangeClient.Instance.webSocketClient.UnsubscribeKlineStream(Symbol, TimeFrame, OnUpdatePriceData);
            TokenSource?.Cancel();
        }

        public async void StartStream(string symbol, TIME_FRAME timeFrame, int dataLength)
        {
            EnableButtons(false);
            ClearData();
            if (Symbol == null)
            {
                Symbol = symbol; TimeFrame = timeFrame; DataLength = dataLength;
                return;
            }
            await StopStream();
            Symbol = symbol; TimeFrame = timeFrame; DataLength = dataLength;
            PricePoints = new ChartValues<PricePoint>();
            cartesianChart1.Series[0].Values = PricePoints;
            await LoadPriceData();
            await ExchangeClient.Instance.webSocketClient.SubscribeSingleTickerStream(Symbol, OnChartHeaderUpdate);
            await ExchangeClient.Instance.webSocketClient.SubscribeKlineStream(symbol, TimeFrame, OnUpdatePriceData);
            StreamChanged?.Invoke();
            EnableButtons(true);

        }
        private void EnableButtons(bool enabled)
        {
            button6.Enabled = enabled;
            btn_5m.Enabled = enabled;
            btn_15m.Enabled = enabled;
            btn_30m.Enabled = enabled;
            btn_1h.Enabled = enabled;
            btn_2h.Enabled = enabled;
            btn_4h.Enabled = enabled;
            btn_1D.Enabled = enabled;
            btn_1W.Enabled = enabled;
            btn_1M.Enabled = enabled;
        }
        public void ChangeTimeFrame(TIME_FRAME tFrame)
        {
            StartStream(Symbol, tFrame, DataLength);

        }

        private void OnStreamChanged()
        {
            if (CurrentButton != null) { ThemeController.Instance.SetButtonStyle(CurrentButton, false); }

            if (TimeFrame == TIME_FRAME.ONE_MIN)
            {
                ThemeController.Instance.SetButtonStyle(button6, true);
                CurrentButton = button6;
            }
            else if (TimeFrame == TIME_FRAME.FIVE_MIN)
            {
                ThemeController.Instance.SetButtonStyle(btn_5m, true);
                CurrentButton = btn_5m;
            }
            else if (TimeFrame == TIME_FRAME.FIFTEEN_MIN)
            {
                ThemeController.Instance.SetButtonStyle(btn_15m, true);
                CurrentButton = btn_15m;
            }
            else if (TimeFrame == TIME_FRAME.THIRTY_MIN)
            {
                ThemeController.Instance.SetButtonStyle(btn_30m, true);
                CurrentButton = btn_30m;
            }
            else if (TimeFrame == TIME_FRAME.ONE_HOUR)
            {
                ThemeController.Instance.SetButtonStyle(btn_1h, true);
                CurrentButton = btn_1h;
            }
            else if (TimeFrame == TIME_FRAME.TWO_HOUR)
            {
                ThemeController.Instance.SetButtonStyle(btn_2h, true);
                CurrentButton = btn_2h;
            }
            else if (TimeFrame == TIME_FRAME.FOUR_HOUR)
            {
                ThemeController.Instance.SetButtonStyle(btn_4h, true);
                CurrentButton = btn_4h;
            }
            else if (TimeFrame == TIME_FRAME.ONE_DAY)
            {
                ThemeController.Instance.SetButtonStyle(btn_1D, true);
                CurrentButton = btn_1D;
            }
            else if (TimeFrame == TIME_FRAME.ONE_WEEK)
            {
                ThemeController.Instance.SetButtonStyle(btn_1W, true);
                CurrentButton = btn_1W;
            }
            else if (TimeFrame == TIME_FRAME.ONE_MONTH)
            {
                ThemeController.Instance.SetButtonStyle(btn_1M, true);
                CurrentButton = btn_1M;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.ONE_MIN);
        }

        private void Btn_5m_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.FIVE_MIN);
        }

        private void Btn_15m_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.FIFTEEN_MIN);
        }

        private void Btn_30m_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.THIRTY_MIN);
        }

        private void Btn_1h_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.ONE_HOUR);
        }

        private void Btn_2h_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.TWO_HOUR);
        }

        private void Btn_4h_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.FOUR_HOUR);
        }

        private void Btn_1D_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.ONE_DAY);
        }

        private void Btn_1W_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.ONE_WEEK);
        }

        private void Btn_1M_Click(object sender, EventArgs e)
        {
            ChangeTimeFrame(TIME_FRAME.ONE_MONTH);
        }
        private void SetStyle()
        {
            ThemeController.Instance.SetBigLableStyle(lbl_symbolName);
            ThemeController.Instance.SetBigLableStyle(lbl_lastPrice);
            ThemeController.Instance.SetBigLableStyle(lbl_pricePercent);
            ThemeController.Instance.SetPanelStyle(pnl_chartTimeFrames);
            ThemeController.Instance.SetPanelStyle(pnl_chartHeader);

            ThemeController.Instance.SetButtonStyle(button6, false);
            ThemeController.Instance.SetButtonStyle(btn_5m, false);
            ThemeController.Instance.SetButtonStyle(btn_15m, false);
            ThemeController.Instance.SetButtonStyle(btn_30m, false);
            ThemeController.Instance.SetButtonStyle(btn_1h, false);
            ThemeController.Instance.SetButtonStyle(btn_2h, false);
            ThemeController.Instance.SetButtonStyle(btn_4h, false);
            ThemeController.Instance.SetButtonStyle(btn_1D, false);
            ThemeController.Instance.SetButtonStyle(btn_1W, false);
            ThemeController.Instance.SetButtonStyle(btn_1M, false);
        }

    }
}
