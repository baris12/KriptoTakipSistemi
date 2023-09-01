using KriptoTakipSistemi.components;
using System.Windows.Forms;

namespace KriptoTakipSistemi.gui_pages
{
    public partial class TradingPage : UserControl
    {

        private TradingPanel tradingPanel;
        public TradingPage()
        {
            InitializeComponent();
            InitializePage();
        }

        private void InitializePage()
        {
            tradingPanel = new TradingPanel
            {
                Dock = DockStyle.Fill,
            };
            splitContainer1.Panel2.Controls.Add(tradingPanel);
        }
    }
}
