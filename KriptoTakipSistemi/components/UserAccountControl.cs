using KriptoTakipSistemi.singleton;
using System.Windows.Forms;

namespace KriptoTakipSistemi.components
{
    public partial class UserAccountControl : UserControl
    {

        private ChangeEmailPanel changeEmailPanel;
        private ChangePasswordPanel changePasswordPanel;
        private Control currentPanel;

        public UserAccountControl()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
        }

        private void CreateEventLinks()
        {
            btn_ChangePassword.MouseUp += OnChangePasswordClicked;
            btn_ChangeEmail.MouseUp += OnChangeEmailClicked;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }

        private void OnChangeEmailClicked(object sender, MouseEventArgs e)
        {
            OpenChangeEmailPanel();
        }

        private void OnChangePasswordClicked(object sender, MouseEventArgs e)
        {
            OpenChangePasswordPanel();
        }

        private void SetStyle()
        {
            ThemeController.Instance.SetButtonStyle(btn_ChangePassword, true);
            ThemeController.Instance.SetButtonStyle(btn_ChangeEmail, true);
        }

        private void CloseCurrentPanel()
        {
            if (currentPanel != null)
            {
                DetailsPanel.Controls.Remove(currentPanel);
            }
        }
        private void OpenChangePasswordPanel()
        {
            CloseCurrentPanel();
            if (changePasswordPanel == null) { changePasswordPanel = new ChangePasswordPanel(); }
            changePasswordPanel.Dock = DockStyle.Fill;
            currentPanel = changePasswordPanel;
            DetailsPanel.Controls.Add(changePasswordPanel);
        }
        private void OpenChangeEmailPanel()
        {
            CloseCurrentPanel();
            if (changeEmailPanel == null) { changeEmailPanel = new ChangeEmailPanel(); }
            changeEmailPanel.Dock = DockStyle.Fill;
            currentPanel = changeEmailPanel;
            DetailsPanel.Controls.Add(changeEmailPanel);
        }
    }
}
