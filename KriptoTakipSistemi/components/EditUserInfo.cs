using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    internal partial class EditUserInfo : UserControl
    {

        private User LoadedUser;

        public event Action<User> UserUpdated;
        public event Action<User.ROLE> RolePrivilegeUpdated;
        public EditUserInfo()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
        }

        private void CreateEventLinks()
        {
            btn_Update.MouseUp += Btn_update_clicked;
            btn_addScreen.MouseUp += Btn_addScreen_clicked;
            btn_removeScreen.MouseUp += Btn_removeScreen_clicked;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void Btn_removeScreen_clicked(object sender, MouseEventArgs e)
        {
            if (LoadedUser.Role == User.Instance.Role)
            {
                MessageBox.Show("Giriş yapılan kullanıcı kendi rolünü güncelleyemez!", "Hata");
                return;
            }
            if (!Enum.TryParse<PAGE>(PrivilegeList.Text, out PAGE selectedPage))
            {
                MessageBox.Show("Seçilen yetki geçerli değil!", "Hata");
                return;
            }
            int result = DataService.Instance.RemovePrivilegeFromRole(LoadedUser.Role, selectedPage);
            if (result == 1)
            {
                PrivilegeList.Items.Remove(selectedPage.ToString());
                AddScreenBox.Items.Add(selectedPage.ToString());
                RolePrivilegeUpdated?.Invoke(LoadedUser.Role);
                MessageBox.Show("Yetki başarıyla silindi", "Uyarı");
            }
            else
            {
                MessageBox.Show("Başarısız", "Hata");
            }
        }

        private void Btn_addScreen_clicked(object sender, MouseEventArgs e)
        {
            if (LoadedUser.Role == User.Instance.Role)
            {
                MessageBox.Show("Giriş yapılan kullanıcı kendi rolünü güncelleyemez!", "Hata");
                return;
            }

            if (!Enum.TryParse<PAGE>(AddScreenBox.Text, out PAGE selectedPage))
            {
                MessageBox.Show("Seçilen yetki geçerli değil!", "Hata");
                return;
            }
            int result = DataService.Instance.AddPrivilegeToRole(LoadedUser.Role, selectedPage);
            if (result == 1)
            {

                AddScreenBox.Items.Remove(selectedPage.ToString());
                AddScreenBox.Text = "";
                PrivilegeList.Items.Add(selectedPage.ToString());
                RolePrivilegeUpdated?.Invoke(LoadedUser.Role);
                MessageBox.Show("Yetki başarıyla eklendi", "Uyarı");
            }
            else
            {
                MessageBox.Show("Başarısız", "Hata");
            }

        }

        private void Btn_update_clicked(object sender, MouseEventArgs e)
        {
            if (LoadedUser.Email != Email.Text)
            {
                int result = DataService.Instance.ChangeUserEmail(LoadedUser.Id, Email.Text);
                if (result == 1)
                {
                    LoadedUser.Email = Email.Text;
                }
                else
                {
                    MessageBox.Show("E-posta güncellenirken bir hata oluştu!", "Hata");
                    return;
                }
            }

            if (LoadedUser.Role.ToString() != UserRoleBox.Text)
            {
                bool success = Enum.TryParse<User.ROLE>(UserRoleBox.Text, out User.ROLE updatedRole);
                if (!success)
                {
                    MessageBox.Show("Geçerli bir rol seçin!", "Hata");
                    return;
                }
                int result = DataService.Instance.ChangeUserRole(LoadedUser.Id, updatedRole);
                if (result == 1)
                {
                    LoadedUser.Role = updatedRole;
                }
                else
                {
                    MessageBox.Show("Rol güncellenirken bir hata oluştu");
                    return;
                }
            }
            LoadUser(LoadedUser);
            UserUpdated?.Invoke(LoadedUser);
            MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Uyarı");
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetLabelStyle(label1);
            ThemeController.Instance.SetLabelStyle(label2);
            ThemeController.Instance.SetLabelStyle(label3);
            ThemeController.Instance.SetLabelStyle(label4);
            ThemeController.Instance.SetLabelStyle(label5);

            ThemeController.Instance.SetButtonStyle(btn_addScreen, true);
            ThemeController.Instance.SetButtonStyle(btn_removeScreen, true);
            ThemeController.Instance.SetButtonStyle(btn_Update, true);
        }


        public void LoadUser(User user)
        {
            RemoveUser();
            LoadedUser = user;
            FirstName.Text = user.FirstName;
            LastName.Text = user.LastName;
            Email.Text = user.Email;
            foreach (User.ROLE role in Enum.GetValues(typeof(User.ROLE)))
            {
                UserRoleBox.Items.Add(role.ToString());
            }
            UserRoleBox.SelectedValue = user.Role.ToString();
            List<PAGE> screens = DataService.Instance.QueryRolePrivilege(user.Role);
            foreach (PAGE screen in screens)
            {
                PrivilegeList.Items.Add(screen.ToString());
            }
            foreach (PAGE page in Enum.GetValues(typeof(PAGE)))
            {
                if (screens.Contains(page) == false)
                {
                    AddScreenBox.Items.Add(page.ToString());
                }
            }
        }

        public void RemoveUser()
        {
            LoadedUser = null;
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            UserRoleBox.Items.Clear();
            PrivilegeList.Items.Clear();
            AddScreenBox.Items.Clear();
        }

    }
}
