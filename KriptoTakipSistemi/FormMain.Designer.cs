namespace KriptoTakipSistemi
{
    partial class FormMain
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
            this.split_sidebar = new System.Windows.Forms.SplitContainer();
            this.split_header = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.split_sidebar)).BeginInit();
            this.split_sidebar.Panel2.SuspendLayout();
            this.split_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_header)).BeginInit();
            this.split_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_sidebar
            // 
            this.split_sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_sidebar.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split_sidebar.IsSplitterFixed = true;
            this.split_sidebar.Location = new System.Drawing.Point(0, 0);
            this.split_sidebar.Name = "split_sidebar";
            // 
            // split_sidebar.Panel2
            // 
            this.split_sidebar.Panel2.Controls.Add(this.split_header);
            this.split_sidebar.Size = new System.Drawing.Size(800, 450);
            this.split_sidebar.SplitterDistance = 199;
            this.split_sidebar.TabIndex = 0;
            // 
            // split_header
            // 
            this.split_header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_header.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split_header.IsSplitterFixed = true;
            this.split_header.Location = new System.Drawing.Point(0, 0);
            this.split_header.Name = "split_header";
            this.split_header.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.split_header.Size = new System.Drawing.Size(597, 450);
            this.split_header.SplitterDistance = 83;
            this.split_header.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.split_sidebar);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FormMain";
            this.Text = "Kripto Takip";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.split_sidebar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_sidebar)).EndInit();
            this.split_sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_header)).EndInit();
            this.split_header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_sidebar;
        private System.Windows.Forms.SplitContainer split_header;
    }
}