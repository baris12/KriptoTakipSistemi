namespace KriptoTakipSistemi.gui_pages
{
    partial class AlarmsPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addAlarm = new System.Windows.Forms.Button();
            this.StrategyAlarmsBox = new System.Windows.Forms.GroupBox();
            this.PriceAlarmsBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PriceAlarmBoxEdit = new System.Windows.Forms.GroupBox();
            this.StrategyAlarmBoxEdit = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_addAlarm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 35);
            this.panel1.TabIndex = 1;
            // 
            // btn_addAlarm
            // 
            this.btn_addAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_addAlarm.Location = new System.Drawing.Point(392, 3);
            this.btn_addAlarm.Name = "btn_addAlarm";
            this.btn_addAlarm.Size = new System.Drawing.Size(32, 26);
            this.btn_addAlarm.TabIndex = 0;
            this.btn_addAlarm.Text = "+";
            this.btn_addAlarm.UseVisualStyleBackColor = true;
            // 
            // StrategyAlarmsBox
            // 
            this.StrategyAlarmsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrategyAlarmsBox.Location = new System.Drawing.Point(3, 212);
            this.StrategyAlarmsBox.Name = "StrategyAlarmsBox";
            this.StrategyAlarmsBox.Size = new System.Drawing.Size(423, 204);
            this.StrategyAlarmsBox.TabIndex = 1;
            this.StrategyAlarmsBox.TabStop = false;
            this.StrategyAlarmsBox.Text = "Strateji Alarmları";
            // 
            // PriceAlarmsBox
            // 
            this.PriceAlarmsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceAlarmsBox.Location = new System.Drawing.Point(3, 3);
            this.PriceAlarmsBox.Name = "PriceAlarmsBox";
            this.PriceAlarmsBox.Size = new System.Drawing.Size(423, 203);
            this.PriceAlarmsBox.TabIndex = 0;
            this.PriceAlarmsBox.TabStop = false;
            this.PriceAlarmsBox.Text = "Fiyat Alarmları";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel1.Controls.Add(this.StrategyAlarmsBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PriceAlarmsBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PriceAlarmBoxEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.StrategyAlarmBoxEdit, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 419);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // PriceAlarmBoxEdit
            // 
            this.PriceAlarmBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceAlarmBoxEdit.Location = new System.Drawing.Point(432, 3);
            this.PriceAlarmBoxEdit.Name = "PriceAlarmBoxEdit";
            this.PriceAlarmBoxEdit.Size = new System.Drawing.Size(264, 203);
            this.PriceAlarmBoxEdit.TabIndex = 2;
            this.PriceAlarmBoxEdit.TabStop = false;
            this.PriceAlarmBoxEdit.Text = "Fiyat Alarmı Düzenle";
            // 
            // StrategyAlarmBoxEdit
            // 
            this.StrategyAlarmBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrategyAlarmBoxEdit.Location = new System.Drawing.Point(432, 212);
            this.StrategyAlarmBoxEdit.Name = "StrategyAlarmBoxEdit";
            this.StrategyAlarmBoxEdit.Size = new System.Drawing.Size(264, 204);
            this.StrategyAlarmBoxEdit.TabIndex = 3;
            this.StrategyAlarmBoxEdit.TabStop = false;
            this.StrategyAlarmBoxEdit.Text = "Strateji Alarmı Düzenle";
            // 
            // AlarmsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "AlarmsPage";
            this.Size = new System.Drawing.Size(699, 454);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addAlarm;
        private System.Windows.Forms.GroupBox StrategyAlarmsBox;
        private System.Windows.Forms.GroupBox PriceAlarmsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox PriceAlarmBoxEdit;
        private System.Windows.Forms.GroupBox StrategyAlarmBoxEdit;
    }
}
