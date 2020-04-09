namespace MPPreventivatore
{
    partial class TipologiaArticoliFrm
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
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTipologiaArticoli = new System.Windows.Forms.DataGridView();
            this.btnChiudi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologiaArticoli)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(108, 10);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 6;
            this.lblMessaggio.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipologia prodotto";
            // 
            // dgvTipologiaArticoli
            // 
            this.dgvTipologiaArticoli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipologiaArticoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipologiaArticoli.Location = new System.Drawing.Point(12, 33);
            this.dgvTipologiaArticoli.MultiSelect = false;
            this.dgvTipologiaArticoli.Name = "dgvTipologiaArticoli";
            this.dgvTipologiaArticoli.Size = new System.Drawing.Size(738, 253);
            this.dgvTipologiaArticoli.TabIndex = 4;
            this.dgvTipologiaArticoli.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipologiaArticoli_CellEndEdit);
            this.dgvTipologiaArticoli.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvTipologiaArticoli_UserAddedRow);
            this.dgvTipologiaArticoli.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTipologiaArticoli_UserDeletingRow);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Location = new System.Drawing.Point(344, 307);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 32);
            this.btnChiudi.TabIndex = 7;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // TipologiaArticoliFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 356);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTipologiaArticoli);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipologiaArticoliFrm";
            this.Text = "Tipologia articoli";
            this.Load += new System.EventHandler(this.TipologiaArticoliFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologiaArticoli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTipologiaArticoli;
        private System.Windows.Forms.Button btnChiudi;
    }
}