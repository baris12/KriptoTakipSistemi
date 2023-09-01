using KriptoTakipSistemi.singleton;
using System;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void CreateEventLinks()
        {
            textBox_username.GotFocus += OnLoginFocus;
            textBox_username.LostFocus += OnLoginLostFocus;

            textBox_password.GotFocus += OnPasswordFocus;
            textBox_password.LostFocus += OnPasswordLostFocus;

            btn_login.Click += OnLoginButtonClicked;
            User.Instance.LoggedIn += OnLoggedIn;
            ThemeController.Instance.ThemeChanged += SetStyle;

        }
        public void RemoveEventLinks()
        {
            textBox_username.GotFocus -= OnLoginFocus;
            textBox_username.LostFocus -= OnLoginLostFocus;

            textBox_password.GotFocus -= OnPasswordFocus;
            textBox_password.LostFocus -= OnPasswordLostFocus;

            btn_login.Click -= OnLoginButtonClicked;
            User.Instance.LoggedIn -= OnLoggedIn;
            ThemeController.Instance.ThemeChanged -= SetStyle;

        }
        private void OnLoginFocus(object sender, EventArgs e)
        {
            if (textBox_username.Text == "Kullanıcı Adı")
            {
                textBox_username.Text = "";
            }
        }
        private void OnLoginLostFocus(object sender, EventArgs e)
        {
            if (textBox_username.TextLength == 0)
            {
                textBox_username.Text = "Kullanıcı Adı";
            }
            else
            {
                if (!IsValidEmail(textBox_username.Text))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi girin.");
                    //textBox_username.Text = "";
                    textBox_username.Focus();
                }
            }
        }

        private void OnPasswordFocus(object sender, EventArgs e)
        {
            if (textBox_password.Text == "Şifre")
            {
                textBox_password.Text = "";
                textBox_password.PasswordChar = '*';
            }
        }
        private void OnPasswordLostFocus(object sender, EventArgs e)
        {
            if (textBox_password.TextLength == 0)
            {
                textBox_password.PasswordChar = '\0';
                textBox_password.Text = "Şifre";
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            SetStyle();
            CreateEventLinks();
            btn_login.Focus();

        }


        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (User.Instance.checkUser())
            {
                return;
            }

            User.Instance.LogIn(textBox_username.Text, textBox_password.Text);
        }

        public void OnLoggedIn()
        {
            MessageBox.Show("Giriş başarılı");
            DialogResult = DialogResult.OK;
            RemoveEventLinks();
            Close();
            Dispose();
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetFormStyle(this);
            ThemeController.Instance.SetButtonStyle(btn_login, true);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
