namespace KriptoTakipSistemi.components
{
    partial class ChangeEmailPanel
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
            this.CurrentEmailBox = new System.Windows.Forms.TextBox();
            this.NewEmailBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NewEmailRepeatBox = new System.Windows.Forms.TextBox();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentEmailBox
            // 
            this.CurrentEmailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentEmailBox.Location = new System.Drawing.Point(183, 3);
            this.CurrentEmailBox.Name = "CurrentEmailBox";
            this.CurrentEmailBox.Size = new System.Drawing.Size(175, 20);
            this.CurrentEmailBox.TabIndex = 0;
            // 
            // NewEmailBox
            // 
            this.NewEmailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewEmailBox.Location = new System.Drawing.Point(183, 69);
            this.NewEmailBox.Name = "NewEmailBox";
            this.NewEmailBox.Size = new System.Drawing.Size(175, 20);
            this.NewEmailBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewEmailBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CurrentEmailBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewEmailRepeatBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_Accept, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 266);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Yeni E-posta tekrar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yeni E-posta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Eski E-posta";
            // 
            // NewEmailRepeatBox
            // 
            this.NewEmailRepeatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewEmailRepeatBox.Location = new System.Drawing.Point(183, 135);
            this.NewEmailRepeatBox.Name = "NewEmailRepeatBox";
            this.NewEmailRepeatBox.Size = new System.Drawing.Size(175, 20);
            this.NewEmailRepeatBox.TabIndex = 5;
            // 
            // btn_Accept
            // 
            this.btn_Accept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Accept.Location = new System.Drawing.Point(183, 201);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(175, 62);
            this.btn_Accept.TabIndex = 6;
            this.btn_Accept.Text = "Onayla";
            this.btn_Accept.UseVisualStyleBackColor = true;
            // 
            // ChangeEmailPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeEmailPanel";
            this.Size = new System.Drawing.Size(361, 266);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox CurrentEmailBox;
        private System.Windows.Forms.TextBox NewEmailBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewEmailRepeatBox;
        private System.Windows.Forms.Button btn_Accept;
    }
}
