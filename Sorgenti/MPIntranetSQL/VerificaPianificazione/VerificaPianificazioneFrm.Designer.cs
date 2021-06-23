namespace VerificaPianificazione
{
    partial class VerificaPianificazioneFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtDataDaVerificare = new System.Windows.Forms.DateTimePicker();
            this.btnVerifica = new System.Windows.Forms.Button();
            this.dgvODP = new System.Windows.Forms.DataGridView();
            this.dgvFasi = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaProduzione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrdineProduzione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAvanzamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAnagrafica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMagazzino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantitaFinita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantitaResidua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDataInizio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDataFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvODP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data da verificare";
            // 
            // dtDataDaVerificare
            // 
            this.dtDataDaVerificare.Location = new System.Drawing.Point(142, 28);
            this.dtDataDaVerificare.Name = "dtDataDaVerificare";
            this.dtDataDaVerificare.Size = new System.Drawing.Size(200, 20);
            this.dtDataDaVerificare.TabIndex = 1;
            // 
            // btnVerifica
            // 
            this.btnVerifica.Location = new System.Drawing.Point(418, 27);
            this.btnVerifica.Name = "btnVerifica";
            this.btnVerifica.Size = new System.Drawing.Size(75, 23);
            this.btnVerifica.TabIndex = 2;
            this.btnVerifica.Text = "Verifica";
            this.btnVerifica.UseVisualStyleBackColor = true;
            this.btnVerifica.Click += new System.EventHandler(this.btnVerifica_Click);
            // 
            // dgvODP
            // 
            this.dgvODP.AllowUserToAddRows = false;
            this.dgvODP.AllowUserToDeleteRows = false;
            this.dgvODP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvODP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvODP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmOrdineProduzione,
            this.clmAvanzamento,
            this.clmCiclo,
            this.clmOperazione,
            this.clmAnagrafica,
            this.clmDescrizione,
            this.clmMagazzino,
            this.clmQuantita,
            this.clmQuantitaFinita,
            this.clmQuantitaResidua,
            this.clmDataInizio,
            this.clmDataFine});
            this.dgvODP.Location = new System.Drawing.Point(34, 76);
            this.dgvODP.Name = "dgvODP";
            this.dgvODP.ReadOnly = true;
            this.dgvODP.Size = new System.Drawing.Size(1145, 457);
            this.dgvODP.TabIndex = 3;
            this.dgvODP.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFasi_RowEnter);
            // 
            // dgvFasi
            // 
            this.dgvFasi.AllowUserToAddRows = false;
            this.dgvFasi.AllowUserToDeleteRows = false;
            this.dgvFasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.clmAreaProduzione,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn10,
            this.WIP,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.DataDocumento});
            this.dgvFasi.Location = new System.Drawing.Point(34, 550);
            this.dgvFasi.Name = "dgvFasi";
            this.dgvFasi.ReadOnly = true;
            this.dgvFasi.Size = new System.Drawing.Size(1145, 236);
            this.dgvFasi.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Avanzamento";
            this.dataGridViewTextBoxColumn2.HeaderText = "Avanzamento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Operazione";
            this.dataGridViewTextBoxColumn4.HeaderText = "Operazione";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // clmAreaProduzione
            // 
            this.clmAreaProduzione.DataPropertyName = "AreaProduzione";
            this.clmAreaProduzione.HeaderText = "Area produzione";
            this.clmAreaProduzione.Name = "clmAreaProduzione";
            this.clmAreaProduzione.ReadOnly = true;
            this.clmAreaProduzione.Width = 140;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DescrizioneAreaProduzione";
            this.dataGridViewTextBoxColumn6.HeaderText = "Descrizione";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Task";
            this.dataGridViewTextBoxColumn10.HeaderText = "Task";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 70;
            // 
            // WIP
            // 
            this.WIP.DataPropertyName = "WIP";
            this.WIP.HeaderText = "WIP";
            this.WIP.Name = "WIP";
            this.WIP.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DataFine";
            this.dataGridViewTextBoxColumn12.HeaderText = "Data fine";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DataInizio";
            this.dataGridViewTextBoxColumn11.HeaderText = "Data Inizio";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "QuantitaInput";
            this.dataGridViewTextBoxColumn8.HeaderText = "Quantità";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "QuantitaOutput";
            this.dataGridViewTextBoxColumn9.HeaderText = "Quantità finita";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // DataDocumento
            // 
            this.DataDocumento.DataPropertyName = "DataVersamento";
            this.DataDocumento.HeaderText = "Versamento";
            this.DataDocumento.Name = "DataDocumento";
            this.DataDocumento.ReadOnly = true;
            // 
            // clmOrdineProduzione
            // 
            this.clmOrdineProduzione.DataPropertyName = "CodiceOrdineProduzione";
            this.clmOrdineProduzione.HeaderText = "Ordine produzione";
            this.clmOrdineProduzione.Name = "clmOrdineProduzione";
            this.clmOrdineProduzione.ReadOnly = true;
            this.clmOrdineProduzione.Width = 120;
            // 
            // clmAvanzamento
            // 
            this.clmAvanzamento.DataPropertyName = "Avanzamento";
            this.clmAvanzamento.HeaderText = "Avanzamento";
            this.clmAvanzamento.Name = "clmAvanzamento";
            this.clmAvanzamento.ReadOnly = true;
            // 
            // clmCiclo
            // 
            this.clmCiclo.DataPropertyName = "Ciclo";
            this.clmCiclo.HeaderText = "Ciclo";
            this.clmCiclo.Name = "clmCiclo";
            this.clmCiclo.ReadOnly = true;
            this.clmCiclo.Width = 140;
            // 
            // clmOperazione
            // 
            this.clmOperazione.DataPropertyName = "Operazione";
            this.clmOperazione.HeaderText = "Operazione";
            this.clmOperazione.Name = "clmOperazione";
            this.clmOperazione.ReadOnly = true;
            this.clmOperazione.Width = 70;
            // 
            // clmAnagrafica
            // 
            this.clmAnagrafica.DataPropertyName = "Anagrafica";
            this.clmAnagrafica.HeaderText = "Anagrafica";
            this.clmAnagrafica.Name = "clmAnagrafica";
            this.clmAnagrafica.ReadOnly = true;
            this.clmAnagrafica.Width = 140;
            // 
            // clmDescrizione
            // 
            this.clmDescrizione.DataPropertyName = "Descrizione";
            this.clmDescrizione.HeaderText = "Descrizione";
            this.clmDescrizione.Name = "clmDescrizione";
            this.clmDescrizione.ReadOnly = true;
            // 
            // clmMagazzino
            // 
            this.clmMagazzino.DataPropertyName = "Magazzino";
            this.clmMagazzino.HeaderText = "Magazzino";
            this.clmMagazzino.Name = "clmMagazzino";
            this.clmMagazzino.ReadOnly = true;
            this.clmMagazzino.Width = 70;
            // 
            // clmQuantita
            // 
            this.clmQuantita.DataPropertyName = "Quantita";
            this.clmQuantita.HeaderText = "Quantità";
            this.clmQuantita.Name = "clmQuantita";
            this.clmQuantita.ReadOnly = true;
            this.clmQuantita.Width = 70;
            // 
            // clmQuantitaFinita
            // 
            this.clmQuantitaFinita.DataPropertyName = "QuantitaFinita";
            this.clmQuantitaFinita.HeaderText = "Quantità finita";
            this.clmQuantitaFinita.Name = "clmQuantitaFinita";
            this.clmQuantitaFinita.ReadOnly = true;
            this.clmQuantitaFinita.Width = 70;
            // 
            // clmQuantitaResidua
            // 
            this.clmQuantitaResidua.DataPropertyName = "QuantitaResidua";
            this.clmQuantitaResidua.HeaderText = "Quantità residua";
            this.clmQuantitaResidua.Name = "clmQuantitaResidua";
            this.clmQuantitaResidua.ReadOnly = true;
            this.clmQuantitaResidua.Width = 70;
            // 
            // clmDataInizio
            // 
            this.clmDataInizio.DataPropertyName = "DataInizio";
            this.clmDataInizio.HeaderText = "Data Inizio";
            this.clmDataInizio.Name = "clmDataInizio";
            this.clmDataInizio.ReadOnly = true;
            // 
            // clmDataFine
            // 
            this.clmDataFine.DataPropertyName = "DataFine";
            this.clmDataFine.HeaderText = "Data fine";
            this.clmDataFine.Name = "clmDataFine";
            this.clmDataFine.ReadOnly = true;
            // 
            // VerificaPianificazioneFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 798);
            this.Controls.Add(this.dgvFasi);
            this.Controls.Add(this.dgvODP);
            this.Controls.Add(this.btnVerifica);
            this.Controls.Add(this.dtDataDaVerificare);
            this.Controls.Add(this.label1);
            this.Name = "VerificaPianificazioneFrm";
            this.Text = "Verifica Pianificazione";
            this.Load += new System.EventHandler(this.VerificaPianificazioneFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvODP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDataDaVerificare;
        private System.Windows.Forms.Button btnVerifica;
        private System.Windows.Forms.DataGridView dgvODP;
        private System.Windows.Forms.DataGridView dgvFasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaProduzione;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrdineProduzione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAvanzamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAnagrafica;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMagazzino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantitaFinita;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantitaResidua;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDataInizio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDataFine;
    }
}

