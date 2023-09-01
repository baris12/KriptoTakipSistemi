using KriptoTakipSistemi.components;
using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoTakipSistemi.gui_pages
{
    public partial class AnalysisPage : UserControl
    {
        private PriceChart priceChart;
        private AnalysisResultChart analysisResultChart;
        public AnalysisPage()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void CreateComponents()
        {
            priceChart = new PriceChart
            {
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(priceChart, 0, 0);

            analysisResultChart = new AnalysisResultChart
            {
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(analysisResultChart, 1, 0);

        }
        private void CreateDataGridColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "indicator_name",
                HeaderText = "indikatör",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "value",
                HeaderText = "Değeri",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "signal",
                HeaderText = "sinyal",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }
        private void SetStyle()
        {
            ThemeController.Instance.SetDataGridStyle(dataGridView1);
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetPanelStyle(panel1);
        }
        private void OnLoad(object sender, EventArgs e)
        {
            FormMain.Instance.LoadingActive();
            //await RsiIndicator("btcusdt", TIME_FRAME.ONE_DAY, 14);
            CreateComponents();
            CreateDataGridColumns();
            SetStyle();
            LoadAllSymbols();

            FormMain.Instance.LoadingDisable();
        }

        private async Task<double> RsiIndicator(string symbol, TIME_FRAME timeFrame, int rsiLength)
        {
            Task<JArray> priceDataTask = ExchangeClient.Instance.GetPriceData(symbol, timeFrame, 100);
            await Task.WhenAll(priceDataTask);
            double[] rsi = TechnicalIndicators.Instance.RelativeStrengthIndex(priceDataTask.Result, rsiLength);
            return rsi[rsi.Count() - 1];
        }

        private async void LoadAllSymbols()
        {
            Task<List<string>> task = ExchangeClient.Instance.GetSymbolList();
            await Task.WhenAll(task);
            List<string> result = task.Result;
            comboBox1.DataSource = result;
        }

    }
}
