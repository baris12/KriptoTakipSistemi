namespace KriptoTakipSistemi.components
{
    partial class AlarmTable
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
            this.table_priceAlarms = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table_priceAlarms)).BeginInit();
            this.SuspendLayout();
            // 
            // table_priceAlarms
            // 
            this.table_priceAlarms.AllowUserToAddRows = false;
            this.table_priceAlarms.AllowUserToDeleteRows = false;
            this.table_priceAlarms.AllowUserToResizeColumns = false;
            this.table_priceAlarms.AllowUserToResizeRows = false;
            this.table_priceAlarms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table_priceAlarms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table_priceAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_priceAlarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.table_priceAlarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_priceAlarms.Location = new System.Drawing.Point(0, 0);
            this.table_priceAlarms.MultiSelect = false;
            this.table_priceAlarms.Name = "table_priceAlarms";
            this.table_priceAlarms.ReadOnly = true;
            this.table_priceAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table_priceAlarms.Size = new System.Drawing.Size(710, 390);
            this.table_priceAlarms.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // AlarmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table_priceAlarms);
            this.Name = "AlarmTable";
            this.Size = new System.Drawing.Size(710, 390);
            ((System.ComponentModel.ISupportInitialize)(this.table_priceAlarms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView table_priceAlarms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
