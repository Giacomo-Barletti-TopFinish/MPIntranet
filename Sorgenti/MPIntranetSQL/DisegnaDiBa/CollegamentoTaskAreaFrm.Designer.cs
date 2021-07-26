namespace DisegnaDiBa
{
    partial class CollegamentoTaskAreaFrm
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
            this.dgvTaskArea = new System.Windows.Forms.DataGridView();
            this.clmIdTaskArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAreaProduzione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPezziPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUtenteModifica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalvaModifiche = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskArea)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaskArea
            // 
            this.dgvTaskArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaskArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdTaskArea,
            this.clmTask,
            this.clmAreaProduzione,
            this.clmPezziPeriodo,
            this.clmPeriodo,
            this.clmUtenteModifica});
            this.dgvTaskArea.Location = new System.Drawing.Point(0, 0);
            this.dgvTaskArea.Name = "dgvTaskArea";
            this.dgvTaskArea.Size = new System.Drawing.Size(602, 386);
            this.dgvTaskArea.TabIndex = 0;
            this.dgvTaskArea.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaskArea_CellEndEdit);
            this.dgvTaskArea.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTaskArea_NewRowNeeded);
            this.dgvTaskArea.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTaskArea_RowsAdded);
            this.dgvTaskArea.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTaskArea_RowsRemoved);
            // 
            // clmIdTaskArea
            // 
            this.clmIdTaskArea.DataPropertyName = "IdTaskArea";
            this.clmIdTaskArea.HeaderText = "ID Task Area";
            this.clmIdTaskArea.Name = "clmIdTaskArea";
            this.clmIdTaskArea.Visible = false;
            // 
            // clmTask
            // 
            this.clmTask.DataPropertyName = "Task";
            this.clmTask.FillWeight = 150F;
            this.clmTask.HeaderText = "Task";
            this.clmTask.MaxInputLength = 10;
            this.clmTask.Name = "clmTask";
            this.clmTask.Width = 150;
            // 
            // clmAreaProduzione
            // 
            this.clmAreaProduzione.DataPropertyName = "AreaProduzione";
            this.clmAreaProduzione.FillWeight = 150F;
            this.clmAreaProduzione.HeaderText = "Area Produzione";
            this.clmAreaProduzione.MaxInputLength = 20;
            this.clmAreaProduzione.Name = "clmAreaProduzione";
            this.clmAreaProduzione.Width = 150;
            // 
            // clmPezziPeriodo
            // 
            this.clmPezziPeriodo.DataPropertyName = "PezziPeriodo";
            this.clmPezziPeriodo.HeaderText = "Pezzi Periodo";
            this.clmPezziPeriodo.Name = "clmPezziPeriodo";
            // 
            // clmPeriodo
            // 
            this.clmPeriodo.DataPropertyName = "Periodo";
            this.clmPeriodo.HeaderText = "Periodo";
            this.clmPeriodo.Name = "clmPeriodo";
            // 
            // clmUtenteModifica
            // 
            this.clmUtenteModifica.DataPropertyName = "UtenteModifica";
            this.clmUtenteModifica.HeaderText = "UtenteModifica";
            this.clmUtenteModifica.Name = "clmUtenteModifica";
            this.clmUtenteModifica.Visible = false;
            // 
            // btnSalvaModifiche
            // 
            this.btnSalvaModifiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalvaModifiche.Location = new System.Drawing.Point(199, 392);
            this.btnSalvaModifiche.Name = "btnSalvaModifiche";
            this.btnSalvaModifiche.Size = new System.Drawing.Size(157, 23);
            this.btnSalvaModifiche.TabIndex = 1;
            this.btnSalvaModifiche.Text = "Salva modifiche";
            this.btnSalvaModifiche.UseVisualStyleBackColor = true;
            this.btnSalvaModifiche.Click += new System.EventHandler(this.btnSalvaModifiche_Click);
            // 
            // CollegamentoTaskAreaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 421);
            this.Controls.Add(this.btnSalvaModifiche);
            this.Controls.Add(this.dgvTaskArea);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollegamentoTaskAreaFrm";
            this.Text = "Collegamento task area";
            this.Load += new System.EventHandler(this.CollegamentoTaskAreaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaskArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdTaskArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAreaProduzione;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPezziPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUtenteModifica;
        private System.Windows.Forms.Button btnSalvaModifiche;
    }
}