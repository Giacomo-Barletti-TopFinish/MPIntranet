namespace DisegnaDiBa
{
    partial class CopiaArticoloFrm
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
            this.btnCopiaAnag = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.txtAnagDest = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.txtAnagOrig = new System.Windows.Forms.TextBox();
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCopiaAnag
            // 
            this.btnCopiaAnag.Location = new System.Drawing.Point(393, 25);
            this.btnCopiaAnag.Name = "btnCopiaAnag";
            this.btnCopiaAnag.Size = new System.Drawing.Size(114, 23);
            this.btnCopiaAnag.TabIndex = 13;
            this.btnCopiaAnag.Text = "Copia Articolo";
            this.btnCopiaAnag.UseVisualStyleBackColor = true;
            this.btnCopiaAnag.Click += new System.EventHandler(this.btnCopiaAnag_Click);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(211, 9);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(138, 13);
            this.label64.TabIndex = 12;
            this.label64.Text = "Tipo articolo di destinazione";
            // 
            // txtAnagDest
            // 
            this.txtAnagDest.Location = new System.Drawing.Point(214, 28);
            this.txtAnagDest.Name = "txtAnagDest";
            this.txtAnagDest.Size = new System.Drawing.Size(148, 20);
            this.txtAnagDest.TabIndex = 11;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(12, 9);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(94, 13);
            this.label63.TabIndex = 10;
            this.label63.Text = "Anagrafica Origine";
            // 
            // txtAnagOrig
            // 
            this.txtAnagOrig.Location = new System.Drawing.Point(12, 28);
            this.txtAnagOrig.Name = "txtAnagOrig";
            this.txtAnagOrig.Size = new System.Drawing.Size(153, 20);
            this.txtAnagOrig.TabIndex = 9;
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Location = new System.Drawing.Point(12, 92);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.ReadOnly = true;
            this.txtMessaggio.Size = new System.Drawing.Size(495, 126);
            this.txtMessaggio.TabIndex = 14;
            // 
            // CopiaArticoloFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 230);
            this.Controls.Add(this.txtMessaggio);
            this.Controls.Add(this.btnCopiaAnag);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.txtAnagDest);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.txtAnagOrig);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopiaArticoloFrm";
            this.Text = "Copia artiolo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopiaAnag;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtAnagDest;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox txtAnagOrig;
        private System.Windows.Forms.TextBox txtMessaggio;
    }
}