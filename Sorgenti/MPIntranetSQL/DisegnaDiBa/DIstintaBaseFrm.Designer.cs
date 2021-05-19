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
            this.IdFase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPadre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDiba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anagrafica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaProduzione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchedaProcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollegamentoDiba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollegamentoCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UMQuantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PezziOrari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Setup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimentazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.IdFase,
            this.IdPadre,
            this.IdDiba,
            this.Descrizione,
            this.Anagrafica,
            this.AreaProduzione,
            this.Task,
            this.SchedaProcesso,
            this.CollegamentoDiba,
            this.CollegamentoCiclo,
            this.Quantita,
            this.UMQuantita,
            this.PezziOrari,
            this.Periodo,
            this.Setup,
            this.Attesa,
            this.Movimentazione});
            this.dgvNodi.Location = new System.Drawing.Point(571, 50);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(1088, 838);
            this.dgvNodi.TabIndex = 5;
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
            // IdFase
            // 
            this.IdFase.DataPropertyName = "IdFase";
            this.IdFase.HeaderText = "IdFase";
            this.IdFase.Name = "IdFase";
            // 
            // IdPadre
            // 
            this.IdPadre.DataPropertyName = "IdPadre";
            this.IdPadre.HeaderText = "IdPadre";
            this.IdPadre.Name = "IdPadre";
            // 
            // IdDiba
            // 
            this.IdDiba.DataPropertyName = "IdDiba";
            this.IdDiba.HeaderText = "IdDiba";
            this.IdDiba.Name = "IdDiba";
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            // 
            // Anagrafica
            // 
            this.Anagrafica.DataPropertyName = "Anagrafica";
            this.Anagrafica.HeaderText = "Anagrafica";
            this.Anagrafica.Name = "Anagrafica";
            // 
            // AreaProduzione
            // 
            this.AreaProduzione.DataPropertyName = "AreaProduzione";
            this.AreaProduzione.HeaderText = "AreaProduzione";
            this.AreaProduzione.Name = "AreaProduzione";
            // 
            // Task
            // 
            this.Task.DataPropertyName = "Task";
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            // 
            // SchedaProcesso
            // 
            this.SchedaProcesso.DataPropertyName = "SchedaProcesso";
            this.SchedaProcesso.HeaderText = "SchedaProcesso";
            this.SchedaProcesso.Name = "SchedaProcesso";
            // 
            // CollegamentoDiba
            // 
            this.CollegamentoDiba.DataPropertyName = "CollegamentoDiba";
            this.CollegamentoDiba.HeaderText = "CollegamentoDiba";
            this.CollegamentoDiba.Name = "CollegamentoDiba";
            // 
            // CollegamentoCiclo
            // 
            this.CollegamentoCiclo.DataPropertyName = "CollegamentoCiclo";
            this.CollegamentoCiclo.HeaderText = "CollegamentoCiclo";
            this.CollegamentoCiclo.Name = "CollegamentoCiclo";
            // 
            // Quantita
            // 
            this.Quantita.DataPropertyName = "Quantita";
            this.Quantita.HeaderText = "Quantita";
            this.Quantita.Name = "Quantita";
            // 
            // UMQuantita
            // 
            this.UMQuantita.DataPropertyName = "UMQuantita";
            this.UMQuantita.HeaderText = "UMQuantita";
            this.UMQuantita.Name = "UMQuantita";
            // 
            // PezziOrari
            // 
            this.PezziOrari.DataPropertyName = "PezziOrari";
            this.PezziOrari.HeaderText = "PezziOrari";
            this.PezziOrari.Name = "PezziOrari";
            // 
            // Periodo
            // 
            this.Periodo.DataPropertyName = "Periodo";
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.Name = "Periodo";
            // 
            // Setup
            // 
            this.Setup.DataPropertyName = "Setup";
            this.Setup.HeaderText = "Setup";
            this.Setup.Name = "Setup";
            // 
            // Attesa
            // 
            this.Attesa.DataPropertyName = "Attesa";
            this.Attesa.HeaderText = "Attesa";
            this.Attesa.Name = "Attesa";
            // 
            // Movimentazione
            // 
            this.Movimentazione.DataPropertyName = "Movimentazione";
            this.Movimentazione.HeaderText = "Movimentazione";
            this.Movimentazione.Name = "Movimentazione";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFase;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPadre;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDiba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anagrafica;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaProduzione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchedaProcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollegamentoDiba;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollegamentoCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn UMQuantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn PezziOrari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Setup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimentazione;
    }
}