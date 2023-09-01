using KriptoTakipSistemi.components;
using KriptoTakipSistemi.exchangeConnectors;
using KriptoTakipSistemi.gui_pages;
using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    internal partial class FormMain : Form
    {

        private PAGE currentPage = PAGE.NONE;
        private Dictionary<PAGE, Control> pages;

        private SplitterPanel sidebarPnl, headerPnl, pagePnl;
        private Sidebar sidebar;
        private FormHeader header;

        public static FormMain Instance;
        private Loading loadingPage;
        private int loadingCount = 0;

        public event Action<PAGE> PageChanged;
        public FormMain()
        {
            InitializeComponent();
            FormMain.Instance = this;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CreateLoadingPage();
            LoadingActive();
            Task.Run(() => ExchangeClient.Instance.webSocketClient.StartAsync());
            pages = new Dictionary<PAGE, Control>();

            DashboardPage dashboardPage = new DashboardPage { Dock = DockStyle.Fill };
            pages.Add(PAGE.DASHBOARD, dashboardPage);

            AlarmsPage alarmsPage = new AlarmsPage { Dock = DockStyle.Fill };
            pages.Add(PAGE.ALARMS, alarmsPage);

            AnalysisPage analysisPage = new AnalysisPage { Dock = DockStyle.Fill };
            pages.Add(PAGE.ANALYSIS, analysisPage);

            TradingPage tradingPage = new TradingPage { Dock = DockStyle.Fill };
            pages.Add(PAGE.TRADING, tradingPage);

            UserSettings userSettingsPage = new UserSettings { Dock = DockStyle.Fill };
            pages.Add(PAGE.USER_SETTINGS, userSettingsPage);

            SystemSettings systemSettingsPage = new SystemSettings { Dock = DockStyle.Fill };
            pages.Add(PAGE.SYSTEM_SETTINGS, systemSettingsPage);


            sidebarPnl = split_sidebar.Panel1;
            headerPnl = split_header.Panel1;
            pagePnl = split_header.Panel2;

            sidebar = new Sidebar { Dock = DockStyle.Fill };
            sidebarPnl.Controls.Add(sidebar);

            header = new FormHeader { Dock = DockStyle.Fill };
            headerPnl.Controls.Add(header);

            SetStyle();
            LoadingDisable();
            CreateEventLinks();
            OpenDashboardOrNone();
        }

        private void CreateEventLinks()
        {
            sidebar.PageChangeRequest += ChangePage;
            ThemeController.Instance.ThemeChanged += SetStyle;
            User.Instance.LoggedIn += OnLoggedInAndOut;
            User.Instance.LoggedOut += OnLoggedInAndOut;
        }
        private void CreateLoadingPage()
        {
            loadingPage = new Loading { Dock = DockStyle.Fill };
        }
        public void LoadingActive()
        {
            this.loadingCount += 1;
            this.Controls.Add(loadingPage);
            loadingPage.BringToFront();
        }
        public void LoadingDisable()
        {
            this.loadingCount -= 1;
            if (this.loadingCount <= 0)
            {
                this.Controls.Remove(loadingPage);
                this.loadingCount = 0;
            }
        }
        private void SetStyle()
        {
            ThemeController.Instance.SetFormStyle(this);
        }

        public void ChangePage(PAGE page)
        {
            LoadingActive();
            if (currentPage != page)
            {
                try
                {
                    if (currentPage != PAGE.NONE)
                    {
                        pagePnl.Controls.Remove(pages[currentPage]);
                    }

                    pagePnl.Controls.Add(pages[page]);
                    currentPage = page;
                    PageChanged?.Invoke(page);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            LoadingDisable();
        }

        private void OpenDashboardOrNone()
        {
            List<PAGE> pages = DataService.Instance.QueryRolePrivilege(User.Instance.Role);
            PAGE toOpen = PAGE.NONE;
            if (pages.Count > 0)
            {
                if (pages.Contains(PAGE.DASHBOARD))
                {
                    toOpen = PAGE.DASHBOARD;
                }
            }
            ChangePage(toOpen);
        }

        public void OnLoggedInAndOut()
        {
            OpenDashboardOrNone();
        }
    }
}
