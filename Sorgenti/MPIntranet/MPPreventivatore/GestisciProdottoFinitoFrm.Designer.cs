namespace MPPreventivatore
{
    partial class GestisciProdottoFinitoFrm
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
            this.btnCerca = new System.Windows.Forms.Button();
            this.chkProduzione = new System.Windows.Forms.CheckBox();
            this.chkPreserie = new System.Windows.Forms.CheckBox();
            this.chkPreventivo = new System.Windows.Forms.CheckBox();
            this.ddlTipoProdotto = new System.Windows.Forms.ComboBox();
            this.ddlColore = new System.Windows.Forms.ComboBox();
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
            this.ddlBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuovoProdottoFinito = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(381, 125);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 35;
            this.lblMessaggio.Text = "label3";
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(976, 45);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(183, 34);
            this.btnCerca.TabIndex = 34;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // chkProduzione
            // 
            this.chkProduzione.AutoSize = true;
            this.chkProduzione.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkProduzione.Location = new System.Drawing.Point(811, 64);
            this.chkProduzione.Name = "chkProduzione";
            this.chkProduzione.Size = new System.Drawing.Size(64, 31);
            this.chkProduzione.TabIndex = 67;
            this.chkProduzione.Text = "Produzione";
            this.chkProduzione.UseVisualStyleBackColor = true;
            // 
            // chkPreserie
            // 
            this.chkPreserie.AutoSize = true;
            this.chkPreserie.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreserie.Location = new System.Drawing.Point(744, 64);
            this.chkPreserie.Name = "chkPreserie";
            this.chkPreserie.Size = new System.Drawing.Size(49, 31);
            this.chkPreserie.TabIndex = 66;
            this.chkPreserie.Text = "Preserie";
            this.chkPreserie.UseVisualStyleBackColor = true;
            // 
            // chkPreventivo
            // 
            this.chkPreventivo.AutoSize = true;
            this.chkPreventivo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPreventivo.Checked = true;
            this.chkPreventivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreventivo.Location = new System.Drawing.Point(667, 64);
            this.chkPreventivo.Name = "chkPreventivo";
            this.chkPreventivo.Size = new System.Drawing.Size(62, 31);
            this.chkPreventivo.TabIndex = 65;
            this.chkPreventivo.Text = "Preventivo";
            this.chkPreventivo.UseVisualStyleBackColor = true;
            // 
            // ddlTipoProdotto
            // 
            this.ddlTipoProdotto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoProdotto.FormattingEnabled = true;
            this.ddlTipoProdotto.Location = new System.Drawing.Point(442, 27);
            this.ddlTipoProdotto.Name = "ddlTipoProdotto";
            this.ddlTipoProdotto.Size = new System.Drawing.Size(260, 21);
            this.ddlTipoProdotto.TabIndex = 64;
            // 
            // ddlColore
            // 
            this.ddlColore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlColore.FormattingEnabled = true;
            this.ddlColore.Location = new System.Drawing.Point(12, 74);
            this.ddlColore.Name = "ddlColore";
            this.ddlColore.Size = new System.Drawing.Size(266, 21);
            this.ddlColore.TabIndex = 63;
            // 
            // txtCodiceProvvisorio
            // 
            this.txtCodiceProvvisorio.Location = new System.Drawing.Point(309, 75);
            this.txtCodiceProvvisorio.MaxLength = 15;
            this.txtCodiceProvvisorio.Name = "txtCodiceProvvisorio";
            this.txtCodiceProvvisorio.Size = new System.Drawing.Size(139, 20);
            this.txtCodiceProvvisorio.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Codice provvisorio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Tipo prodotto";
            // 
            // txtCodiceDefinitivo
            // 
            this.txtCodiceDefinitivo.Location = new System.Drawing.Point(483, 75);
            this.txtCodiceDefinitivo.MaxLength = 15;
            this.txtCodiceDefinitivo.Name = "txtCodiceDefinitivo";
            this.txtCodiceDefinitivo.Size = new System.Drawing.Size(139, 20);
            this.txtCodiceDefinitivo.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Colore";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(12, 121);
            this.txtDescrizione.MaxLength = 80;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(341, 20);
            this.txtDescrizione.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Codice definitivo";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(210, 28);
            this.txtModello.MaxLength = 30;
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(202, 20);
            this.txtModello.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Descrizione";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(12, 28);
            this.txtCodice.MaxLength = 10;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(169, 20);
            this.txtCodice.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Modello";
            // 
            // ddlBrand
            // 
            this.ddlBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrand.FormattingEnabled = true;
            this.ddlBrand.Location = new System.Drawing.Point(734, 27);
            this.ddlBrand.Name = "ddlBrand";
            this.ddlBrand.Size = new System.Drawing.Size(169, 21);
            this.ddlBrand.TabIndex = 60;
            this.ddlBrand.SelectedIndexChanged += new System.EventHandler(this.ddlBrand_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Codice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Brand";
            // 
            // btnNuovoProdottoFinito
            // 
            this.btnNuovoProdottoFinito.Location = new System.Drawing.Point(976, 92);
            this.btnNuovoProdottoFinito.Name = "btnNuovoProdottoFinito";
            this.btnNuovoProdottoFinito.Size = new System.Drawing.Size(183, 34);
            this.btnNuovoProdottoFinito.TabIndex = 34;
            this.btnNuovoProdottoFinito.Text = "Nuovo prodotto finito";
            this.btnNuovoProdottoFinito.UseVisualStyleBackColor = true;
            this.btnNuovoProdottoFinito.Click += new System.EventHandler(this.btnNuovoProdottoFinito_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 159);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1144, 490);
            this.tableLayoutPanel1.TabIndex = 69;
            // 
            // GestisciProdottoFinitoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.btnNuovoProdottoFinito);
            this.Controls.Add(this.btnCerca);
            this.Name = "GestisciProdottoFinitoFrm";
            this.Load += new System.EventHandler(this.GestisciProdottoFinitoFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.CheckBox chkProduzione;
        private System.Windows.Forms.CheckBox chkPreserie;
        private System.Windows.Forms.CheckBox chkPreventivo;
        private System.Windows.Forms.ComboBox ddlTipoProdotto;
        private System.Windows.Forms.ComboBox ddlColore;
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
        private System.Windows.Forms.ComboBox ddlBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuovoProdottoFinito;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}