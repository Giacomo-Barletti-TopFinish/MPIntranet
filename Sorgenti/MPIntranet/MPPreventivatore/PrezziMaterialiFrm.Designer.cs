namespace MPPreventivatore
{
    partial class PrezziMaterialiFrm
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
            this.ddlMateriali = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nuPrezzo = new System.Windows.Forms.NumericUpDown();
            this.dtDataValidita = new System.Windows.Forms.DateTimePicker();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.dgvMateriali = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblMessaggio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nuPrezzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriali)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlMateriali
            // 
            this.ddlMateriali.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMateriali.FormattingEnabled = true;
            this.ddlMateriali.Location = new System.Drawing.Point(139, 15);
            this.ddlMateriali.Name = "ddlMateriali";
            this.ddlMateriali.Size = new System.Drawing.Size(210, 23);
            this.ddlMateriali.TabIndex = 0;
            this.ddlMateriali.SelectedIndexChanged += new System.EventHandler(this.ddlMateriali_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Materiale";
            // 
            // nuPrezzo
            // 
            this.nuPrezzo.DecimalPlaces = 3;
            this.nuPrezzo.Location = new System.Drawing.Point(139, 58);
            this.nuPrezzo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nuPrezzo.Name = "nuPrezzo";
            this.nuPrezzo.Size = new System.Drawing.Size(103, 21);
            this.nuPrezzo.TabIndex = 1;
            // 
            // dtDataValidita
            // 
            this.dtDataValidita.Location = new System.Drawing.Point(139, 100);
            this.dtDataValidita.Name = "dtDataValidita";
            this.dtDataValidita.Size = new System.Drawing.Size(210, 21);
            this.dtDataValidita.TabIndex = 2;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(355, 139);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(152, 27);
            this.btnAggiungi.TabIndex = 4;
            this.btnAggiungi.Text = "Registra nuovo prezzo";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // dgvMateriali
            // 
            this.dgvMateriali.AllowUserToAddRows = false;
            this.dgvMateriali.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMateriali.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriali.Location = new System.Drawing.Point(27, 199);
            this.dgvMateriali.Name = "dgvMateriali";
            this.dgvMateriali.Size = new System.Drawing.Size(480, 239);
            this.dgvMateriali.TabIndex = 5;
            this.dgvMateriali.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMateriali_CellEndEdit);
            this.dgvMateriali.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMateriali_UserDeletingRow);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nuovo prezzo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data inizio validità";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "€/gr";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(139, 142);
            this.txtNota.MaxLength = 100;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(210, 21);
            this.txtNota.TabIndex = 3;
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AutoSize = true;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggio.Location = new System.Drawing.Point(24, 170);
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.Size = new System.Drawing.Size(51, 16);
            this.lblMessaggio.TabIndex = 9;
            this.lblMessaggio.Text = "label3";
            // 
            // PrezziMaterialiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 468);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvMateriali);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.dtDataValidita);
            this.Controls.Add(this.nuPrezzo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlMateriali);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrezziMaterialiFrm";
            this.Text = "Prezzi materiali";
            this.Load += new System.EventHandler(this.PrezziMaterialiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuPrezzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriali)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlMateriali;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuPrezzo;
        private System.Windows.Forms.DateTimePicker dtDataValidita;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.DataGridView dgvMateriali;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblMessaggio;
    }
}