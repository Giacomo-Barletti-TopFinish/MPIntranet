namespace MPPreventivatore
{
    partial class MainForm
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
            this.MPMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anagraficaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distintaBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MPMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MPMenu
            // 
            this.MPMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.anagraficaToolStripMenuItem,
            this.distintaBaseToolStripMenuItem,
            this.costiToolStripMenuItem});
            this.MPMenu.Location = new System.Drawing.Point(0, 0);
            this.MPMenu.Name = "MPMenu";
            this.MPMenu.Size = new System.Drawing.Size(1558, 25);
            this.MPMenu.TabIndex = 2;
            this.MPMenu.Text = "cdcMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // anagraficaToolStripMenuItem
            // 
            this.anagraficaToolStripMenuItem.Name = "anagraficaToolStripMenuItem";
            this.anagraficaToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.anagraficaToolStripMenuItem.Text = "Anagrafica";
            // 
            // distintaBaseToolStripMenuItem
            // 
            this.distintaBaseToolStripMenuItem.Name = "distintaBaseToolStripMenuItem";
            this.distintaBaseToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.distintaBaseToolStripMenuItem.Text = "Distinta base";
            // 
            // costiToolStripMenuItem
            // 
            this.costiToolStripMenuItem.Name = "costiToolStripMenuItem";
            this.costiToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.costiToolStripMenuItem.Text = "Costi";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 785);
            this.Controls.Add(this.MPMenu);
            this.Name = "MainForm";
            this.Text = "MPPreventivatore";
            this.Controls.SetChildIndex(this.MPMenu, 0);
            this.MPMenu.ResumeLayout(false);
            this.MPMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MPMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anagraficaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distintaBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costiToolStripMenuItem;
    }
}

