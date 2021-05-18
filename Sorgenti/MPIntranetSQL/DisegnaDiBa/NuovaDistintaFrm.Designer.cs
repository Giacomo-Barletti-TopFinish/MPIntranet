namespace DisegnaDiBa
{
    partial class NuovaDistintaFrm
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
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtVersione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlTipoDistinta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreaDistinta = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrizione.Location = new System.Drawing.Point(119, 57);
            this.txtDescrizione.MaxLength = 50;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(537, 21);
            this.txtDescrizione.TabIndex = 9;
            // 
            // txtVersione
            // 
            this.txtVersione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersione.Location = new System.Drawing.Point(416, 12);
            this.txtVersione.MaxLength = 50;
            this.txtVersione.Name = "txtVersione";
            this.txtVersione.ReadOnly = true;
            this.txtVersione.Size = new System.Drawing.Size(240, 21);
            this.txtVersione.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrizione";
            // 
            // ddlTipoDistinta
            // 
            this.ddlTipoDistinta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoDistinta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTipoDistinta.FormattingEnabled = true;
            this.ddlTipoDistinta.Location = new System.Drawing.Point(119, 12);
            this.ddlTipoDistinta.Name = "ddlTipoDistinta";
            this.ddlTipoDistinta.Size = new System.Drawing.Size(152, 23);
            this.ddlTipoDistinta.TabIndex = 7;
            this.ddlTipoDistinta.SelectedIndexChanged += new System.EventHandler(this.ddlTipoDistinta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Versione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo distinta";
            // 
            // btnCreaDistinta
            // 
            this.btnCreaDistinta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreaDistinta.Location = new System.Drawing.Point(276, 120);
            this.btnCreaDistinta.Name = "btnCreaDistinta";
            this.btnCreaDistinta.Size = new System.Drawing.Size(163, 30);
            this.btnCreaDistinta.TabIndex = 12;
            this.btnCreaDistinta.Text = "Crea distinta";
            this.btnCreaDistinta.UseVisualStyleBackColor = true;
            this.btnCreaDistinta.Click += new System.EventHandler(this.btnCreaDistinta_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(116, 169);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 15);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "label1";
            // 
            // NuovaDistintaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(691, 218);
            this.Controls.Add(this.btnCreaDistinta);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtVersione);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlTipoDistinta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuovaDistintaFrm";
            this.Text = "Nuova distinta";
            this.Load += new System.EventHandler(this.NuovaDistintaFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtVersione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlTipoDistinta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreaDistinta;
        private System.Windows.Forms.Label lblMessage;
    }
}