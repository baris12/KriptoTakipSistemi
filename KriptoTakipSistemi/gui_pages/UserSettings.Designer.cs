namespace KriptoTakipSistemi.gui_pages
{
    partial class UserSettings
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.AccountSettingsPanel = new System.Windows.Forms.GroupBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.userAccountControl1 = new KriptoTakipSistemi.components.UserAccountControl();
            this.AccountSettingsPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // AccountSettingsPanel
            // 
            this.AccountSettingsPanel.Controls.Add(this.userAccountControl1);
            this.AccountSettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AccountSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.AccountSettingsPanel.Name = "AccountSettingsPanel";
            this.AccountSettingsPanel.Size = new System.Drawing.Size(741, 249);
            this.AccountSettingsPanel.TabIndex = 1;
            this.AccountSettingsPanel.TabStop = false;
            this.AccountSettingsPanel.Text = "Hesap ayarları";
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.Controls.Add(this.AccountSettingsPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(741, 390);
            this.MainPanel.TabIndex = 2;
            // 
            // userAccountControl1
            // 
            this.userAccountControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAccountControl1.Location = new System.Drawing.Point(3, 16);
            this.userAccountControl1.Name = "userAccountControl1";
            this.userAccountControl1.Size = new System.Drawing.Size(735, 230);
            this.userAccountControl1.TabIndex = 0;
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainPanel);
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(741, 390);
            this.AccountSettingsPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox AccountSettingsPanel;
        private System.Windows.Forms.Panel MainPanel;
        private components.UserAccountControl userAccountControl1;
    }
}
