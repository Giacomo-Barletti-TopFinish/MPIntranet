namespace MPIntranet.Common
{
    partial class MPIBaseForm
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
            this.MPStatusBar = new System.Windows.Forms.StatusStrip();
            this.lblUserLoggato = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.stUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.MPStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MPStatusBar
            // 
            this.MPStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserLoggato,
            this.lblStatusBar,
            this.stUser});
            this.MPStatusBar.Location = new System.Drawing.Point(0, 428);
            this.MPStatusBar.Name = "MPStatusBar";
            this.MPStatusBar.Size = new System.Drawing.Size(800, 22);
            this.MPStatusBar.TabIndex = 4;
            this.MPStatusBar.Text = "cdcStatus";
            // 
            // lblUserLoggato
            // 
            this.lblUserLoggato.Name = "lblUserLoggato";
            this.lblUserLoggato.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // stUser
            // 
            this.stUser.Name = "stUser";
            this.stUser.Size = new System.Drawing.Size(118, 17);
            this.stUser.Text = "toolStripStatusLabel1";
            // 
            // MPIBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MPStatusBar);
            this.IsMdiContainer = true;
            this.Name = "MPIBaseForm";
            this.Text = "MPIBaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MPIBaseForm_FormClosing);
            this.Load += new System.EventHandler(this.MPIBaseForm_Load);
            this.MPStatusBar.ResumeLayout(false);
            this.MPStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MPStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblUserLoggato;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel stUser;
    }
}