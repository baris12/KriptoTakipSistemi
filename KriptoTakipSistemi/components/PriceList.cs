using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.singleton;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KriptoTakipSistemi.components
{
    public partial class PriceList : UserControl
    {

        private bool searchActive = false;

        public event Action<string> SymbolClicked;
        public Image wishlist_active = Properties.Resources.minus_icon;
        public Image wishlist_passive = Properties.Resources.plus_icon;
        public PriceList()
        {
            InitializeComponent();
        }


        protected virtual void OnSymbolClicked(string symbol)
        {
            SymbolClicked?.Invoke(symbol);
        }

        private void PriceList_Load(object sender, EventArgs e)
        {
            CreateColumns();
            CreateEventLinks();
            SetStyle();
            StartStreams();
        }

        private void CreateColumns()
        {
            price_list.Columns.Clear();
            price_list.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "symbols",
                HeaderText = "Sembol",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            price_list.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "price",
                HeaderText = "Fiyat",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            price_list.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "changePercent",
                HeaderText = "24 saat değişim(%)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "favorite",
                HeaderText = "Favori ekle",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            price_list.Columns.Add(imageColumn);
        }
        private void CreateEventLinks()
        {
            price_list.SortCompare += DataGridView1_SortCompare;
            price_list.CellParsing += DataGridView1_CellParsing;
            searchBox.TextChanged += TextBoxSearch_TextChanged;
            searchBox.GotFocus += OnSearchBoxFocus;
            searchBox.LostFocus += OnSearchBoxLostFocus;

            User.Instance.LoggedIn += OnLoggedIn;
            User.Instance.LoggedOut += OnLoggedOut;
            User.Instance.FavoriteSymbolAdded += OnSymbolAdded;
            User.Instance.FavoriteSymbolRemoved += OnSymbolRemoved;
            GetPriceList().CellClick += Price_list_clicked;

            TickerUpdated += OnTickerUpdated;

            ThemeController.Instance.ThemeChanged += SetStyle;
        }
        private void SetStyle()
        {
            ThemeController.Instance.SetDataGridStyle(price_list);
        }
        private async void StartStreams()
        {
            FormMain.Instance.LoadingActive();
            Task<string> tickerTask = ExchangeClient.Instance.GetAllTicker();
            await Task.WhenAll(tickerTask);
            this.OnTickerUpdatedEvent(tickerTask.Result);
            FormMain.Instance.LoadingDisable();
            if (User.Instance.checkUser())
            {
                OnLoggedIn();
            }

            await ExchangeClient.Instance.webSocketClient.SubscribeAllTickerStream(OnTickerUpdatedEvent);
        }
        private event Action<string> TickerUpdated;
        private void OnTickerUpdatedEvent(string obj)
        {
            TickerUpdated?.Invoke(obj);
        }
        private void OnTickerUpdated(string obj)
        {
            try
            {
                JArray jArray = JArray.Parse(obj);
                foreach (JObject priceObj in jArray.Cast<JObject>())
                {
                    bool found = false;

                    // check if symbol exists
                    foreach (DataGridViewRow row in price_list.Rows)
                    {
                        if (row.Cells["symbols"].Value != null && row.Cells["symbols"].Value.ToString() == priceObj["symbol"].ToString())
                        {
                            // symbol already exists, update
                            double currentValue = double.Parse(row.Cells["price"].Value.ToString());
                            double newValue = double.Parse(priceObj["price"].ToString());

                            if (currentValue < newValue)
                            {
                                row.Cells["price"].Style.BackColor = Color.Green;
                            }
                            else if (currentValue > newValue)
                            {
                                row.Cells["price"].Style.BackColor = Color.Red;
                            }

                            row.Cells["price"].Value = priceObj["price"].ToString();
                            row.Cells["changePercent"].Value = priceObj["changePercent"].ToString();
                            found = true;
                            break;
                        }
                    }

                    // if not found then add
                    if (!found)
                    {
                        price_list.Rows.Add(priceObj["symbol"].ToString(), priceObj["price"].ToString(), priceObj["changePercent"].ToString(), wishlist_passive);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in PriceList:onTickerUpdate()");
                Console.WriteLine(ex.ToString());
            }
        }

        private void DataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType == typeof(double) && e.Value is string stringValue)
            {
                if (double.TryParse(stringValue, out double parsedValue))
                {
                    e.Value = parsedValue;  // set with the parsedValue
                    e.ParsingApplied = true;
                }
                else
                {
                    e.ParsingApplied = false;
                }
            }
        }


        private void DataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "price" || e.Column.Name == "changePercent")
            {

                e.SortResult = (double.Parse(e.CellValue1.ToString())).CompareTo(double.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        public DataGridView GetPriceList()
        {
            return this.price_list;
        }


        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!searchActive)
            {
                return;
            }

            string searchText = searchBox.Text.Trim().ToLower();

            foreach (DataGridViewRow row in price_list.Rows)
            {
                if (searchText.Length == 0) { row.Visible = true; continue; }

                DataGridViewCell cell = row.Cells[0];
                if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void OnSearchBoxFocus(object sender, EventArgs e)
        {
            if (searchBox.Text == "Sembol ara")
            {
                searchBox.Text = "";
                searchActive = true;
            }
        }
        private void OnSearchBoxLostFocus(object sender, EventArgs e)
        {
            if (searchBox.TextLength == 0)
            {
                searchActive = false;
                searchBox.Text = "Sembol ara";
            }
        }

        public void OnLoggedIn()
        {
            try
            {
                FormMain.Instance.LoadingActive();
                foreach (DataGridViewRow row in price_list.Rows)
                {
                    SetPassiveFavoriteMark(row.Cells["favorite"]);
                    foreach (string symbol in User.Instance.FavoriteSymbols)
                    {
                        if (row.Cells["symbols"].Value.ToString().ToLower() == symbol.ToLower())
                        {
                            SetActiveFavoriteMark(row.Cells["favorite"]);
                        }
                    }
                }
                FormMain.Instance.LoadingDisable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"price_list error in onLoggedIn() {ex}");
            }

        }
        public void OnLoggedOut()
        {
            FormMain.Instance.LoadingActive();
            foreach (DataGridViewRow row in price_list.Rows)
            {
                SetPassiveFavoriteMark(row.Cells["favorite"]);
            }
            FormMain.Instance.LoadingDisable();
        }

        private void Price_list_clicked(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView price_list = this.GetPriceList();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = price_list.Columns[e.ColumnIndex].Name;
                if (columnName == "symbols")
                {
                    object cellValue = price_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue != null)
                    {
                        string cellValueString = cellValue.ToString();
                        OnSymbolClicked(cellValueString);
                    }
                }
                else if (columnName == "favorite")
                {
                    if (!User.Instance.checkUser())
                    {
                        MessageBox.Show("Önce giriş yapın!");
                    }
                    else
                    {
                        try
                        {
                            DataGridViewImageCell cell = (DataGridViewImageCell)price_list.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            string selectedSymbol = price_list.Rows[e.RowIndex].Cells["symbols"].Value.ToString().ToLower();
                            if (!User.Instance.FavoriteSymbols.Contains(selectedSymbol))
                            {

                                if (User.Instance.AddFavoriteSymbol(selectedSymbol))
                                {
                                    SetActiveFavoriteMark(cell);
                                }
                            }
                            else
                            {
                                if (User.Instance.RemoveFavoriteSymbol(selectedSymbol))
                                {
                                    SetPassiveFavoriteMark(cell);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"book mark error {ex}");
                        }
                    }
                }
            }
        }

        private void SetActiveFavoriteMark(DataGridViewCell cell)
        {
            cell.Value = wishlist_active;
        }
        private void SetPassiveFavoriteMark(DataGridViewCell cell)
        {
            cell.Value = wishlist_passive;
        }

        private void OnSymbolAdded(string symbol)
        {
            foreach (DataGridViewRow row in price_list.Rows)
            {
                if (row.Cells["symbols"].Value.ToString().ToLower() == symbol)
                {
                    SetActiveFavoriteMark(row.Cells["favorite"]);
                }
            }
        }

        private void OnSymbolRemoved(string symbol)
        {
            foreach (DataGridViewRow row in price_list.Rows)
            {
                if (row.Cells["symbols"].Value.ToString().ToLower() == symbol)
                {
                    SetPassiveFavoriteMark(row.Cells["favorite"]);
                }
            }
        }
    }
}
