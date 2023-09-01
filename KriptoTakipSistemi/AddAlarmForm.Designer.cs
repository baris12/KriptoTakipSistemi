namespace KriptoTakipSistemi
{
    partial class AddAlarmForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectAlarmType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceAlarmBox = new System.Windows.Forms.GroupBox();
            this.btn_AddPriceAlarm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PriceAlarmConditionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PriceAlarmValidityPeriodBox = new System.Windows.Forms.ComboBox();
            this.PriceAlarmPriceText = new System.Windows.Forms.TextBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_symbol = new System.Windows.Forms.Label();
            this.PriceAlarmSymbolBox = new System.Windows.Forms.ComboBox();
            this.PriceAlarmBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectAlarmType
            // 
            this.SelectAlarmType.FormattingEnabled = true;
            this.SelectAlarmType.Items.AddRange(new object[] {
            "Fiyat alarmı",
            "Strateji alarmı"});
            this.SelectAlarmType.Location = new System.Drawing.Point(187, 32);
            this.SelectAlarmType.Name = "SelectAlarmType";
            this.SelectAlarmType.Size = new System.Drawing.Size(121, 21);
            this.SelectAlarmType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alarm Türü";
            // 
            // PriceAlarmBox
            // 
            this.PriceAlarmBox.Controls.Add(this.btn_AddPriceAlarm);
            this.PriceAlarmBox.Controls.Add(this.label3);
            this.PriceAlarmBox.Controls.Add(this.PriceAlarmConditionBox);
            this.PriceAlarmBox.Controls.Add(this.label2);
            this.PriceAlarmBox.Controls.Add(this.PriceAlarmValidityPeriodBox);
            this.PriceAlarmBox.Controls.Add(this.PriceAlarmPriceText);
            this.PriceAlarmBox.Controls.Add(this.lbl_price);
            this.PriceAlarmBox.Controls.Add(this.lbl_symbol);
            this.PriceAlarmBox.Controls.Add(this.PriceAlarmSymbolBox);
            this.PriceAlarmBox.Location = new System.Drawing.Point(12, 84);
            this.PriceAlarmBox.Name = "PriceAlarmBox";
            this.PriceAlarmBox.Size = new System.Drawing.Size(302, 233);
            this.PriceAlarmBox.TabIndex = 2;
            this.PriceAlarmBox.TabStop = false;
            this.PriceAlarmBox.Text = "Fiyat Alarmı";
            // 
            // btn_AddPriceAlarm
            // 
            this.btn_AddPriceAlarm.Location = new System.Drawing.Point(175, 199);
            this.btn_AddPriceAlarm.Name = "btn_AddPriceAlarm";
            this.btn_AddPriceAlarm.Size = new System.Drawing.Size(121, 23);
            this.btn_AddPriceAlarm.TabIndex = 11;
            this.btn_AddPriceAlarm.Text = "Ekle";
            this.btn_AddPriceAlarm.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Şart";
            // 
            // PriceAlarmConditionBox
            // 
            this.PriceAlarmConditionBox.FormattingEnabled = true;
            this.PriceAlarmConditionBox.Location = new System.Drawing.Point(175, 155);
            this.PriceAlarmConditionBox.Name = "PriceAlarmConditionBox";
            this.PriceAlarmConditionBox.Size = new System.Drawing.Size(121, 21);
            this.PriceAlarmConditionBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Geçerlilik süresi";
            // 
            // PriceAlarmValidityPeriodBox
            // 
            this.PriceAlarmValidityPeriodBox.FormattingEnabled = true;
            this.PriceAlarmValidityPeriodBox.Location = new System.Drawing.Point(175, 115);
            this.PriceAlarmValidityPeriodBox.Name = "PriceAlarmValidityPeriodBox";
            this.PriceAlarmValidityPeriodBox.Size = new System.Drawing.Size(121, 21);
            this.PriceAlarmValidityPeriodBox.TabIndex = 7;
            // 
            // PriceAlarmPriceText
            // 
            this.PriceAlarmPriceText.Location = new System.Drawing.Point(175, 76);
            this.PriceAlarmPriceText.Name = "PriceAlarmPriceText";
            this.PriceAlarmPriceText.Size = new System.Drawing.Size(121, 20);
            this.PriceAlarmPriceText.TabIndex = 6;
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(21, 76);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(29, 13);
            this.lbl_price.TabIndex = 5;
            this.lbl_price.Text = "Fiyat";
            // 
            // lbl_symbol
            // 
            this.lbl_symbol.AutoSize = true;
            this.lbl_symbol.Location = new System.Drawing.Point(21, 37);
            this.lbl_symbol.Name = "lbl_symbol";
            this.lbl_symbol.Size = new System.Drawing.Size(42, 13);
            this.lbl_symbol.TabIndex = 3;
            this.lbl_symbol.Text = "Sembol";
            // 
            // PriceAlarmSymbolBox
            // 
            this.PriceAlarmSymbolBox.FormattingEnabled = true;
            this.PriceAlarmSymbolBox.Location = new System.Drawing.Point(175, 34);
            this.PriceAlarmSymbolBox.Name = "PriceAlarmSymbolBox";
            this.PriceAlarmSymbolBox.Size = new System.Drawing.Size(121, 21);
            this.PriceAlarmSymbolBox.TabIndex = 2;
            // 
            // AddAlarmForm
            // 
            this.AcceptButton = this.btn_AddPriceAlarm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 341);
            this.Controls.Add(this.PriceAlarmBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectAlarmType);
            this.Name = "AddAlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm ekle";
            this.PriceAlarmBox.ResumeLayout(false);
            this.PriceAlarmBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectAlarmType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox PriceAlarmBox;
        private System.Windows.Forms.Label lbl_symbol;
        private System.Windows.Forms.ComboBox PriceAlarmSymbolBox;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PriceAlarmValidityPeriodBox;
        private System.Windows.Forms.TextBox PriceAlarmPriceText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PriceAlarmConditionBox;
        private System.Windows.Forms.Button btn_AddPriceAlarm;
    }
}