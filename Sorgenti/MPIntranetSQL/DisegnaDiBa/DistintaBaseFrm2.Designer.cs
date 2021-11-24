namespace DisegnaDiBa
{
    partial class DistintaBaseFrm2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistintaBaseFrm2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.dgvFasiCiclo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.txtTipoDiba = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizioneDiba = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersioneDiba = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvComponenti = new System.Windows.Forms.DataGridView();
            this.clmIdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdPadreComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErroreComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdDibaComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescrizioneComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAnagraficaComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoDibaComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantitaComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUMQuantitaComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrSalvataggio = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAutosalvataggio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolApriDiBa = new System.Windows.Forms.ToolStripButton();
            this.toolNuovaDiBa = new System.Windows.Forms.ToolStripButton();
            this.toolSalvaDiba = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCancellaDiBa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCollegamento = new System.Windows.Forms.ToolStripButton();
            this.toolCreaDiBaProduzione = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolEsporta = new System.Windows.Forms.ToolStripButton();
            this.txtCodiceEsteso = new System.Windows.Forms.TextBox();
            this.clmIDFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdComponenteFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErroreFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdDibaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperazioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAnagraficaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantitaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUMQuantitaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTaskFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaProduzioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNotaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPezziOrariFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPeriodoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSchedaProcessoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoDiBAFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoCicloFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSetupFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttesaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMovimentazioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Location = new System.Drawing.Point(3, 73);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(684, 383);
            this.tvDiBa.TabIndex = 1;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
            // 
            // dgvFasiCiclo
            // 
            this.dgvFasiCiclo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFasiCiclo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFasiCiclo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIDFaseCiclo,
            this.clmIdComponenteFaseCiclo,
            this.clmErroreFaseCiclo,
            this.clmIdDibaFaseCiclo,
            this.clmOperazioneFaseCiclo,
            this.clmAnagraficaFaseCiclo,
            this.clmQuantitaFaseCiclo,
            this.clmUMQuantitaFaseCiclo,
            this.clmTaskFaseCiclo,
            this.clmAreaProduzioneFaseCiclo,
            this.clmNotaFaseCiclo,
            this.clmPezziOrariFaseCiclo,
            this.clmPeriodoFaseCiclo,
            this.clmSchedaProcessoFaseCiclo,
            this.clmCollegamentoDiBAFaseCiclo,
            this.clmCollegamentoCicloFaseCiclo,
            this.clmSetupFaseCiclo,
            this.clmAttesaFaseCiclo,
            this.clmMovimentazioneFaseCiclo});
            this.dgvFasiCiclo.Location = new System.Drawing.Point(3, 471);
            this.dgvFasiCiclo.Name = "dgvFasiCiclo";
            this.dgvFasiCiclo.Size = new System.Drawing.Size(1672, 469);
            this.dgvFasiCiclo.TabIndex = 5;
            this.dgvFasiCiclo.VirtualMode = true;
            this.dgvFasiCiclo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFasiCiclo_CellEndEdit);
            this.dgvFasiCiclo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFasiCiclo_DataError);
            this.dgvFasiCiclo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvNodi_EditingControlShowing);
            this.dgvFasiCiclo.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvFasiCiclo_NewRowNeeded);
            this.dgvFasiCiclo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvFasiCiclo_RowsAdded);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Articolo";
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(64, 35);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.ReadOnly = true;
            this.txtArticolo.Size = new System.Drawing.Size(204, 20);
            this.txtArticolo.TabIndex = 6;
            // 
            // txtTipoDiba
            // 
            this.txtTipoDiba.Location = new System.Drawing.Point(558, 35);
            this.txtTipoDiba.Name = "txtTipoDiba";
            this.txtTipoDiba.ReadOnly = true;
            this.txtTipoDiba.Size = new System.Drawing.Size(244, 20);
            this.txtTipoDiba.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // txtDescrizioneDiba
            // 
            this.txtDescrizioneDiba.Location = new System.Drawing.Point(1021, 35);
            this.txtDescrizioneDiba.MaxLength = 50;
            this.txtDescrizioneDiba.Name = "txtDescrizioneDiba";
            this.txtDescrizioneDiba.Size = new System.Drawing.Size(470, 20);
            this.txtDescrizioneDiba.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(954, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descrizione";
            // 
            // txtVersioneDiba
            // 
            this.txtVersioneDiba.Location = new System.Drawing.Point(870, 35);
            this.txtVersioneDiba.Name = "txtVersioneDiba";
            this.txtVersioneDiba.ReadOnly = true;
            this.txtVersioneDiba.Size = new System.Drawing.Size(73, 20);
            this.txtVersioneDiba.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(808, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Versione";
            // 
            // dgvComponenti
            // 
            this.dgvComponenti.AllowUserToAddRows = false;
            this.dgvComponenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComponenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdComponente,
            this.clmIdPadreComponente,
            this.clmErroreComponente,
            this.clmIdDibaComponente,
            this.clmDescrizioneComponente,
            this.clmAnagraficaComponente,
            this.clmCollegamentoDibaComponente,
            this.clmQuantitaComponente,
            this.clmUMQuantitaComponente});
            this.dgvComponenti.Location = new System.Drawing.Point(716, 73);
            this.dgvComponenti.Name = "dgvComponenti";
            this.dgvComponenti.Size = new System.Drawing.Size(959, 383);
            this.dgvComponenti.TabIndex = 21;
            this.dgvComponenti.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponenti_CellEndEdit);
            this.dgvComponenti.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponenti_CellValueChanged);
            this.dgvComponenti.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvComponenti_EditingControlShowing);
            this.dgvComponenti.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponenti_RowEnter);
            this.dgvComponenti.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponenti_RowLeave);
            // 
            // clmIdComponente
            // 
            this.clmIdComponente.DataPropertyName = "IdComponente";
            this.clmIdComponente.FillWeight = 50F;
            this.clmIdComponente.HeaderText = "ID";
            this.clmIdComponente.Name = "clmIdComponente";
            this.clmIdComponente.Width = 50;
            // 
            // clmIdPadreComponente
            // 
            this.clmIdPadreComponente.DataPropertyName = "IdPadre";
            this.clmIdPadreComponente.FillWeight = 50F;
            this.clmIdPadreComponente.HeaderText = "IdPadre";
            this.clmIdPadreComponente.Name = "clmIdPadreComponente";
            this.clmIdPadreComponente.Width = 50;
            // 
            // clmErroreComponente
            // 
            this.clmErroreComponente.DataPropertyName = "Errore";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.clmErroreComponente.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmErroreComponente.HeaderText = "Errore";
            this.clmErroreComponente.Name = "clmErroreComponente";
            this.clmErroreComponente.ReadOnly = true;
            // 
            // clmIdDibaComponente
            // 
            this.clmIdDibaComponente.DataPropertyName = "IdDiba";
            this.clmIdDibaComponente.HeaderText = "IdDiba";
            this.clmIdDibaComponente.Name = "clmIdDibaComponente";
            this.clmIdDibaComponente.Visible = false;
            // 
            // clmDescrizioneComponente
            // 
            this.clmDescrizioneComponente.DataPropertyName = "Descrizione";
            this.clmDescrizioneComponente.FillWeight = 150F;
            this.clmDescrizioneComponente.HeaderText = "Descrizione";
            this.clmDescrizioneComponente.MaxInputLength = 50;
            this.clmDescrizioneComponente.Name = "clmDescrizioneComponente";
            this.clmDescrizioneComponente.Width = 150;
            // 
            // clmAnagraficaComponente
            // 
            this.clmAnagraficaComponente.DataPropertyName = "Anagrafica";
            this.clmAnagraficaComponente.FillWeight = 130F;
            this.clmAnagraficaComponente.HeaderText = "Anagrafica";
            this.clmAnagraficaComponente.MaxInputLength = 20;
            this.clmAnagraficaComponente.Name = "clmAnagraficaComponente";
            this.clmAnagraficaComponente.Width = 130;
            // 
            // clmCollegamentoDibaComponente
            // 
            this.clmCollegamentoDibaComponente.DataPropertyName = "CollegamentoDiba";
            this.clmCollegamentoDibaComponente.HeaderText = "CollegamentoDiba";
            this.clmCollegamentoDibaComponente.MaxInputLength = 20;
            this.clmCollegamentoDibaComponente.Name = "clmCollegamentoDibaComponente";
            // 
            // clmQuantitaComponente
            // 
            this.clmQuantitaComponente.DataPropertyName = "Quantita";
            this.clmQuantitaComponente.FillWeight = 60F;
            this.clmQuantitaComponente.HeaderText = "Quantita";
            this.clmQuantitaComponente.Name = "clmQuantitaComponente";
            this.clmQuantitaComponente.Width = 60;
            // 
            // clmUMQuantitaComponente
            // 
            this.clmUMQuantitaComponente.DataPropertyName = "UMQuantita";
            this.clmUMQuantitaComponente.FillWeight = 70F;
            this.clmUMQuantitaComponente.HeaderText = "UMQuantita";
            this.clmUMQuantitaComponente.MaxInputLength = 10;
            this.clmUMQuantitaComponente.Name = "clmUMQuantitaComponente";
            this.clmUMQuantitaComponente.Width = 70;
            // 
            // tmrSalvataggio
            // 
            this.tmrSalvataggio.Interval = 600000;
            this.tmrSalvataggio.Tick += new System.EventHandler(this.tmrSalvataggio_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAutosalvataggio,
            this.toolStripSeparator1,
            this.toolApriDiBa,
            this.toolNuovaDiBa,
            this.toolSalvaDiba,
            this.toolStripSeparator4,
            this.toolCancellaDiBa,
            this.toolStripSeparator2,
            this.toolCollegamento,
            this.toolCreaDiBaProduzione,
            this.toolStripSeparator3,
            this.toolEsporta});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1694, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAutosalvataggio
            // 
            this.toolAutosalvataggio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAutosalvataggio.Enabled = false;
            this.toolAutosalvataggio.Image = ((System.Drawing.Image)(resources.GetObject("toolAutosalvataggio.Image")));
            this.toolAutosalvataggio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAutosalvataggio.Name = "toolAutosalvataggio";
            this.toolAutosalvataggio.Size = new System.Drawing.Size(97, 22);
            this.toolAutosalvataggio.Text = "Autosalvataggio";
            this.toolAutosalvataggio.Click += new System.EventHandler(this.toolAutosalvataggio_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolApriDiBa
            // 
            this.toolApriDiBa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolApriDiBa.Image = ((System.Drawing.Image)(resources.GetObject("toolApriDiBa.Image")));
            this.toolApriDiBa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolApriDiBa.Name = "toolApriDiBa";
            this.toolApriDiBa.Size = new System.Drawing.Size(60, 22);
            this.toolApriDiBa.Text = "Apri DiBa";
            this.toolApriDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // toolNuovaDiBa
            // 
            this.toolNuovaDiBa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolNuovaDiBa.Image = ((System.Drawing.Image)(resources.GetObject("toolNuovaDiBa.Image")));
            this.toolNuovaDiBa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNuovaDiBa.Name = "toolNuovaDiBa";
            this.toolNuovaDiBa.Size = new System.Drawing.Size(73, 22);
            this.toolNuovaDiBa.Text = "Nuova DiBa";
            this.toolNuovaDiBa.Click += new System.EventHandler(this.btnNuovaDistinta_Click);
            // 
            // toolSalvaDiba
            // 
            this.toolSalvaDiba.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSalvaDiba.Image = ((System.Drawing.Image)(resources.GetObject("toolSalvaDiba.Image")));
            this.toolSalvaDiba.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSalvaDiba.Name = "toolSalvaDiba";
            this.toolSalvaDiba.Size = new System.Drawing.Size(65, 22);
            this.toolSalvaDiba.Text = "Salva DiBa";
            this.toolSalvaDiba.Click += new System.EventHandler(this.btnSalvaDiba_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCancellaDiBa
            // 
            this.toolCancellaDiBa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCancellaDiBa.Image = ((System.Drawing.Image)(resources.GetObject("toolCancellaDiBa.Image")));
            this.toolCancellaDiBa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancellaDiBa.Name = "toolCancellaDiBa";
            this.toolCancellaDiBa.Size = new System.Drawing.Size(83, 22);
            this.toolCancellaDiBa.Text = "Cancella DiBa";
            this.toolCancellaDiBa.Click += new System.EventHandler(this.toolCancellaDiBa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCollegamento
            // 
            this.toolCollegamento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCollegamento.Image = ((System.Drawing.Image)(resources.GetObject("toolCollegamento.Image")));
            this.toolCollegamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCollegamento.Name = "toolCollegamento";
            this.toolCollegamento.Size = new System.Drawing.Size(169, 22);
            this.toolCollegamento.Text = "Imposta Codici Collegamento";
            this.toolCollegamento.Click += new System.EventHandler(this.toolCollegamento_Click);
            // 
            // toolCreaDiBaProduzione
            // 
            this.toolCreaDiBaProduzione.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCreaDiBaProduzione.Image = ((System.Drawing.Image)(resources.GetObject("toolCreaDiBaProduzione.Image")));
            this.toolCreaDiBaProduzione.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCreaDiBaProduzione.Name = "toolCreaDiBaProduzione";
            this.toolCreaDiBaProduzione.Size = new System.Drawing.Size(125, 22);
            this.toolCreaDiBaProduzione.Text = "Crea DiBa Produzione";
            this.toolCreaDiBaProduzione.Click += new System.EventHandler(this.toolCreaDiBaProduzione_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolEsporta
            // 
            this.toolEsporta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEsporta.Image = ((System.Drawing.Image)(resources.GetObject("toolEsporta.Image")));
            this.toolEsporta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEsporta.Name = "toolEsporta";
            this.toolEsporta.Size = new System.Drawing.Size(50, 22);
            this.toolEsporta.Text = "Esporta";
            this.toolEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
            // 
            // txtCodiceEsteso
            // 
            this.txtCodiceEsteso.Location = new System.Drawing.Point(274, 35);
            this.txtCodiceEsteso.Name = "txtCodiceEsteso";
            this.txtCodiceEsteso.ReadOnly = true;
            this.txtCodiceEsteso.Size = new System.Drawing.Size(229, 20);
            this.txtCodiceEsteso.TabIndex = 25;
            // 
            // clmIDFaseCiclo
            // 
            this.clmIDFaseCiclo.DataPropertyName = "IdFaseCiclo";
            this.clmIDFaseCiclo.FillWeight = 60F;
            this.clmIDFaseCiclo.HeaderText = "IdFaseCiclo";
            this.clmIDFaseCiclo.Name = "clmIDFaseCiclo";
            this.clmIDFaseCiclo.ReadOnly = true;
            this.clmIDFaseCiclo.Width = 60;
            // 
            // clmIdComponenteFaseCiclo
            // 
            this.clmIdComponenteFaseCiclo.DataPropertyName = "IdComponente";
            this.clmIdComponenteFaseCiclo.FillWeight = 60F;
            this.clmIdComponenteFaseCiclo.HeaderText = "IdComponente";
            this.clmIdComponenteFaseCiclo.Name = "clmIdComponenteFaseCiclo";
            this.clmIdComponenteFaseCiclo.ReadOnly = true;
            this.clmIdComponenteFaseCiclo.Width = 60;
            // 
            // clmErroreFaseCiclo
            // 
            this.clmErroreFaseCiclo.DataPropertyName = "Errore";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.clmErroreFaseCiclo.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmErroreFaseCiclo.FillWeight = 130F;
            this.clmErroreFaseCiclo.HeaderText = "Errore";
            this.clmErroreFaseCiclo.Name = "clmErroreFaseCiclo";
            this.clmErroreFaseCiclo.ReadOnly = true;
            this.clmErroreFaseCiclo.Width = 130;
            // 
            // clmIdDibaFaseCiclo
            // 
            this.clmIdDibaFaseCiclo.DataPropertyName = "IdDiba";
            this.clmIdDibaFaseCiclo.FillWeight = 60F;
            this.clmIdDibaFaseCiclo.HeaderText = "IdDiba";
            this.clmIdDibaFaseCiclo.Name = "clmIdDibaFaseCiclo";
            this.clmIdDibaFaseCiclo.Visible = false;
            this.clmIdDibaFaseCiclo.Width = 60;
            // 
            // clmOperazioneFaseCiclo
            // 
            this.clmOperazioneFaseCiclo.DataPropertyName = "Operazione";
            this.clmOperazioneFaseCiclo.FillWeight = 50F;
            this.clmOperazioneFaseCiclo.HeaderText = "Operazione";
            this.clmOperazioneFaseCiclo.Name = "clmOperazioneFaseCiclo";
            this.clmOperazioneFaseCiclo.Width = 50;
            // 
            // clmAnagraficaFaseCiclo
            // 
            this.clmAnagraficaFaseCiclo.DataPropertyName = "Anagrafica";
            this.clmAnagraficaFaseCiclo.FillWeight = 130F;
            this.clmAnagraficaFaseCiclo.HeaderText = "Anagrafica";
            this.clmAnagraficaFaseCiclo.Name = "clmAnagraficaFaseCiclo";
            this.clmAnagraficaFaseCiclo.Width = 130;
            // 
            // clmQuantitaFaseCiclo
            // 
            this.clmQuantitaFaseCiclo.DataPropertyName = "Quantita";
            this.clmQuantitaFaseCiclo.HeaderText = "Quantita";
            this.clmQuantitaFaseCiclo.Name = "clmQuantitaFaseCiclo";
            // 
            // clmUMQuantitaFaseCiclo
            // 
            this.clmUMQuantitaFaseCiclo.DataPropertyName = "UMQuantita";
            this.clmUMQuantitaFaseCiclo.FillWeight = 70F;
            this.clmUMQuantitaFaseCiclo.HeaderText = "UM";
            this.clmUMQuantitaFaseCiclo.Name = "clmUMQuantitaFaseCiclo";
            this.clmUMQuantitaFaseCiclo.Width = 70;
            // 
            // clmTaskFaseCiclo
            // 
            this.clmTaskFaseCiclo.DataPropertyName = "Task";
            this.clmTaskFaseCiclo.FillWeight = 70F;
            this.clmTaskFaseCiclo.HeaderText = "Task";
            this.clmTaskFaseCiclo.Name = "clmTaskFaseCiclo";
            this.clmTaskFaseCiclo.Width = 70;
            // 
            // clmAreaProduzioneFaseCiclo
            // 
            this.clmAreaProduzioneFaseCiclo.DataPropertyName = "AreaProduzione";
            this.clmAreaProduzioneFaseCiclo.HeaderText = "Area Produzione";
            this.clmAreaProduzioneFaseCiclo.Name = "clmAreaProduzioneFaseCiclo";
            // 
            // clmNotaFaseCiclo
            // 
            this.clmNotaFaseCiclo.DataPropertyName = "Nota";
            this.clmNotaFaseCiclo.FillWeight = 200F;
            this.clmNotaFaseCiclo.HeaderText = "Nota";
            this.clmNotaFaseCiclo.MaxInputLength = 150;
            this.clmNotaFaseCiclo.Name = "clmNotaFaseCiclo";
            this.clmNotaFaseCiclo.Width = 200;
            // 
            // clmPezziOrariFaseCiclo
            // 
            this.clmPezziOrariFaseCiclo.DataPropertyName = "PezziPeriodo";
            this.clmPezziOrariFaseCiclo.FillWeight = 60F;
            this.clmPezziOrariFaseCiclo.HeaderText = "Pezzi Periodo";
            this.clmPezziOrariFaseCiclo.Name = "clmPezziOrariFaseCiclo";
            this.clmPezziOrariFaseCiclo.Width = 60;
            // 
            // clmPeriodoFaseCiclo
            // 
            this.clmPeriodoFaseCiclo.DataPropertyName = "Periodo";
            this.clmPeriodoFaseCiclo.FillWeight = 60F;
            this.clmPeriodoFaseCiclo.HeaderText = "Periodo";
            this.clmPeriodoFaseCiclo.Name = "clmPeriodoFaseCiclo";
            this.clmPeriodoFaseCiclo.Width = 60;
            // 
            // clmSchedaProcessoFaseCiclo
            // 
            this.clmSchedaProcessoFaseCiclo.DataPropertyName = "SchedaProcesso";
            this.clmSchedaProcessoFaseCiclo.HeaderText = "SchedaProcesso";
            this.clmSchedaProcessoFaseCiclo.Name = "clmSchedaProcessoFaseCiclo";
            // 
            // clmCollegamentoDiBAFaseCiclo
            // 
            this.clmCollegamentoDiBAFaseCiclo.DataPropertyName = "CollegamentoDiBa";
            this.clmCollegamentoDiBAFaseCiclo.HeaderText = "Collegamento DiBa";
            this.clmCollegamentoDiBAFaseCiclo.Name = "clmCollegamentoDiBAFaseCiclo";
            // 
            // clmCollegamentoCicloFaseCiclo
            // 
            this.clmCollegamentoCicloFaseCiclo.DataPropertyName = "CollegamentoCiclo";
            this.clmCollegamentoCicloFaseCiclo.HeaderText = "CollegamentoCiclo";
            this.clmCollegamentoCicloFaseCiclo.Name = "clmCollegamentoCicloFaseCiclo";
            // 
            // clmSetupFaseCiclo
            // 
            this.clmSetupFaseCiclo.DataPropertyName = "Setup";
            this.clmSetupFaseCiclo.FillWeight = 60F;
            this.clmSetupFaseCiclo.HeaderText = "Setup";
            this.clmSetupFaseCiclo.Name = "clmSetupFaseCiclo";
            this.clmSetupFaseCiclo.Width = 60;
            // 
            // clmAttesaFaseCiclo
            // 
            this.clmAttesaFaseCiclo.DataPropertyName = "Attesa";
            this.clmAttesaFaseCiclo.FillWeight = 60F;
            this.clmAttesaFaseCiclo.HeaderText = "Attesa";
            this.clmAttesaFaseCiclo.Name = "clmAttesaFaseCiclo";
            this.clmAttesaFaseCiclo.Width = 60;
            // 
            // clmMovimentazioneFaseCiclo
            // 
            this.clmMovimentazioneFaseCiclo.DataPropertyName = "Movimentazione";
            this.clmMovimentazioneFaseCiclo.HeaderText = "Movimentazione";
            this.clmMovimentazioneFaseCiclo.Name = "clmMovimentazioneFaseCiclo";
            // 
            // DistintaBaseFrm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1694, 954);
            this.Controls.Add(this.txtCodiceEsteso);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvFasiCiclo);
            this.Controls.Add(this.dgvComponenti);
            this.Controls.Add(this.txtVersioneDiba);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescrizioneDiba);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTipoDiba);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.tvDiBa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistintaBaseFrm2";
            this.Text = "DIstintaBaseFrm";
            this.Load += new System.EventHandler(this.DistintaBaseFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.DataGridView dgvFasiCiclo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.TextBox txtTipoDiba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizioneDiba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersioneDiba;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvComponenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdPadreComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErroreComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdDibaComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescrizioneComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAnagraficaComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoDibaComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantitaComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUMQuantitaComponente;
        private System.Windows.Forms.Timer tmrSalvataggio;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAutosalvataggio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolApriDiBa;
        private System.Windows.Forms.ToolStripButton toolNuovaDiBa;
        private System.Windows.Forms.ToolStripButton toolSalvaDiba;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolEsporta;
        private System.Windows.Forms.ToolStripButton toolCollegamento;
        private System.Windows.Forms.ToolStripButton toolCreaDiBaProduzione;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox txtCodiceEsteso;
        private System.Windows.Forms.ToolStripButton toolCancellaDiBa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdComponenteFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErroreFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdDibaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperazioneFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAnagraficaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantitaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUMQuantitaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTaskFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaProduzioneFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNotaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPezziOrariFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPeriodoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSchedaProcessoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoDiBAFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoCicloFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSetupFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttesaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMovimentazioneFaseCiclo;
    }
}