namespace KriptoTakipSistemi.components
{
    partial class UserAccountControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SidebarPanel = new System.Windows.Forms.Panel();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.btn_ChangeEmail = new System.Windows.Forms.Button();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.SidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.AutoScroll = true;
            this.SidebarPanel.Controls.Add(this.btn_ChangeEmail);
            this.SidebarPanel.Controls.Add(this.btn_ChangePassword);
            this.SidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Size = new System.Drawing.Size(166, 378);
            this.SidebarPanel.TabIndex = 0;
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Location = new System.Drawing.Point(20, 31);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(116, 30);
            this.btn_ChangePassword.TabIndex = 1;
            this.btn_ChangePassword.Text = "Şifre değiştir";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // btn_ChangeEmail
            // 
            this.btn_ChangeEmail.Location = new System.Drawing.Point(20, 67);
            this.btn_ChangeEmail.Name = "btn_ChangeEmail";
            this.btn_ChangeEmail.Size = new System.Drawing.Size(116, 30);
            this.btn_ChangeEmail.TabIndex = 2;
            this.btn_ChangeEmail.Text = "Eposta değiştir";
            this.btn_ChangeEmail.UseVisualStyleBackColor = true;
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsPanel.Location = new System.Drawing.Point(166, 0);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Size = new System.Drawing.Size(551, 378);
            this.DetailsPanel.TabIndex = 3;
            // 
            // UserAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DetailsPanel);
            this.Controls.Add(this.SidebarPanel);
            this.Name = "UserAccountControl";
            this.Size = new System.Drawing.Size(717, 378);
            this.SidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SidebarPanel;
        private System.Windows.Forms.Panel DetailsPanel;
        private System.Windows.Forms.Button btn_ChangeEmail;
        private System.Windows.Forms.Button btn_ChangePassword;
    }
}
