namespace DisegnaDiBa
{
    partial class DistintaBaseFrm
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
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.dgvNodi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIZIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPARTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMAGAZZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAGRAFICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODICECICLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLLEGAMENTOCICLO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.COLLEGAMENTODIBA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PEZZIORARI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OREPERIODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTESTANDARD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITACONSUMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITAOCCORRENZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METODO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERSIONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTROLLATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORNITOCOMMITTENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUPERFICIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTETECNICHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContoLavoro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.btnCercaDiBa = new System.Windows.Forms.Button();
            this.txtTipoDiba = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizioneDiba = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersioneDiba = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNuovaDistinta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(3, 50);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(534, 838);
            this.tvDiBa.TabIndex = 1;
            // 
            // dgvNodi
            // 
            this.dgvNodi.AllowUserToAddRows = false;
            this.dgvNodi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MODELLO,
            this.DESCRIZIONE,
            this.REPARTO,
            this.FASE,
            this.IDMAGAZZ,
            this.ANAGRAFICA,
            this.CODICECICLO,
            this.COLLEGAMENTOCICLO,
            this.COLLEGAMENTODIBA,
            this.PEZZIORARI,
            this.OREPERIODO,
            this.NOTESTANDARD,
            this.QUANTITA,
            this.QUANTITACONSUMO,
            this.QUANTITAOCCORRENZA,
            this.UM,
            this.METODO,
            this.VERSIONE,
            this.ATTIVA,
            this.CONTROLLATA,
            this.FORNITOCOMMITTENTE,
            this.PESO,
            this.SUPERFICIE,
            this.NOTETECNICHE,
            this.ContoLavoro});
            this.dgvNodi.Location = new System.Drawing.Point(571, 50);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(1088, 838);
            this.dgvNodi.TabIndex = 5;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MODELLO
            // 
            this.MODELLO.DataPropertyName = "Modello";
            this.MODELLO.Frozen = true;
            this.MODELLO.HeaderText = "MODELLO";
            this.MODELLO.Name = "MODELLO";
            // 
            // DESCRIZIONE
            // 
            this.DESCRIZIONE.DataPropertyName = "DescrizioneArticolo";
            this.DESCRIZIONE.Frozen = true;
            this.DESCRIZIONE.HeaderText = "DESCRIZIONE";
            this.DESCRIZIONE.Name = "DESCRIZIONE";
            this.DESCRIZIONE.ReadOnly = true;
            // 
            // REPARTO
            // 
            this.REPARTO.DataPropertyName = "Reparto";
            this.REPARTO.Frozen = true;
            this.REPARTO.HeaderText = "REPARTO";
            this.REPARTO.Name = "REPARTO";
            this.REPARTO.ReadOnly = true;
            // 
            // FASE
            // 
            this.FASE.DataPropertyName = "Fase";
            this.FASE.Frozen = true;
            this.FASE.HeaderText = "FASE";
            this.FASE.Name = "FASE";
            this.FASE.ReadOnly = true;
            // 
            // IDMAGAZZ
            // 
            this.IDMAGAZZ.DataPropertyName = "IDMAGAZZ";
            this.IDMAGAZZ.Frozen = true;
            this.IDMAGAZZ.HeaderText = "IDMAGAZZ";
            this.IDMAGAZZ.Name = "IDMAGAZZ";
            // 
            // ANAGRAFICA
            // 
            this.ANAGRAFICA.DataPropertyName = "Anagrafica";
            this.ANAGRAFICA.FillWeight = 160F;
            this.ANAGRAFICA.Frozen = true;
            this.ANAGRAFICA.HeaderText = "ANAGRAFICA";
            this.ANAGRAFICA.Name = "ANAGRAFICA";
            this.ANAGRAFICA.Width = 160;
            // 
            // CODICECICLO
            // 
            this.CODICECICLO.DataPropertyName = "CodiceCiclo";
            this.CODICECICLO.FillWeight = 80F;
            this.CODICECICLO.HeaderText = "CODICE CICLO";
            this.CODICECICLO.Name = "CODICECICLO";
            this.CODICECICLO.Width = 80;
            // 
            // COLLEGAMENTOCICLO
            // 
            this.COLLEGAMENTOCICLO.DataPropertyName = "CollegamentoCiclo";
            this.COLLEGAMENTOCICLO.HeaderText = "COLLEGAMENTO CICLO";
            this.COLLEGAMENTOCICLO.Name = "COLLEGAMENTOCICLO";
            this.COLLEGAMENTOCICLO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLLEGAMENTOCICLO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COLLEGAMENTOCICLO.Width = 80;
            // 
            // COLLEGAMENTODIBA
            // 
            this.COLLEGAMENTODIBA.DataPropertyName = "CollegamentoDiba";
            this.COLLEGAMENTODIBA.HeaderText = "COLLEGAMENTO DISTINTA";
            this.COLLEGAMENTODIBA.Name = "COLLEGAMENTODIBA";
            this.COLLEGAMENTODIBA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLLEGAMENTODIBA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COLLEGAMENTODIBA.Width = 80;
            // 
            // PEZZIORARI
            // 
            this.PEZZIORARI.DataPropertyName = "PezziOrari";
            this.PEZZIORARI.HeaderText = "PEZZI ORARI";
            this.PEZZIORARI.Name = "PEZZIORARI";
            this.PEZZIORARI.Width = 50;
            // 
            // OREPERIODO
            // 
            this.OREPERIODO.DataPropertyName = "OrePeriodo";
            this.OREPERIODO.FillWeight = 50F;
            this.OREPERIODO.HeaderText = "ORE PERIODO";
            this.OREPERIODO.Name = "OREPERIODO";
            this.OREPERIODO.Width = 50;
            // 
            // NOTESTANDARD
            // 
            this.NOTESTANDARD.DataPropertyName = "NoteStandard";
            this.NOTESTANDARD.HeaderText = "NOTE STANDARD";
            this.NOTESTANDARD.Name = "NOTESTANDARD";
            this.NOTESTANDARD.ReadOnly = true;
            this.NOTESTANDARD.Width = 200;
            // 
            // QUANTITA
            // 
            this.QUANTITA.DataPropertyName = "Quantita";
            this.QUANTITA.HeaderText = "QUANTITA";
            this.QUANTITA.Name = "QUANTITA";
            // 
            // QUANTITACONSUMO
            // 
            this.QUANTITACONSUMO.DataPropertyName = "QuantitaConsumo";
            this.QUANTITACONSUMO.HeaderText = "QUANTITA CONSUMO";
            this.QUANTITACONSUMO.Name = "QUANTITACONSUMO";
            this.QUANTITACONSUMO.ReadOnly = true;
            // 
            // QUANTITAOCCORRENZA
            // 
            this.QUANTITAOCCORRENZA.DataPropertyName = "QualitaOccorrenza";
            this.QUANTITAOCCORRENZA.HeaderText = "QUANTITA OCCORRENZA";
            this.QUANTITAOCCORRENZA.Name = "QUANTITAOCCORRENZA";
            this.QUANTITAOCCORRENZA.ReadOnly = true;
            // 
            // UM
            // 
            this.UM.DataPropertyName = "UM";
            this.UM.HeaderText = "UM";
            this.UM.Name = "UM";
            // 
            // METODO
            // 
            this.METODO.DataPropertyName = "Metodo";
            this.METODO.HeaderText = "METODO";
            this.METODO.Name = "METODO";
            this.METODO.ReadOnly = true;
            // 
            // VERSIONE
            // 
            this.VERSIONE.DataPropertyName = "Versione";
            this.VERSIONE.HeaderText = "VERSIONE";
            this.VERSIONE.Name = "VERSIONE";
            this.VERSIONE.ReadOnly = true;
            // 
            // ATTIVA
            // 
            this.ATTIVA.DataPropertyName = "Attiva";
            this.ATTIVA.HeaderText = "ATTIVA";
            this.ATTIVA.Name = "ATTIVA";
            this.ATTIVA.ReadOnly = true;
            // 
            // CONTROLLATA
            // 
            this.CONTROLLATA.DataPropertyName = "Controllata";
            this.CONTROLLATA.HeaderText = "CONTROLLATA";
            this.CONTROLLATA.Name = "CONTROLLATA";
            this.CONTROLLATA.ReadOnly = true;
            // 
            // FORNITOCOMMITTENTE
            // 
            this.FORNITOCOMMITTENTE.DataPropertyName = "FornitoDaCommittente";
            this.FORNITOCOMMITTENTE.HeaderText = "FORN. COMMIT.";
            this.FORNITOCOMMITTENTE.Name = "FORNITOCOMMITTENTE";
            this.FORNITOCOMMITTENTE.ReadOnly = true;
            // 
            // PESO
            // 
            this.PESO.DataPropertyName = "Peso";
            this.PESO.HeaderText = "PESO";
            this.PESO.Name = "PESO";
            this.PESO.ReadOnly = true;
            this.PESO.Width = 50;
            // 
            // SUPERFICIE
            // 
            this.SUPERFICIE.DataPropertyName = "Superficie";
            this.SUPERFICIE.HeaderText = "SUPERFICIE";
            this.SUPERFICIE.Name = "SUPERFICIE";
            this.SUPERFICIE.ReadOnly = true;
            this.SUPERFICIE.Width = 50;
            // 
            // NOTETECNICHE
            // 
            this.NOTETECNICHE.DataPropertyName = "NoteTecniche";
            this.NOTETECNICHE.HeaderText = "NOTE TECNICHE";
            this.NOTETECNICHE.Name = "NOTETECNICHE";
            this.NOTETECNICHE.ReadOnly = true;
            this.NOTETECNICHE.Width = 200;
            // 
            // ContoLavoro
            // 
            this.ContoLavoro.DataPropertyName = "ContoLavoro";
            this.ContoLavoro.HeaderText = "ContoLavoro";
            this.ContoLavoro.Name = "ContoLavoro";
            this.ContoLavoro.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Articolo";
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(64, 12);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.ReadOnly = true;
            this.txtArticolo.Size = new System.Drawing.Size(238, 20);
            this.txtArticolo.TabIndex = 6;
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(330, 8);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(116, 27);
            this.btnCercaDiBa.TabIndex = 8;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // txtTipoDiba
            // 
            this.txtTipoDiba.Location = new System.Drawing.Point(642, 10);
            this.txtTipoDiba.Name = "txtTipoDiba";
            this.txtTipoDiba.ReadOnly = true;
            this.txtTipoDiba.Size = new System.Drawing.Size(279, 20);
            this.txtTipoDiba.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // txtDescrizioneDiba
            // 
            this.txtDescrizioneDiba.Location = new System.Drawing.Point(1002, 10);
            this.txtDescrizioneDiba.Name = "txtDescrizioneDiba";
            this.txtDescrizioneDiba.ReadOnly = true;
            this.txtDescrizioneDiba.Size = new System.Drawing.Size(504, 20);
            this.txtDescrizioneDiba.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(935, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descrizione";
            // 
            // txtVersioneDiba
            // 
            this.txtVersioneDiba.Location = new System.Drawing.Point(1580, 10);
            this.txtVersioneDiba.Name = "txtVersioneDiba";
            this.txtVersioneDiba.ReadOnly = true;
            this.txtVersioneDiba.Size = new System.Drawing.Size(73, 20);
            this.txtVersioneDiba.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1518, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Versione";
            // 
            // btnNuovaDistinta
            // 
            this.btnNuovaDistinta.Location = new System.Drawing.Point(468, 8);
            this.btnNuovaDistinta.Name = "btnNuovaDistinta";
            this.btnNuovaDistinta.Size = new System.Drawing.Size(116, 27);
            this.btnNuovaDistinta.TabIndex = 15;
            this.btnNuovaDistinta.Text = "Nuova DiBa";
            this.btnNuovaDistinta.UseVisualStyleBackColor = true;
            this.btnNuovaDistinta.Click += new System.EventHandler(this.btnNuovaDistinta_Click);
            // 
            // DistintaBaseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.btnNuovaDistinta);
            this.Controls.Add(this.txtVersioneDiba);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescrizioneDiba);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTipoDiba);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Controls.Add(this.dgvNodi);
            this.Controls.Add(this.tvDiBa);
            this.Name = "DistintaBaseFrm";
            this.Text = "DIstintaBaseFrm";
            this.Load += new System.EventHandler(this.DistintaBaseFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.DataGridView dgvNodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIZIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPARTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMAGAZZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAGRAFICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODICECICLO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COLLEGAMENTOCICLO;
        private System.Windows.Forms.DataGridViewComboBoxColumn COLLEGAMENTODIBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEZZIORARI;
        private System.Windows.Forms.DataGridViewTextBoxColumn OREPERIODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTESTANDARD;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITA;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITACONSUMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITAOCCORRENZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn METODO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERSIONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTROLLATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORNITOCOMMITTENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPERFICIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTETECNICHE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ContoLavoro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.TextBox txtTipoDiba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizioneDiba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersioneDiba;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNuovaDistinta;
    }
}