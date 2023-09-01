using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    partial class AlarmTable : UserControl
    {
        private List<User.PriceAlarm> LoadedPriceAlarms = new List<User.PriceAlarm>();

        public event Action<User.PriceAlarm> Clicked;

        public AlarmTable()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            InitializeDataGridView();
            CreateEventHandlers();
            SetDataGridViewStyle();
            LoadAllAlarms();
        }

        private void InitializeDataGridView()
        {
            table_priceAlarms.Columns.Clear();
            table_priceAlarms.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "id", HeaderText = "ID", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "symbols", HeaderText = "Sembol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "price", HeaderText = "Fiyat", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "conditions", HeaderText = "Şart", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "validity_period", HeaderText = "Geçerlilik Süresi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "status", HeaderText = "Durum", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
            );
        }

        private void CreateEventHandlers()
        {
            User.Instance.AlarmAdded += OnAdd;
            User.Instance.AlarmRemoved += OnDelete;
            User.Instance.AlarmUpdated += OnUpdate;
            User.Instance.LoggedOut += OnLoggedOut;
            User.Instance.LoggedIn += OnLoggedIn;
            table_priceAlarms.CellClick += AlarmTableClicked;
            ThemeController.Instance.ThemeChanged += SetDataGridViewStyle;
        }

        private void OnUpdate(User.PriceAlarm priceAlarm)
        {
            foreach (DataGridViewRow row in table_priceAlarms.Rows)
            {
                if (row.Cells["id"].Value.ToString().ToLower() == priceAlarm.id.ToString())
                {
                    row.Cells["price"].Value = priceAlarm.price.ToString();
                    row.Cells["conditions"].Value = priceAlarm.condition.ToString();
                    row.Cells["status"].Value = priceAlarm.active.ToString();
                }
            }
        }

        private void OnAdd(User.PriceAlarm priceAlarm)
        {
            AddAlarm(priceAlarm);
        }

        private void OnDelete(User.PriceAlarm priceAlarm)
        {
            RemoveAlarm(priceAlarm);
        }

        private void OnLoggedIn()
        {
            LoadAllAlarms();
        }

        private void OnLoggedOut()
        {
            List<User.PriceAlarm> alarmsToRemove = new List<User.PriceAlarm>();

            foreach (User.PriceAlarm priceAlarm in LoadedPriceAlarms)
            {
                alarmsToRemove.Add(priceAlarm);
            }

            foreach (User.PriceAlarm priceAlarm in alarmsToRemove)
            {
                RemoveAlarm(priceAlarm);
            }
        }


        private void AddAlarm(User.PriceAlarm priceAlarm)
        {
            ExchangeClient.Instance.webSocketClient.SubscribeSingleTickerStream(priceAlarm.symbol, OnTickerUpdate);
            table_priceAlarms.Rows.Add(priceAlarm.id.ToString(), priceAlarm.symbol, priceAlarm.price.ToString(), priceAlarm.condition.ToString(), priceAlarm.validityPeriod, priceAlarm.active.ToString());
            LoadedPriceAlarms.Add(priceAlarm);
        }

        private void OnTickerUpdate(string obj)
        {
            JObject parsedData = JObject.Parse(obj);
            TriggerAlarm(parsedData);
        }

        private void RemoveAlarm(User.PriceAlarm priceAlarm)
        {
            foreach (DataGridViewRow row in table_priceAlarms.Rows)
            {
                if (row.Cells["id"].Value.ToString() == priceAlarm.id.ToString())
                {
                    ExchangeClient.Instance.webSocketClient.UnsubscribeSingleTickerStream(priceAlarm.symbol, OnTickerUpdate);
                    LoadedPriceAlarms.Remove(priceAlarm);
                    table_priceAlarms.Rows.Remove(row);
                    return;
                }
            }
        }

        private void LoadAllAlarms()
        {
            if (!User.Instance.checkUser())
            {
                return;
            }

            LoadedPriceAlarms.Clear();
            table_priceAlarms.Rows.Clear();
            foreach (User.PriceAlarm priceAlarm in User.Instance.Alarms)
            {
                AddAlarm(priceAlarm);
            }
        }

        private void AlarmTableClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = table_priceAlarms.Rows[e.RowIndex];
                if (long.TryParse(row.Cells["id"].Value.ToString(), out long alarmId))
                {
                    foreach (User.PriceAlarm priceAlarm in LoadedPriceAlarms)
                    {
                        if (priceAlarm.id == alarmId)
                        {
                            Clicked?.Invoke(priceAlarm);
                        }
                    }
                }
            }
        }

        private void TriggerAlarm(JObject ticker)
        {
            string symbol = ticker["symbol"].ToString();
            double.TryParse(ticker["price"].ToString(), out double lastPrice);

            foreach (User.PriceAlarm alarm in LoadedPriceAlarms)
            {
                if (alarm.lastPrice < 0)
                {
                    alarm.lastPrice = lastPrice;
                }

                if (alarm.symbol == symbol && alarm.active)
                {
                    bool crossOver = lastPrice >= alarm.price && alarm.lastPrice < alarm.price;
                    bool crossUnder = lastPrice <= alarm.price && alarm.lastPrice > alarm.price;
                    bool cross = crossOver || crossUnder;

                    if (alarm.condition == User.PriceAlarm.CONDITION.CROSS && cross)
                    {
                        // Trigger alarm
                        ProcessAlarmTrigger(alarm);
                        MessageBox.Show($"Alarm tetiklendi! \n{symbol}, {alarm.price} seviyesine dokundu!", "Fiyat alarmı");
                    }
                    else if (alarm.condition == User.PriceAlarm.CONDITION.CROSS_UP && crossOver)
                    {
                        // Trigger alarm
                        ProcessAlarmTrigger(alarm);
                        MessageBox.Show($"Alarm tetiklendi! \n{symbol}, {alarm.price} seviyesini yukarı kırdı!", "Fiyat alarmı");
                    }
                    else if (alarm.condition == User.PriceAlarm.CONDITION.CROSS_DOWN && crossUnder)
                    {
                        // Trigger alarm
                        ProcessAlarmTrigger(alarm);
                        MessageBox.Show($"Alarm tetiklendi! \n{symbol}, {alarm.price} seviyesini aşağı kırdı!", "Fiyat alarmı");
                    }
                    alarm.lastPrice = lastPrice;
                }
            }
        }

        private void ProcessAlarmTrigger(User.PriceAlarm processingAlarm)
        {
            User.PriceAlarm updatedAlarm = processingAlarm.Copy();
            if (processingAlarm.validityPeriod == User.PriceAlarm.VALIDITY_PERIOD.ONE_TIME)
            {
                updatedAlarm.active = false;
                User.Instance.UpdatePriceAlarm(processingAlarm, updatedAlarm);
            }
        }

        private void SetDataGridViewStyle()
        {
            ThemeController.Instance.SetDataGridStyle(table_priceAlarms);
        }

    }
}
