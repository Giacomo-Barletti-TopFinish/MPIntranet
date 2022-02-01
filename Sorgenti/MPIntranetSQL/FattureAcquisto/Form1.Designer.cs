namespace FattureAcquisto
{
    partial class Form1
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
            this.ddlFornitori = new System.Windows.Forms.ComboBox();
            this.btnTrova = new System.Windows.Forms.Button();
            this.dgrRisultati = new System.Windows.Forms.DataGridView();
            this.IDDocumentoClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumentoClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceFornitoreClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FornitoreClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RiferimentoClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportoClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEsporta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRisultati)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fornitore";
            // 
            // ddlFornitori
            // 
            this.ddlFornitori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFornitori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFornitori.FormattingEnabled = true;
            this.ddlFornitori.Location = new System.Drawing.Point(116, 32);
            this.ddlFornitori.Margin = new System.Windows.Forms.Padding(4);
            this.ddlFornitori.Name = "ddlFornitori";
            this.ddlFornitori.Size = new System.Drawing.Size(313, 24);
            this.ddlFornitori.TabIndex = 1;
            // 
            // btnTrova
            // 
            this.btnTrova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrova.Location = new System.Drawing.Point(473, 29);
            this.btnTrova.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrova.Name = "btnTrova";
            this.btnTrova.Size = new System.Drawing.Size(232, 28);
            this.btnTrova.TabIndex = 2;
            this.btnTrova.Text = "Trova";
            this.btnTrova.UseVisualStyleBackColor = true;
            this.btnTrova.Click += new System.EventHandler(this.btnTrova_Click);
            // 
            // dgrRisultati
            // 
            this.dgrRisultati.AllowUserToAddRows = false;
            this.dgrRisultati.AllowUserToDeleteRows = false;
            this.dgrRisultati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRisultati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrRisultati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDocumentoClm,
            this.TipoDocumentoClm,
            this.CodiceFornitoreClm,
            this.FornitoreClm,
            this.RiferimentoClm,
            this.ImportoClm,
            this.DataClm});
            this.dgrRisultati.Location = new System.Drawing.Point(30, 94);
            this.dgrRisultati.MultiSelect = false;
            this.dgrRisultati.Name = "dgrRisultati";
            this.dgrRisultati.ReadOnly = true;
            this.dgrRisultati.Size = new System.Drawing.Size(613, 431);
            this.dgrRisultati.TabIndex = 3;
            // 
            // IDDocumentoClm
            // 
            this.IDDocumentoClm.DataPropertyName = "IDDocumento";
            this.IDDocumentoClm.HeaderText = "IDDocumento";
            this.IDDocumentoClm.Name = "IDDocumentoClm";
            this.IDDocumentoClm.ReadOnly = true;
            this.IDDocumentoClm.Visible = false;
            // 
            // TipoDocumentoClm
            // 
            this.TipoDocumentoClm.DataPropertyName = "TipoDocumento";
            this.TipoDocumentoClm.HeaderText = "TipoDocumentoClm";
            this.TipoDocumentoClm.Name = "TipoDocumentoClm";
            this.TipoDocumentoClm.ReadOnly = true;
            this.TipoDocumentoClm.Visible = false;
            // 
            // CodiceFornitoreClm
            // 
            this.CodiceFornitoreClm.DataPropertyName = "CodiceFornitore";
            this.CodiceFornitoreClm.HeaderText = "Fornitore";
            this.CodiceFornitoreClm.Name = "CodiceFornitoreClm";
            this.CodiceFornitoreClm.ReadOnly = true;
            this.CodiceFornitoreClm.Visible = false;
            // 
            // FornitoreClm
            // 
            this.FornitoreClm.DataPropertyName = "Fornitore";
            this.FornitoreClm.HeaderText = "Fornitore";
            this.FornitoreClm.Name = "FornitoreClm";
            this.FornitoreClm.ReadOnly = true;
            this.FornitoreClm.Visible = false;
            // 
            // RiferimentoClm
            // 
            this.RiferimentoClm.DataPropertyName = "Riferimento";
            this.RiferimentoClm.FillWeight = 250F;
            this.RiferimentoClm.HeaderText = "Riferimento";
            this.RiferimentoClm.Name = "RiferimentoClm";
            this.RiferimentoClm.ReadOnly = true;
            this.RiferimentoClm.Width = 250;
            // 
            // ImportoClm
            // 
            this.ImportoClm.DataPropertyName = "Importo";
            this.ImportoClm.FillWeight = 150F;
            this.ImportoClm.HeaderText = "Importo";
            this.ImportoClm.Name = "ImportoClm";
            this.ImportoClm.ReadOnly = true;
            this.ImportoClm.Width = 150;
            // 
            // DataClm
            // 
            this.DataClm.DataPropertyName = "Data";
            this.DataClm.FillWeight = 1550F;
            this.DataClm.HeaderText = "Data";
            this.DataClm.Name = "DataClm";
            this.DataClm.ReadOnly = true;
            this.DataClm.Width = 150;
            // 
            // btnEsporta
            // 
            this.btnEsporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsporta.Location = new System.Drawing.Point(650, 213);
            this.btnEsporta.Margin = new System.Windows.Forms.Padding(4);
            this.btnEsporta.Name = "btnEsporta";
            this.btnEsporta.Size = new System.Drawing.Size(141, 53);
            this.btnEsporta.TabIndex = 4;
            this.btnEsporta.Text = "Esporta";
            this.btnEsporta.UseVisualStyleBackColor = true;
            this.btnEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 554);
            this.Controls.Add(this.btnEsporta);
            this.Controls.Add(this.dgrRisultati);
            this.Controls.Add(this.btnTrova);
            this.Controls.Add(this.ddlFornitori);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Fatture Acquisto";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrRisultati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlFornitori;
        private System.Windows.Forms.Button btnTrova;
        private System.Windows.Forms.DataGridView dgrRisultati;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDocumentoClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumentoClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceFornitoreClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FornitoreClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RiferimentoClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportoClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataClm;
        private System.Windows.Forms.Button btnEsporta;
    }
}

