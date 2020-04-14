namespace MPPreventivatore
{
    partial class ProdottoFinitoFrm
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
            this.chkProduzione = new System.Windows.Forms.CheckBox();
            this.chkPreserie = new System.Windows.Forms.CheckBox();
            this.chkPreventivo = new System.Windows.Forms.CheckBox();
            this.txtCodiceProvvisorio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodiceDefinitivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtColore = new System.Windows.Forms.TextBox();
            this.txtTipoProdotto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalvaModifiche = new System.Windows.Forms.Button();
            this.btnCopiaProdotto = new System.Windows.Forms.Button();
            this.txtNuovoDocumento = new System.Windows.Forms.TextBox();
            this.btnCerca = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.dgvDocumenti = new System.Windows.Forms.DataGridView();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.ddlTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumenti)).BeginInit();
            this.SuspendLayout();
            // 
            // chkProduzione
            // 
            this.chkProduzione.AutoSize = true;
            this.chkProduzione.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkProduzione.Location = new System.Drawing.Point(762, 149);
            this.chkProduzione.Name = "chkProduzione";
            this.chkProduzione.Size = new System.Drawing.Size(74, 33);
            this.chkProduzione.TabIndex = 9;
            this.chkProduzione.Text = "Produzione";
            this.chkProduzione.UseVisualStyleBackColor = true;
            // 
            // chkPreserie
            // 
            this.chkPreserie.AutoSize = true;
            this.chkPreserie.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreserie.Location = new System.Drawing.Point(848, 149);
            this.chkPreserie.Name = "chkPreserie";
            this.chkPreserie.Size = new System.Drawing.Size(57, 33);
            this.chkPreserie.TabIndex = 10;
            this.chkPreserie.Text = "Preserie";
            this.chkPreserie.UseVisualStyleBackColor = true;
            // 
            // chkPreventivo
            // 
            this.chkPreventivo.AutoSize = true;
            this.chkPreventivo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreventivo.Checked = true;
            this.chkPreventivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreventivo.Location = new System.Drawing.Point(684, 149);
            this.chkPreventivo.Name = "chkPreventivo";
            this.chkPreventivo.Size = new System.Drawing.Size(67, 33);
            this.chkPreventivo.TabIndex = 8;
            this.chkPreventivo.Text = "Preventivo";
            this.chkPreventivo.UseVisualStyleBackColor = true;
            // 
            // txtCodiceProvvisorio
            // 
            this.txtCodiceProvvisorio.Location = new System.Drawing.Point(245, 98);
            this.txtCodiceProvvisorio.MaxLength = 15;
            this.txtCodiceProvvisorio.Name = "txtCodiceProvvisorio";
            this.txtCodiceProvvisorio.Size = new System.Drawing.Size(161, 21);
            this.txtCodiceProvvisorio.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Codice provvisorio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tipo prodotto";
            // 
            // txtCodiceDefinitivo
            // 
            this.txtCodiceDefinitivo.Location = new System.Drawing.Point(516, 98);
            this.txtCodiceDefinitivo.MaxLength = 15;
            this.txtCodiceDefinitivo.Name = "txtCodiceDefinitivo";
            this.txtCodiceDefinitivo.Size = new System.Drawing.Size(161, 21);
            this.txtCodiceDefinitivo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Colore";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(514, 33);
            this.txtDescrizione.MaxLength = 80;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(397, 21);
            this.txtDescrizione.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Codice definitivo";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(245, 33);
            this.txtModello.MaxLength = 30;
            this.txtModello.Name = "txtModello";
            this.txtModello.ReadOnly = true;
            this.txtModello.Size = new System.Drawing.Size(235, 21);
            this.txtModello.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Descrizione";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(17, 33);
            this.txtCodice.MaxLength = 10;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(196, 21);
            this.txtCodice.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Modello";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Codice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(17, 92);
            this.txtBrand.MaxLength = 10;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.ReadOnly = true;
            this.txtBrand.Size = new System.Drawing.Size(196, 21);
            this.txtBrand.TabIndex = 3;
            // 
            // txtColore
            // 
            this.txtColore.Location = new System.Drawing.Point(17, 162);
            this.txtColore.MaxLength = 10;
            this.txtColore.Name = "txtColore";
            this.txtColore.ReadOnly = true;
            this.txtColore.Size = new System.Drawing.Size(327, 21);
            this.txtColore.TabIndex = 6;
            // 
            // txtTipoProdotto
            // 
            this.txtTipoProdotto.Location = new System.Drawing.Point(356, 162);
            this.txtTipoProdotto.MaxLength = 10;
            this.txtTipoProdotto.Name = "txtTipoProdotto";
            this.txtTipoProdotto.ReadOnly = true;
            this.txtTipoProdotto.Size = new System.Drawing.Size(327, 21);
            this.txtTipoProdotto.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Documento";
            // 
            // btnSalvaModifiche
            // 
            this.btnSalvaModifiche.Location = new System.Drawing.Point(8, 204);
            this.btnSalvaModifiche.Name = "btnSalvaModifiche";
            this.btnSalvaModifiche.Size = new System.Drawing.Size(112, 35);
            this.btnSalvaModifiche.TabIndex = 11;
            this.btnSalvaModifiche.Text = "Salva modifiche";
            this.btnSalvaModifiche.UseVisualStyleBackColor = true;
            this.btnSalvaModifiche.Click += new System.EventHandler(this.btnSalvaModifiche_Click);
            // 
            // btnCopiaProdotto
            // 
            this.btnCopiaProdotto.Location = new System.Drawing.Point(355, 204);
            this.btnCopiaProdotto.Name = "btnCopiaProdotto";
            this.btnCopiaProdotto.Size = new System.Drawing.Size(112, 35);
            this.btnCopiaProdotto.TabIndex = 13;
            this.btnCopiaProdotto.Text = "Copia prodotto";
            this.btnCopiaProdotto.UseVisualStyleBackColor = true;
            this.btnCopiaProdotto.Click += new System.EventHandler(this.btnCopiaProdotto_Click);
            // 
            // txtNuovoDocumento
            // 
            this.txtNuovoDocumento.Location = new System.Drawing.Point(98, 273);
            this.txtNuovoDocumento.MaxLength = 15;
            this.txtNuovoDocumento.Name = "txtNuovoDocumento";
            this.txtNuovoDocumento.Size = new System.Drawing.Size(253, 21);
            this.txtNuovoDocumento.TabIndex = 14;
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(368, 266);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(112, 35);
            this.btnCerca.TabIndex = 15;
            this.btnCerca.Text = "Cerca...";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(790, 267);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(112, 35);
            this.btnAggiungi.TabIndex = 16;
            this.btnAggiungi.Text = "Aggiungi...";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // dgvDocumenti
            // 
            this.dgvDocumenti.AllowUserToAddRows = false;
            this.dgvDocumenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumenti.Location = new System.Drawing.Point(17, 318);
            this.dgvDocumenti.Name = "dgvDocumenti";
            this.dgvDocumenti.ReadOnly = true;
            this.dgvDocumenti.Size = new System.Drawing.Size(895, 271);
            this.dgvDocumenti.TabIndex = 17;
            this.dgvDocumenti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumenti_CellDoubleClick);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Location = new System.Drawing.Point(143, 204);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(112, 35);
            this.btnChiudi.TabIndex = 12;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(11, 247);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 36;
            this.lblMessaggio.Text = "label3";
            // 
            // ddlTipoDocumento
            // 
            this.ddlTipoDocumento.FormattingEnabled = true;
            this.ddlTipoDocumento.Location = new System.Drawing.Point(607, 272);
            this.ddlTipoDocumento.Name = "ddlTipoDocumento";
            this.ddlTipoDocumento.Size = new System.Drawing.Size(177, 23);
            this.ddlTipoDocumento.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Tipo documento";
            // 
            // ProdottoFinitoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 603);
            this.Controls.Add(this.ddlTipoDocumento);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.dgvDocumenti);
            this.Controls.Add(this.btnCopiaProdotto);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnSalvaModifiche);
            this.Controls.Add(this.txtTipoProdotto);
            this.Controls.Add(this.txtColore);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.chkProduzione);
            this.Controls.Add(this.chkPreserie);
            this.Controls.Add(this.chkPreventivo);
            this.Controls.Add(this.txtNuovoDocumento);
            this.Controls.Add(this.txtCodiceProvvisorio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCodiceDefinitivo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdottoFinitoFrm";
            this.Text = "Prodotto finito";
            this.Load += new System.EventHandler(this.ProdottoFinitoFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkProduzione;
        private System.Windows.Forms.CheckBox chkPreserie;
        private System.Windows.Forms.CheckBox chkPreventivo;
        private System.Windows.Forms.TextBox txtCodiceProvvisorio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodiceDefinitivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtColore;
        private System.Windows.Forms.TextBox txtTipoProdotto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalvaModifiche;
        private System.Windows.Forms.Button btnCopiaProdotto;
        private System.Windows.Forms.TextBox txtNuovoDocumento;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.DataGridView dgvDocumenti;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.ComboBox ddlTipoDocumento;
        private System.Windows.Forms.Label label10;
    }
}