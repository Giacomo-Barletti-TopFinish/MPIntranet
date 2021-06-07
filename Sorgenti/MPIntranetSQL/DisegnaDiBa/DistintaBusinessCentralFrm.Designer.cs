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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNodi = new System.Windows.Forms.DataGridView();
            this.IdFase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Errore = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtVersioneDiba = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescrizioneDiba = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoDiba = new System.Windows.Forms.TextBox();
            this.btnCercaDiBa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticolo = new System.Windows.Forms.TextBox();
            this.tvDiBa = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).BeginInit();
            this.SuspendLayout();
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
            this.Errore,
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
            this.dgvNodi.Location = new System.Drawing.Point(574, 53);
            this.dgvNodi.Name = "dgvNodi";
            this.dgvNodi.Size = new System.Drawing.Size(1108, 838);
            this.dgvNodi.TabIndex = 5;
            // 
            // IdFase
            // 
            this.IdFase.DataPropertyName = "IdFaseDiba";
            this.IdFase.FillWeight = 60F;
            this.IdFase.HeaderText = "ID";
            this.IdFase.Name = "IdFase";
            this.IdFase.Width = 60;
            // 
            // Errore
            // 
            this.Errore.DataPropertyName = "Errore";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.Errore.DefaultCellStyle = dataGridViewCellStyle4;
            this.Errore.HeaderText = "Errore";
            this.Errore.Name = "Errore";
            this.Errore.ReadOnly = true;
            // 
            // IdPadre
            // 
            this.IdPadre.DataPropertyName = "IdPadre";
            this.IdPadre.HeaderText = "IdPadre";
            this.IdPadre.Name = "IdPadre";
            this.IdPadre.Visible = false;
            // 
            // IdDiba
            // 
            this.IdDiba.DataPropertyName = "IdDiba";
            this.IdDiba.HeaderText = "IdDiba";
            this.IdDiba.Name = "IdDiba";
            this.IdDiba.Visible = false;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.FillWeight = 150F;
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.Width = 150;
            // 
            // Anagrafica
            // 
            this.Anagrafica.DataPropertyName = "Anagrafica";
            this.Anagrafica.FillWeight = 130F;
            this.Anagrafica.HeaderText = "Anagrafica";
            this.Anagrafica.Name = "Anagrafica";
            this.Anagrafica.Width = 130;
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
            this.Quantita.FillWeight = 60F;
            this.Quantita.HeaderText = "Quantita";
            this.Quantita.Name = "Quantita";
            this.Quantita.Width = 60;
            // 
            // UMQuantita
            // 
            this.UMQuantita.DataPropertyName = "UMQuantita";
            this.UMQuantita.FillWeight = 70F;
            this.UMQuantita.HeaderText = "UMQuantita";
            this.UMQuantita.Name = "UMQuantita";
            this.UMQuantita.Width = 70;
            // 
            // PezziOrari
            // 
            this.PezziOrari.DataPropertyName = "PezziOrari";
            this.PezziOrari.FillWeight = 60F;
            this.PezziOrari.HeaderText = "PezziOrari";
            this.PezziOrari.Name = "PezziOrari";
            this.PezziOrari.Width = 60;
            // 
            // Periodo
            // 
            this.Periodo.DataPropertyName = "Periodo";
            this.Periodo.FillWeight = 60F;
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.Name = "Periodo";
            this.Periodo.Width = 60;
            // 
            // Setup
            // 
            this.Setup.DataPropertyName = "Setup";
            this.Setup.FillWeight = 60F;
            this.Setup.HeaderText = "Setup";
            this.Setup.Name = "Setup";
            this.Setup.Width = 60;
            // 
            // Attesa
            // 
            this.Attesa.DataPropertyName = "Attesa";
            this.Attesa.FillWeight = 60F;
            this.Attesa.HeaderText = "Attesa";
            this.Attesa.Name = "Attesa";
            this.Attesa.Width = 60;
            // 
            // Movimentazione
            // 
            this.Movimentazione.DataPropertyName = "Movimentazione";
            this.Movimentazione.HeaderText = "Movimentazione";
            this.Movimentazione.Name = "Movimentazione";
            // 
            // txtVersioneDiba
            // 
            this.txtVersioneDiba.Location = new System.Drawing.Point(1037, 14);
            this.txtVersioneDiba.Name = "txtVersioneDiba";
            this.txtVersioneDiba.ReadOnly = true;
            this.txtVersioneDiba.Size = new System.Drawing.Size(73, 20);
            this.txtVersioneDiba.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(975, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Versione";
            // 
            // txtDescrizioneDiba
            // 
            this.txtDescrizioneDiba.Location = new System.Drawing.Point(1188, 14);
            this.txtDescrizioneDiba.Name = "txtDescrizioneDiba";
            this.txtDescrizioneDiba.ReadOnly = true;
            this.txtDescrizioneDiba.Size = new System.Drawing.Size(470, 20);
            this.txtDescrizioneDiba.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1121, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Descrizione";
            // 
            // txtTipoDiba
            // 
            this.txtTipoDiba.Location = new System.Drawing.Point(681, 14);
            this.txtTipoDiba.Name = "txtTipoDiba";
            this.txtTipoDiba.ReadOnly = true;
            this.txtTipoDiba.Size = new System.Drawing.Size(279, 20);
            this.txtTipoDiba.TabIndex = 26;
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
            this.txtArticolo.Name = "txtArticolo";
            this.txtArticolo.ReadOnly = true;
            this.txtArticolo.Size = new System.Drawing.Size(204, 20);
            this.txtArticolo.TabIndex = 22;
            // 
            // tvDiBa
            // 
            this.tvDiBa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvDiBa.Location = new System.Drawing.Point(8, 53);
            this.tvDiBa.Name = "tvDiBa";
            this.tvDiBa.Size = new System.Drawing.Size(534, 838);
            this.tvDiBa.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo";
            // 
            // DistintaBusinessCentralFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 932);
            this.Controls.Add(this.dgvNodi);
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
            this.Name = "DistintaBusinessCentralFrm";
            this.Text = "DistintaBusinessCentralFrm";
            this.Load += new System.EventHandler(this.DistintaBusinessCentralFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvNodi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Errore;
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
        private System.Windows.Forms.TextBox txtVersioneDiba;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescrizioneDiba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoDiba;
        private System.Windows.Forms.Button btnCercaDiBa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArticolo;
        private System.Windows.Forms.TreeView tvDiBa;
        private System.Windows.Forms.Label label2;
    }
}