namespace KriptoTakipSistemi
{
    partial class LogoutConfirm
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
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(68, 54);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(154, 46);
            this.btn_logout.TabIndex = 4;
            this.btn_logout.Text = "Çıkış yap";
            this.btn_logout.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(68, 118);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(154, 46);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Vazgeç";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // LogoutConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 199);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_logout);
            this.MaximumSize = new System.Drawing.Size(309, 238);
            this.MinimumSize = new System.Drawing.Size(309, 238);
            this.Name = "LogoutConfirm";
            this.Text = "LogoutConfirm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_cancel;
    }
}