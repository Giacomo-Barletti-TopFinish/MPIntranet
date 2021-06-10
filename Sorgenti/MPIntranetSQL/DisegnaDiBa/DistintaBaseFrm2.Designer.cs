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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.dgvFasiCiclo = new System.Windows.Forms.DataGridView();
            this.clmIDFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdComponenteFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmErroreFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdDibaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperazioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaProduzioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTaskFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSchedaProcessoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollegamentoCicloFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPezziOrariFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPeriodoFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSetupFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttesaFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMovimentazioneFaseCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnSalvaDiba = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(3, 50);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(684, 396);
            this.tvDiBa.TabIndex = 1;
            this.tvDiBa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDiBa_NodeMouseClick);
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
            this.clmAreaProduzioneFaseCiclo,
            this.clmTaskFaseCiclo,
            this.clmSchedaProcessoFaseCiclo,
            this.clmCollegamentoCicloFaseCiclo,
            this.clmPezziOrariFaseCiclo,
            this.clmPeriodoFaseCiclo,
            this.clmSetupFaseCiclo,
            this.clmAttesaFaseCiclo,
            this.clmMovimentazioneFaseCiclo});
            this.dgvFasiCiclo.Location = new System.Drawing.Point(711, 50);
            this.dgvFasiCiclo.Name = "dgvFasiCiclo";
            this.dgvFasiCiclo.Size = new System.Drawing.Size(960, 870);
            this.dgvFasiCiclo.TabIndex = 5;
            this.dgvFasiCiclo.VirtualMode = true;
            this.dgvFasiCiclo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvNodi_EditingControlShowing);
            this.dgvFasiCiclo.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvFasiCiclo_NewRowNeeded);
            this.dgvFasiCiclo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvFasiCiclo_RowsAdded);
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
            this.clmIdComponenteFaseCiclo.HeaderText = "IdComponente";
            this.clmIdComponenteFaseCiclo.Name = "clmIdComponenteFaseCiclo";
            this.clmIdComponenteFaseCiclo.ReadOnly = true;
            // 
            // clmErroreFaseCiclo
            // 
            this.clmErroreFaseCiclo.DataPropertyName = "Errore";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.clmErroreFaseCiclo.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmErroreFaseCiclo.HeaderText = "Errore";
            this.clmErroreFaseCiclo.Name = "clmErroreFaseCiclo";
            this.clmErroreFaseCiclo.ReadOnly = true;
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
            // clmAreaProduzioneFaseCiclo
            // 
            this.clmAreaProduzioneFaseCiclo.DataPropertyName = "AreaProduzione";
            this.clmAreaProduzioneFaseCiclo.HeaderText = "AreaProduzione";
            this.clmAreaProduzioneFaseCiclo.Name = "clmAreaProduzioneFaseCiclo";
            // 
            // clmTaskFaseCiclo
            // 
            this.clmTaskFaseCiclo.DataPropertyName = "Task";
            this.clmTaskFaseCiclo.FillWeight = 70F;
            this.clmTaskFaseCiclo.HeaderText = "Task";
            this.clmTaskFaseCiclo.Name = "clmTaskFaseCiclo";
            this.clmTaskFaseCiclo.Width = 70;
            // 
            // clmSchedaProcessoFaseCiclo
            // 
            this.clmSchedaProcessoFaseCiclo.DataPropertyName = "SchedaProcesso";
            this.clmSchedaProcessoFaseCiclo.HeaderText = "SchedaProcesso";
            this.clmSchedaProcessoFaseCiclo.Name = "clmSchedaProcessoFaseCiclo";
            // 
            // clmCollegamentoCicloFaseCiclo
            // 
            this.clmCollegamentoCicloFaseCiclo.DataPropertyName = "CollegamentoCiclo";
            this.clmCollegamentoCicloFaseCiclo.HeaderText = "CollegamentoCiclo";
            this.clmCollegamentoCicloFaseCiclo.Name = "clmCollegamentoCicloFaseCiclo";
            // 
            // clmPezziOrariFaseCiclo
            // 
            this.clmPezziOrariFaseCiclo.DataPropertyName = "PezziOrari";
            this.clmPezziOrariFaseCiclo.FillWeight = 60F;
            this.clmPezziOrariFaseCiclo.HeaderText = "PezziOrari";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Articolo";
            // 
            // txtArticolo
            // 
            this.txtArticolo.Location = new System.Drawing.Point(64, 13);
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.ReadOnly = true;
            this.txtArticolo.Size = new System.Drawing.Size(204, 20);
            this.txtArticolo.TabIndex = 6;
            // 
            // btnCercaDiBa
            // 
            this.btnCercaDiBa.Location = new System.Drawing.Point(283, 10);
            this.btnCercaDiBa.Name = "btnCercaDiBa";
            this.btnCercaDiBa.Size = new System.Drawing.Size(94, 27);
            this.btnCercaDiBa.TabIndex = 8;
            this.btnCercaDiBa.Text = "Cerca DiBa";
            this.btnCercaDiBa.UseVisualStyleBackColor = true;
            this.btnCercaDiBa.Click += new System.EventHandler(this.btnCercaDiBa_Click);
            // 
            // txtTipoDiba
            // 
            this.txtTipoDiba.Location = new System.Drawing.Point(676, 11);
            this.txtTipoDiba.Name = "txtTipoDiba";
            this.txtTipoDiba.ReadOnly = true;
            this.txtTipoDiba.Size = new System.Drawing.Size(279, 20);
            this.txtTipoDiba.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // txtDescrizioneDiba
            // 
            this.txtDescrizioneDiba.Location = new System.Drawing.Point(1183, 11);
            this.txtDescrizioneDiba.Name = "txtDescrizioneDiba";
            this.txtDescrizioneDiba.ReadOnly = true;
            this.txtDescrizioneDiba.Size = new System.Drawing.Size(470, 20);
            this.txtDescrizioneDiba.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1116, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descrizione";
            // 
            // txtVersioneDiba
            // 
            this.txtVersioneDiba.Location = new System.Drawing.Point(1032, 11);
            this.txtVersioneDiba.Name = "txtVersioneDiba";
            this.txtVersioneDiba.ReadOnly = true;
            this.txtVersioneDiba.Size = new System.Drawing.Size(73, 20);
            this.txtVersioneDiba.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(970, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Versione";
            // 
            // btnNuovaDistinta
            // 
            this.btnNuovaDistinta.Location = new System.Drawing.Point(408, 10);
            this.btnNuovaDistinta.Name = "btnNuovaDistinta";
            this.btnNuovaDistinta.Size = new System.Drawing.Size(94, 27);
            this.btnNuovaDistinta.TabIndex = 15;
            this.btnNuovaDistinta.Text = "Nuova DiBa";
            this.btnNuovaDistinta.UseVisualStyleBackColor = true;
            this.btnNuovaDistinta.Click += new System.EventHandler(this.btnNuovaDistinta_Click);
            // 
            // btnSalvaDiba
            // 
            this.btnSalvaDiba.Location = new System.Drawing.Point(533, 10);
            this.btnSalvaDiba.Name = "btnSalvaDiba";
            this.btnSalvaDiba.Size = new System.Drawing.Size(94, 27);
            this.btnSalvaDiba.TabIndex = 19;
            this.btnSalvaDiba.Text = "Salva DiBa";
            this.btnSalvaDiba.UseVisualStyleBackColor = true;
            this.btnSalvaDiba.Click += new System.EventHandler(this.btnSalvaDiba_Click);
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
            this.dgvComponenti.Location = new System.Drawing.Point(3, 485);
            this.dgvComponenti.Name = "dgvComponenti";
            this.dgvComponenti.Size = new System.Drawing.Size(684, 435);
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
            // DistintaBaseFrm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.dgvFasiCiclo);
            this.Controls.Add(this.dgvComponenti);
            this.Controls.Add(this.btnSalvaDiba);
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
            this.Controls.Add(this.tvDiBa);
            this.Name = "DistintaBaseFrm2";
            this.Text = "DIstintaBaseFrm";
            this.Load += new System.EventHandler(this.DistintaBaseFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasiCiclo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.DataGridView dgvFasiCiclo;
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
        private System.Windows.Forms.Button btnSalvaDiba;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdComponenteFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmErroreFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdDibaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperazioneFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaProduzioneFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTaskFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSchedaProcessoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollegamentoCicloFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPezziOrariFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPeriodoFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSetupFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttesaFaseCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMovimentazioneFaseCiclo;
    }
}