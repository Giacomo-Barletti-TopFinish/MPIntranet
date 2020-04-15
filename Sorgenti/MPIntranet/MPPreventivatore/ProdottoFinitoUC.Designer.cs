namespace MPPreventivatore
{
    partial class ProdottoFinitoUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImmagine = new System.Windows.Forms.PictureBox();
            this.txtCodiceProvvisorio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipoProdotto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImmagine)).BeginInit();
            this.SuspendLayout();
            // 
            // picImmagine
            // 
            this.picImmagine.Location = new System.Drawing.Point(3, 9);
            this.picImmagine.Name = "picImmagine";
            this.picImmagine.Size = new System.Drawing.Size(120, 120);
            this.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImmagine.TabIndex = 0;
            this.picImmagine.TabStop = false;
            // 
            // txtCodiceProvvisorio
            // 
            this.txtCodiceProvvisorio.Location = new System.Drawing.Point(254, 107);
            this.txtCodiceProvvisorio.MaxLength = 15;
            this.txtCodiceProvvisorio.Name = "txtCodiceProvvisorio";
            this.txtCodiceProvvisorio.ReadOnly = true;
            this.txtCodiceProvvisorio.Size = new System.Drawing.Size(139, 20);
            this.txtCodiceProvvisorio.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Codice provvisorio";
            // 
            // txtCodiceDefinitivo
            // 
            this.txtCodiceDefinitivo.Location = new System.Drawing.Point(501, 107);
            this.txtCodiceDefinitivo.MaxLength = 15;
            this.txtCodiceDefinitivo.Name = "txtCodiceDefinitivo";
            this.txtCodiceDefinitivo.ReadOnly = true;
            this.txtCodiceDefinitivo.Size = new System.Drawing.Size(139, 20);
            this.txtCodiceDefinitivo.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Colore";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(234, 81);
            this.txtDescrizione.MaxLength = 80;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(406, 20);
            this.txtDescrizione.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Codice definitivo";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(438, 5);
            this.txtModello.MaxLength = 30;
            this.txtModello.Name = "txtModello";
            this.txtModello.ReadOnly = true;
            this.txtModello.Size = new System.Drawing.Size(202, 20);
            this.txtModello.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descrizione";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(205, 5);
            this.txtCodice.MaxLength = 10;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(169, 20);
            this.txtCodice.TabIndex = 15;
            this.txtCodice.Click += new System.EventHandler(this.txtCodice_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Modello";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Codice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(205, 29);
            this.txtBrand.MaxLength = 10;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.ReadOnly = true;
            this.txtBrand.Size = new System.Drawing.Size(169, 20);
            this.txtBrand.TabIndex = 15;
            // 
            // txtColore
            // 
            this.txtColore.Location = new System.Drawing.Point(438, 29);
            this.txtColore.MaxLength = 30;
            this.txtColore.Name = "txtColore";
            this.txtColore.ReadOnly = true;
            this.txtColore.Size = new System.Drawing.Size(202, 20);
            this.txtColore.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tipo prodotto";
            // 
            // txtTipoProdotto
            // 
            this.txtTipoProdotto.Location = new System.Drawing.Point(234, 55);
            this.txtTipoProdotto.MaxLength = 10;
            this.txtTipoProdotto.Name = "txtTipoProdotto";
            this.txtTipoProdotto.ReadOnly = true;
            this.txtTipoProdotto.Size = new System.Drawing.Size(406, 20);
            this.txtTipoProdotto.TabIndex = 15;
            // 
            // ProdottoFinitoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCodiceProvvisorio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodiceDefinitivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtColore);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipoProdotto);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImmagine);
            this.Name = "ProdottoFinitoUC";
            this.Size = new System.Drawing.Size(645, 139);
            this.Load += new System.EventHandler(this.ProdottoFinitoUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImmagine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImmagine;
        private System.Windows.Forms.TextBox txtCodiceProvvisorio;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTipoProdotto;
    }
}
