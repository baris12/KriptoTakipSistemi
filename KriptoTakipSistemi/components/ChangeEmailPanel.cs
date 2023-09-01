using KriptoTakipSistemi.singleton;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class ChangeEmailPanel : UserControl
    {
        public ChangeEmailPanel()
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
            if (CheckCurrentEmail())
            {
                if (CheckEmailSame())
                {
                    if (ChangeEmail())
                    {
                        MessageBox.Show("E-posta başarıyla güncellendi!", "Uyarı");
                    }
                    else
                    {
                        ClearBoxes();
                        MessageBox.Show("E-posta güncelleme başarısız oldu!", "Hata");
                    }
                }
                else
                {
                    MessageBox.Show("E-postalar eşleşmiyor!", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Güncel olan e-postanızı yanlış girdiniz!", "Hata");
            }
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetButtonStyle(btn_Accept, true);
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetLabelStyle(label2);
            ThemeController.Instance.SetLabelStyle(label3);
        }


        private bool CheckCurrentEmail()
        {
            return User.Instance.Email == CurrentEmailBox.Text;
        }

        private bool CheckEmailSame()
        {
            return NewEmailBox.Text == NewEmailRepeatBox.Text;
        }

        private bool ChangeEmail()
        {
            return User.Instance.UpdateEmail(NewEmailBox.Text);
        }

        private void ClearBoxes()
        {
            CurrentEmailBox.Text = "";
            NewEmailBox.Text = "";
            NewEmailRepeatBox.Text = "";
        }

        private void OnLoggedOut()
        {
            ClearBoxes();
        }
    }
}
