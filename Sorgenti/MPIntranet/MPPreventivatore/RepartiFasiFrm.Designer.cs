namespace MPPreventivatore
{
    partial class RepartiFasiFrm
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
            this.dgvReparti = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFasi = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.lblMessaggio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReparti
            // 
            this.dgvReparti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReparti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReparti.Location = new System.Drawing.Point(14, 30);
            this.dgvReparti.MultiSelect = false;
            this.dgvReparti.Name = "dgvReparti";
            this.dgvReparti.Size = new System.Drawing.Size(726, 253);
            this.dgvReparti.TabIndex = 0;
            this.dgvReparti.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReparti_CellEndEdit);
            this.dgvReparti.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReparti_RowEnter);
            this.dgvReparti.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvReparti_UserAddedRow);
            this.dgvReparti.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvReparti_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reparti";
            // 
            // dgvFasi
            // 
            this.dgvFasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFasi.Location = new System.Drawing.Point(14, 313);
            this.dgvFasi.MultiSelect = false;
            this.dgvFasi.Name = "dgvFasi";
            this.dgvFasi.Size = new System.Drawing.Size(726, 285);
            this.dgvFasi.TabIndex = 0;
            this.dgvFasi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFasi_CellEndEdit);
            this.dgvFasi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFasi_EditingControlShowing);
            this.dgvFasi.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvFasi_UserAddedRow);
            this.dgvFasi.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvFasi_UserDeletingRow);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fasi";
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiudi.Location = new System.Drawing.Point(335, 606);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 32);
            this.btnChiudi.TabIndex = 2;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(110, 7);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 3;
            this.lblMessaggio.Text = "label3";
            // 
            // RepartiFasiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 641);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFasi);
            this.Controls.Add(this.dgvReparti);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepartiFasiFrm";
            this.Text = "Reparti e fasi";
            this.Load += new System.EventHandler(this.RepartiFasiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReparti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label lblMessaggio;
    }
}