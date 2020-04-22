namespace MPPreventivatore
{
    partial class TipologiaDocumentiFrm
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
            this.btnChiudi = new System.Windows.Forms.Button();
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTipologiaDocumenti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologiaDocumenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiudi.Location = new System.Drawing.Point(184, 303);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 32);
            this.btnChiudi.TabIndex = 11;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(108, 6);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 10;
            this.lblMessaggio.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tipologia prodotto";
            // 
            // dgvTipologiaDocumenti
            // 
            this.dgvTipologiaDocumenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipologiaDocumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipologiaDocumenti.Location = new System.Drawing.Point(12, 29);
            this.dgvTipologiaDocumenti.MultiSelect = false;
            this.dgvTipologiaDocumenti.Name = "dgvTipologiaDocumenti";
            this.dgvTipologiaDocumenti.Size = new System.Drawing.Size(418, 253);
            this.dgvTipologiaDocumenti.TabIndex = 8;
            this.dgvTipologiaDocumenti.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipologiaDocumenti_CellEndEdit);
            this.dgvTipologiaDocumenti.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTipologiaDocumenti_UserAddedRow);
            this.dgvTipologiaDocumenti.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTipologiaDocumenti_UserDeletingRow);
            // 
            // TipologiaDocumentiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 358);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTipologiaDocumenti);
            this.Name = "TipologiaDocumentiFrm";
            this.Text = "Tipologia documenti";
            this.Load += new System.EventHandler(this.TipologiaDocumentiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologiaDocumenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTipologiaDocumenti;
    }
}