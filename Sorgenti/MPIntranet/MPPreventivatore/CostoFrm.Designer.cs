namespace MPPreventivatore
{
    partial class CostoFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prodottoFinitoUC1 = new MPPreventivatore.ProdottoFinitoUC();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotaPrevetivoCosto = new System.Windows.Forms.TextBox();
            this.txtNotaPreventivo = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.ddlPreventivoCosto = new System.Windows.Forms.ComboBox();
            this.btnCreaNuovaVersione = new System.Windows.Forms.Button();
            this.ddlPreventivi = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgvElementi = new System.Windows.Forms.DataGridView();
            this.IdElementoCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncludiPreventivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Articolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reparto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gruppo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Superficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PezziOrari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ricarico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoArticolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoFigli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTotali = new System.Windows.Forms.TabPage();
            this.nuPrezzoProdottoFinito = new System.Windows.Forms.NumericUpDown();
            this.nuCostoProdottoFinito = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCostoProdottoFinito = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotaliCostiFissiPrezo = new System.Windows.Forms.TextBox();
            this.txtMargineProdottoFinito = new System.Windows.Forms.TextBox();
            this.txtTotaliCostiFissiMargine = new System.Windows.Forms.TextBox();
            this.txtTotaliCostiFissiCosto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabDettaglio = new System.Windows.Forms.TabPage();
            this.tabGalvanica = new System.Windows.Forms.TabPage();
            this.txtProcessoGalvanico = new System.Windows.Forms.TextBox();
            this.dgvProcessoGalvanico = new System.Windows.Forms.DataGridView();
            this.Vasca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreNominale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreMassimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.tabCostiFissi = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostiFissiPrezzo = new System.Windows.Forms.TextBox();
            this.txtCostiFissiRicarico = new System.Windows.Forms.TextBox();
            this.txtCostiFissiCosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAggiorna_costiFissi = new System.Windows.Forms.Button();
            this.dgvCostiFissi = new System.Windows.Forms.DataGridView();
            this.IdCostoFissoPreventivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceCostoFisso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescrizioneCostoFisso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RicaricoCostoFisso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoCostoFisso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressoCostoFisso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstCostiFissi = new MPPreventivatore.DraggableListbox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCostiGalvanica = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabTotali.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPrezzoProdottoFinito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCostoProdottoFinito)).BeginInit();
            this.tabDettaglio.SuspendLayout();
            this.tabGalvanica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessoGalvanico)).BeginInit();
            this.tabCostiFissi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiGalvanica)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.prodottoFinitoUC1);
            this.groupBox1.Location = new System.Drawing.Point(593, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prodotto finito";
            // 
            // prodottoFinitoUC1
            // 
            this.prodottoFinitoUC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prodottoFinitoUC1.Location = new System.Drawing.Point(6, 17);
            this.prodottoFinitoUC1.Name = "prodottoFinitoUC1";
            this.prodottoFinitoUC1.Size = new System.Drawing.Size(767, 157);
            this.prodottoFinitoUC1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNotaPrevetivoCosto);
            this.groupBox2.Controls.Add(this.txtNotaPreventivo);
            this.groupBox2.Controls.Add(this.btnSalva);
            this.groupBox2.Controls.Add(this.ddlPreventivoCosto);
            this.groupBox2.Controls.Add(this.btnCreaNuovaVersione);
            this.groupBox2.Controls.Add(this.ddlPreventivi);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 206);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preventivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nota versione costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Versione costo";
            // 
            // txtNotaPrevetivoCosto
            // 
            this.txtNotaPrevetivoCosto.Location = new System.Drawing.Point(6, 156);
            this.txtNotaPrevetivoCosto.MaxLength = 200;
            this.txtNotaPrevetivoCosto.Multiline = true;
            this.txtNotaPrevetivoCosto.Name = "txtNotaPrevetivoCosto";
            this.txtNotaPrevetivoCosto.Size = new System.Drawing.Size(376, 43);
            this.txtNotaPrevetivoCosto.TabIndex = 2;
            // 
            // txtNotaPreventivo
            // 
            this.txtNotaPreventivo.Location = new System.Drawing.Point(6, 45);
            this.txtNotaPreventivo.MaxLength = 100;
            this.txtNotaPreventivo.Multiline = true;
            this.txtNotaPreventivo.Name = "txtNotaPreventivo";
            this.txtNotaPreventivo.ReadOnly = true;
            this.txtNotaPreventivo.Size = new System.Drawing.Size(376, 43);
            this.txtNotaPreventivo.TabIndex = 2;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(412, 166);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(141, 33);
            this.btnSalva.TabIndex = 1;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // ddlPreventivoCosto
            // 
            this.ddlPreventivoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPreventivoCosto.FormattingEnabled = true;
            this.ddlPreventivoCosto.Location = new System.Drawing.Point(6, 110);
            this.ddlPreventivoCosto.Name = "ddlPreventivoCosto";
            this.ddlPreventivoCosto.Size = new System.Drawing.Size(376, 23);
            this.ddlPreventivoCosto.TabIndex = 0;
            this.ddlPreventivoCosto.SelectedIndexChanged += new System.EventHandler(this.ddlPreventivoCosto_SelectedIndexChanged);
            // 
            // btnCreaNuovaVersione
            // 
            this.btnCreaNuovaVersione.Location = new System.Drawing.Point(412, 106);
            this.btnCreaNuovaVersione.Name = "btnCreaNuovaVersione";
            this.btnCreaNuovaVersione.Size = new System.Drawing.Size(141, 33);
            this.btnCreaNuovaVersione.TabIndex = 1;
            this.btnCreaNuovaVersione.Text = "Crea nuova versione";
            this.btnCreaNuovaVersione.UseVisualStyleBackColor = true;
            this.btnCreaNuovaVersione.Click += new System.EventHandler(this.btnCreaNuovaVersione_Click);
            // 
            // ddlPreventivi
            // 
            this.ddlPreventivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPreventivi.FormattingEnabled = true;
            this.ddlPreventivi.Location = new System.Drawing.Point(6, 20);
            this.ddlPreventivi.Name = "ddlPreventivi";
            this.ddlPreventivi.Size = new System.Drawing.Size(376, 23);
            this.ddlPreventivi.TabIndex = 0;
            this.ddlPreventivi.SelectedIndexChanged += new System.EventHandler(this.ddlPreventivi_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(12, 224);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(446, 415);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // dgvElementi
            // 
            this.dgvElementi.AllowUserToAddRows = false;
            this.dgvElementi.AllowUserToDeleteRows = false;
            this.dgvElementi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElementi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdElementoCosto,
            this.IncludiPreventivo,
            this.Articolo,
            this.Codice,
            this.Descrizione,
            this.Reparto,
            this.Gruppo,
            this.Peso,
            this.Superficie,
            this.Quantita,
            this.PezziOrari,
            this.Costo,
            this.Ricarico,
            this.colCostoArticolo,
            this.colCostoFigli,
            this.colCostoCompleto});
            this.dgvElementi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElementi.Location = new System.Drawing.Point(3, 3);
            this.dgvElementi.MultiSelect = false;
            this.dgvElementi.Name = "dgvElementi";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElementi.Size = new System.Drawing.Size(894, 387);
            this.dgvElementi.TabIndex = 9;
            this.dgvElementi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellClick);
            this.dgvElementi.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellValidated);
            this.dgvElementi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvElementi_EditingControlShowing);
            this.dgvElementi.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvElementi_RowPrePaint);
            // 
            // IdElementoCosto
            // 
            this.IdElementoCosto.DataPropertyName = "IdElementoCosto";
            this.IdElementoCosto.Frozen = true;
            this.IdElementoCosto.HeaderText = "IdElementoCosto";
            this.IdElementoCosto.Name = "IdElementoCosto";
            this.IdElementoCosto.Visible = false;
            // 
            // IncludiPreventivo
            // 
            this.IncludiPreventivo.DataPropertyName = "IncludiPreventivo";
            this.IncludiPreventivo.Frozen = true;
            this.IncludiPreventivo.HeaderText = "Includi";
            this.IncludiPreventivo.Name = "IncludiPreventivo";
            // 
            // Articolo
            // 
            this.Articolo.DataPropertyName = "ElementoPreventivo.Articolo";
            this.Articolo.Frozen = true;
            this.Articolo.HeaderText = "Articolo";
            this.Articolo.MaxInputLength = 30;
            this.Articolo.Name = "Articolo";
            this.Articolo.ReadOnly = true;
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "ElementoPreventivo.Codice";
            this.Codice.Frozen = true;
            this.Codice.HeaderText = "Codice";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "ElementoPreventivo.Descrizione";
            this.Descrizione.Frozen = true;
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            // 
            // Reparto
            // 
            this.Reparto.DataPropertyName = "ElementoPreventivo.Reparto";
            this.Reparto.Frozen = true;
            this.Reparto.HeaderText = "Reparto";
            this.Reparto.Name = "Reparto";
            this.Reparto.ReadOnly = true;
            // 
            // Gruppo
            // 
            this.Gruppo.HeaderText = "ElementoPreventivo.Gruppo";
            this.Gruppo.Name = "Gruppo";
            this.Gruppo.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "ElementoPreventivo.Peso";
            this.Peso.FillWeight = 80F;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            this.Peso.Width = 80;
            // 
            // Superficie
            // 
            this.Superficie.DataPropertyName = "ElementoPreventivo.Superficie";
            this.Superficie.FillWeight = 80F;
            this.Superficie.HeaderText = "Superficie";
            this.Superficie.Name = "Superficie";
            this.Superficie.ReadOnly = true;
            this.Superficie.Width = 80;
            // 
            // Quantita
            // 
            this.Quantita.DataPropertyName = "ElementoPreventivo.Quantita";
            this.Quantita.FillWeight = 80F;
            this.Quantita.HeaderText = "Quantità";
            this.Quantita.Name = "Quantita";
            this.Quantita.ReadOnly = true;
            this.Quantita.Width = 80;
            // 
            // PezziOrari
            // 
            this.PezziOrari.DataPropertyName = "PezziOrari";
            this.PezziOrari.FillWeight = 80F;
            this.PezziOrari.HeaderText = "Pezzi orari";
            this.PezziOrari.Name = "PezziOrari";
            this.PezziOrari.Width = 80;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "CostoOrario";
            this.Costo.HeaderText = "CostoHH";
            this.Costo.Name = "Costo";
            // 
            // Ricarico
            // 
            this.Ricarico.DataPropertyName = "Ricarico";
            this.Ricarico.HeaderText = "Ricarico";
            this.Ricarico.Name = "Ricarico";
            // 
            // colCostoArticolo
            // 
            this.colCostoArticolo.DataPropertyName = "CostoArticolo";
            this.colCostoArticolo.HeaderText = "Costo articolo";
            this.colCostoArticolo.Name = "colCostoArticolo";
            // 
            // colCostoFigli
            // 
            this.colCostoFigli.DataPropertyName = "CostoFigli";
            this.colCostoFigli.HeaderText = "Costo figli";
            this.colCostoFigli.Name = "colCostoFigli";
            // 
            // colCostoCompleto
            // 
            this.colCostoCompleto.DataPropertyName = "CostoCompleto";
            this.colCostoCompleto.HeaderText = "Costo completo";
            this.colCostoCompleto.Name = "colCostoCompleto";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabTotali);
            this.tabControl1.Controls.Add(this.tabDettaglio);
            this.tabControl1.Controls.Add(this.tabGalvanica);
            this.tabControl1.Controls.Add(this.tabCostiFissi);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(464, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 421);
            this.tabControl1.TabIndex = 10;
            // 
            // tabTotali
            // 
            this.tabTotali.Controls.Add(this.nuPrezzoProdottoFinito);
            this.tabTotali.Controls.Add(this.nuCostoProdottoFinito);
            this.tabTotali.Controls.Add(this.label14);
            this.tabTotali.Controls.Add(this.label15);
            this.tabTotali.Controls.Add(this.label16);
            this.tabTotali.Controls.Add(this.label17);
            this.tabTotali.Controls.Add(this.label12);
            this.tabTotali.Controls.Add(this.txtCostoProdottoFinito);
            this.tabTotali.Controls.Add(this.label13);
            this.tabTotali.Controls.Add(this.label7);
            this.tabTotali.Controls.Add(this.label8);
            this.tabTotali.Controls.Add(this.label9);
            this.tabTotali.Controls.Add(this.txtTotaliCostiFissiPrezo);
            this.tabTotali.Controls.Add(this.txtMargineProdottoFinito);
            this.tabTotali.Controls.Add(this.txtTotaliCostiFissiMargine);
            this.tabTotali.Controls.Add(this.txtTotaliCostiFissiCosto);
            this.tabTotali.Controls.Add(this.label10);
            this.tabTotali.Location = new System.Drawing.Point(4, 24);
            this.tabTotali.Name = "tabTotali";
            this.tabTotali.Padding = new System.Windows.Forms.Padding(3);
            this.tabTotali.Size = new System.Drawing.Size(900, 393);
            this.tabTotali.TabIndex = 3;
            this.tabTotali.Text = "Totali";
            this.tabTotali.UseVisualStyleBackColor = true;
            // 
            // nuPrezzoProdottoFinito
            // 
            this.nuPrezzoProdottoFinito.Location = new System.Drawing.Point(276, 163);
            this.nuPrezzoProdottoFinito.Name = "nuPrezzoProdottoFinito";
            this.nuPrezzoProdottoFinito.Size = new System.Drawing.Size(100, 21);
            this.nuPrezzoProdottoFinito.TabIndex = 27;
            this.nuPrezzoProdottoFinito.ValueChanged += new System.EventHandler(this.nuCostoProdottoFinito_ValueChanged);
            // 
            // nuCostoProdottoFinito
            // 
            this.nuCostoProdottoFinito.Location = new System.Drawing.Point(167, 163);
            this.nuCostoProdottoFinito.Name = "nuCostoProdottoFinito";
            this.nuCostoProdottoFinito.Size = new System.Drawing.Size(100, 21);
            this.nuCostoProdottoFinito.TabIndex = 26;
            this.nuCostoProdottoFinito.ValueChanged += new System.EventHandler(this.nuCostoProdottoFinito_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(383, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 25;
            this.label14.Text = "Margine";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(277, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "Prezzo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(168, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "Costo";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(31, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 15);
            this.label17.TabIndex = 19;
            this.label17.Text = "Totali costi fissi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(168, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Costo";
            // 
            // txtCostoProdottoFinito
            // 
            this.txtCostoProdottoFinito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoProdottoFinito.Location = new System.Drawing.Point(167, 99);
            this.txtCostoProdottoFinito.Name = "txtCostoProdottoFinito";
            this.txtCostoProdottoFinito.ReadOnly = true;
            this.txtCostoProdottoFinito.Size = new System.Drawing.Size(100, 21);
            this.txtCostoProdottoFinito.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(31, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 16;
            this.label13.Text = "Prodotto finito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(383, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Margine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(277, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Prezzo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(168, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Costo";
            // 
            // txtTotaliCostiFissiPrezo
            // 
            this.txtTotaliCostiFissiPrezo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotaliCostiFissiPrezo.Location = new System.Drawing.Point(276, 44);
            this.txtTotaliCostiFissiPrezo.Name = "txtTotaliCostiFissiPrezo";
            this.txtTotaliCostiFissiPrezo.ReadOnly = true;
            this.txtTotaliCostiFissiPrezo.Size = new System.Drawing.Size(100, 21);
            this.txtTotaliCostiFissiPrezo.TabIndex = 10;
            // 
            // txtMargineProdottoFinito
            // 
            this.txtMargineProdottoFinito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMargineProdottoFinito.Location = new System.Drawing.Point(386, 162);
            this.txtMargineProdottoFinito.Name = "txtMargineProdottoFinito";
            this.txtMargineProdottoFinito.ReadOnly = true;
            this.txtMargineProdottoFinito.Size = new System.Drawing.Size(100, 21);
            this.txtMargineProdottoFinito.TabIndex = 11;
            // 
            // txtTotaliCostiFissiMargine
            // 
            this.txtTotaliCostiFissiMargine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotaliCostiFissiMargine.Location = new System.Drawing.Point(382, 44);
            this.txtTotaliCostiFissiMargine.Name = "txtTotaliCostiFissiMargine";
            this.txtTotaliCostiFissiMargine.ReadOnly = true;
            this.txtTotaliCostiFissiMargine.Size = new System.Drawing.Size(100, 21);
            this.txtTotaliCostiFissiMargine.TabIndex = 11;
            // 
            // txtTotaliCostiFissiCosto
            // 
            this.txtTotaliCostiFissiCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotaliCostiFissiCosto.Location = new System.Drawing.Point(167, 44);
            this.txtTotaliCostiFissiCosto.Name = "txtTotaliCostiFissiCosto";
            this.txtTotaliCostiFissiCosto.ReadOnly = true;
            this.txtTotaliCostiFissiCosto.Size = new System.Drawing.Size(100, 21);
            this.txtTotaliCostiFissiCosto.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Totali costi fissi";
            // 
            // tabDettaglio
            // 
            this.tabDettaglio.Controls.Add(this.dgvElementi);
            this.tabDettaglio.Location = new System.Drawing.Point(4, 24);
            this.tabDettaglio.Name = "tabDettaglio";
            this.tabDettaglio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettaglio.Size = new System.Drawing.Size(900, 393);
            this.tabDettaglio.TabIndex = 0;
            this.tabDettaglio.Text = "Dettaglio elementi";
            this.tabDettaglio.UseVisualStyleBackColor = true;
            // 
            // tabGalvanica
            // 
            this.tabGalvanica.Controls.Add(this.txtProcessoGalvanico);
            this.tabGalvanica.Controls.Add(this.dgvProcessoGalvanico);
            this.tabGalvanica.Controls.Add(this.label11);
            this.tabGalvanica.Location = new System.Drawing.Point(4, 24);
            this.tabGalvanica.Name = "tabGalvanica";
            this.tabGalvanica.Padding = new System.Windows.Forms.Padding(3);
            this.tabGalvanica.Size = new System.Drawing.Size(900, 393);
            this.tabGalvanica.TabIndex = 1;
            this.tabGalvanica.Text = "Dettaglio processo galvanico";
            this.tabGalvanica.UseVisualStyleBackColor = true;
            // 
            // txtProcessoGalvanico
            // 
            this.txtProcessoGalvanico.Location = new System.Drawing.Point(6, 23);
            this.txtProcessoGalvanico.Name = "txtProcessoGalvanico";
            this.txtProcessoGalvanico.ReadOnly = true;
            this.txtProcessoGalvanico.Size = new System.Drawing.Size(247, 21);
            this.txtProcessoGalvanico.TabIndex = 16;
            // 
            // dgvProcessoGalvanico
            // 
            this.dgvProcessoGalvanico.AllowUserToAddRows = false;
            this.dgvProcessoGalvanico.AllowUserToDeleteRows = false;
            this.dgvProcessoGalvanico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcessoGalvanico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessoGalvanico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vasca,
            this.Materiale,
            this.SpessoreMinimo,
            this.SpessoreNominale,
            this.SpessoreMassimo});
            this.dgvProcessoGalvanico.Location = new System.Drawing.Point(295, 5);
            this.dgvProcessoGalvanico.Name = "dgvProcessoGalvanico";
            this.dgvProcessoGalvanico.ReadOnly = true;
            this.dgvProcessoGalvanico.Size = new System.Drawing.Size(595, 383);
            this.dgvProcessoGalvanico.TabIndex = 15;
            // 
            // Vasca
            // 
            this.Vasca.HeaderText = "Vasca";
            this.Vasca.Name = "Vasca";
            this.Vasca.ReadOnly = true;
            // 
            // Materiale
            // 
            this.Materiale.HeaderText = "Materiale";
            this.Materiale.Name = "Materiale";
            this.Materiale.ReadOnly = true;
            // 
            // SpessoreMinimo
            // 
            this.SpessoreMinimo.HeaderText = "Spessore minimo";
            this.SpessoreMinimo.Name = "SpessoreMinimo";
            this.SpessoreMinimo.ReadOnly = true;
            // 
            // SpessoreNominale
            // 
            this.SpessoreNominale.HeaderText = "Spessore nominale";
            this.SpessoreNominale.Name = "SpessoreNominale";
            this.SpessoreNominale.ReadOnly = true;
            // 
            // SpessoreMassimo
            // 
            this.SpessoreMassimo.HeaderText = "Spessore massimo";
            this.SpessoreMassimo.Name = "SpessoreMassimo";
            this.SpessoreMassimo.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Processo galvanico";
            // 
            // tabCostiFissi
            // 
            this.tabCostiFissi.Controls.Add(this.label6);
            this.tabCostiFissi.Controls.Add(this.label5);
            this.tabCostiFissi.Controls.Add(this.label4);
            this.tabCostiFissi.Controls.Add(this.txtCostiFissiPrezzo);
            this.tabCostiFissi.Controls.Add(this.txtCostiFissiRicarico);
            this.tabCostiFissi.Controls.Add(this.txtCostiFissiCosto);
            this.tabCostiFissi.Controls.Add(this.label3);
            this.tabCostiFissi.Controls.Add(this.btnAggiorna_costiFissi);
            this.tabCostiFissi.Controls.Add(this.dgvCostiFissi);
            this.tabCostiFissi.Controls.Add(this.lstCostiFissi);
            this.tabCostiFissi.Location = new System.Drawing.Point(4, 24);
            this.tabCostiFissi.Name = "tabCostiFissi";
            this.tabCostiFissi.Padding = new System.Windows.Forms.Padding(3);
            this.tabCostiFissi.Size = new System.Drawing.Size(900, 393);
            this.tabCostiFissi.TabIndex = 2;
            this.tabCostiFissi.Text = "Costi fissi";
            this.tabCostiFissi.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(696, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Margine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(590, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Prezzo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Costo";
            // 
            // txtCostiFissiPrezzo
            // 
            this.txtCostiFissiPrezzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostiFissiPrezzo.Location = new System.Drawing.Point(589, 20);
            this.txtCostiFissiPrezzo.Name = "txtCostiFissiPrezzo";
            this.txtCostiFissiPrezzo.ReadOnly = true;
            this.txtCostiFissiPrezzo.Size = new System.Drawing.Size(100, 21);
            this.txtCostiFissiPrezzo.TabIndex = 5;
            // 
            // txtCostiFissiRicarico
            // 
            this.txtCostiFissiRicarico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostiFissiRicarico.Location = new System.Drawing.Point(695, 20);
            this.txtCostiFissiRicarico.Name = "txtCostiFissiRicarico";
            this.txtCostiFissiRicarico.ReadOnly = true;
            this.txtCostiFissiRicarico.Size = new System.Drawing.Size(100, 21);
            this.txtCostiFissiRicarico.TabIndex = 5;
            // 
            // txtCostiFissiCosto
            // 
            this.txtCostiFissiCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostiFissiCosto.Location = new System.Drawing.Point(480, 20);
            this.txtCostiFissiCosto.Name = "txtCostiFissiCosto";
            this.txtCostiFissiCosto.ReadOnly = true;
            this.txtCostiFissiCosto.Size = new System.Drawing.Size(100, 21);
            this.txtCostiFissiCosto.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Totali";
            // 
            // btnAggiorna_costiFissi
            // 
            this.btnAggiorna_costiFissi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAggiorna_costiFissi.Location = new System.Drawing.Point(6, 358);
            this.btnAggiorna_costiFissi.Name = "btnAggiorna_costiFissi";
            this.btnAggiorna_costiFissi.Size = new System.Drawing.Size(292, 33);
            this.btnAggiorna_costiFissi.TabIndex = 2;
            this.btnAggiorna_costiFissi.Text = "Aggiorna lista costi fissi";
            this.btnAggiorna_costiFissi.UseVisualStyleBackColor = true;
            this.btnAggiorna_costiFissi.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // dgvCostiFissi
            // 
            this.dgvCostiFissi.AllowDrop = true;
            this.dgvCostiFissi.AllowUserToAddRows = false;
            this.dgvCostiFissi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostiFissi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCostoFissoPreventivo,
            this.CodiceCostoFisso,
            this.DescrizioneCostoFisso,
            this.RicaricoCostoFisso,
            this.CostoCostoFisso,
            this.PressoCostoFisso});
            this.dgvCostiFissi.Location = new System.Drawing.Point(347, 45);
            this.dgvCostiFissi.Name = "dgvCostiFissi";
            this.dgvCostiFissi.Size = new System.Drawing.Size(547, 340);
            this.dgvCostiFissi.TabIndex = 1;
            this.dgvCostiFissi.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCostiFissi_CellValidated);
            this.dgvCostiFissi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCostiFissi_EditingControlShowing);
            this.dgvCostiFissi.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvCostiFissi_UserDeletedRow);
            this.dgvCostiFissi.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvCostiFissi_DragDrop);
            this.dgvCostiFissi.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvCostiFissi_DragEnter);
            // 
            // IdCostoFissoPreventivo
            // 
            this.IdCostoFissoPreventivo.DataPropertyName = "IdElementoCosto";
            this.IdCostoFissoPreventivo.HeaderText = "IdCostoFissoPreventivo";
            this.IdCostoFissoPreventivo.Name = "IdCostoFissoPreventivo";
            this.IdCostoFissoPreventivo.Visible = false;
            // 
            // CodiceCostoFisso
            // 
            this.CodiceCostoFisso.DataPropertyName = "Codice";
            this.CodiceCostoFisso.HeaderText = "Codice";
            this.CodiceCostoFisso.Name = "CodiceCostoFisso";
            this.CodiceCostoFisso.ReadOnly = true;
            // 
            // DescrizioneCostoFisso
            // 
            this.DescrizioneCostoFisso.DataPropertyName = "Descrizione";
            this.DescrizioneCostoFisso.HeaderText = "Descrizione";
            this.DescrizioneCostoFisso.MaxInputLength = 30;
            this.DescrizioneCostoFisso.Name = "DescrizioneCostoFisso";
            // 
            // RicaricoCostoFisso
            // 
            this.RicaricoCostoFisso.DataPropertyName = "Ricarico";
            this.RicaricoCostoFisso.HeaderText = "Ricarico";
            this.RicaricoCostoFisso.Name = "RicaricoCostoFisso";
            // 
            // CostoCostoFisso
            // 
            this.CostoCostoFisso.DataPropertyName = "Costo";
            this.CostoCostoFisso.HeaderText = "Costo";
            this.CostoCostoFisso.Name = "CostoCostoFisso";
            // 
            // PressoCostoFisso
            // 
            this.PressoCostoFisso.DataPropertyName = "Prezzo";
            this.PressoCostoFisso.HeaderText = "Prezzo";
            this.PressoCostoFisso.Name = "PressoCostoFisso";
            this.PressoCostoFisso.ReadOnly = true;
            // 
            // lstCostiFissi
            // 
            this.lstCostiFissi.Location = new System.Drawing.Point(6, 6);
            this.lstCostiFissi.Name = "lstCostiFissi";
            this.lstCostiFissi.Size = new System.Drawing.Size(292, 329);
            this.lstCostiFissi.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCostiGalvanica);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 393);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Costi galvanica";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCostiGalvanica
            // 
            this.dgvCostiGalvanica.AllowUserToAddRows = false;
            this.dgvCostiGalvanica.AllowUserToDeleteRows = false;
            this.dgvCostiGalvanica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostiGalvanica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCostiGalvanica.Location = new System.Drawing.Point(3, 3);
            this.dgvCostiGalvanica.Name = "dgvCostiGalvanica";
            this.dgvCostiGalvanica.ReadOnly = true;
            this.dgvCostiGalvanica.Size = new System.Drawing.Size(894, 387);
            this.dgvCostiGalvanica.TabIndex = 0;
            // 
            // CostoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CostoFrm";
            this.Text = "Preventivo";
            this.Load += new System.EventHandler(this.CostoFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabTotali.ResumeLayout(false);
            this.tabTotali.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuPrezzoProdottoFinito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCostoProdottoFinito)).EndInit();
            this.tabDettaglio.ResumeLayout(false);
            this.tabGalvanica.ResumeLayout(false);
            this.tabGalvanica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessoGalvanico)).EndInit();
            this.tabCostiFissi.ResumeLayout(false);
            this.tabCostiFissi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiFissi)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostiGalvanica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProdottoFinitoUC prodottoFinitoUC1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNotaPreventivo;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCreaNuovaVersione;
        private System.Windows.Forms.ComboBox ddlPreventivi;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvElementi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDettaglio;
        private System.Windows.Forms.TabPage tabGalvanica;
        private System.Windows.Forms.TabPage tabCostiFissi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotaPrevetivoCosto;
        private System.Windows.Forms.ComboBox ddlPreventivoCosto;
        private System.Windows.Forms.Button btnAggiorna_costiFissi;
        private System.Windows.Forms.DataGridView dgvCostiFissi;
        private System.Windows.Forms.TabPage tabTotali;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdElementoPreventivo;
        private DraggableListbox lstCostiFissi;
        private System.Windows.Forms.TextBox txtCostiFissiPrezzo;
        private System.Windows.Forms.TextBox txtCostiFissiRicarico;
        private System.Windows.Forms.TextBox txtCostiFissiCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotaliCostiFissiPrezo;
        private System.Windows.Forms.TextBox txtTotaliCostiFissiMargine;
        private System.Windows.Forms.TextBox txtTotaliCostiFissiCosto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCostoFissoPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceCostoFisso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescrizioneCostoFisso;
        private System.Windows.Forms.DataGridViewTextBoxColumn RicaricoCostoFisso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoCostoFisso;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressoCostoFisso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdElementoCosto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncludiPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoArticolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoCodice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoDescrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoReparto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoGruppo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoSuperficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoQuantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoPezziOrari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoCostoOrario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementoRicarico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoArticolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoFigli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reparto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gruppo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Superficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn PezziOrari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ricarico;
        private System.Windows.Forms.TextBox txtProcessoGalvanico;
        private System.Windows.Forms.DataGridView dgvProcessoGalvanico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vasca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreNominale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreMassimo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCostiGalvanica;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCostoProdottoFinito;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nuPrezzoProdottoFinito;
        private System.Windows.Forms.NumericUpDown nuCostoProdottoFinito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMargineProdottoFinito;
    }
}