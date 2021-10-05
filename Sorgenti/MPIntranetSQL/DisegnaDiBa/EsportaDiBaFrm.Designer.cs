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
            this.SelezionatoFaseClm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.btnPulisciMessaggi = new System.Windows.Forms.Button();
            this.dgvEsportaDistinte = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEsportaCicli = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaComponenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaFasi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaDistinte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaCicli)).BeginInit();
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
            this.dgvEsportaComponenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaComponenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaComponenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelezionaComponentiClm,
            this.EsitoComponentiClm,
            this.IDComponentiClm,
            this.DistintaComponentiClm,
            this.AnagraficaComponentiClm,
            this.ErroreComponentiClm});
            this.dgvEsportaComponenti.Location = new System.Drawing.Point(528, 26);
            this.dgvEsportaComponenti.Name = "dgvEsportaComponenti";
            this.dgvEsportaComponenti.ReadOnly = true;
            this.dgvEsportaComponenti.Size = new System.Drawing.Size(528, 322);
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
            this.dgvEsportaFasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEsportaFasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaFasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelezionatoFaseClm,
            this.EsitoFaseClm,
            this.CodiceCicloFaseClm,
            this.IDFAseClm,
            this.OperazioneFaseClm,
            this.AreaProduzioneFaseClm,
            this.TaskFaseClm,
            this.ErroreFaseClm});
            this.dgvEsportaFasi.Location = new System.Drawing.Point(529, 373);
            this.dgvEsportaFasi.Name = "dgvEsportaFasi";
            this.dgvEsportaFasi.ReadOnly = true;
            this.dgvEsportaFasi.Size = new System.Drawing.Size(527, 322);
            this.dgvEsportaFasi.TabIndex = 10;
            // 
            // SelezionatoFaseClm
            // 
            this.SelezionatoFaseClm.DataPropertyName = "Selezionato";
            this.SelezionatoFaseClm.HeaderText = "Seleziona";
            this.SelezionatoFaseClm.Name = "SelezionatoFaseClm";
            this.SelezionatoFaseClm.ReadOnly = true;
            this.SelezionatoFaseClm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelezionatoFaseClm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelezionatoFaseClm.Visible = false;
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
            this.txtEsportazione.Location = new System.Drawing.Point(1104, 220);
            this.txtEsportazione.Multiline = true;
            this.txtEsportazione.Name = "txtEsportazione";
            this.txtEsportazione.ReadOnly = true;
            this.txtEsportazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEsportazione.Size = new System.Drawing.Size(249, 481);
            this.txtEsportazione.TabIndex = 14;
            // 
            // pbEsportazione
            // 
            this.pbEsportazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEsportazione.Location = new System.Drawing.Point(1102, 159);
            this.pbEsportazione.Name = "pbEsportazione";
            this.pbEsportazione.Size = new System.Drawing.Size(249, 23);
            this.pbEsportazione.TabIndex = 15;
            // 
            // btnAvviaEsportazione
            // 
            this.btnAvviaEsportazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvviaEsportazione.Location = new System.Drawing.Point(1102, 83);
            this.btnAvviaEsportazione.Name = "btnAvviaEsportazione";
            this.btnAvviaEsportazione.Size = new System.Drawing.Size(249, 37);
            this.btnAvviaEsportazione.TabIndex = 16;
            this.btnAvviaEsportazione.Text = "Esporta";
            this.btnAvviaEsportazione.UseVisualStyleBackColor = true;
            this.btnAvviaEsportazione.Click += new System.EventHandler(this.btnAvviaEsportazione_Click);
            // 
            // lblElementi
            // 
            this.lblElementi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElementi.AutoSize = true;
            this.lblElementi.Location = new System.Drawing.Point(1316, 143);
            this.lblElementi.Name = "lblElementi";
            this.lblElementi.Size = new System.Drawing.Size(35, 13);
            this.lblElementi.TabIndex = 17;
            this.lblElementi.Text = "label3";
            // 
            // lblAvanzamento
            // 
            this.lblAvanzamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvanzamento.AutoSize = true;
            this.lblAvanzamento.Location = new System.Drawing.Point(1206, 143);
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
            this.tabControl1.Size = new System.Drawing.Size(1413, 779);
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
            this.tabPage1.Size = new System.Drawing.Size(1405, 753);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FIle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPulisciMessaggi);
            this.tabPage2.Controls.Add(this.dgvEsportaDistinte);
            this.tabPage2.Controls.Add(this.dgvEsportaComponenti);
            this.tabPage2.Controls.Add(this.dgvEsportaCicli);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblAvanzamento);
            this.tabPage2.Controls.Add(this.dgvEsportaFasi);
            this.tabPage2.Controls.Add(this.lblElementi);
            this.tabPage2.Controls.Add(this.btnAvviaEsportazione);
            this.tabPage2.Controls.Add(this.pbEsportazione);
            this.tabPage2.Controls.Add(this.txtEsportazione);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1405, 753);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servizi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPulisciMessaggi
            // 
            this.btnPulisciMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPulisciMessaggi.Location = new System.Drawing.Point(1179, 707);
            this.btnPulisciMessaggi.Name = "btnPulisciMessaggi";
            this.btnPulisciMessaggi.Size = new System.Drawing.Size(75, 23);
            this.btnPulisciMessaggi.TabIndex = 18;
            this.btnPulisciMessaggi.Text = "Pulisci";
            this.btnPulisciMessaggi.UseVisualStyleBackColor = true;
            this.btnPulisciMessaggi.Click += new System.EventHandler(this.btnPulisciMessaggi_Click);
            // 
            // dgvEsportaDistinte
            // 
            this.dgvEsportaDistinte.AllowUserToAddRows = false;
            this.dgvEsportaDistinte.AllowUserToDeleteRows = false;
            this.dgvEsportaDistinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaDistinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13});
            this.dgvEsportaDistinte.Location = new System.Drawing.Point(15, 26);
            this.dgvEsportaDistinte.Name = "dgvEsportaDistinte";
            this.dgvEsportaDistinte.Size = new System.Drawing.Size(489, 322);
            this.dgvEsportaDistinte.TabIndex = 9;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Selezionato";
            this.dataGridViewCheckBoxColumn2.FillWeight = 60F;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Seleziona";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Esito";
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Esito";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Codice";
            this.dataGridViewTextBoxColumn10.FillWeight = 130F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Distinta";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 130;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Stato";
            this.dataGridViewTextBoxColumn11.FillWeight = 50F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Stato";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Errore";
            this.dataGridViewTextBoxColumn13.FillWeight = 150F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Errore";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // dgvEsportaCicli
            // 
            this.dgvEsportaCicli.AllowUserToAddRows = false;
            this.dgvEsportaCicli.AllowUserToDeleteRows = false;
            this.dgvEsportaCicli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvEsportaCicli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEsportaCicli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvEsportaCicli.Location = new System.Drawing.Point(16, 373);
            this.dgvEsportaCicli.Name = "dgvEsportaCicli";
            this.dgvEsportaCicli.Size = new System.Drawing.Size(486, 322);
            this.dgvEsportaCicli.TabIndex = 10;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Selezionato";
            this.dataGridViewCheckBoxColumn1.FillWeight = 60F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Seleziona";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Esito";
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Esito";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Codice";
            this.dataGridViewTextBoxColumn2.FillWeight = 130F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Ciclo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Stato";
            this.dataGridViewTextBoxColumn6.FillWeight = 50F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Stato";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Errore";
            this.dataGridViewTextBoxColumn7.FillWeight = 150F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Errore";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1101, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Messaggi";
            // 
            // EsportaDiBaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 779);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaDistinte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsportaCicli)).EndInit();
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelezionaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsitoComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistintaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnagraficaComponentiClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErroreComponentiClm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelezionatoFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsitoFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceCicloFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFAseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperazioneFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaProduzioneFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskFaseClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErroreFaseClm;
        private System.Windows.Forms.Button btnPulisciMessaggi;
        private System.Windows.Forms.Label label3;
    }
}