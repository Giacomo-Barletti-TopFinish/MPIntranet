namespace DisegnaDiBa
{
    partial class SelezionaDistintaFrm
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
            this.dgvDistinte = new System.Windows.Forms.DataGridView();
            this.TipoDistinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Versione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistinte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDistinte
            // 
            this.dgvDistinte.AllowUserToAddRows = false;
            this.dgvDistinte.AllowUserToDeleteRows = false;
            this.dgvDistinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoDistinta,
            this.Versione,
            this.Descrizione});
            this.dgvDistinte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDistinte.Location = new System.Drawing.Point(0, 0);
            this.dgvDistinte.Name = "dgvDistinte";
            this.dgvDistinte.ReadOnly = true;
            this.dgvDistinte.Size = new System.Drawing.Size(471, 225);
            this.dgvDistinte.TabIndex = 0;
            this.dgvDistinte.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistinte_CellDoubleClick);
            // 
            // TipoDistinta
            // 
            this.TipoDistinta.DataPropertyName = "TipoDistinta";
            this.TipoDistinta.HeaderText = "Tipo distinta";
            this.TipoDistinta.Name = "TipoDistinta";
            this.TipoDistinta.ReadOnly = true;
            // 
            // Versione
            // 
            this.Versione.DataPropertyName = "Versione";
            this.Versione.HeaderText = "Versione";
            this.Versione.Name = "Versione";
            this.Versione.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.FillWeight = 200F;
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            this.Descrizione.Width = 200;
            // 
            // SelezionaDistintaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 225);
            this.Controls.Add(this.dgvDistinte);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelezionaDistintaFrm";
            this.Text = "SelezionaDistintaFrm";
            this.Load += new System.EventHandler(this.SelezionaDistintaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistinte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDistinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDistinta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Versione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
    }
}