namespace DisegnaDiBa
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
            this.preventiviMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distinteRVLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovaDistintaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriEsistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finestreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessCentralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preventiviMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // preventiviMenu
            // 
            this.preventiviMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preventiviMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.distinteRVLToolStripMenuItem,
            this.finestreToolStripMenuItem});
            this.preventiviMenu.Location = new System.Drawing.Point(0, 0);
            this.preventiviMenu.MdiWindowListItem = this.finestreToolStripMenuItem;
            this.preventiviMenu.Name = "preventiviMenu";
            this.preventiviMenu.Size = new System.Drawing.Size(1452, 25);
            this.preventiviMenu.TabIndex = 2;
            this.preventiviMenu.Text = "menuStrip1";
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
            this.exitToolStripMenuItem.MergeIndex = 100;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // distinteRVLToolStripMenuItem
            // 
            this.distinteRVLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaDistintaToolStripMenuItem,
            this.apriEsistenteToolStripMenuItem,
            this.businessCentralToolStripMenuItem});
            this.distinteRVLToolStripMenuItem.Name = "distinteRVLToolStripMenuItem";
            this.distinteRVLToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.distinteRVLToolStripMenuItem.Text = "Distinte base";
            // 
            // nuovaDistintaToolStripMenuItem
            // 
            this.nuovaDistintaToolStripMenuItem.Name = "nuovaDistintaToolStripMenuItem";
            this.nuovaDistintaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuovaDistintaToolStripMenuItem.Text = "Nuova...";
            this.nuovaDistintaToolStripMenuItem.Visible = false;
            this.nuovaDistintaToolStripMenuItem.Click += new System.EventHandler(this.nuovaDistintaToolStripMenuItem_Click);
            // 
            // apriEsistenteToolStripMenuItem
            // 
            this.apriEsistenteToolStripMenuItem.Name = "apriEsistenteToolStripMenuItem";
            this.apriEsistenteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apriEsistenteToolStripMenuItem.Text = "Apri ...";
            this.apriEsistenteToolStripMenuItem.Click += new System.EventHandler(this.apriEsistenteToolStripMenuItem_Click);
            // 
            // finestreToolStripMenuItem
            // 
            this.finestreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponiToolStripMenuItem});
            this.finestreToolStripMenuItem.Name = "finestreToolStripMenuItem";
            this.finestreToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.finestreToolStripMenuItem.Text = "Finestre";
            // 
            // disponiToolStripMenuItem
            // 
            this.disponiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascataToolStripMenuItem,
            this.organizzaToolStripMenuItem});
            this.disponiToolStripMenuItem.Name = "disponiToolStripMenuItem";
            this.disponiToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.disponiToolStripMenuItem.Text = "Disponi";
            // 
            // cascataToolStripMenuItem
            // 
            this.cascataToolStripMenuItem.Name = "cascataToolStripMenuItem";
            this.cascataToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.cascataToolStripMenuItem.Text = "Cascata";
            this.cascataToolStripMenuItem.Click += new System.EventHandler(this.cascataToolStripMenuItem_Click);
            // 
            // organizzaToolStripMenuItem
            // 
            this.organizzaToolStripMenuItem.Name = "organizzaToolStripMenuItem";
            this.organizzaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.organizzaToolStripMenuItem.Text = "Organizza orizzontale";
            this.organizzaToolStripMenuItem.Click += new System.EventHandler(this.organizzaToolStripMenuItem_Click);
            // 
            // businessCentralToolStripMenuItem
            // 
            this.businessCentralToolStripMenuItem.Name = "businessCentralToolStripMenuItem";
            this.businessCentralToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.businessCentralToolStripMenuItem.Text = "Business Central...";
            this.businessCentralToolStripMenuItem.Click += new System.EventHandler(this.businessCentralToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 808);
            this.Controls.Add(this.preventiviMenu);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.preventiviMenu.ResumeLayout(false);
            this.preventiviMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip preventiviMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distinteRVLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovaDistintaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriEsistenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessCentralToolStripMenuItem;
    }
}

