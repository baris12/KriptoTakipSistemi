namespace KriptoTakipSistemi.components
{
    partial class PriceChart
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.pnl_chartTimeFrames = new System.Windows.Forms.TableLayoutPanel();
            this.btn_1h = new System.Windows.Forms.Button();
            this.btn_2h = new System.Windows.Forms.Button();
            this.btn_4h = new System.Windows.Forms.Button();
            this.btn_30m = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_5m = new System.Windows.Forms.Button();
            this.btn_1M = new System.Windows.Forms.Button();
            this.btn_1W = new System.Windows.Forms.Button();
            this.btn_1D = new System.Windows.Forms.Button();
            this.btn_15m = new System.Windows.Forms.Button();
            this.pnl_chartHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_pricePercent = new System.Windows.Forms.Label();
            this.lbl_lastPrice = new System.Windows.Forms.Label();
            this.lbl_symbolName = new System.Windows.Forms.Label();
            this.pnl_chartTimeFrames.SuspendLayout();
            this.pnl_chartHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 62);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(564, 354);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // pnl_chartTimeFrames
            // 
            this.pnl_chartTimeFrames.ColumnCount = 10;
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnl_chartTimeFrames.Controls.Add(this.btn_1h, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_2h, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_4h, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_30m, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.button6, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_5m, 0, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_1M, 3, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_1W, 2, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_1D, 1, 0);
            this.pnl_chartTimeFrames.Controls.Add(this.btn_15m, 0, 0);
            this.pnl_chartTimeFrames.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_chartTimeFrames.Location = new System.Drawing.Point(0, 31);
            this.pnl_chartTimeFrames.Name = "pnl_chartTimeFrames";
            this.pnl_chartTimeFrames.RowCount = 1;
            this.pnl_chartTimeFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_chartTimeFrames.Size = new System.Drawing.Size(564, 31);
            this.pnl_chartTimeFrames.TabIndex = 9;
            // 
            // btn_1h
            // 
            this.btn_1h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_1h.FlatAppearance.BorderSize = 0;
            this.btn_1h.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1h.Location = new System.Drawing.Point(227, 3);
            this.btn_1h.Name = "btn_1h";
            this.btn_1h.Size = new System.Drawing.Size(50, 25);
            this.btn_1h.TabIndex = 17;
            this.btn_1h.Text = "1s";
            this.btn_1h.UseVisualStyleBackColor = true;
            // 
            // btn_2h
            // 
            this.btn_2h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_2h.FlatAppearance.BorderSize = 0;
            this.btn_2h.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_2h.Location = new System.Drawing.Point(283, 3);
            this.btn_2h.Name = "btn_2h";
            this.btn_2h.Size = new System.Drawing.Size(50, 25);
            this.btn_2h.TabIndex = 16;
            this.btn_2h.Text = "2s";
            this.btn_2h.UseVisualStyleBackColor = true;
            // 
            // btn_4h
            // 
            this.btn_4h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_4h.FlatAppearance.BorderSize = 0;
            this.btn_4h.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_4h.Location = new System.Drawing.Point(339, 3);
            this.btn_4h.Name = "btn_4h";
            this.btn_4h.Size = new System.Drawing.Size(50, 25);
            this.btn_4h.TabIndex = 15;
            this.btn_4h.Text = "4h";
            this.btn_4h.UseVisualStyleBackColor = true;
            // 
            // btn_30m
            // 
            this.btn_30m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_30m.FlatAppearance.BorderSize = 0;
            this.btn_30m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_30m.Location = new System.Drawing.Point(171, 3);
            this.btn_30m.Name = "btn_30m";
            this.btn_30m.Size = new System.Drawing.Size(50, 25);
            this.btn_30m.TabIndex = 14;
            this.btn_30m.Text = "30d";
            this.btn_30m.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 25);
            this.button6.TabIndex = 13;
            this.button6.Text = "1d";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btn_5m
            // 
            this.btn_5m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_5m.FlatAppearance.BorderSize = 0;
            this.btn_5m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_5m.Location = new System.Drawing.Point(59, 3);
            this.btn_5m.Name = "btn_5m";
            this.btn_5m.Size = new System.Drawing.Size(50, 25);
            this.btn_5m.TabIndex = 12;
            this.btn_5m.Text = "5d";
            this.btn_5m.UseVisualStyleBackColor = true;
            // 
            // btn_1M
            // 
            this.btn_1M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_1M.FlatAppearance.BorderSize = 0;
            this.btn_1M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1M.Location = new System.Drawing.Point(507, 3);
            this.btn_1M.Name = "btn_1M";
            this.btn_1M.Size = new System.Drawing.Size(54, 25);
            this.btn_1M.TabIndex = 11;
            this.btn_1M.Text = "1A";
            this.btn_1M.UseVisualStyleBackColor = true;
            // 
            // btn_1W
            // 
            this.btn_1W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_1W.FlatAppearance.BorderSize = 0;
            this.btn_1W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1W.Location = new System.Drawing.Point(451, 3);
            this.btn_1W.Name = "btn_1W";
            this.btn_1W.Size = new System.Drawing.Size(50, 25);
            this.btn_1W.TabIndex = 10;
            this.btn_1W.Text = "1H";
            this.btn_1W.UseVisualStyleBackColor = true;
            // 
            // btn_1D
            // 
            this.btn_1D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_1D.FlatAppearance.BorderSize = 0;
            this.btn_1D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1D.Location = new System.Drawing.Point(395, 3);
            this.btn_1D.Name = "btn_1D";
            this.btn_1D.Size = new System.Drawing.Size(50, 25);
            this.btn_1D.TabIndex = 9;
            this.btn_1D.Text = "1G";
            this.btn_1D.UseVisualStyleBackColor = true;
            // 
            // btn_15m
            // 
            this.btn_15m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_15m.FlatAppearance.BorderSize = 0;
            this.btn_15m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_15m.Location = new System.Drawing.Point(115, 3);
            this.btn_15m.Name = "btn_15m";
            this.btn_15m.Size = new System.Drawing.Size(50, 25);
            this.btn_15m.TabIndex = 8;
            this.btn_15m.Text = "15d";
            this.btn_15m.UseVisualStyleBackColor = true;
            // 
            // pnl_chartHeader
            // 
            this.pnl_chartHeader.ColumnCount = 3;
            this.pnl_chartHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.pnl_chartHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.pnl_chartHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.pnl_chartHeader.Controls.Add(this.lbl_pricePercent, 2, 0);
            this.pnl_chartHeader.Controls.Add(this.lbl_lastPrice, 1, 0);
            this.pnl_chartHeader.Controls.Add(this.lbl_symbolName, 0, 0);
            this.pnl_chartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_chartHeader.Location = new System.Drawing.Point(0, 0);
            this.pnl_chartHeader.Name = "pnl_chartHeader";
            this.pnl_chartHeader.RowCount = 1;
            this.pnl_chartHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_chartHeader.Size = new System.Drawing.Size(564, 31);
            this.pnl_chartHeader.TabIndex = 8;
            // 
            // lbl_pricePercent
            // 
            this.lbl_pricePercent.AutoSize = true;
            this.lbl_pricePercent.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_pricePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_pricePercent.ForeColor = System.Drawing.Color.Coral;
            this.lbl_pricePercent.Location = new System.Drawing.Point(407, 0);
            this.lbl_pricePercent.Name = "lbl_pricePercent";
            this.lbl_pricePercent.Size = new System.Drawing.Size(154, 31);
            this.lbl_pricePercent.TabIndex = 4;
            this.lbl_pricePercent.Text = "Change Percent";
            // 
            // lbl_lastPrice
            // 
            this.lbl_lastPrice.AutoSize = true;
            this.lbl_lastPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_lastPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_lastPrice.ForeColor = System.Drawing.Color.Coral;
            this.lbl_lastPrice.Location = new System.Drawing.Point(264, 0);
            this.lbl_lastPrice.Name = "lbl_lastPrice";
            this.lbl_lastPrice.Size = new System.Drawing.Size(98, 31);
            this.lbl_lastPrice.TabIndex = 3;
            this.lbl_lastPrice.Text = "Last Price";
            // 
            // lbl_symbolName
            // 
            this.lbl_symbolName.AutoSize = true;
            this.lbl_symbolName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_symbolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_symbolName.ForeColor = System.Drawing.Color.Coral;
            this.lbl_symbolName.Location = new System.Drawing.Point(19, 0);
            this.lbl_symbolName.Name = "lbl_symbolName";
            this.lbl_symbolName.Size = new System.Drawing.Size(135, 31);
            this.lbl_symbolName.TabIndex = 2;
            this.lbl_symbolName.Text = "Symbol Name";
            // 
            // PriceChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.pnl_chartTimeFrames);
            this.Controls.Add(this.pnl_chartHeader);
            this.Name = "PriceChart";
            this.Size = new System.Drawing.Size(564, 416);
            this.pnl_chartTimeFrames.ResumeLayout(false);
            this.pnl_chartHeader.ResumeLayout(false);
            this.pnl_chartHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.TableLayoutPanel pnl_chartTimeFrames;
        private System.Windows.Forms.Button btn_1h;
        private System.Windows.Forms.Button btn_2h;
        private System.Windows.Forms.Button btn_4h;
        private System.Windows.Forms.Button btn_30m;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_5m;
        private System.Windows.Forms.Button btn_1M;
        private System.Windows.Forms.Button btn_1W;
        private System.Windows.Forms.Button btn_1D;
        private System.Windows.Forms.Button btn_15m;
        private System.Windows.Forms.TableLayoutPanel pnl_chartHeader;
        private System.Windows.Forms.Label lbl_pricePercent;
        private System.Windows.Forms.Label lbl_lastPrice;
        private System.Windows.Forms.Label lbl_symbolName;
    }
}
