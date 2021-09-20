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
            this.SuspendLayout();
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Location = new System.Drawing.Point(12, 245);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.Size = new System.Drawing.Size(776, 193);
            this.txtMessaggio.TabIndex = 0;
            // 
            // txtDistintaNo
            // 
            this.txtDistintaNo.Location = new System.Drawing.Point(77, 15);
            this.txtDistintaNo.Name = "txtDistintaNo";
            this.txtDistintaNo.Size = new System.Drawing.Size(170, 20);
            this.txtDistintaNo.TabIndex = 0;
            this.txtDistintaNo.Text = "A-LOG700018FIB14A01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distinta No";
            // 
            // btnApriDistinta
            // 
            this.btnApriDistinta.Location = new System.Drawing.Point(278, 13);
            this.btnApriDistinta.Name = "btnApriDistinta";
            this.btnApriDistinta.Size = new System.Drawing.Size(106, 23);
            this.btnApriDistinta.TabIndex = 2;
            this.btnApriDistinta.Text = "Estrai descrizione";
            this.btnApriDistinta.UseVisualStyleBackColor = true;
            this.btnApriDistinta.Click += new System.EventHandler(this.btnApriDistinta_Click);
            // 
            // btnEstraiRigheDiba
            // 
            this.btnEstraiRigheDiba.Location = new System.Drawing.Point(404, 14);
            this.btnEstraiRigheDiba.Name = "btnEstraiRigheDiba";
            this.btnEstraiRigheDiba.Size = new System.Drawing.Size(106, 23);
            this.btnEstraiRigheDiba.TabIndex = 2;
            this.btnEstraiRigheDiba.Text = "Estrai componenti";
            this.btnEstraiRigheDiba.UseVisualStyleBackColor = true;
            this.btnEstraiRigheDiba.Click += new System.EventHandler(this.btnEstraiRigheDiba_Click);
            // 
            // btnDistintaInSviluppo
            // 
            this.btnDistintaInSviluppo.Location = new System.Drawing.Point(530, 15);
            this.btnDistintaInSviluppo.Name = "btnDistintaInSviluppo";
            this.btnDistintaInSviluppo.Size = new System.Drawing.Size(106, 23);
            this.btnDistintaInSviluppo.TabIndex = 2;
            this.btnDistintaInSviluppo.Text = "In sviluppo";
            this.btnDistintaInSviluppo.UseVisualStyleBackColor = true;
            this.btnDistintaInSviluppo.Click += new System.EventHandler(this.btnDistintaInSviluppo_Click);
            // 
            // btnDistintaCertificata
            // 
            this.btnDistintaCertificata.Location = new System.Drawing.Point(656, 15);
            this.btnDistintaCertificata.Name = "btnDistintaCertificata";
            this.btnDistintaCertificata.Size = new System.Drawing.Size(106, 23);
            this.btnDistintaCertificata.TabIndex = 2;
            this.btnDistintaCertificata.Text = "Certificata";
            this.btnDistintaCertificata.UseVisualStyleBackColor = true;
            this.btnDistintaCertificata.Click += new System.EventHandler(this.btnDistintaCertificata_Click);
            // 
            // txtDistintaDescrizione
            // 
            this.txtDistintaDescrizione.Location = new System.Drawing.Point(77, 41);
            this.txtDistintaDescrizione.Name = "txtDistintaDescrizione";
            this.txtDistintaDescrizione.Size = new System.Drawing.Size(170, 20);
            this.txtDistintaDescrizione.TabIndex = 0;
            this.txtDistintaDescrizione.Text = "A-LOG700018FIB14A01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrizione";
            // 
            // btnCambiaDescrizioneDistinta
            // 
            this.btnCambiaDescrizioneDistinta.Location = new System.Drawing.Point(278, 40);
            this.btnCambiaDescrizioneDistinta.Name = "btnCambiaDescrizioneDistinta";
            this.btnCambiaDescrizioneDistinta.Size = new System.Drawing.Size(106, 23);
            this.btnCambiaDescrizioneDistinta.TabIndex = 2;
            this.btnCambiaDescrizioneDistinta.Text = "Cambia descrizione";
            this.btnCambiaDescrizioneDistinta.UseVisualStyleBackColor = true;
            this.btnCambiaDescrizioneDistinta.Click += new System.EventHandler(this.btnCambiaDescrizioneDistinta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDistintaCertificata);
            this.Controls.Add(this.btnDistintaInSviluppo);
            this.Controls.Add(this.btnEstraiRigheDiba);
            this.Controls.Add(this.btnCambiaDescrizioneDistinta);
            this.Controls.Add(this.btnApriDistinta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDistintaDescrizione);
            this.Controls.Add(this.txtDistintaNo);
            this.Controls.Add(this.txtMessaggio);
            this.Name = "Form1";
            this.Text = "TEST WEB Services";
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
    }
}

