namespace KriptoTakipSistemi.components
{
    partial class FavoriteList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.price_list = new System.Windows.Forms.DataGridView();
            this.pnl_splitter = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.pnl_allSymbols = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.price_list)).BeginInit();
            this.pnl_allSymbols.SuspendLayout();
            this.SuspendLayout();
            // 
            // price_list
            // 
            this.price_list.AllowUserToAddRows = false;
            this.price_list.AllowUserToDeleteRows = false;
            this.price_list.AllowUserToResizeColumns = false;
            this.price_list.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            this.price_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.price_list.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.price_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.price_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.price_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.price_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.price_list.EnableHeadersVisualStyles = false;
            this.price_list.GridColor = System.Drawing.Color.White;
            this.price_list.Location = new System.Drawing.Point(0, 34);
            this.price_list.MultiSelect = false;
            this.price_list.Name = "price_list";
            this.price_list.ReadOnly = true;
            this.price_list.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.price_list.RowHeadersVisible = false;
            this.price_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.price_list.Size = new System.Drawing.Size(383, 507);
            this.price_list.TabIndex = 0;
            // 
            // pnl_splitter
            // 
            this.pnl_splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_splitter.Location = new System.Drawing.Point(0, 20);
            this.pnl_splitter.Name = "pnl_splitter";
            this.pnl_splitter.Size = new System.Drawing.Size(383, 14);
            this.pnl_splitter.TabIndex = 2;
            // 
            // searchBox
            // 
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(383, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Sembol ara";
            // 
            // pnl_allSymbols
            // 
            this.pnl_allSymbols.Controls.Add(this.price_list);
            this.pnl_allSymbols.Controls.Add(this.pnl_splitter);
            this.pnl_allSymbols.Controls.Add(this.searchBox);
            this.pnl_allSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_allSymbols.Location = new System.Drawing.Point(0, 0);
            this.pnl_allSymbols.Name = "pnl_allSymbols";
            this.pnl_allSymbols.Size = new System.Drawing.Size(383, 541);
            this.pnl_allSymbols.TabIndex = 5;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Favori";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FavoriteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_allSymbols);
            this.Name = "FavoriteList";
            this.Size = new System.Drawing.Size(383, 541);
            ((System.ComponentModel.ISupportInitialize)(this.price_list)).EndInit();
            this.pnl_allSymbols.ResumeLayout(false);
            this.pnl_allSymbols.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView price_list;
        private System.Windows.Forms.Panel pnl_splitter;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Panel pnl_allSymbols;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
