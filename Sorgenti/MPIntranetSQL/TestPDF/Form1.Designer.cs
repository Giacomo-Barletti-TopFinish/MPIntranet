namespace TestPDF
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
            this.btnCreaPdfTest = new System.Windows.Forms.Button();
            this.btnSalvaFile = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreaPdfScheda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreaPdfTest
            // 
            this.btnCreaPdfTest.Location = new System.Drawing.Point(371, 40);
            this.btnCreaPdfTest.Name = "btnCreaPdfTest";
            this.btnCreaPdfTest.Size = new System.Drawing.Size(75, 23);
            this.btnCreaPdfTest.TabIndex = 0;
            this.btnCreaPdfTest.Text = "Crea PDF Test";
            this.btnCreaPdfTest.UseVisualStyleBackColor = true;
            this.btnCreaPdfTest.Click += new System.EventHandler(this.btnCreaPdfTest_Click);
            // 
            // btnSalvaFile
            // 
            this.btnSalvaFile.Location = new System.Drawing.Point(259, 41);
            this.btnSalvaFile.Name = "btnSalvaFile";
            this.btnSalvaFile.Size = new System.Drawing.Size(106, 23);
            this.btnSalvaFile.TabIndex = 5;
            this.btnSalvaFile.Text = "Browse";
            this.btnSalvaFile.UseVisualStyleBackColor = true;
            this.btnSalvaFile.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(66, 41);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(170, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(74, 26);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(49, 13);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Filename";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID Scheda";
            // 
            // btnCreaPdfScheda
            // 
            this.btnCreaPdfScheda.Location = new System.Drawing.Point(259, 101);
            this.btnCreaPdfScheda.Name = "btnCreaPdfScheda";
            this.btnCreaPdfScheda.Size = new System.Drawing.Size(115, 23);
            this.btnCreaPdfScheda.TabIndex = 8;
            this.btnCreaPdfScheda.Text = "Crea PDF Scheda";
            this.btnCreaPdfScheda.UseVisualStyleBackColor = true;
            this.btnCreaPdfScheda.Click += new System.EventHandler(this.btnCreaPdfScheda_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreaPdfScheda);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvaFile);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnCreaPdfTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreaPdfTest;
        private System.Windows.Forms.Button btnSalvaFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreaPdfScheda;
    }
}

