using KriptoTakipSistemi.components;
using KriptoTakipSistemi.singleton;
using System;
using System.Windows.Forms;

namespace KriptoTakipSistemi.gui_pages
{
    public partial class AlarmsPage : UserControl
    {
        AlarmTable priceAlarms;
        EditPriceAlarmPanel priceAlarmsEdit;
        AddAlarmForm addAlarmForm;

        public AlarmsPage()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetStyle();
            Setup();
            CreateEventLinks();
        }
        private void CreateEventLinks()
        {
            btn_addAlarm.MouseUp += OnAddButtonClicked;
            priceAlarms.Clicked += priceAlarmsEdit.ShowAlarm;

        }
        private void Setup()
        {
            priceAlarms = new AlarmTable
            {
                Dock = DockStyle.Fill
            };
            PriceAlarmsBox.Controls.Add(priceAlarms);

            priceAlarmsEdit = new EditPriceAlarmPanel
            {
                Dock = DockStyle.Fill
            };
            PriceAlarmBoxEdit.Controls.Add(priceAlarmsEdit);
        }

        private void SetStyle()
        {
            //BackColor = Constants.COLOR_LAYER_1;
            PriceAlarmsBox.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
            PriceAlarmBoxEdit.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
            StrategyAlarmBoxEdit.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
            StrategyAlarmsBox.ForeColor = ThemeController.Instance.COLOR_LABEL_BRIGHT;
        }

        private void OnAddButtonClicked(object sender, MouseEventArgs e)
        {
            if (addAlarmForm != null) { return; }
            addAlarmForm = new AddAlarmForm();
            addAlarmForm.FormClosed += OnFormClosed;
            addAlarmForm.ShowDialog();
        }
        private void OnFormClosed(object sender, EventArgs e)
        {
            AddAlarmForm form = addAlarmForm;
            addAlarmForm = null;
            form?.Dispose();
            return;
        }
    }
}
