namespace DisegnaDiBa
{
    partial class EsportaDiBaFrm
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
            this.btnTrovaFileDistinte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileDistinte = new System.Windows.Forms.TextBox();
            this.btnSalvaFileDistinte = new System.Windows.Forms.Button();
            this.txtFileCicli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvaCicli = new System.Windows.Forms.Button();
            this.btnTrovaFileCicli = new System.Windows.Forms.Button();
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTrovaFileDistinte
            // 
            this.btnTrovaFileDistinte.Location = new System.Drawing.Point(557, 18);
            this.btnTrovaFileDistinte.Name = "btnTrovaFileDistinte";
            this.btnTrovaFileDistinte.Size = new System.Drawing.Size(100, 23);
            this.btnTrovaFileDistinte.TabIndex = 0;
            this.btnTrovaFileDistinte.Text = "Trova";
            this.btnTrovaFileDistinte.UseVisualStyleBackColor = true;
            this.btnTrovaFileDistinte.Click += new System.EventHandler(this.btnTrovaFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File distinte";
            // 
            // txtFileDistinte
            // 
            this.txtFileDistinte.Location = new System.Drawing.Point(98, 18);
            this.txtFileDistinte.Name = "txtFileDistinte";
            this.txtFileDistinte.Size = new System.Drawing.Size(439, 20);
            this.txtFileDistinte.TabIndex = 2;
            // 
            // btnSalvaFileDistinte
            // 
            this.btnSalvaFileDistinte.Location = new System.Drawing.Point(696, 18);
            this.btnSalvaFileDistinte.Name = "btnSalvaFileDistinte";
            this.btnSalvaFileDistinte.Size = new System.Drawing.Size(123, 23);
            this.btnSalvaFileDistinte.TabIndex = 0;
            this.btnSalvaFileDistinte.Text = "Salva Distinte";
            this.btnSalvaFileDistinte.UseVisualStyleBackColor = true;
            this.btnSalvaFileDistinte.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // txtFileCicli
            // 
            this.txtFileCicli.Location = new System.Drawing.Point(98, 51);
            this.txtFileCicli.Name = "txtFileCicli";
            this.txtFileCicli.Size = new System.Drawing.Size(439, 20);
            this.txtFileCicli.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File cicli";
            // 
            // btnSalvaCicli
            // 
            this.btnSalvaCicli.Location = new System.Drawing.Point(696, 50);
            this.btnSalvaCicli.Name = "btnSalvaCicli";
            this.btnSalvaCicli.Size = new System.Drawing.Size(123, 23);
            this.btnSalvaCicli.TabIndex = 3;
            this.btnSalvaCicli.Text = "Salva Cicli";
            this.btnSalvaCicli.UseVisualStyleBackColor = true;
            this.btnSalvaCicli.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // btnTrovaFileCicli
            // 
            this.btnTrovaFileCicli.Location = new System.Drawing.Point(557, 50);
            this.btnTrovaFileCicli.Name = "btnTrovaFileCicli";
            this.btnTrovaFileCicli.Size = new System.Drawing.Size(100, 23);
            this.btnTrovaFileCicli.TabIndex = 4;
            this.btnTrovaFileCicli.Text = "Trova";
            this.btnTrovaFileCicli.UseVisualStyleBackColor = true;
            this.btnTrovaFileCicli.Click += new System.EventHandler(this.btnTrovaFile_Click);
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Location = new System.Drawing.Point(29, 77);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.ReadOnly = true;
            this.txtMessaggio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessaggio.Size = new System.Drawing.Size(917, 653);
            this.txtMessaggio.TabIndex = 8;
            // 
            // EsportaDiBaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 746);
            this.Controls.Add(this.txtMessaggio);
            this.Controls.Add(this.txtFileCicli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvaCicli);
            this.Controls.Add(this.btnTrovaFileCicli);
            this.Controls.Add(this.txtFileDistinte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvaFileDistinte);
            this.Controls.Add(this.btnTrovaFileDistinte);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EsportaDiBaFrm";
            this.Text = "Esporta distinte ";
            this.Load += new System.EventHandler(this.EsportaDiBaFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrovaFileDistinte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileDistinte;
        private System.Windows.Forms.Button btnSalvaFileDistinte;
        private System.Windows.Forms.TextBox txtFileCicli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvaCicli;
        private System.Windows.Forms.Button btnTrovaFileCicli;
        private System.Windows.Forms.TextBox txtMessaggio;
    }
}