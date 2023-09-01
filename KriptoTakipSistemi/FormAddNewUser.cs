using KriptoTakipSistemi.singleton;
using System;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    public partial class FormAddNewUser : Form
    {

        public event Action NewUserAdded;
        public FormAddNewUser()
        {
            InitializeComponent();
            SetStyle();
            LoadAllRoles();
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetLabelStyle(label2);
            ThemeController.Instance.SetLabelStyle(label3);
            ThemeController.Instance.SetLabelStyle(label4);
            ThemeController.Instance.SetLabelStyle(label5);

            ThemeController.Instance.SetFormStyle(this);
            ThemeController.Instance.SetButtonStyle(button1, true);
        }

        private void LoadAllRoles()
        {
            foreach (User.ROLE role in Enum.GetValues(typeof(User.ROLE)))
            {
                Role.Items.Add(role.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse<User.ROLE>(Role.Text, out User.ROLE role))
            {
                MessageBox.Show("Seçilen kullanıcı rolü geçersiz", "Hata");
            }
            int result = DataService.Instance.AddNewUser(FirstName.Text, LastName.Text, Email.Text, Password.Text, role);
            if (result == 1)
            {
                MessageBox.Show("Kullanıcı başarıyla eklendi!");
                NewUserAdded?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı eklenemedi!", "Hata");
            }
        }
    }
}
