﻿namespace DisegnaDiBa
{
    partial class SelezionaDistintaBCFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelezionaDistintaBCFrm));
            this.dgvDistinte = new System.Windows.Forms.DataGridView();
            this.Codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistinte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDistinte
            // 
            this.dgvDistinte.AllowUserToAddRows = false;
            this.dgvDistinte.AllowUserToDeleteRows = false;
            this.dgvDistinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codice,
            this.Descrizione,
            this.Descrizione2});
            this.dgvDistinte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDistinte.Location = new System.Drawing.Point(0, 0);
            this.dgvDistinte.Name = "dgvDistinte";
            this.dgvDistinte.ReadOnly = true;
            this.dgvDistinte.Size = new System.Drawing.Size(620, 331);
            this.dgvDistinte.TabIndex = 0;
            this.dgvDistinte.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistinte_CellDoubleClick);
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "Codice";
            this.Codice.FillWeight = 130F;
            this.Codice.HeaderText = "Codice";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            this.Codice.Width = 130;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.FillWeight = 220F;
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            this.Descrizione.Width = 220;
            // 
            // Descrizione2
            // 
            this.Descrizione2.DataPropertyName = "Descrizione2";
            this.Descrizione2.FillWeight = 220F;
            this.Descrizione2.HeaderText = "Descrizione2";
            this.Descrizione2.Name = "Descrizione2";
            this.Descrizione2.ReadOnly = true;
            this.Descrizione2.Width = 220;
            // 
            // SelezionaDistintaBCFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 331);
            this.Controls.Add(this.dgvDistinte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelezionaDistintaBCFrm";
            this.Text = "SelezionaDistintaFrm";
            this.Load += new System.EventHandler(this.SelezionaDistintaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistinte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDistinte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione2;
    }
}