using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    partial class EditPriceAlarmPanel : UserControl
    {
        public User.PriceAlarm currentAlarm;
        public EditPriceAlarmPanel()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
            LoadAlarmConditions();
            LoadAlarmValidityPeriod();
        }

        private void CreateEventLinks()
        {
            btn_remove.MouseUp += OnRemoveButtonClicked;
            btn_save.MouseUp += OnSaveButtonClicked;
            btn_start_stop.MouseUp += OnStartStopButtonClicked;
            PriceBox.KeyPress += TextBox_number_KeyPress;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void OnSaveButtonClicked(object sender, MouseEventArgs e)
        {
            if (currentAlarm == null) { MessageBox.Show("Önce bir alarm seçin", "Uyarı"); return; }
            UpdateAlarm(currentAlarm);
        }

        private void OnStartStopButtonClicked(object sender, MouseEventArgs e)
        {
            if (currentAlarm == null) { MessageBox.Show("Önce bir alarm seçin", "Uyarı"); return; }
            if (currentAlarm.active)
            {
                StopAlarm(currentAlarm);
            }
            else
            {
                StartAlarm(currentAlarm);
            }
        }

        private void OnRemoveButtonClicked(object sender, MouseEventArgs e)
        {
            if (currentAlarm == null) { MessageBox.Show("Önce bir alarm seçin", "Uyarı"); return; }
            RemoveAlarm(currentAlarm);
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetLabelStyle(label2);
            ThemeController.Instance.SetLabelStyle(label3);
            ThemeController.Instance.SetLabelStyle(label4);

            ThemeController.Instance.SetButtonStyle(btn_remove, true);
            ThemeController.Instance.SetButtonStyle(btn_start_stop, true);
            ThemeController.Instance.SetButtonStyle(btn_save, true);


        }

        public void ShowAlarm(User.PriceAlarm priceAlarm)
        {
            currentAlarm = priceAlarm;
            SymbolBox.Text = priceAlarm.symbol;
            PriceBox.Text = priceAlarm.price.ToString();
            ConditionBox.Text = priceAlarm.condition.ToString();
            ValidityPeriodBox.Text = priceAlarm.validityPeriod.ToString();
        }

        public void DissappearAlarm()
        {
            SymbolBox.Text = "";
            PriceBox.Text = "";
            ConditionBox.Text = "";
            ValidityPeriodBox.Text = "";
            currentAlarm = null;

        }

        public void UpdateAlarm(User.PriceAlarm priceAlarm)
        {
            User.PriceAlarm updatedAlarm = priceAlarm.Copy();
            bool success = double.TryParse(PriceBox.Text, out updatedAlarm.price);
            if (!success) { MessageBox.Show("Fiyat geçerli değil!", "Hata"); return; }

            success = Enum.TryParse<User.PriceAlarm.CONDITION>(ConditionBox.Text, out updatedAlarm.condition);
            if (!success) { MessageBox.Show("Şart geçerli değil!", "Hata"); return; }

            success = Enum.TryParse<User.PriceAlarm.VALIDITY_PERIOD>(ValidityPeriodBox.Text, out updatedAlarm.validityPeriod);
            if (!success) { MessageBox.Show("Geçerlilik süresi geçerli değil!", "Hata"); return; }

            User.Instance.UpdatePriceAlarm(priceAlarm, updatedAlarm);
        }
        public void StopAlarm(User.PriceAlarm priceAlarm)
        {
            User.PriceAlarm updatedAlarm = priceAlarm.Copy();
            updatedAlarm.active = false;
            User.Instance.UpdatePriceAlarm(priceAlarm, updatedAlarm);
        }
        public void StartAlarm(User.PriceAlarm priceAlarm)
        {
            User.PriceAlarm updatedAlarm = priceAlarm.Copy();
            updatedAlarm.active = true;
            User.Instance.UpdatePriceAlarm(priceAlarm, updatedAlarm);
        }
        public void RemoveAlarm(User.PriceAlarm priceAlarm)
        {
            User.Instance.RemovePriceAlarm(priceAlarm);
            DissappearAlarm();
        }

        private void TextBox_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private List<string> EnumToList<T>()
        {
            List<string> list = new List<string>();
            foreach (T deger in Enum.GetValues(typeof(T)))
            {
                list.Add(deger.ToString());
            }
            return list;
        }
        private void LoadAlarmConditions()
        {
            List<string> conditions = EnumToList<User.PriceAlarm.CONDITION>();
            ConditionBox.DataSource = conditions;
        }
        private void LoadAlarmValidityPeriod()
        {
            List<string> validityPeriods = EnumToList<User.PriceAlarm.VALIDITY_PERIOD>();
            ValidityPeriodBox.DataSource = validityPeriods;
        }
    }
}
