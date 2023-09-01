using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    internal partial class Sidebar : UserControl
    {
        private Button currentButton;

        public event Action<PAGE> PageChangeRequest;
        public Sidebar()
        {
            InitializeComponent();
        }
        private void CreateEventLinks()
        {
            btn_dashboard.MouseUp += Btn_dashboard_MouseUp;
            btn_alarms.MouseUp += Btn_alarms_MouseUp;
            btn_analysis.MouseUp += Btn_analysis_MouseUp;
            btn_trading.MouseUp += Btn_trading_MouseUp;
            btn_userSettings.MouseUp += Btn_userSettings_MouseUp;
            btn_systemSettings.MouseUp += Btn_systemSettings_MouseUp;

            User.Instance.LoggedIn += OnLoggedIn;
            User.Instance.LoggedOut += OnLoggedOut;

            FormMain.Instance.PageChanged += OnPageChanged;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void SetStyle()
        {

            this.BackColor = ThemeController.Instance.COLOR_LAYER_1;
            this.pnl_menu.BackColor = ThemeController.Instance.COLOR_LAYER_1;
            this.pnl_logo.BackColor = ThemeController.Instance.COLOR_LAYER_1;

            ThemeController.Instance.SetButtonStyle(btn_dashboard, false);
            ThemeController.Instance.SetButtonStyle(btn_alarms, false);
            ThemeController.Instance.SetButtonStyle(btn_analysis, false);
            ThemeController.Instance.SetButtonStyle(btn_trading, false);
            ThemeController.Instance.SetButtonStyle(btn_userSettings, false);
            ThemeController.Instance.SetButtonStyle(btn_systemSettings, false);
        }

        public void ActivateButton(object btnSender)
        {
            if (this.currentButton == null || this.currentButton != (Button)btnSender)
            {
                this.currentButton = (Button)btnSender;
                ThemeController.Instance.SetButtonStyle(currentButton, true);
            }
        }

        public void DeactivateCurrentButton()
        {
            if (this.currentButton == null)
            {
                return;
            }

            ThemeController.Instance.SetButtonStyle(currentButton, false);
            this.currentButton = null;
        }

        private void EnableButton(object btnSender)
        {
            if (btnSender == null)
            {
                return;
            } ((Button)btnSender).Enabled = true;
        }
        private void DisableButton(object btnSender)
        {
            if (btnSender == null)
            {
                return;
            } ((Button)btnSender).Enabled = false;
        }
        private void DisableAllButtons()
        {
            DisableButton(btn_dashboard);
            DisableButton(btn_alarms);
            DisableButton(btn_analysis);
            DisableButton(btn_trading);
            DisableButton(btn_userSettings);
            DisableButton(btn_systemSettings);
        }

        private void OnPageChanged(PAGE page)
        {
            DeactivateCurrentButton();
            if (page == PAGE.DASHBOARD)
            {
                ActivateButton(btn_dashboard);
            }
            else if (page == PAGE.ALARMS)
            {
                ActivateButton(btn_alarms);
            }
            else if (page == PAGE.ANALYSIS)
            {
                ActivateButton(btn_analysis);
            }
            else if (page == PAGE.TRADING)
            {
                ActivateButton(btn_trading);
            }
            else if (page == PAGE.USER_SETTINGS)
            {
                ActivateButton(btn_userSettings);
            }
            else if (page == PAGE.SYSTEM_SETTINGS)
            {
                ActivateButton(btn_systemSettings);
            }
        }

        private void SelectDashboard()
        {
            PageChangeRequest?.Invoke(PAGE.DASHBOARD);
        }
        private void SelectAnalysis()
        {
            PageChangeRequest?.Invoke(PAGE.ANALYSIS);
        }

        private void SelectAlarms()
        {
            PageChangeRequest?.Invoke(PAGE.ALARMS);
        }
        private void SelectTrading()
        {
            PageChangeRequest?.Invoke(PAGE.TRADING);
        }
        private void SelectUserSettings()
        {
            PageChangeRequest?.Invoke(PAGE.USER_SETTINGS);
        }
        private void SelectSystemSettings()
        {
            PageChangeRequest?.Invoke(PAGE.SYSTEM_SETTINGS);
        }



        private void Sidebar_Load(object sender, EventArgs e)
        {
            CreateEventLinks();
            SetStyle();
            PrivilageButtonControl();
        }

        private void Btn_dashboard_MouseUp(object sender, MouseEventArgs e)
        {
            SelectDashboard();
        }

        private void Btn_analysis_MouseUp(object sender, MouseEventArgs e)
        {
            SelectAnalysis();
        }
        private void Btn_alarms_MouseUp(object sender, MouseEventArgs e)
        {
            SelectAlarms();
        }
        private void Btn_trading_MouseUp(object sender, MouseEventArgs e)
        {
            SelectTrading();
        }
        private void Btn_userSettings_MouseUp(object sender, MouseEventArgs e)
        {
            SelectUserSettings();
        }
        private void Btn_systemSettings_MouseUp(object sender, MouseEventArgs e)
        {
            SelectSystemSettings();
        }



        private void OnLoggedIn()
        {
            PrivilageButtonControl();
        }

        private void OnLoggedOut()
        {
            PrivilageButtonControl();
        }

        private void PrivilageButtonControl()
        {
            List<PAGE> pages = DataService.Instance.QueryRolePrivilege(User.Instance.Role);
            DisableAllButtons();
            foreach (PAGE page in pages)
            {
                Console.Write(page.ToString());
                if (page == PAGE.DASHBOARD)
                {
                    EnableButton(btn_dashboard);
                }
                else if (page == PAGE.ALARMS)
                {
                    EnableButton(btn_alarms);
                }
                else if (page == PAGE.ANALYSIS)
                {
                    EnableButton(btn_analysis);
                }
                else if (page == PAGE.TRADING)
                {
                    EnableButton(btn_trading);
                }
                else if (page == PAGE.USER_SETTINGS)
                {
                    EnableButton(btn_userSettings);
                }
                else if (page == PAGE.SYSTEM_SETTINGS)
                {
                    EnableButton(btn_systemSettings);
                }
            }

        }
    }
}
