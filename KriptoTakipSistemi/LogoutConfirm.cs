using KriptoTakipSistemi.singleton;
using System;
using System.Windows.Forms;

namespace KriptoTakipSistemi
{
    public partial class LogoutConfirm : Form
    {
        public LogoutConfirm()
        {
            InitializeComponent();
            SetStyle();
            CreateEventLinks();
        }
        private void CreateEventLinks()
        {
            this.btn_cancel.Click += CancelClick;
            this.btn_logout.Click += OnAccept;
            ThemeController.Instance.ThemeChanged += SetStyle;
        }
        private void CloseForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void CancelClick(object sender, EventArgs e)
        {
            this.CloseForm();
        }
        public void OnAccept(object sender, EventArgs e)
        {
            User.Instance.LogOut();
            this.CloseForm();
        }

        public void SetStyle()
        {
            ThemeController.Instance.SetFormStyle(this);
            ThemeController.Instance.SetButtonStyle(btn_cancel, false);
            ThemeController.Instance.SetButtonStyle(btn_logout, false);
        }
    }
}
