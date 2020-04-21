namespace MPPreventivatore
{
    partial class GruppiFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRepartiGruppi = new System.Windows.Forms.DataGridView();
            this.dgvGruppi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlBrand = new System.Windows.Forms.ComboBox();
            this.btnAssocia = new System.Windows.Forms.Button();
            this.btnDisassocia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepartiGruppi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).BeginInit();
            this.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reparti";
            // 
            // dgvRepartiGruppi
            // 
            this.dgvRepartiGruppi.AllowUserToAddRows = false;
            this.dgvRepartiGruppi.AllowUserToDeleteRows = false;
            this.dgvRepartiGruppi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRepartiGruppi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepartiGruppi.Location = new System.Drawing.Point(14, 313);
            this.dgvRepartiGruppi.Name = "dgvRepartiGruppi";
            this.dgvRepartiGruppi.ReadOnly = true;
            this.dgvRepartiGruppi.Size = new System.Drawing.Size(540, 285);
            this.dgvRepartiGruppi.TabIndex = 0;
            this.dgvRepartiGruppi.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvRepartiGruppi_RowPrePaint);
            // 
            // dgvGruppi
            // 
            this.dgvGruppi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGruppi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruppi.Location = new System.Drawing.Point(14, 98);
            this.dgvGruppi.MultiSelect = false;
            this.dgvGruppi.Name = "dgvGruppi";
            this.dgvGruppi.Size = new System.Drawing.Size(726, 185);
            this.dgvGruppi.TabIndex = 0;
            this.dgvGruppi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGruppi_CellEndEdit);
            this.dgvGruppi.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvGruppi_UserAddedRow);
            this.dgvGruppi.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGruppi_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gruppi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Brand";
            // 
            // ddlBrand
            // 
            this.ddlBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrand.FormattingEnabled = true;
            this.ddlBrand.Location = new System.Drawing.Point(70, 43);
            this.ddlBrand.Name = "ddlBrand";
            this.ddlBrand.Size = new System.Drawing.Size(306, 23);
            this.ddlBrand.TabIndex = 4;
            this.ddlBrand.SelectedIndexChanged += new System.EventHandler(this.ddlBrand_SelectedIndexChanged);
            // 
            // btnAssocia
            // 
            this.btnAssocia.Location = new System.Drawing.Point(580, 332);
            this.btnAssocia.Name = "btnAssocia";
            this.btnAssocia.Size = new System.Drawing.Size(75, 32);
            this.btnAssocia.TabIndex = 2;
            this.btnAssocia.Text = "Associa";
            this.btnAssocia.UseVisualStyleBackColor = true;
            this.btnAssocia.Click += new System.EventHandler(this.btnAssocia_Click);
            // 
            // btnDisassocia
            // 
            this.btnDisassocia.Location = new System.Drawing.Point(580, 420);
            this.btnDisassocia.Name = "btnDisassocia";
            this.btnDisassocia.Size = new System.Drawing.Size(75, 32);
            this.btnDisassocia.TabIndex = 2;
            this.btnDisassocia.Text = "Disassocia";
            this.btnDisassocia.UseVisualStyleBackColor = true;
            this.btnDisassocia.Click += new System.EventHandler(this.btnDisassocia_Click);
            // 
            // GruppiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 641);
            this.Controls.Add(this.ddlBrand);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.btnDisassocia);
            this.Controls.Add(this.btnAssocia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRepartiGruppi);
            this.Controls.Add(this.dgvGruppi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GruppiFrm";
            this.Text = "Gruppi e reparti";
            this.Load += new System.EventHandler(this.GruppiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepartiGruppi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruppi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessaggio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRepartiGruppi;
        private System.Windows.Forms.DataGridView dgvGruppi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlBrand;
        private System.Windows.Forms.Button btnAssocia;
        private System.Windows.Forms.Button btnDisassocia;
    }
}