namespace MPPreventivatore
{
    partial class CreaProdottoFinitoFrm
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
            this.ddlBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodiceDefinitivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodiceProvvisorio = new System.Windows.Forms.TextBox();
            this.ddlColore = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlTipoProdotto = new System.Windows.Forms.ComboBox();
            this.chkPreventivo = new System.Windows.Forms.CheckBox();
            this.chkPreserie = new System.Windows.Forms.CheckBox();
            this.chkProduzione = new System.Windows.Forms.CheckBox();
            this.btnEsci = new System.Windows.Forms.Button();
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.btnCreaNuovo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand";
            // 
            // ddlBrand
            // 
            this.ddlBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrand.FormattingEnabled = true;
            this.ddlBrand.Location = new System.Drawing.Point(12, 92);
            this.ddlBrand.Name = "ddlBrand";
            this.ddlBrand.Size = new System.Drawing.Size(169, 23);
            this.ddlBrand.TabIndex = 3;
            this.ddlBrand.SelectedIndexChanged += new System.EventHandler(this.ddlBrand_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codice";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(12, 38);
            this.txtCodice.MaxLength = 10;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(169, 21);
            this.txtCodice.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Modello";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(210, 38);
            this.txtModello.MaxLength = 30;
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(202, 21);
            this.txtModello.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(441, 38);
            this.txtDescrizione.MaxLength = 80;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(341, 21);
            this.txtDescrizione.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Codice definitivo";
            // 
            // txtCodiceDefinitivo
            // 
            this.txtCodiceDefinitivo.Location = new System.Drawing.Point(442, 94);
            this.txtCodiceDefinitivo.MaxLength = 15;
            this.txtCodiceDefinitivo.Name = "txtCodiceDefinitivo";
            this.txtCodiceDefinitivo.Size = new System.Drawing.Size(139, 21);
            this.txtCodiceDefinitivo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Colore";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Codice provvisorio";
            // 
            // txtCodiceProvvisorio
            // 
            this.txtCodiceProvvisorio.Location = new System.Drawing.Point(210, 94);
            this.txtCodiceProvvisorio.MaxLength = 15;
            this.txtCodiceProvvisorio.Name = "txtCodiceProvvisorio";
            this.txtCodiceProvvisorio.Size = new System.Drawing.Size(139, 21);
            this.txtCodiceProvvisorio.TabIndex = 4;
            // 
            // ddlColore
            // 
            this.ddlColore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlColore.FormattingEnabled = true;
            this.ddlColore.Location = new System.Drawing.Point(12, 148);
            this.ddlColore.Name = "ddlColore";
            this.ddlColore.Size = new System.Drawing.Size(250, 23);
            this.ddlColore.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tipo prodotto";
            // 
            // ddlTipoProdotto
            // 
            this.ddlTipoProdotto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoProdotto.FormattingEnabled = true;
            this.ddlTipoProdotto.Location = new System.Drawing.Point(302, 148);
            this.ddlTipoProdotto.Name = "ddlTipoProdotto";
            this.ddlTipoProdotto.Size = new System.Drawing.Size(269, 23);
            this.ddlTipoProdotto.TabIndex = 7;
            // 
            // chkPreventivo
            // 
            this.chkPreventivo.AutoSize = true;
            this.chkPreventivo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreventivo.Checked = true;
            this.chkPreventivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreventivo.Location = new System.Drawing.Point(586, 138);
            this.chkPreventivo.Name = "chkPreventivo";
            this.chkPreventivo.Size = new System.Drawing.Size(67, 33);
            this.chkPreventivo.TabIndex = 8;
            this.chkPreventivo.Text = "Preventivo";
            this.chkPreventivo.UseVisualStyleBackColor = true;
            // 
            // chkPreserie
            // 
            this.chkPreserie.AutoSize = true;
            this.chkPreserie.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreserie.Location = new System.Drawing.Point(727, 138);
            this.chkPreserie.Name = "chkPreserie";
            this.chkPreserie.Size = new System.Drawing.Size(57, 33);
            this.chkPreserie.TabIndex = 9;
            this.chkPreserie.Text = "Preserie";
            this.chkPreserie.UseVisualStyleBackColor = true;
            // 
            // chkProduzione
            // 
            this.chkProduzione.AutoSize = true;
            this.chkProduzione.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkProduzione.Location = new System.Drawing.Point(653, 138);
            this.chkProduzione.Name = "chkProduzione";
            this.chkProduzione.Size = new System.Drawing.Size(74, 33);
            this.chkProduzione.TabIndex = 10;
            this.chkProduzione.Text = "Produzione";
            this.chkProduzione.UseVisualStyleBackColor = true;
            // 
            // btnEsci
            // 
            this.btnEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsci.Location = new System.Drawing.Point(210, 207);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.Size = new System.Drawing.Size(106, 36);
            this.btnEsci.TabIndex = 12;
            this.btnEsci.Text = "Esci";
            this.btnEsci.UseVisualStyleBackColor = true;
            this.btnEsci.Click += new System.EventHandler(this.btnEsci_Click);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(339, 217);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 6;
            this.lblMessaggio.Text = "label3";
            // 
            // btnCreaNuovo
            // 
            this.btnCreaNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreaNuovo.Location = new System.Drawing.Point(12, 207);
            this.btnCreaNuovo.Name = "btnCreaNuovo";
            this.btnCreaNuovo.Size = new System.Drawing.Size(106, 36);
            this.btnCreaNuovo.TabIndex = 11;
            this.btnCreaNuovo.Text = "Crea nuovo";
            this.btnCreaNuovo.UseVisualStyleBackColor = true;
            this.btnCreaNuovo.Click += new System.EventHandler(this.btnCreaNuovo_Click);
            // 
            // CreaProdottoFinitoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 263);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.btnCreaNuovo);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.chkProduzione);
            this.Controls.Add(this.chkPreserie);
            this.Controls.Add(this.chkPreventivo);
            this.Controls.Add(this.ddlTipoProdotto);
            this.Controls.Add(this.ddlColore);
            this.Controls.Add(this.txtCodiceProvvisorio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCodiceDefinitivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreaProdottoFinitoFrm";
            this.Text = "Crea prodotto finito";
            this.Load += new System.EventHandler(this.CreaProdottoFinitoFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodiceDefinitivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodiceProvvisorio;
        private System.Windows.Forms.ComboBox ddlColore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlTipoProdotto;
        private System.Windows.Forms.CheckBox chkPreventivo;
        private System.Windows.Forms.CheckBox chkPreserie;
        private System.Windows.Forms.CheckBox chkProduzione;
        private System.Windows.Forms.Button btnEsci;
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Button btnCreaNuovo;
    }
}