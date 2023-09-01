namespace KriptoTakipSistemi.components
{
    partial class EditPriceAlarmPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.ConditionBox = new System.Windows.Forms.ComboBox();
            this.ValidityPeriodBox = new System.Windows.Forms.ComboBox();
            this.SymbolBox = new System.Windows.Forms.TextBox();
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sembol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Geçerlilik süresi";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PriceBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ConditionBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ValidityPeriodBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SymbolBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(289, 271);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // PriceBox
            // 
            this.PriceBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.PriceBox.Location = new System.Drawing.Point(160, 73);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(121, 20);
            this.PriceBox.TabIndex = 7;
            // 
            // ConditionBox
            // 
            this.ConditionBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConditionBox.FormattingEnabled = true;
            this.ConditionBox.Location = new System.Drawing.Point(160, 138);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(121, 21);
            this.ConditionBox.TabIndex = 5;
            // 
            // ValidityPeriodBox
            // 
            this.ValidityPeriodBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ValidityPeriodBox.FormattingEnabled = true;
            this.ValidityPeriodBox.Location = new System.Drawing.Point(160, 203);
            this.ValidityPeriodBox.Name = "ValidityPeriodBox";
            this.ValidityPeriodBox.Size = new System.Drawing.Size(121, 21);
            this.ValidityPeriodBox.TabIndex = 6;
            // 
            // SymbolBox
            // 
            this.SymbolBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.SymbolBox.Location = new System.Drawing.Point(160, 8);
            this.SymbolBox.Name = "SymbolBox";
            this.SymbolBox.ReadOnly = true;
            this.SymbolBox.Size = new System.Drawing.Size(121, 20);
            this.SymbolBox.TabIndex = 8;
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start_stop.Location = new System.Drawing.Point(213, 6);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(68, 23);
            this.btn_start_stop.TabIndex = 8;
            this.btn_start_stop.Text = "Durdur";
            this.btn_start_stop.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(11, 6);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(68, 23);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Kaydet";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_remove
            // 
            this.btn_remove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_remove.Location = new System.Drawing.Point(112, 6);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(68, 23);
            this.btn_remove.TabIndex = 10;
            this.btn_remove.Text = "Sil";
            this.btn_remove.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_remove);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_start_stop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 36);
            this.panel1.TabIndex = 11;
            // 
            // EditPriceAlarmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "EditPriceAlarmPanel";
            this.Size = new System.Drawing.Size(289, 307);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox ConditionBox;
        private System.Windows.Forms.ComboBox ValidityPeriodBox;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.Button btn_start_stop;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox SymbolBox;
    }
}
