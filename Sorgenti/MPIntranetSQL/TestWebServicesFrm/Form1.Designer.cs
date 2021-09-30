namespace TestWebServicesFrm
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
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.txtDistintaNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApriDistinta = new System.Windows.Forms.Button();
            this.btnEstraiRigheDiba = new System.Windows.Forms.Button();
            this.btnDistintaInSviluppo = new System.Windows.Forms.Button();
            this.btnDistintaCertificata = new System.Windows.Forms.Button();
            this.txtDistintaDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCambiaDescrizioneDistinta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuantità = new System.Windows.Forms.NumericUpDown();
            this.btnAggiungiComponente = new System.Windows.Forms.Button();
            this.txtNRComponente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodiceCollegamentoCicliDiBa = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTipoCoponente = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.Label();
            this.txtNRRigaComponente = new System.Windows.Forms.TextBox();
            this.ll = new System.Windows.Forms.Label();
            this.txtQuantitàPrezioso = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUnitàMisuraComponente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantityPercent = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescrizioneComponente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodiceVersioneComponente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantità)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessaggio.Location = new System.Drawing.Point(12, 465);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.Size = new System.Drawing.Size(1512, 193);
            this.txtMessaggio.TabIndex = 0;
            // 
            // txtDistintaNo
            // 
            this.txtDistintaNo.Location = new System.Drawing.Point(79, 21);
            this.txtDistintaNo.Name = "txtDistintaNo";
            this.txtDistintaNo.Size = new System.Drawing.Size(170, 20);
            this.txtDistintaNo.TabIndex = 0;
            this.txtDistintaNo.Text = "A-LOG700018FIB14A01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distinta No";
            // 
            // btnApriDistinta
            // 
            this.btnApriDistinta.Location = new System.Drawing.Point(280, 19);
            this.btnApriDistinta.Name = "btnApriDistinta";
            this.btnApriDistinta.Size = new System.Drawing.Size(106, 23);
            this.btnApriDistinta.TabIndex = 2;
            this.btnApriDistinta.Text = "Estrai descrizione";
            this.btnApriDistinta.UseVisualStyleBackColor = true;
            this.btnApriDistinta.Click += new System.EventHandler(this.btnApriDistinta_Click);
            // 
            // btnEstraiRigheDiba
            // 
            this.btnEstraiRigheDiba.Location = new System.Drawing.Point(406, 20);
            this.btnEstraiRigheDiba.Name = "btnEstraiRigheDiba";
            this.btnEstraiRigheDiba.Size = new System.Drawing.Size(106, 23);
            this.btnEstraiRigheDiba.TabIndex = 2;
            this.btnEstraiRigheDiba.Text = "Estrai componenti";
            this.btnEstraiRigheDiba.UseVisualStyleBackColor = true;
            this.btnEstraiRigheDiba.Click += new System.EventHandler(this.btnEstraiRigheDiba_Click);
            // 
            // btnDistintaInSviluppo
            // 
            this.btnDistintaInSviluppo.Location = new System.Drawing.Point(532, 21);
            this.btnDistintaInSviluppo.Name = "btnDistintaInSviluppo";
            this.btnDistintaInSviluppo.Size = new System.Drawing.Size(106, 23);
            this.btnDistintaInSviluppo.TabIndex = 2;
            this.btnDistintaInSviluppo.Text = "In sviluppo";
            this.btnDistintaInSviluppo.UseVisualStyleBackColor = true;
            this.btnDistintaInSviluppo.Click += new System.EventHandler(this.btnDistintaInSviluppo_Click);
            // 
            // btnDistintaCertificata
            // 
            this.btnDistintaCertificata.Location = new System.Drawing.Point(658, 21);
            this.btnDistintaCertificata.Name = "btnDistintaCertificata";
            this.btnDistintaCertificata.Size = new System.Drawing.Size(106, 23);
            this.btnDistintaCertificata.TabIndex = 2;
            this.btnDistintaCertificata.Text = "Certificata";
            this.btnDistintaCertificata.UseVisualStyleBackColor = true;
            this.btnDistintaCertificata.Click += new System.EventHandler(this.btnDistintaCertificata_Click);
            // 
            // txtDistintaDescrizione
            // 
            this.txtDistintaDescrizione.Location = new System.Drawing.Point(79, 47);
            this.txtDistintaDescrizione.Name = "txtDistintaDescrizione";
            this.txtDistintaDescrizione.Size = new System.Drawing.Size(170, 20);
            this.txtDistintaDescrizione.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrizione";
            // 
            // btnCambiaDescrizioneDistinta
            // 
            this.btnCambiaDescrizioneDistinta.Location = new System.Drawing.Point(280, 46);
            this.btnCambiaDescrizioneDistinta.Name = "btnCambiaDescrizioneDistinta";
            this.btnCambiaDescrizioneDistinta.Size = new System.Drawing.Size(106, 23);
            this.btnCambiaDescrizioneDistinta.TabIndex = 2;
            this.btnCambiaDescrizioneDistinta.Text = "Cambia descrizione";
            this.btnCambiaDescrizioneDistinta.UseVisualStyleBackColor = true;
            this.btnCambiaDescrizioneDistinta.Click += new System.EventHandler(this.btnCambiaDescrizioneDistinta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApriDistinta);
            this.groupBox1.Controls.Add(this.btnDistintaCertificata);
            this.groupBox1.Controls.Add(this.txtDistintaNo);
            this.groupBox1.Controls.Add(this.btnDistintaInSviluppo);
            this.groupBox1.Controls.Add(this.txtDistintaDescrizione);
            this.groupBox1.Controls.Add(this.btnEstraiRigheDiba);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCambiaDescrizioneDistinta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1207, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuantità);
            this.groupBox2.Controls.Add(this.btnAggiungiComponente);
            this.groupBox2.Controls.Add(this.txtNRComponente);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCodiceCollegamentoCicliDiBa);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTipoCoponente);
            this.groupBox2.Controls.Add(this.l);
            this.groupBox2.Controls.Add(this.txtNRRigaComponente);
            this.groupBox2.Controls.Add(this.ll);
            this.groupBox2.Controls.Add(this.txtQuantitàPrezioso);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtUnitàMisuraComponente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtQuantityPercent);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDescrizioneComponente);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCodiceVersioneComponente);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1207, 171);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Componenti";
            // 
            // txtQuantità
            // 
            this.txtQuantità.Location = new System.Drawing.Point(594, 65);
            this.txtQuantità.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtQuantità.Name = "txtQuantità";
            this.txtQuantità.Size = new System.Drawing.Size(170, 20);
            this.txtQuantità.TabIndex = 3;
            // 
            // btnAggiungiComponente
            // 
            this.btnAggiungiComponente.Location = new System.Drawing.Point(967, 132);
            this.btnAggiungiComponente.Name = "btnAggiungiComponente";
            this.btnAggiungiComponente.Size = new System.Drawing.Size(156, 23);
            this.btnAggiungiComponente.TabIndex = 2;
            this.btnAggiungiComponente.Text = "Aggiungi componente";
            this.btnAggiungiComponente.UseVisualStyleBackColor = true;
            this.btnAggiungiComponente.Click += new System.EventHandler(this.btnAggiungiComponente_Click);
            // 
            // txtNRComponente
            // 
            this.txtNRComponente.Location = new System.Drawing.Point(967, 25);
            this.txtNRComponente.Name = "txtNRComponente";
            this.txtNRComponente.Size = new System.Drawing.Size(170, 20);
            this.txtNRComponente.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(938, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "NR";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtCodiceCollegamentoCicliDiBa
            // 
            this.txtCodiceCollegamentoCicliDiBa.Location = new System.Drawing.Point(967, 65);
            this.txtCodiceCollegamentoCicliDiBa.Name = "txtCodiceCollegamentoCicliDiBa";
            this.txtCodiceCollegamentoCicliDiBa.Size = new System.Drawing.Size(170, 20);
            this.txtCodiceCollegamentoCicliDiBa.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(804, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Codice collegamento Ciclo/DiBa";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(541, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Quantità";
            // 
            // txtTipoCoponente
            // 
            this.txtTipoCoponente.Location = new System.Drawing.Point(594, 25);
            this.txtTipoCoponente.Name = "txtTipoCoponente";
            this.txtTipoCoponente.Size = new System.Drawing.Size(170, 20);
            this.txtTipoCoponente.TabIndex = 0;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(560, 29);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(28, 13);
            this.l.TabIndex = 1;
            this.l.Text = "Tipo";
            // 
            // txtNRRigaComponente
            // 
            this.txtNRRigaComponente.Location = new System.Drawing.Point(364, 25);
            this.txtNRRigaComponente.Name = "txtNRRigaComponente";
            this.txtNRRigaComponente.Size = new System.Drawing.Size(170, 20);
            this.txtNRRigaComponente.TabIndex = 0;
            // 
            // ll
            // 
            this.ll.AutoSize = true;
            this.ll.Location = new System.Drawing.Point(313, 29);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(43, 13);
            this.ll.TabIndex = 1;
            this.ll.Text = "NR riga";
            // 
            // txtQuantitàPrezioso
            // 
            this.txtQuantitàPrezioso.Location = new System.Drawing.Point(364, 101);
            this.txtQuantitàPrezioso.Name = "txtQuantitàPrezioso";
            this.txtQuantitàPrezioso.Size = new System.Drawing.Size(170, 20);
            this.txtQuantitàPrezioso.TabIndex = 0;
            this.txtQuantitàPrezioso.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Quantità Prezioso";
            // 
            // txtUnitàMisuraComponente
            // 
            this.txtUnitàMisuraComponente.Location = new System.Drawing.Point(364, 63);
            this.txtUnitàMisuraComponente.Name = "txtUnitàMisuraComponente";
            this.txtUnitàMisuraComponente.Size = new System.Drawing.Size(170, 20);
            this.txtUnitàMisuraComponente.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Unità di Misura";
            // 
            // txtQuantityPercent
            // 
            this.txtQuantityPercent.Location = new System.Drawing.Point(79, 101);
            this.txtQuantityPercent.Name = "txtQuantityPercent";
            this.txtQuantityPercent.Size = new System.Drawing.Size(170, 20);
            this.txtQuantityPercent.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Quantita per";
            // 
            // txtDescrizioneComponente
            // 
            this.txtDescrizioneComponente.Location = new System.Drawing.Point(79, 63);
            this.txtDescrizioneComponente.Name = "txtDescrizioneComponente";
            this.txtDescrizioneComponente.Size = new System.Drawing.Size(170, 20);
            this.txtDescrizioneComponente.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Descrizione";
            // 
            // txtCodiceVersioneComponente
            // 
            this.txtCodiceVersioneComponente.Location = new System.Drawing.Point(79, 25);
            this.txtCodiceVersioneComponente.Name = "txtCodiceVersioneComponente";
            this.txtCodiceVersioneComponente.Size = new System.Drawing.Size(170, 20);
            this.txtCodiceVersioneComponente.TabIndex = 0;
            this.txtCodiceVersioneComponente.TextChanged += new System.EventHandler(this.txtCodiceVersioneComponente_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cod Versione";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 670);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMessaggio);
            this.Name = "Form1";
            this.Text = "TEST WEB Services";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantità)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessaggio;
        private System.Windows.Forms.TextBox txtDistintaNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApriDistinta;
        private System.Windows.Forms.Button btnEstraiRigheDiba;
        private System.Windows.Forms.Button btnDistintaInSviluppo;
        private System.Windows.Forms.Button btnDistintaCertificata;
        private System.Windows.Forms.TextBox txtDistintaDescrizione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCambiaDescrizioneDistinta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNRRigaComponente;
        private System.Windows.Forms.Label ll;
        private System.Windows.Forms.TextBox txtCodiceVersioneComponente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNRComponente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodiceCollegamentoCicliDiBa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTipoCoponente;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox txtQuantitàPrezioso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUnitàMisuraComponente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantityPercent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescrizioneComponente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAggiungiComponente;
        private System.Windows.Forms.NumericUpDown txtQuantità;
    }
}

