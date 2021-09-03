namespace DisegnaDiBa
{
    partial class NuovoArticoloFrm
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
            this.ddlBrands = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnagrafica = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodiceCliente = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCreaArticolo = new System.Windows.Forms.Button();
            this.dgvArticoli = new System.Windows.Forms.DataGridView();
            this.IdArticoloColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anagrafica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiceCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancellato = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnTrovaArticolo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoli)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand";
            // 
            // ddlBrands
            // 
            this.ddlBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBrands.FormattingEnabled = true;
            this.ddlBrands.Location = new System.Drawing.Point(145, 20);
            this.ddlBrands.Name = "ddlBrands";
            this.ddlBrands.Size = new System.Drawing.Size(152, 23);
            this.ddlBrands.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrizione.Location = new System.Drawing.Point(442, 20);
            this.txtDescrizione.MaxLength = 50;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(240, 21);
            this.txtDescrizione.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Anagrafica";
            // 
            // txtAnagrafica
            // 
            this.txtAnagrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnagrafica.Location = new System.Drawing.Point(145, 65);
            this.txtAnagrafica.MaxLength = 20;
            this.txtAnagrafica.Name = "txtAnagrafica";
            this.txtAnagrafica.Size = new System.Drawing.Size(152, 21);
            this.txtAnagrafica.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Colore";
            // 
            // txtColore
            // 
            this.txtColore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColore.Location = new System.Drawing.Point(442, 62);
            this.txtColore.MaxLength = 15;
            this.txtColore.Name = "txtColore";
            this.txtColore.Size = new System.Drawing.Size(240, 21);
            this.txtColore.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Codice cliente";
            // 
            // txtCodiceCliente
            // 
            this.txtCodiceCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodiceCliente.Location = new System.Drawing.Point(145, 109);
            this.txtCodiceCliente.MaxLength = 20;
            this.txtCodiceCliente.Name = "txtCodiceCliente";
            this.txtCodiceCliente.Size = new System.Drawing.Size(152, 21);
            this.txtCodiceCliente.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(142, 148);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 15);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "label1";
            // 
            // btnCreaArticolo
            // 
            this.btnCreaArticolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreaArticolo.Location = new System.Drawing.Point(593, 100);
            this.btnCreaArticolo.Name = "btnCreaArticolo";
            this.btnCreaArticolo.Size = new System.Drawing.Size(89, 30);
            this.btnCreaArticolo.TabIndex = 7;
            this.btnCreaArticolo.Text = "Crea articolo";
            this.btnCreaArticolo.UseVisualStyleBackColor = true;
            this.btnCreaArticolo.Click += new System.EventHandler(this.btnCreaArticolo_Click);
            // 
            // dgvArticoli
            // 
            this.dgvArticoli.AllowUserToAddRows = false;
            this.dgvArticoli.AllowUserToDeleteRows = false;
            this.dgvArticoli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticoli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdArticoloColumn,
            this.Brand,
            this.Descrizione,
            this.Colore,
            this.Anagrafica,
            this.CodiceCliente});
            this.dgvArticoli.Location = new System.Drawing.Point(12, 179);
            this.dgvArticoli.Name = "dgvArticoli";
            this.dgvArticoli.ReadOnly = true;
            this.dgvArticoli.Size = new System.Drawing.Size(708, 125);
            this.dgvArticoli.TabIndex = 4;
            this.dgvArticoli.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticoli_CellDoubleClick);
            // 
            // IdArticoloColumn
            // 
            this.IdArticoloColumn.DataPropertyName = "IdArticolo";
            this.IdArticoloColumn.HeaderText = "idarticolo";
            this.IdArticoloColumn.Name = "IdArticoloColumn";
            this.IdArticoloColumn.ReadOnly = true;
            this.IdArticoloColumn.Visible = false;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.FillWeight = 180F;
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            this.Descrizione.Width = 180;
            // 
            // Colore
            // 
            this.Colore.DataPropertyName = "Colore";
            this.Colore.HeaderText = "Colore";
            this.Colore.Name = "Colore";
            this.Colore.ReadOnly = true;
            // 
            // Anagrafica
            // 
            this.Anagrafica.DataPropertyName = "Anagrafica";
            this.Anagrafica.HeaderText = "Anagrafica";
            this.Anagrafica.Name = "Anagrafica";
            this.Anagrafica.ReadOnly = true;
            // 
            // CodiceCliente
            // 
            this.CodiceCliente.DataPropertyName = "CodiceCliente";
            this.CodiceCliente.HeaderText = "Codice cliente";
            this.CodiceCliente.Name = "CodiceCliente";
            this.CodiceCliente.ReadOnly = true;
            // 
            // BrandColumn
            // 
            this.BrandColumn.DataPropertyName = "Brand";
            this.BrandColumn.HeaderText = "Brand";
            this.BrandColumn.Name = "BrandColumn";
            // 
            // Cancellato
            // 
            this.Cancellato.HeaderText = "Cancellato";
            this.Cancellato.Name = "Cancellato";
            // 
            // btnTrovaArticolo
            // 
            this.btnTrovaArticolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrovaArticolo.Location = new System.Drawing.Point(442, 100);
            this.btnTrovaArticolo.Name = "btnTrovaArticolo";
            this.btnTrovaArticolo.Size = new System.Drawing.Size(89, 30);
            this.btnTrovaArticolo.TabIndex = 6;
            this.btnTrovaArticolo.Text = "Trova articolo";
            this.btnTrovaArticolo.UseVisualStyleBackColor = true;
            this.btnTrovaArticolo.Click += new System.EventHandler(this.btnTrovaArticolo_Click);
            // 
            // NuovoArticoloFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 316);
            this.Controls.Add(this.dgvArticoli);
            this.Controls.Add(this.btnTrovaArticolo);
            this.Controls.Add(this.btnCreaArticolo);
            this.Controls.Add(this.txtCodiceCliente);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtColore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAnagrafica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlBrands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuovoArticoloFrm";
            this.Text = "Trova articolo";
            this.Load += new System.EventHandler(this.NuovoArticoloFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticoli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBrands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnagrafica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodiceCliente;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCreaArticolo;
        private System.Windows.Forms.DataGridView dgvArticoli;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancellato;
        private System.Windows.Forms.Button btnTrovaArticolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArticoloColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anagrafica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiceCliente;
    }
}