namespace DisegnaDiBa
{
    partial class DistintaBusinessCentralFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCercaDiBa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.dgvFasiCiclo = new System.Windows.Forms.DataGridView();
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
            this.tvDiBa = new System.Windows.Forms.TreeView();
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
            this.clmPezziOrariFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPeriodoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSchedaProcessoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoDiBAFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoCicloFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSetupFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttesaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMovimentazioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNotaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(288, 13);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(94, 27);
            this.btnCercaDiBa.TabIndex = 24;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Articolo";
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(69, 16);
            this.txtArticolo.MaxLength = 22;
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.Size = new System.Drawing.Size(204, 20);
            this.txtArticolo.TabIndex = 1;
            // 
            // dgvFasiCiclo
            // 
            this.dgvFasiCiclo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.clmPezziOrariFaseCiclo,
            this.clmPeriodoFaseCiclo,
            this.clmSchedaProcessoFaseCiclo,
            this.clmCollegamentoDiBAFaseCiclo,
            this.clmCollegamentoCicloFaseCiclo,
            this.clmSetupFaseCiclo,
            this.clmAttesaFaseCiclo,
            this.clmMovimentazioneFaseCiclo,
            this.clmNotaFaseCiclo});
            this.dgvFasiCiclo.Location = new System.Drawing.Point(719, 52);
            this.dgvFasiCiclo.Name = "dgvFasiCiclo";
            this.dgvFasiCiclo.Size = new System.Drawing.Size(960, 869);
            this.dgvFasiCiclo.TabIndex = 26;
            this.dgvFasiCiclo.VirtualMode = true;
            // 
            // dgvComponenti
            // 
            this.dgvComponenti.AllowUserToAddRows = false;
            this.dgvComponenti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.dgvComponenti.Location = new System.Drawing.Point(15, 486);
            this.dgvComponenti.Name = "dgvComponenti";
            this.dgvComponenti.Size = new System.Drawing.Size(684, 435);
            this.dgvComponenti.TabIndex = 27;
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
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(15, 52);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(684, 395);
            this.tvDiBa.TabIndex = 25;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
            // 
            // clmIDFaseCiclo
            // 
            this.clmIDFaseCiclo.DataPropertyName = "IdFaseCiclo";
            this.clmIDFaseCiclo.FillWeight = 60F;
            this.clmIDFaseCiclo.HeaderText = "IdFaseCiclo";
            this.clmIDFaseCiclo.Name = "clmIDFaseCiclo";
            this.clmIDFaseCiclo.ReadOnly = true;
            this.clmIDFaseCiclo.Visible = false;
            this.clmIDFaseCiclo.Width = 60;
            // 
            // clmIdComponenteFaseCiclo
            // 
            this.clmIdComponenteFaseCiclo.DataPropertyName = "IdComponente";
            this.clmIdComponenteFaseCiclo.FillWeight = 130F;
            this.clmIdComponenteFaseCiclo.HeaderText = "IdComponente";
            this.clmIdComponenteFaseCiclo.Name = "clmIdComponenteFaseCiclo";
            this.clmIdComponenteFaseCiclo.ReadOnly = true;
            this.clmIdComponenteFaseCiclo.Width = 130;
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
            this.clmErroreFaseCiclo.Visible = false;
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
            this.clmCollegamentoDiBAFaseCiclo.Visible = false;
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
            // clmNotaFaseCiclo
            // 
            this.clmNotaFaseCiclo.DataPropertyName = "Nota";
            this.clmNotaFaseCiclo.FillWeight = 200F;
            this.clmNotaFaseCiclo.HeaderText = "Nota";
            this.clmNotaFaseCiclo.MaxInputLength = 300;
            this.clmNotaFaseCiclo.Name = "clmNotaFaseCiclo";
            this.clmNotaFaseCiclo.Width = 200;
            // 
            // DistintaBusinessCentralFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.dgvFasiCiclo);
            this.Controls.Add(this.dgvComponenti);
            this.Controls.Add(this.tvDiBa);
            this.Controls.Add(this.btnCercaDiBa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticolo);
            this.Name = "DistintaBusinessCentralFrm";
            this.Text = "DistintaBusinessCentralFrm";
            this.Load += new System.EventHandler(this.DistintaBusinessCentralFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.DataGridView dgvFasiCiclo;
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
        private System.Windows.Forms.TreeView tvDiBa;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPezziOrariFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPeriodoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSchedaProcessoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoDiBAFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoCicloFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSetupFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttesaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMovimentazioneFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNotaFaseCiclo;
    }
}