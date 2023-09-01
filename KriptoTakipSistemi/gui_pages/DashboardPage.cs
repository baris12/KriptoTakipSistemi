using KriptoTakipSistemi.components;
using System;
using System.Windows.Forms;
namespace KriptoTakipSistemi
{
    public partial class DashboardPage : UserControl
    {

        PriceList priceList1 = new PriceList();
        FavoriteList favoriteList1 = new FavoriteList();
        PriceChart priceChart1 = new PriceChart();

        public DashboardPage()
        {
            InitializeComponent();
        }


        private void DashboardPage_Load(object sender, EventArgs e)
        {
            LoadComponents();
            CreateEventLinks();
        }

        private void LoadComponents()
        {
            priceChart1.Dock = DockStyle.Fill;
            panel1.Controls.Add(priceChart1);

            priceList1.Dock = DockStyle.Fill;
            tab_priceList.TabPages["allSymbols"].Controls.Add(priceList1);

            favoriteList1.Dock = DockStyle.Fill;
            tab_priceList.TabPages["favorites"].Controls.Add(favoriteList1);
        }
        private void CreateEventLinks()
        {
            priceList1.SymbolClicked += OnPriceListClick;
            favoriteList1.SymbolClicked += OnPriceListClick;
        }


        public void OnPriceListClick(string symbol)
        {
            if (symbol == null) { return; }
            priceChart1.StartStream(symbol, TIME_FRAME.ONE_MIN, 25);
        }

    }
}
