namespace MPPreventivatore
{
    partial class PreventivoFrm
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
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCreaNuovaVersione = new System.Windows.Forms.Button();
            this.ddlPreventivi = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lstFasi = new System.Windows.Forms.ListBox();
            this.ddlReparti = new System.Windows.Forms.ComboBox();
            this.dgvElementi = new System.Windows.Forms.DataGridView();
            this.IdEelementoPreventivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reparto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Superficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PezziOrari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstMateriePrime = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAggiorna2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAggiorna = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvProcessoGalvanico = new System.Windows.Forms.DataGridView();
            this.Vasca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materiale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreNominale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpessoreMassimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlProcessiGalvanici = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessoGalvanico)).BeginInit();
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
            this.groupBox2.Controls.Add(this.txtNota);
            this.groupBox2.Controls.Add(this.btnSalva);
            this.groupBox2.Controls.Add(this.btnCreaNuovaVersione);
            this.groupBox2.Controls.Add(this.ddlPreventivi);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 182);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preventivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(6, 65);
            this.txtNota.MaxLength = 100;
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(376, 104);
            this.txtNota.TabIndex = 2;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(399, 136);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(141, 33);
            this.btnSalva.TabIndex = 1;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnCreaNuovaVersione
            // 
            this.btnCreaNuovaVersione.Location = new System.Drawing.Point(399, 15);
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
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            // 
            // lstFasi
            // 
            this.lstFasi.AllowDrop = true;
            this.lstFasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFasi.FormattingEnabled = true;
            this.lstFasi.ItemHeight = 15;
            this.lstFasi.Location = new System.Drawing.Point(9, 70);
            this.lstFasi.Name = "lstFasi";
            this.lstFasi.Size = new System.Drawing.Size(292, 259);
            this.lstFasi.TabIndex = 4;
            this.lstFasi.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFasi_DragOver);
            this.lstFasi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFasi_MouseDown);
            // 
            // ddlReparti
            // 
            this.ddlReparti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlReparti.FormattingEnabled = true;
            this.ddlReparti.Location = new System.Drawing.Point(9, 24);
            this.ddlReparti.Name = "ddlReparti";
            this.ddlReparti.Size = new System.Drawing.Size(292, 23);
            this.ddlReparti.TabIndex = 5;
            this.ddlReparti.SelectedIndexChanged += new System.EventHandler(this.ddlReparti_SelectedIndexChanged);
            // 
            // dgvElementi
            // 
            this.dgvElementi.AllowUserToAddRows = false;
            this.dgvElementi.AllowUserToDeleteRows = false;
            this.dgvElementi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElementi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEelementoPreventivo,
            this.Articolo,
            this.Codice,
            this.Descrizione,
            this.Reparto,
            this.Peso,
            this.Superficie,
            this.Quantita,
            this.PezziOrari,
            this.Nota});
            this.dgvElementi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElementi.Location = new System.Drawing.Point(3, 3);
            this.dgvElementi.MultiSelect = false;
            this.dgvElementi.Name = "dgvElementi";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElementi.Size = new System.Drawing.Size(888, 405);
            this.dgvElementi.TabIndex = 9;
            this.dgvElementi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellClick);
            this.dgvElementi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellEndEdit);
            this.dgvElementi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvElementi_EditingControlShowing);
            // 
            // IdEelementoPreventivo
            // 
            this.IdEelementoPreventivo.DataPropertyName = "IdElementoPreventivo";
            this.IdEelementoPreventivo.HeaderText = "IdEelementoPreventivo";
            this.IdEelementoPreventivo.Name = "IdEelementoPreventivo";
            this.IdEelementoPreventivo.Visible = false;
            // 
            // Articolo
            // 
            this.Articolo.DataPropertyName = "Articolo";
            this.Articolo.HeaderText = "Articolo";
            this.Articolo.MaxInputLength = 30;
            this.Articolo.Name = "Articolo";
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "Codice";
            this.Codice.HeaderText = "Codice";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            // 
            // Reparto
            // 
            this.Reparto.DataPropertyName = "Reparto";
            this.Reparto.HeaderText = "Reparto";
            this.Reparto.Name = "Reparto";
            this.Reparto.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "Peso";
            this.Peso.FillWeight = 80F;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Width = 80;
            // 
            // Superficie
            // 
            this.Superficie.DataPropertyName = "Superficie";
            this.Superficie.FillWeight = 80F;
            this.Superficie.HeaderText = "Superficie";
            this.Superficie.Name = "Superficie";
            this.Superficie.Width = 80;
            // 
            // Quantita
            // 
            this.Quantita.DataPropertyName = "Quantita";
            this.Quantita.FillWeight = 80F;
            this.Quantita.HeaderText = "Quantità";
            this.Quantita.Name = "Quantita";
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
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.MaxInputLength = 200;
            this.Nota.Name = "Nota";
            // 
            // lstMateriePrime
            // 
            this.lstMateriePrime.AllowDrop = true;
            this.lstMateriePrime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMateriePrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMateriePrime.FormattingEnabled = true;
            this.lstMateriePrime.ItemHeight = 15;
            this.lstMateriePrime.Location = new System.Drawing.Point(6, 4);
            this.lstMateriePrime.Name = "lstMateriePrime";
            this.lstMateriePrime.Size = new System.Drawing.Size(292, 334);
            this.lstMateriePrime.TabIndex = 4;
            this.lstMateriePrime.DragOver += new System.Windows.Forms.DragEventHandler(this.lstFasi_DragOver);
            this.lstMateriePrime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstMateriePrime_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(464, 200);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 439);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvElementi);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(894, 411);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Elementi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAggiorna2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lstFasi);
            this.tabPage1.Controls.Add(this.ddlReparti);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fasi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAggiorna2
            // 
            this.btnAggiorna2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAggiorna2.Location = new System.Drawing.Point(90, 372);
            this.btnAggiorna2.Name = "btnAggiorna2";
            this.btnAggiorna2.Size = new System.Drawing.Size(129, 27);
            this.btnAggiorna2.TabIndex = 9;
            this.btnAggiorna2.Text = "Aggiorna";
            this.btnAggiorna2.UseVisualStyleBackColor = true;
            this.btnAggiorna2.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fasi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reparto";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAggiorna);
            this.tabPage2.Controls.Add(this.lstMateriePrime);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Materie prime";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAggiorna
            // 
            this.btnAggiorna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAggiorna.Location = new System.Drawing.Point(90, 360);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(129, 27);
            this.btnAggiorna.TabIndex = 8;
            this.btnAggiorna.Text = "Aggiorna";
            this.btnAggiorna.UseVisualStyleBackColor = true;
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvProcessoGalvanico);
            this.tabPage4.Controls.Add(this.ddlProcessiGalvanici);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(894, 411);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Processo galvanico";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.dgvProcessoGalvanico.Location = new System.Drawing.Point(293, 22);
            this.dgvProcessoGalvanico.Name = "dgvProcessoGalvanico";
            this.dgvProcessoGalvanico.ReadOnly = true;
            this.dgvProcessoGalvanico.Size = new System.Drawing.Size(595, 383);
            this.dgvProcessoGalvanico.TabIndex = 12;
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
            // ddlProcessiGalvanici
            // 
            this.ddlProcessiGalvanici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProcessiGalvanici.FormattingEnabled = true;
            this.ddlProcessiGalvanici.Location = new System.Drawing.Point(12, 40);
            this.ddlProcessiGalvanici.Name = "ddlProcessiGalvanici";
            this.ddlProcessiGalvanici.Size = new System.Drawing.Size(265, 23);
            this.ddlProcessiGalvanici.TabIndex = 11;
            this.ddlProcessiGalvanici.SelectedIndexChanged += new System.EventHandler(this.ddlProcessiGalvanici_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Processo galvanico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Premere shift per inserire dopo il nodo selezionato";
            // 
            // PreventivoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PreventivoFrm";
            this.Text = "Preventivo";
            this.Load += new System.EventHandler(this.PreventivoFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessoGalvanico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProdottoFinitoUC prodottoFinitoUC1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCreaNuovaVersione;
        private System.Windows.Forms.ComboBox ddlPreventivi;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox lstFasi;
        private System.Windows.Forms.ComboBox ddlReparti;
        private System.Windows.Forms.DataGridView dgvElementi;
        private System.Windows.Forms.ListBox lstMateriePrime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAggiorna;
        private System.Windows.Forms.Button btnAggiorna2;
        private System.Windows.Forms.ComboBox ddlProcessiGalvanici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEelementoPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reparto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Superficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn PezziOrari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvProcessoGalvanico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vasca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materiale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreNominale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpessoreMassimo;
    }
}