namespace MPPreventivatore
{
    partial class MateriePrimeFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMateriePrime = new System.Windows.Forms.DataGridView();
            this.btnChiudi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriePrime)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(108, 9);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 6;
            this.lblMessaggio.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Materie prime";
            // 
            // dgvMateriePrime
            // 
            this.dgvMateriePrime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMateriePrime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriePrime.Location = new System.Drawing.Point(12, 32);
            this.dgvMateriePrime.MultiSelect = false;
            this.dgvMateriePrime.Name = "dgvMateriePrime";
            this.dgvMateriePrime.Size = new System.Drawing.Size(835, 253);
            this.dgvMateriePrime.TabIndex = 4;
            this.dgvMateriePrime.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMateriePrime_CellEndEdit);
            this.dgvMateriePrime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvMateriePrime_EditingControlShowing);
            this.dgvMateriePrime.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvMateriePrime_UserAddedRow);
            this.dgvMateriePrime.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMateriePrime_UserDeletingRow);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiudi.Location = new System.Drawing.Point(392, 308);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 32);
            this.btnChiudi.TabIndex = 7;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // MateriePrimeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 360);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMateriePrime);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriePrimeFrm";
            this.Text = "Materie prime";
            this.Load += new System.EventHandler(this.MateriePrimeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriePrime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMateriePrime;
        private System.Windows.Forms.Button btnChiudi;
    }
}