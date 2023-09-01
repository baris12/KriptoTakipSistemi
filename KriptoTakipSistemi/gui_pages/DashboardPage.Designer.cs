namespace KriptoTakipSistemi
{
    partial class DashboardPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab_priceList = new System.Windows.Forms.TabControl();
            this.allSymbols = new System.Windows.Forms.TabPage();
            this.favorites = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tab_priceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.73802F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.26198F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tab_priceList, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.92537F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.07462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(977, 509);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 360);
            this.panel1.TabIndex = 6;
            // 
            // tab_priceList
            // 
            this.tab_priceList.Controls.Add(this.allSymbols);
            this.tab_priceList.Controls.Add(this.favorites);
            this.tab_priceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_priceList.Location = new System.Drawing.Point(625, 67);
            this.tab_priceList.Name = "tab_priceList";
            this.tab_priceList.SelectedIndex = 0;
            this.tab_priceList.Size = new System.Drawing.Size(349, 360);
            this.tab_priceList.TabIndex = 7;
            // 
            // allSymbols
            // 
            this.allSymbols.Location = new System.Drawing.Point(4, 22);
            this.allSymbols.Name = "allSymbols";
            this.allSymbols.Padding = new System.Windows.Forms.Padding(3);
            this.allSymbols.Size = new System.Drawing.Size(341, 334);
            this.allSymbols.TabIndex = 0;
            this.allSymbols.Text = "Tüm Semboller";
            this.allSymbols.UseVisualStyleBackColor = true;
            // 
            // favorites
            // 
            this.favorites.Location = new System.Drawing.Point(4, 22);
            this.favorites.Name = "favorites";
            this.favorites.Padding = new System.Windows.Forms.Padding(3);
            this.favorites.Size = new System.Drawing.Size(341, 334);
            this.favorites.TabIndex = 1;
            this.favorites.Text = "Favoriler";
            this.favorites.UseVisualStyleBackColor = true;
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DashboardPage";
            this.Size = new System.Drawing.Size(977, 509);
            this.Load += new System.EventHandler(this.DashboardPage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tab_priceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tab_priceList;
        private System.Windows.Forms.TabPage allSymbols;
        private System.Windows.Forms.TabPage favorites;
    }
}
