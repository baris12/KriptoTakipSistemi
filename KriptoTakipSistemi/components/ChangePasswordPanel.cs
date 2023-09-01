using KriptoTakipSistemi.singleton;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class ChangePasswordPanel : UserControl
    {
        public ChangePasswordPanel()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
        }

        private void CreateEventLinks()
        {
            btn_Accept.MouseUp += OnAcceptClicked;
            User.Instance.LoggedOut += OnLoggedOut;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void OnAcceptClicked(object sender, MouseEventArgs e)
        {
            if (CheckCurrentPassword())
            {
                if (CheckPasswordSame())
                {
                    if (ChangePassword())
                    {
                        ClearBoxes();
                        MessageBox.Show("Şifreniz başarıyla güncelendi!", "Uyarı");
                    }
                    else
                    {
                        MessageBox.Show("Şifre güncelleme başarısız!", "Hata");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler eşleşmiyor!", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Güncel olan şifrenizi yanlış girdiniz!", "Hata");
            }
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetButtonStyle(btn_Accept, true);
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetLabelStyle(label2);
            ThemeController.Instance.SetLabelStyle(label3);
            CurrentPasswordBox.PasswordChar = '*';
            NewPasswordBox.PasswordChar = '*';
            NewPasswordRepeatBox.PasswordChar = '*';
        }

        private bool CheckCurrentPassword()
        {
            return DataService.Instance.UserCheckPassword(User.Instance.Id, CurrentPasswordBox.Text);
        }

        private bool CheckPasswordSame()
        {
            return NewPasswordBox.Text == NewPasswordRepeatBox.Text;
        }

        private bool ChangePassword()
        {
            int result = DataService.Instance.ChangeUserPassword(User.Instance.Id, NewPasswordBox.Text);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ClearBoxes()
        {
            CurrentPasswordBox.Text = "";
            NewPasswordBox.Text = "";
            NewPasswordRepeatBox.Text = "";
        }

        private void OnLoggedOut()
        {
            ClearBoxes();
        }
    }
}
