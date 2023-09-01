namespace KriptoTakipSistemi.components
{
    partial class TradingPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.btn_Buy = new System.Windows.Forms.Button();
            this.btn_Sell = new System.Windows.Forms.Button();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.SymbolBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_SelectSymbol = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 51);
            this.panel1.TabIndex = 0;
            // 
            // QuantityBox
            // 
            this.QuantityBox.Location = new System.Drawing.Point(94, 132);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(149, 20);
            this.QuantityBox.TabIndex = 0;
            // 
            // btn_Buy
            // 
            this.btn_Buy.Location = new System.Drawing.Point(51, 182);
            this.btn_Buy.Name = "btn_Buy";
            this.btn_Buy.Size = new System.Drawing.Size(192, 35);
            this.btn_Buy.TabIndex = 1;
            this.btn_Buy.Text = "Al";
            this.btn_Buy.UseVisualStyleBackColor = true;
            // 
            // btn_Sell
            // 
            this.btn_Sell.Location = new System.Drawing.Point(51, 234);
            this.btn_Sell.Name = "btn_Sell";
            this.btn_Sell.Size = new System.Drawing.Size(192, 35);
            this.btn_Sell.TabIndex = 2;
            this.btn_Sell.Text = "Sat";
            this.btn_Sell.UseVisualStyleBackColor = true;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(48, 135);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(36, 13);
            this.lbl_Quantity.TabIndex = 3;
            this.lbl_Quantity.Text = "Miktar";
            // 
            // SymbolBox
            // 
            this.SymbolBox.FormattingEnabled = true;
            this.SymbolBox.Location = new System.Drawing.Point(158, 12);
            this.SymbolBox.Name = "SymbolBox";
            this.SymbolBox.Size = new System.Drawing.Size(132, 21);
            this.SymbolBox.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_SelectSymbol);
            this.panel2.Controls.Add(this.SymbolBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 51);
            this.panel2.TabIndex = 5;
            // 
            // lbl_SelectSymbol
            // 
            this.lbl_SelectSymbol.AutoSize = true;
            this.lbl_SelectSymbol.Location = new System.Drawing.Point(48, 20);
            this.lbl_SelectSymbol.Name = "lbl_SelectSymbol";
            this.lbl_SelectSymbol.Size = new System.Drawing.Size(54, 13);
            this.lbl_SelectSymbol.TabIndex = 5;
            this.lbl_SelectSymbol.Text = "Parite seç";
            // 
            // TradingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.btn_Sell);
            this.Controls.Add(this.btn_Buy);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TradingPanel";
            this.Size = new System.Drawing.Size(310, 300);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.Button btn_Buy;
        private System.Windows.Forms.Button btn_Sell;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.ComboBox SymbolBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_SelectSymbol;
    }
}
