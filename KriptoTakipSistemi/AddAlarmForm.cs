using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    public partial class AddAlarmForm : Form
    {
        public AddAlarmForm()
        {
            InitializeComponent();
            SetColor();
            CreateEventLinks();
            LoadAllSymbols();
            LoadAlarmConditions();
            LoadAlarmValidityPeriod();

        }
        private void SetColor()
        {

        }
        private void CreateEventLinks()
        {
            SelectAlarmType.SelectedIndexChanged += OnSelectedAlarmChanged;
            btn_AddPriceAlarm.MouseUp += OnAddPriceAlarmClicked;

            PriceAlarmPriceText.KeyPress += TextBox_number_KeyPress;
        }
        private void OnSelectedAlarmChanged(object sender, EventArgs e)
        {

        }

        private async void LoadAllSymbols()
        {
            Task<List<string>> task = ExchangeClient.Instance.GetSymbolList();
            await Task.WhenAll(task);
            List<string> result = task.Result;
            PriceAlarmSymbolBox.DataSource = result;
        }
        private void LoadAlarmConditions()
        {
            List<string> conditions = EnumToList<User.PriceAlarm.CONDITION>();
            PriceAlarmConditionBox.DataSource = conditions;
        }
        private void LoadAlarmValidityPeriod()
        {
            List<string> validityPeriods = EnumToList<User.PriceAlarm.VALIDITY_PERIOD>();
            PriceAlarmValidityPeriodBox.DataSource = validityPeriods;
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

        private void OnAddPriceAlarmClicked(object sender, MouseEventArgs e)
        {
            string symbol = PriceAlarmSymbolBox.Text;
            bool success = double.TryParse(PriceAlarmPriceText.Text, out double price);
            if (!success) { MessageBox.Show("Fiyat alanına bir sayı girilmeli!", "Hata"); return; };
            bool active = true;
            success = Enum.TryParse<User.PriceAlarm.CONDITION>(PriceAlarmConditionBox.Text, out User.PriceAlarm.CONDITION condition);
            if (!success) { MessageBox.Show("Şart değeri geçerli değil!", "Hata"); return; };
            success = Enum.TryParse<User.PriceAlarm.VALIDITY_PERIOD>(PriceAlarmValidityPeriodBox.Text, out User.PriceAlarm.VALIDITY_PERIOD validityPeriod);
            if (!success) { MessageBox.Show("Geçerlilik süresi değeri geçerli değil!", "Hata"); return; };
            if (User.Instance.AddPriceAlarm(symbol, price, active, condition, validityPeriod))
            {
                MessageBox.Show("Alarm başarıyla oluşturuldu");
            }
            else
            {
                MessageBox.Show("Alarm oluşturma başarısız oldu!", "Hata");
            }
        }

        private void TextBox_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
