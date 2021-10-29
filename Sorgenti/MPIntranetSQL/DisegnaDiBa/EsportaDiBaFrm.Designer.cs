namespace DisegnaDiBa
{
    partial class EsportaDiBaFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsportaDiBaFrm));
            this.btnTrovaFileDistinte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileDistinte = new System.Windows.Forms.TextBox();
            this.btnSalvaFileDistinte = new System.Windows.Forms.Button();
            this.txtFileCicli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvaCicli = new System.Windows.Forms.Button();
            this.btnTrovaFileCicli = new System.Windows.Forms.Button();
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.dgvEsportaComponenti = new System.Windows.Forms.DataGridView();
            this.SelezionaComponentiClm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EsitoComponentiClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDComponentiClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistintaComponentiClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnagraficaComponentiClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErroreComponentiClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEsportaFasi = new System.Windows.Forms.DataGridView();
            this.SelezionaFaseClm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EsitoFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceCicloFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDFAseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperazioneFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaProduzioneFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErroreFaseClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEsportazione = new System.Windows.Forms.TextBox();
            this.pbEsportazione = new System.Windows.Forms.ProgressBar();
            this.btnAvviaEsportazione = new System.Windows.Forms.Button();
            this.lblElementi = new System.Windows.Forms.Label();
            this.lblAvanzamento = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menucicliStatoCertificato = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEsportaCicli = new System.Windows.Forms.DataGridView();
            this.selezionaCicliClm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codiceCicloClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mettiInSviluppoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDistinteStatoCertificato = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEsportaDistinte = new System.Windows.Forms.DataGridView();
            this.selezionaDistintaClm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codiceDistintaClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPulisciMessaggi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaComponenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaFasi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaCicli)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaDistinte)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrovaFileDistinte
            // 
            this.btnTrovaFileDistinte.Location = new System.Drawing.Point(650, 19);
            this.btnTrovaFileDistinte.Name = "btnTrovaFileDistinte";
            this.btnTrovaFileDistinte.Size = new System.Drawing.Size(100, 23);
            this.btnTrovaFileDistinte.TabIndex = 0;
            this.btnTrovaFileDistinte.Text = "Trova";
            this.btnTrovaFileDistinte.UseVisualStyleBackColor = true;
            this.btnTrovaFileDistinte.Click += new System.EventHandler(this.btnTrovaFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File distinte";
            // 
            // txtFileDistinte
            // 
            this.txtFileDistinte.Location = new System.Drawing.Point(186, 20);
            this.txtFileDistinte.Name = "txtFileDistinte";
            this.txtFileDistinte.Size = new System.Drawing.Size(439, 20);
            this.txtFileDistinte.TabIndex = 2;
            // 
            // btnSalvaFileDistinte
            // 
            this.btnSalvaFileDistinte.Location = new System.Drawing.Point(789, 19);
            this.btnSalvaFileDistinte.Name = "btnSalvaFileDistinte";
            this.btnSalvaFileDistinte.Size = new System.Drawing.Size(123, 23);
            this.btnSalvaFileDistinte.TabIndex = 0;
            this.btnSalvaFileDistinte.Text = "Salva Distinte";
            this.btnSalvaFileDistinte.UseVisualStyleBackColor = true;
            this.btnSalvaFileDistinte.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // txtFileCicli
            // 
            this.txtFileCicli.Location = new System.Drawing.Point(186, 53);
            this.txtFileCicli.Name = "txtFileCicli";
            this.txtFileCicli.Size = new System.Drawing.Size(439, 20);
            this.txtFileCicli.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File cicli";
            // 
            // btnSalvaCicli
            // 
            this.btnSalvaCicli.Location = new System.Drawing.Point(789, 51);
            this.btnSalvaCicli.Name = "btnSalvaCicli";
            this.btnSalvaCicli.Size = new System.Drawing.Size(123, 23);
            this.btnSalvaCicli.TabIndex = 3;
            this.btnSalvaCicli.Text = "Salva Cicli";
            this.btnSalvaCicli.UseVisualStyleBackColor = true;
            this.btnSalvaCicli.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // btnTrovaFileCicli
            // 
            this.btnTrovaFileCicli.Location = new System.Drawing.Point(650, 51);
            this.btnTrovaFileCicli.Name = "btnTrovaFileCicli";
            this.btnTrovaFileCicli.Size = new System.Drawing.Size(100, 23);
            this.btnTrovaFileCicli.TabIndex = 4;
            this.btnTrovaFileCicli.Text = "Trova";
            this.btnTrovaFileCicli.UseVisualStyleBackColor = true;
            this.btnTrovaFileCicli.Click += new System.EventHandler(this.btnTrovaFile_Click);
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessaggio.Location = new System.Drawing.Point(186, 88);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.ReadOnly = true;
            this.txtMessaggio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessaggio.Size = new System.Drawing.Size(439, 618);
            this.txtMessaggio.TabIndex = 8;
            // 
            // dgvEsportaComponenti
            // 
            this.dgvEsportaComponenti.AllowUserToAddRows = false;
            this.dgvEsportaComponenti.AllowUserToDeleteRows = false;
            this.dgvEsportaComponenti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaComponenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaComponenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelezionaComponentiClm,
            this.EsitoComponentiClm,
            this.IDComponentiClm,
            this.DistintaComponentiClm,
            this.AnagraficaComponentiClm,
            this.ErroreComponentiClm});
            this.dgvEsportaComponenti.Location = new System.Drawing.Point(357, 31);
            this.dgvEsportaComponenti.Name = "dgvEsportaComponenti";
            this.dgvEsportaComponenti.ReadOnly = true;
            this.dgvEsportaComponenti.Size = new System.Drawing.Size(635, 283);
            this.dgvEsportaComponenti.TabIndex = 9;
            // 
            // SelezionaComponentiClm
            // 
            this.SelezionaComponentiClm.DataPropertyName = "Selezionato";
            this.SelezionaComponentiClm.FillWeight = 70F;
            this.SelezionaComponentiClm.HeaderText = "Seleziona";
            this.SelezionaComponentiClm.Name = "SelezionaComponentiClm";
            this.SelezionaComponentiClm.ReadOnly = true;
            this.SelezionaComponentiClm.Visible = false;
            this.SelezionaComponentiClm.Width = 70;
            // 
            // EsitoComponentiClm
            // 
            this.EsitoComponentiClm.DataPropertyName = "Esito";
            this.EsitoComponentiClm.FillWeight = 50F;
            this.EsitoComponentiClm.HeaderText = "Esito";
            this.EsitoComponentiClm.Name = "EsitoComponentiClm";
            this.EsitoComponentiClm.ReadOnly = true;
            this.EsitoComponentiClm.Width = 50;
            // 
            // IDComponentiClm
            // 
            this.IDComponentiClm.DataPropertyName = "ID";
            this.IDComponentiClm.HeaderText = "ID";
            this.IDComponentiClm.Name = "IDComponentiClm";
            this.IDComponentiClm.ReadOnly = true;
            this.IDComponentiClm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDComponentiClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IDComponentiClm.Visible = false;
            // 
            // DistintaComponentiClm
            // 
            this.DistintaComponentiClm.DataPropertyName = "DistintaPadre";
            this.DistintaComponentiClm.FillWeight = 130F;
            this.DistintaComponentiClm.HeaderText = "Distinta";
            this.DistintaComponentiClm.Name = "DistintaComponentiClm";
            this.DistintaComponentiClm.ReadOnly = true;
            this.DistintaComponentiClm.Width = 130;
            // 
            // AnagraficaComponentiClm
            // 
            this.AnagraficaComponentiClm.DataPropertyName = "Anagrafica";
            this.AnagraficaComponentiClm.FillWeight = 130F;
            this.AnagraficaComponentiClm.HeaderText = "Anagrafica";
            this.AnagraficaComponentiClm.Name = "AnagraficaComponentiClm";
            this.AnagraficaComponentiClm.ReadOnly = true;
            this.AnagraficaComponentiClm.Width = 130;
            // 
            // ErroreComponentiClm
            // 
            this.ErroreComponentiClm.DataPropertyName = "Errore";
            this.ErroreComponentiClm.FillWeight = 150F;
            this.ErroreComponentiClm.HeaderText = "Errore";
            this.ErroreComponentiClm.Name = "ErroreComponentiClm";
            this.ErroreComponentiClm.ReadOnly = true;
            this.ErroreComponentiClm.Width = 150;
            // 
            // dgvEsportaFasi
            // 
            this.dgvEsportaFasi.AllowUserToAddRows = false;
            this.dgvEsportaFasi.AllowUserToDeleteRows = false;
            this.dgvEsportaFasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaFasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaFasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelezionaFaseClm,
            this.EsitoFaseClm,
            this.CodiceCicloFaseClm,
            this.IDFAseClm,
            this.OperazioneFaseClm,
            this.AreaProduzioneFaseClm,
            this.TaskFaseClm,
            this.ErroreFaseClm});
            this.dgvEsportaFasi.Location = new System.Drawing.Point(357, 34);
            this.dgvEsportaFasi.Name = "dgvEsportaFasi";
            this.dgvEsportaFasi.ReadOnly = true;
            this.dgvEsportaFasi.Size = new System.Drawing.Size(634, 265);
            this.dgvEsportaFasi.TabIndex = 10;
            // 
            // SelezionaFaseClm
            // 
            this.SelezionaFaseClm.DataPropertyName = "Selezionato";
            this.SelezionaFaseClm.HeaderText = "Seleziona";
            this.SelezionaFaseClm.Name = "SelezionaFaseClm";
            this.SelezionaFaseClm.ReadOnly = true;
            this.SelezionaFaseClm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelezionaFaseClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelezionaFaseClm.Visible = false;
            // 
            // EsitoFaseClm
            // 
            this.EsitoFaseClm.DataPropertyName = "Esito";
            this.EsitoFaseClm.FillWeight = 50F;
            this.EsitoFaseClm.HeaderText = "Esito";
            this.EsitoFaseClm.Name = "EsitoFaseClm";
            this.EsitoFaseClm.ReadOnly = true;
            this.EsitoFaseClm.Width = 50;
            // 
            // CodiceCicloFaseClm
            // 
            this.CodiceCicloFaseClm.DataPropertyName = "CodiceCiclo";
            this.CodiceCicloFaseClm.FillWeight = 130F;
            this.CodiceCicloFaseClm.HeaderText = "Ciclo";
            this.CodiceCicloFaseClm.Name = "CodiceCicloFaseClm";
            this.CodiceCicloFaseClm.ReadOnly = true;
            this.CodiceCicloFaseClm.Width = 130;
            // 
            // IDFAseClm
            // 
            this.IDFAseClm.DataPropertyName = "ID";
            this.IDFAseClm.HeaderText = "ID";
            this.IDFAseClm.Name = "IDFAseClm";
            this.IDFAseClm.ReadOnly = true;
            this.IDFAseClm.Visible = false;
            // 
            // OperazioneFaseClm
            // 
            this.OperazioneFaseClm.DataPropertyName = "Operazione";
            this.OperazioneFaseClm.FillWeight = 80F;
            this.OperazioneFaseClm.HeaderText = "Operazione";
            this.OperazioneFaseClm.Name = "OperazioneFaseClm";
            this.OperazioneFaseClm.ReadOnly = true;
            this.OperazioneFaseClm.Width = 80;
            // 
            // AreaProduzioneFaseClm
            // 
            this.AreaProduzioneFaseClm.DataPropertyName = "AreaProduzione";
            this.AreaProduzioneFaseClm.FillWeight = 80F;
            this.AreaProduzioneFaseClm.HeaderText = "Area produzione";
            this.AreaProduzioneFaseClm.Name = "AreaProduzioneFaseClm";
            this.AreaProduzioneFaseClm.ReadOnly = true;
            this.AreaProduzioneFaseClm.Width = 80;
            // 
            // TaskFaseClm
            // 
            this.TaskFaseClm.DataPropertyName = "Task";
            this.TaskFaseClm.FillWeight = 80F;
            this.TaskFaseClm.HeaderText = "Task";
            this.TaskFaseClm.Name = "TaskFaseClm";
            this.TaskFaseClm.ReadOnly = true;
            this.TaskFaseClm.Width = 80;
            // 
            // ErroreFaseClm
            // 
            this.ErroreFaseClm.DataPropertyName = "Errore";
            this.ErroreFaseClm.FillWeight = 150F;
            this.ErroreFaseClm.HeaderText = "Errore";
            this.ErroreFaseClm.Name = "ErroreFaseClm";
            this.ErroreFaseClm.ReadOnly = true;
            this.ErroreFaseClm.Width = 150;
            // 
            // txtEsportazione
            // 
            this.txtEsportazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsportazione.Location = new System.Drawing.Point(1021, 226);
            this.txtEsportazione.Multiline = true;
            this.txtEsportazione.Name = "txtEsportazione";
            this.txtEsportazione.ReadOnly = true;
            this.txtEsportazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEsportazione.Size = new System.Drawing.Size(374, 438);
            this.txtEsportazione.TabIndex = 14;
            // 
            // pbEsportazione
            // 
            this.pbEsportazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEsportazione.Location = new System.Drawing.Point(1021, 136);
            this.pbEsportazione.Name = "pbEsportazione";
            this.pbEsportazione.Size = new System.Drawing.Size(374, 23);
            this.pbEsportazione.TabIndex = 15;
            // 
            // btnAvviaEsportazione
            // 
            this.btnAvviaEsportazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvviaEsportazione.Location = new System.Drawing.Point(1021, 50);
            this.btnAvviaEsportazione.Name = "btnAvviaEsportazione";
            this.btnAvviaEsportazione.Size = new System.Drawing.Size(374, 37);
            this.btnAvviaEsportazione.TabIndex = 16;
            this.btnAvviaEsportazione.Text = "Esporta";
            this.btnAvviaEsportazione.UseVisualStyleBackColor = true;
            this.btnAvviaEsportazione.Click += new System.EventHandler(this.btnAvviaEsportazione_Click);
            // 
            // lblElementi
            // 
            this.lblElementi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElementi.AutoSize = true;
            this.lblElementi.Location = new System.Drawing.Point(1360, 120);
            this.lblElementi.Name = "lblElementi";
            this.lblElementi.Size = new System.Drawing.Size(35, 13);
            this.lblElementi.TabIndex = 17;
            this.lblElementi.Text = "label3";
            // 
            // lblAvanzamento
            // 
            this.lblAvanzamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvanzamento.AutoSize = true;
            this.lblAvanzamento.Location = new System.Drawing.Point(1188, 120);
            this.lblAvanzamento.Name = "lblAvanzamento";
            this.lblAvanzamento.Size = new System.Drawing.Size(35, 13);
            this.lblAvanzamento.TabIndex = 17;
            this.lblAvanzamento.Text = "label3";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1413, 709);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMessaggio);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFileDistinte);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtFileCicli);
            this.tabPage1.Controls.Add(this.btnSalvaCicli);
            this.tabPage1.Controls.Add(this.btnTrovaFileDistinte);
            this.tabPage1.Controls.Add(this.btnSalvaFileDistinte);
            this.tabPage1.Controls.Add(this.btnTrovaFileCicli);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1405, 683);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FIle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnPulisciMessaggi);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblAvanzamento);
            this.tabPage2.Controls.Add(this.lblElementi);
            this.tabPage2.Controls.Add(this.btnAvviaEsportazione);
            this.tabPage2.Controls.Add(this.pbEsportazione);
            this.tabPage2.Controls.Add(this.txtEsportazione);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1405, 683);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servizi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.menuStrip2);
            this.panel2.Controls.Add(this.dgvEsportaCicli);
            this.panel2.Controls.Add(this.dgvEsportaFasi);
            this.panel2.Location = new System.Drawing.Point(8, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 321);
            this.panel2.TabIndex = 23;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menucicliStatoCertificato});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1005, 24);
            this.menuStrip2.TabIndex = 11;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 20);
            this.toolStripMenuItem1.Text = "Metti in sviluppo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.btnCambiaStatoCicli_Click);
            // 
            // menucicliStatoCertificato
            // 
            this.menucicliStatoCertificato.Name = "menucicliStatoCertificato";
            this.menucicliStatoCertificato.Size = new System.Drawing.Size(118, 20);
            this.menucicliStatoCertificato.Text = "Metti in Certificato";
            this.menucicliStatoCertificato.Click += new System.EventHandler(this.btnCambiaStatoCicli_Click);
            // 
            // dgvEsportaCicli
            // 
            this.dgvEsportaCicli.AllowUserToAddRows = false;
            this.dgvEsportaCicli.AllowUserToDeleteRows = false;
            this.dgvEsportaCicli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaCicli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaCicli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selezionaCicliClm,
            this.dataGridViewTextBoxColumn1,
            this.codiceCicloClm,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvEsportaCicli.Location = new System.Drawing.Point(11, 34);
            this.dgvEsportaCicli.Name = "dgvEsportaCicli";
            this.dgvEsportaCicli.Size = new System.Drawing.Size(336, 265);
            this.dgvEsportaCicli.TabIndex = 10;
            // 
            // selezionaCicliClm
            // 
            this.selezionaCicliClm.DataPropertyName = "Selezionato";
            this.selezionaCicliClm.FillWeight = 60F;
            this.selezionaCicliClm.HeaderText = "Seleziona";
            this.selezionaCicliClm.Name = "selezionaCicliClm";
            this.selezionaCicliClm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selezionaCicliClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selezionaCicliClm.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Esito";
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Esito";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // codiceCicloClm
            // 
            this.codiceCicloClm.DataPropertyName = "Codice";
            this.codiceCicloClm.FillWeight = 130F;
            this.codiceCicloClm.HeaderText = "Ciclo";
            this.codiceCicloClm.Name = "codiceCicloClm";
            this.codiceCicloClm.ReadOnly = true;
            this.codiceCicloClm.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Stato";
            this.dataGridViewTextBoxColumn6.FillWeight = 70F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Stato";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Errore";
            this.dataGridViewTextBoxColumn7.FillWeight = 150F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Errore";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.dgvEsportaComponenti);
            this.panel1.Controls.Add(this.dgvEsportaDistinte);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 321);
            this.panel1.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mettiInSviluppoToolStripMenuItem,
            this.menuDistinteStatoCertificato});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1005, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mettiInSviluppoToolStripMenuItem
            // 
            this.mettiInSviluppoToolStripMenuItem.Name = "mettiInSviluppoToolStripMenuItem";
            this.mettiInSviluppoToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.mettiInSviluppoToolStripMenuItem.Text = "Metti in sviluppo";
            this.mettiInSviluppoToolStripMenuItem.Click += new System.EventHandler(this.btnCambiaStatoDistinte_Click);
            // 
            // menuDistinteStatoCertificato
            // 
            this.menuDistinteStatoCertificato.Name = "menuDistinteStatoCertificato";
            this.menuDistinteStatoCertificato.Size = new System.Drawing.Size(118, 20);
            this.menuDistinteStatoCertificato.Text = "Metti in Certificato";
            this.menuDistinteStatoCertificato.Click += new System.EventHandler(this.btnCambiaStatoDistinte_Click);
            // 
            // dgvEsportaDistinte
            // 
            this.dgvEsportaDistinte.AllowUserToAddRows = false;
            this.dgvEsportaDistinte.AllowUserToDeleteRows = false;
            this.dgvEsportaDistinte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaDistinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaDistinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selezionaDistintaClm,
            this.dataGridViewTextBoxColumn8,
            this.codiceDistintaClm,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13});
            this.dgvEsportaDistinte.Location = new System.Drawing.Point(8, 31);
            this.dgvEsportaDistinte.Name = "dgvEsportaDistinte";
            this.dgvEsportaDistinte.Size = new System.Drawing.Size(339, 283);
            this.dgvEsportaDistinte.TabIndex = 9;
            // 
            // selezionaDistintaClm
            // 
            this.selezionaDistintaClm.DataPropertyName = "Selezionato";
            this.selezionaDistintaClm.FillWeight = 60F;
            this.selezionaDistintaClm.HeaderText = "Seleziona";
            this.selezionaDistintaClm.Name = "selezionaDistintaClm";
            this.selezionaDistintaClm.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Esito";
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Esito";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // codiceDistintaClm
            // 
            this.codiceDistintaClm.DataPropertyName = "Codice";
            this.codiceDistintaClm.FillWeight = 130F;
            this.codiceDistintaClm.HeaderText = "Distinta";
            this.codiceDistintaClm.Name = "codiceDistintaClm";
            this.codiceDistintaClm.Width = 130;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Stato";
            this.dataGridViewTextBoxColumn11.FillWeight = 70F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Stato";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Errore";
            this.dataGridViewTextBoxColumn13.FillWeight = 150F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Errore";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // btnPulisciMessaggi
            // 
            this.btnPulisciMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPulisciMessaggi.Location = new System.Drawing.Point(1320, 200);
            this.btnPulisciMessaggi.Name = "btnPulisciMessaggi";
            this.btnPulisciMessaggi.Size = new System.Drawing.Size(75, 23);
            this.btnPulisciMessaggi.TabIndex = 18;
            this.btnPulisciMessaggi.Text = "Pulisci";
            this.btnPulisciMessaggi.UseVisualStyleBackColor = true;
            this.btnPulisciMessaggi.Click += new System.EventHandler(this.btnPulisciMessaggi_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1027, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Messaggi";
            // 
            // EsportaDiBaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 709);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EsportaDiBaFrm";
            this.Text = "Esporta distinte ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EsportaDiBaFrm_FormClosing);
            this.Load += new System.EventHandler(this.EsportaDiBaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaComponenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaFasi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaCicli)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaDistinte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrovaFileDistinte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileDistinte;
        private System.Windows.Forms.Button btnSalvaFileDistinte;
        private System.Windows.Forms.TextBox txtFileCicli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvaCicli;
        private System.Windows.Forms.Button btnTrovaFileCicli;
        private System.Windows.Forms.TextBox txtMessaggio;
        private System.Windows.Forms.DataGridView dgvEsportaComponenti;
        private System.Windows.Forms.DataGridView dgvEsportaFasi;
        private System.Windows.Forms.TextBox txtEsportazione;
        private System.Windows.Forms.ProgressBar pbEsportazione;
        private System.Windows.Forms.Button btnAvviaEsportazione;
        private System.Windows.Forms.Label lblElementi;
        private System.Windows.Forms.Label lblAvanzamento;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvEsportaDistinte;
        private System.Windows.Forms.DataGridView dgvEsportaCicli;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelezionaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsitoComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistintaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnagraficaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErroreComponentiClm;
        private System.Windows.Forms.Button btnPulisciMessaggi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelezionaFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsitoFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceCicloFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFAseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperazioneFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaProduzioneFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErroreFaseClm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selezionaDistintaClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDistintaClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selezionaCicliClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceCicloClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menucicliStatoCertificato;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mettiInSviluppoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDistinteStatoCertificato;
    }
}