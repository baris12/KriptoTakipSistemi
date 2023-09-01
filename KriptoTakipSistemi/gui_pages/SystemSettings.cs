using KriptoTakipSistemi.components;
using KriptoTakipSistemi.singleton;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KriptoTakipSistemi.gui_pages
{
    internal partial class SystemSettings : UserControl
    {
        private List<User> LoadedUsers;

        public event Action<User> UserSelected;

        private FormAddNewUser FormAddUser;

        private EditUserInfo UserInfoEditPanel;
        public SystemSettings()
        {
            InitializeComponent();
            SetStyle();
            CreateCompoments();
            InitializeUserTable();
            CreateEventLinks();
        }

        private void CreateCompoments()
        {
            UserInfoEditPanel = new EditUserInfo
            {
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(UserInfoEditPanel);
        }
        private void InitializeUserTable()
        {
            UserTable.Columns.Clear();
            UserTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UserTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "first_name",
                HeaderText = "Ad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UserTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "last_name",
                HeaderText = "Soyad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UserTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "email",
                HeaderText = "E-Posta",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UserTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "role",
                HeaderText = "Kullanıcı rolü",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetDataGridStyle(UserTable);
            ThemeController.Instance.SetPanelStyle(panel1);
            ThemeController.Instance.SetButtonStyle(btn_AddUser, true);
        }
        private void CreateEventLinks()
        {
            User.Instance.LoggedIn += OnLoggedIn;
            User.Instance.LoggedOut += OnLoggedOut;

            UserTable.CellClick += UserClicked;
            UserSelected += UserInfoEditPanel.LoadUser;
            UserInfoEditPanel.UserUpdated += OnUserUpdated;

            btn_AddUser.MouseUp += OnAddUserClicked;

            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void OnAddUserClicked(object sender, MouseEventArgs e)
        {
            OpenAddUserPanel();
        }

        private void OnUserUpdated(User user)
        {
            RemoveAllUsers();
            LoadAllUsers();
        }

        private void UserClicked(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = UserTable.Rows[e.RowIndex];
            string id = row.Cells["id"].Value.ToString();
            foreach (User user in LoadedUsers)
            {
                if (user.Id.ToString() == id)
                {
                    UserSelected?.Invoke(user);
                }
            }
        }

        private void OnLoggedIn()
        {
            LoadAllUsers();
        }

        private void OnLoggedOut()
        {
            RemoveAllUsers();
        }

        private void AddUser(User user)
        {
            if (LoadedUsers == null)
            {
                LoadedUsers = new List<User>();
            }

            UserTable.Rows.Add(user.Id.ToString(), user.FirstName, user.LastName, user.Email, user.Role.ToString());
            LoadedUsers.Add(user);
        }
        private void RemoveUser(User user)
        {
            try
            {
                foreach (DataGridViewRow row in UserTable.Rows)
                {
                    if (row.Cells["id"].Value.ToString() == user.Id.ToString())
                    {
                        LoadedUsers.Remove(user);
                        UserTable.Rows.Remove(row);
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void RemoveAllUsers()
        {
            for (int i = 0; i < LoadedUsers.Count; i++)
            {
                RemoveUser(LoadedUsers[i]);
            }
            LoadedUsers.Clear();
            UserTable.Rows.Clear();
        }
        private void LoadAllUsers()
        {
            List<User> users = DataService.Instance.QueryAllUsers();
            foreach (User user in users)
            {
                AddUser(user);
            }
        }

        private void OpenAddUserPanel()
        {
            FormAddUser = new FormAddNewUser();
            FormAddUser.NewUserAdded += OnNewUserAdded;
            FormAddUser.ShowDialog();
        }

        private void OnNewUserAdded()
        {
            RemoveAllUsers();
            LoadAllUsers();
        }
    }
}
