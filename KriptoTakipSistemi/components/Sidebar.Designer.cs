namespace KriptoTakipSistemi
{
    partial class Sidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sidebar));
            this.btn_dashboard = new System.Windows.Forms.Button();
            this.pnl_logo = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.pnl_menu = new System.Windows.Forms.SplitContainer();
            this.btn_systemSettings = new System.Windows.Forms.Button();
            this.btn_userSettings = new System.Windows.Forms.Button();
            this.btn_analysis = new System.Windows.Forms.Button();
            this.btn_alarms = new System.Windows.Forms.Button();
            this.btn_trading = new System.Windows.Forms.Button();
            this.pnl_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_menu)).BeginInit();
            this.pnl_menu.Panel1.SuspendLayout();
            this.pnl_menu.Panel2.SuspendLayout();
            this.pnl_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dashboard.BackColor = System.Drawing.Color.Aqua;
            this.btn_dashboard.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_dashboard.Location = new System.Drawing.Point(0, 10);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(275, 36);
            this.btn_dashboard.TabIndex = 1;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            // 
            // pnl_logo
            // 
            this.pnl_logo.BackColor = System.Drawing.Color.Azure;
            this.pnl_logo.Controls.Add(this.logo);
            this.pnl_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_logo.Name = "pnl_logo";
            this.pnl_logo.Size = new System.Drawing.Size(275, 142);
            this.pnl_logo.TabIndex = 1;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(275, 142);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // pnl_menu
            // 
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_menu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnl_menu.IsSplitterFixed = true;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnl_menu.Panel1
            // 
            this.pnl_menu.Panel1.Controls.Add(this.pnl_logo);
            // 
            // pnl_menu.Panel2
            // 
            this.pnl_menu.Panel2.AutoScroll = true;
            this.pnl_menu.Panel2.Controls.Add(this.btn_trading);
            this.pnl_menu.Panel2.Controls.Add(this.btn_systemSettings);
            this.pnl_menu.Panel2.Controls.Add(this.btn_userSettings);
            this.pnl_menu.Panel2.Controls.Add(this.btn_analysis);
            this.pnl_menu.Panel2.Controls.Add(this.btn_alarms);
            this.pnl_menu.Panel2.Controls.Add(this.btn_dashboard);
            this.pnl_menu.Size = new System.Drawing.Size(275, 522);
            this.pnl_menu.SplitterDistance = 142;
            this.pnl_menu.TabIndex = 2;
            // 
            // btn_systemSettings
            // 
            this.btn_systemSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_systemSettings.BackColor = System.Drawing.Color.Aqua;
            this.btn_systemSettings.FlatAppearance.BorderSize = 0;
            this.btn_systemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_systemSettings.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_systemSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_systemSettings.Location = new System.Drawing.Point(0, 220);
            this.btn_systemSettings.Name = "btn_systemSettings";
            this.btn_systemSettings.Size = new System.Drawing.Size(275, 36);
            this.btn_systemSettings.TabIndex = 5;
            this.btn_systemSettings.Text = "Sistem Ayarları";
            this.btn_systemSettings.UseVisualStyleBackColor = false;
            // 
            // btn_userSettings
            // 
            this.btn_userSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_userSettings.BackColor = System.Drawing.Color.Aqua;
            this.btn_userSettings.FlatAppearance.BorderSize = 0;
            this.btn_userSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_userSettings.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_userSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_userSettings.Location = new System.Drawing.Point(0, 178);
            this.btn_userSettings.Name = "btn_userSettings";
            this.btn_userSettings.Size = new System.Drawing.Size(275, 36);
            this.btn_userSettings.TabIndex = 4;
            this.btn_userSettings.Text = "Kullanıcı Ayarları";
            this.btn_userSettings.UseVisualStyleBackColor = false;
            // 
            // btn_analysis
            // 
            this.btn_analysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_analysis.BackColor = System.Drawing.Color.Aqua;
            this.btn_analysis.FlatAppearance.BorderSize = 0;
            this.btn_analysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_analysis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_analysis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_analysis.Location = new System.Drawing.Point(0, 94);
            this.btn_analysis.Name = "btn_analysis";
            this.btn_analysis.Size = new System.Drawing.Size(275, 36);
            this.btn_analysis.TabIndex = 3;
            this.btn_analysis.Text = "Analiz";
            this.btn_analysis.UseVisualStyleBackColor = false;
            // 
            // btn_alarms
            // 
            this.btn_alarms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_alarms.BackColor = System.Drawing.Color.Aqua;
            this.btn_alarms.FlatAppearance.BorderSize = 0;
            this.btn_alarms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alarms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alarms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_alarms.Location = new System.Drawing.Point(0, 52);
            this.btn_alarms.Name = "btn_alarms";
            this.btn_alarms.Size = new System.Drawing.Size(275, 36);
            this.btn_alarms.TabIndex = 2;
            this.btn_alarms.Text = "Alarmlar";
            this.btn_alarms.UseVisualStyleBackColor = false;
            // 
            // btn_trading
            // 
            this.btn_trading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_trading.BackColor = System.Drawing.Color.Aqua;
            this.btn_trading.FlatAppearance.BorderSize = 0;
            this.btn_trading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_trading.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_trading.Location = new System.Drawing.Point(0, 136);
            this.btn_trading.Name = "btn_trading";
            this.btn_trading.Size = new System.Drawing.Size(275, 36);
            this.btn_trading.TabIndex = 6;
            this.btn_trading.Text = "Ticaret";
            this.btn_trading.UseVisualStyleBackColor = false;
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_menu);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(275, 522);
            this.Load += new System.EventHandler(this.Sidebar_Load);
            this.pnl_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.pnl_menu.Panel1.ResumeLayout(false);
            this.pnl_menu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_menu)).EndInit();
            this.pnl_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_dashboard;
        private System.Windows.Forms.Panel pnl_logo;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.SplitContainer pnl_menu;
        private System.Windows.Forms.Button btn_alarms;
        private System.Windows.Forms.Button btn_analysis;
        private System.Windows.Forms.Button btn_systemSettings;
        private System.Windows.Forms.Button btn_userSettings;
        private System.Windows.Forms.Button btn_trading;
    }
}
