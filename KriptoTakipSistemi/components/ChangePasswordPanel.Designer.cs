namespace KriptoTakipSistemi.components
{
    partial class ChangePasswordPanel
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
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.CurrentPasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewPasswordRepeatBox = new System.Windows.Forms.TextBox();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPasswordBox.Location = new System.Drawing.Point(186, 73);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.Size = new System.Drawing.Size(178, 20);
            this.NewPasswordBox.TabIndex = 1;
            // 
            // CurrentPasswordBox
            // 
            this.CurrentPasswordBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPasswordBox.Location = new System.Drawing.Point(186, 3);
            this.CurrentPasswordBox.Name = "CurrentPasswordBox";
            this.CurrentPasswordBox.Size = new System.Drawing.Size(178, 20);
            this.CurrentPasswordBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Eski Şifre";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewPasswordBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CurrentPasswordBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewPasswordRepeatBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_Accept, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 283);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yeni Şifre Tekrar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yeni Şifre";
            // 
            // NewPasswordRepeatBox
            // 
            this.NewPasswordRepeatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPasswordRepeatBox.Location = new System.Drawing.Point(186, 143);
            this.NewPasswordRepeatBox.Name = "NewPasswordRepeatBox";
            this.NewPasswordRepeatBox.Size = new System.Drawing.Size(178, 20);
            this.NewPasswordRepeatBox.TabIndex = 5;
            // 
            // btn_Accept
            // 
            this.btn_Accept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Accept.Location = new System.Drawing.Point(186, 213);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(178, 67);
            this.btn_Accept.TabIndex = 6;
            this.btn_Accept.Text = "Onayla";
            this.btn_Accept.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangePasswordPanel";
            this.Size = new System.Drawing.Size(367, 283);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.TextBox CurrentPasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewPasswordRepeatBox;
        private System.Windows.Forms.Button btn_Accept;
    }
}
