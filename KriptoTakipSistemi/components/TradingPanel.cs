using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class TradingPanel : UserControl
    {
        class PriceDataBinding
        {
            public string PriceText { get; set; }
        }
        string LoadedSymbol;
        PriceDataBinding priceDataBinding;

        public TradingPanel()
        {
            InitializeComponent();
            CreateDataBinding();
            LoadAllSymbols();
            CreateEventLinks();
            SetStyle();
        }

        private void CreateDataBinding()
        {
            priceDataBinding = new PriceDataBinding();
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetPanelStyle(panel1);
            ThemeController.Instance.SetPanelStyle(panel2);
            ThemeController.Instance.SetLabelStyle(lbl_Quantity);
            ThemeController.Instance.SetLabelStyle(lbl_SelectSymbol);
            ThemeController.Instance.SetButtonStyle(btn_Buy, true);
            ThemeController.Instance.SetButtonStyle(btn_Sell, true);
        }

        private void CreateEventLinks()
        {
            SymbolBox.SelectedValueChanged += OnSymbolSelected;
            btn_Buy.MouseUp += OnBuyClicked;
            btn_Sell.MouseUp += OnSellClicked;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void OnSellClicked(object sender, MouseEventArgs e)
        {
            SendSellOrder();
        }

        private void OnBuyClicked(object sender, MouseEventArgs e)
        {
            SendBuyOrder();
        }

        private void OnSymbolSelected(object sender, EventArgs e)
        {
            LoadSymbol(SymbolBox.Text);
        }

        private async void LoadSymbol(string symbol)
        {
            await ExchangeClient.Instance.webSocketClient.SubscribeSingleTickerStream(symbol, OnTickerUpdate);
            LoadedSymbol = symbol;
        }

        private void OnTickerUpdate(string obj)
        {

            JObject ticker = JObject.Parse(obj);
            if (ticker["symbol"].ToString() != LoadedSymbol) { return; }
            if (double.TryParse(ticker["price"].ToString(), out double lastPrice))
            {
                priceDataBinding.PriceText = lastPrice.ToString();
            }
        }


        private async void SendBuyOrder()
        {
            try
            {
                decimal quantity = decimal.Parse(QuantityBox.Text);
                Task<bool> buyTask = TradingClass.Instance.BuyMarket(LoadedSymbol, quantity);
                await Task.WhenAll(buyTask);
                if (buyTask.Result)
                {
                    MessageBox.Show("Başarılı!", "Uyarı");
                }
                else
                {
                    MessageBox.Show("Başarısız!", "Hata");
                }
            }
            catch
            {
                MessageBox.Show("Başarısız!", "Hata");
            }
        }

        private async void SendSellOrder()
        {
            try
            {
                decimal quantity = decimal.Parse(QuantityBox.Text);
                await TradingClass.Instance.SellMarket(LoadedSymbol, quantity);
                MessageBox.Show("Başarılı!", "Uyarı");
            }
            catch
            {
                MessageBox.Show("Başarısız!", "Hata");
            }
        }
        private async void LoadAllSymbols()
        {
            Task<List<string>> task = ExchangeClient.Instance.GetSymbolList();
            await Task.WhenAll(task);
            List<string> result = task.Result;
            SymbolBox.DataSource = result;
        }
    }
}
