using KriptoTakipSistemi.singleton;
using System;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class AccountPanel : UserControl
    {
        private LoginPage loginPage;
        private LogoutConfirm logoutConfirm;

        public AccountPanel()
        {
            InitializeComponent();
            Load += AccountPanel_Load;
        }

        private void CreateEventLinks()
        {
            btn_user.Click += Btn_click;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void AccountPanel_Load(object sender, EventArgs e)
        {
            SetStyle();
            CreateEventLinks();
            CheckUser();
        }

        private void SetUserInfo()
        {
            string labelText = $"{char.ToUpper(User.Instance.FirstName[0]) + User.Instance.FirstName.Substring(1).ToLower()} {User.Instance.LastName.ToUpper()}";
            lbl_username.Text = labelText;
        }

        private void RemoveUserInfo()
        {
            lbl_username.Text = "Giriş yapılmadı";
        }

        private void Btn_click(object sender, EventArgs e)
        {
            if (!User.Instance.checkUser())
            {
                ShowLoginForm();
            }
            else
            {
                ShowLogoutConfirmForm();
                CheckUser();
            }
        }

        private void ShowLoginForm()
        {
            if (loginPage == null)
            {
                loginPage = new LoginPage();
                loginPage.FormClosing += OnPopUpClose;
                loginPage.FormClosing += OnLoginScreenClosed;
                loginPage.Show();
            }
        }

        private void ShowLogoutConfirmForm()
        {
            if (logoutConfirm == null)
            {
                logoutConfirm = new LogoutConfirm();
                logoutConfirm.FormClosing += OnPopUpClose;
                logoutConfirm.FormClosing += OnLogoutScreenClosed;
                logoutConfirm.Show();
            }
        }

        private void OnLoginScreenClosed(object sender, EventArgs e)
        {
            RemoveEventLinks(loginPage, OnPopUpClose, OnLoginScreenClosed);
        }

        private void OnLogoutScreenClosed(object sender, EventArgs e)
        {
            RemoveEventLinks(logoutConfirm, OnPopUpClose, OnLogoutScreenClosed);
        }

        private void RemoveEventLinks(Form form, FormClosingEventHandler closeHandler1, FormClosingEventHandler closeHandler2)
        {
            if (form != null)
            {
                form.FormClosing -= closeHandler1;
                form.FormClosing -= closeHandler2;
                form = null;
            }
        }

        private void CheckUser()
        {
            if (!User.Instance.checkUser())
            {
                RemoveUserInfo();
                btn_user.Text = "Giriş";
            }
            else
            {
                SetUserInfo();
                btn_user.Text = "Çıkış";
            }
        }

        public void OnPopUpClose(object sender, EventArgs e)
        {
            CheckUser();
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetButtonStyle(btn_user, true);
            ThemeController.Instance.SetLabelStyle(lbl_username);
        }
    }
}
