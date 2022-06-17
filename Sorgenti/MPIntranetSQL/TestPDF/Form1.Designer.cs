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
            this.SuspendLayout();
            // 
            // btnCreaPdfTest
            // 
            this.btnCreaPdfTest.Location = new System.Drawing.Point(76, 110);
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
            this.txtFilename.Location = new System.Drawing.Point(76, 43);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

