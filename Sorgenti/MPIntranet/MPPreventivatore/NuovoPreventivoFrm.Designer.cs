namespace MPPreventivatore
{
    partial class NuovoPreventivoFrm
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
            this.lblArticolo = new System.Windows.Forms.Label();
            this.lblMessaggio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.chkCopiaPrecedente = new System.Windows.Forms.CheckBox();
            this.ddlVersionePrecedente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblArticolo
            // 
            this.lblArticolo.AutoSize = true;
            this.lblArticolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblArticolo.Location = new System.Drawing.Point(14, 10);
            this.lblArticolo.Name = "lblArticolo";
            this.lblArticolo.Size = new System.Drawing.Size(51, 16);
            this.lblArticolo.TabIndex = 0;
            this.lblArticolo.Text = "label1";
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(12, 213);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 7;
            this.lblMessaggio.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Versione";
            // 
            // txtVersione
            // 
            this.txtVersione.Location = new System.Drawing.Point(93, 40);
            this.txtVersione.Name = "txtVersione";
            this.txtVersione.ReadOnly = true;
            this.txtVersione.Size = new System.Drawing.Size(100, 21);
            this.txtVersione.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(93, 69);
            this.txtDescrizione.MaxLength = 30;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(420, 21);
            this.txtDescrizione.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(153, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crea nuova versione";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(93, 99);
            this.txtNota.MaxLength = 100;
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(420, 73);
            this.txtNota.TabIndex = 1;
            // 
            // chkCopiaPrecedente
            // 
            this.chkCopiaPrecedente.AutoSize = true;
            this.chkCopiaPrecedente.Location = new System.Drawing.Point(93, 188);
            this.chkCopiaPrecedente.Name = "chkCopiaPrecedente";
            this.chkCopiaPrecedente.Size = new System.Drawing.Size(189, 19);
            this.chkCopiaPrecedente.TabIndex = 13;
            this.chkCopiaPrecedente.Text = "Copia da versione precedente";
            this.chkCopiaPrecedente.UseVisualStyleBackColor = true;
            this.chkCopiaPrecedente.CheckedChanged += new System.EventHandler(this.chkCopiaPrecedente_CheckedChanged);
            // 
            // ddlVersionePrecedente
            // 
            this.ddlVersionePrecedente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVersionePrecedente.Enabled = false;
            this.ddlVersionePrecedente.FormattingEnabled = true;
            this.ddlVersionePrecedente.Location = new System.Drawing.Point(288, 186);
            this.ddlVersionePrecedente.Name = "ddlVersionePrecedente";
            this.ddlVersionePrecedente.Size = new System.Drawing.Size(225, 23);
            this.ddlVersionePrecedente.TabIndex = 14;
            // 
            // NuovoPreventivoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 272);
            this.Controls.Add(this.ddlVersionePrecedente);
            this.Controls.Add(this.chkCopiaPrecedente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVersione);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.lblArticolo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuovoPreventivoFrm";
            this.Text = "Nuovo preventivo";
            this.Load += new System.EventHandler(this.NuovoPreventivoFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArticolo;
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.CheckBox chkCopiaPrecedente;
        private System.Windows.Forms.ComboBox ddlVersionePrecedente;
    }
}