namespace MPPreventivatore
{
    partial class CostoFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prodottoFinitoUC1 = new MPPreventivatore.ProdottoFinitoUC();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotaPrevetivoCosto = new System.Windows.Forms.TextBox();
            this.txtNotaPreventivo = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.ddlPreventivoCosto = new System.Windows.Forms.ComboBox();
            this.btnCreaNuovaVersione = new System.Windows.Forms.Button();
            this.ddlPreventivi = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgvElementi = new System.Windows.Forms.DataGridView();
            this.IdEelementoPreventivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncludiPreventivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Articolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reparto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gruppo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Superficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PezziOrari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoArticolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ricarico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAggiorna_costiFissi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstCostiFissi = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.prodottoFinitoUC1);
            this.groupBox1.Location = new System.Drawing.Point(593, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prodotto finito";
            // 
            // prodottoFinitoUC1
            // 
            this.prodottoFinitoUC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prodottoFinitoUC1.Location = new System.Drawing.Point(6, 17);
            this.prodottoFinitoUC1.Name = "prodottoFinitoUC1";
            this.prodottoFinitoUC1.Size = new System.Drawing.Size(767, 157);
            this.prodottoFinitoUC1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNotaPrevetivoCosto);
            this.groupBox2.Controls.Add(this.txtNotaPreventivo);
            this.groupBox2.Controls.Add(this.btnSalva);
            this.groupBox2.Controls.Add(this.ddlPreventivoCosto);
            this.groupBox2.Controls.Add(this.btnCreaNuovaVersione);
            this.groupBox2.Controls.Add(this.ddlPreventivi);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 206);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preventivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nota versione costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Versione costo";
            // 
            // txtNotaPrevetivoCosto
            // 
            this.txtNotaPrevetivoCosto.Location = new System.Drawing.Point(6, 156);
            this.txtNotaPrevetivoCosto.MaxLength = 200;
            this.txtNotaPrevetivoCosto.Multiline = true;
            this.txtNotaPrevetivoCosto.Name = "txtNotaPrevetivoCosto";
            this.txtNotaPrevetivoCosto.Size = new System.Drawing.Size(376, 43);
            this.txtNotaPrevetivoCosto.TabIndex = 2;
            // 
            // txtNotaPreventivo
            // 
            this.txtNotaPreventivo.Location = new System.Drawing.Point(6, 45);
            this.txtNotaPreventivo.MaxLength = 100;
            this.txtNotaPreventivo.Multiline = true;
            this.txtNotaPreventivo.Name = "txtNotaPreventivo";
            this.txtNotaPreventivo.ReadOnly = true;
            this.txtNotaPreventivo.Size = new System.Drawing.Size(376, 43);
            this.txtNotaPreventivo.TabIndex = 2;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(412, 166);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(141, 33);
            this.btnSalva.TabIndex = 1;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // ddlPreventivoCosto
            // 
            this.ddlPreventivoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPreventivoCosto.FormattingEnabled = true;
            this.ddlPreventivoCosto.Location = new System.Drawing.Point(6, 110);
            this.ddlPreventivoCosto.Name = "ddlPreventivoCosto";
            this.ddlPreventivoCosto.Size = new System.Drawing.Size(376, 23);
            this.ddlPreventivoCosto.TabIndex = 0;
            this.ddlPreventivoCosto.SelectedIndexChanged += new System.EventHandler(this.ddlPreventivoCosto_SelectedIndexChanged);
            // 
            // btnCreaNuovaVersione
            // 
            this.btnCreaNuovaVersione.Location = new System.Drawing.Point(412, 106);
            this.btnCreaNuovaVersione.Name = "btnCreaNuovaVersione";
            this.btnCreaNuovaVersione.Size = new System.Drawing.Size(141, 33);
            this.btnCreaNuovaVersione.TabIndex = 1;
            this.btnCreaNuovaVersione.Text = "Crea nuova versione";
            this.btnCreaNuovaVersione.UseVisualStyleBackColor = true;
            this.btnCreaNuovaVersione.Click += new System.EventHandler(this.btnCreaNuovaVersione_Click);
            // 
            // ddlPreventivi
            // 
            this.ddlPreventivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPreventivi.FormattingEnabled = true;
            this.ddlPreventivi.Location = new System.Drawing.Point(6, 20);
            this.ddlPreventivi.Name = "ddlPreventivi";
            this.ddlPreventivi.Size = new System.Drawing.Size(376, 23);
            this.ddlPreventivi.TabIndex = 0;
            this.ddlPreventivi.SelectedIndexChanged += new System.EventHandler(this.ddlPreventivi_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(12, 224);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(446, 415);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // dgvElementi
            // 
            this.dgvElementi.AllowUserToAddRows = false;
            this.dgvElementi.AllowUserToDeleteRows = false;
            this.dgvElementi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElementi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEelementoPreventivo,
            this.IncludiPreventivo,
            this.Articolo,
            this.Codice,
            this.Descrizione,
            this.Reparto,
            this.Gruppo,
            this.Peso,
            this.Superficie,
            this.Quantita,
            this.PezziOrari,
            this.Costo,
            this.CostoArticolo,
            this.Ricarico});
            this.dgvElementi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElementi.Location = new System.Drawing.Point(3, 3);
            this.dgvElementi.MultiSelect = false;
            this.dgvElementi.Name = "dgvElementi";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElementi.Size = new System.Drawing.Size(894, 387);
            this.dgvElementi.TabIndex = 9;
            this.dgvElementi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellClick);
            this.dgvElementi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellEndEdit);
            this.dgvElementi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellValueChanged);
            this.dgvElementi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvElementi_EditingControlShowing);
            this.dgvElementi.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvElementi_RowPrePaint);
            // 
            // IdEelementoPreventivo
            // 
            this.IdEelementoPreventivo.DataPropertyName = "IdElementoPreventivo";
            this.IdEelementoPreventivo.HeaderText = "IdEelementoPreventivo";
            this.IdEelementoPreventivo.Name = "IdEelementoPreventivo";
            this.IdEelementoPreventivo.Visible = false;
            // 
            // IncludiPreventivo
            // 
            this.IncludiPreventivo.HeaderText = "Includi";
            this.IncludiPreventivo.Name = "IncludiPreventivo";
            // 
            // Articolo
            // 
            this.Articolo.DataPropertyName = "Articolo";
            this.Articolo.HeaderText = "Articolo";
            this.Articolo.MaxInputLength = 30;
            this.Articolo.Name = "Articolo";
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "Codice";
            this.Codice.HeaderText = "Codice";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "Descrizione";
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            // 
            // Reparto
            // 
            this.Reparto.DataPropertyName = "Reparto";
            this.Reparto.HeaderText = "Reparto";
            this.Reparto.Name = "Reparto";
            this.Reparto.ReadOnly = true;
            // 
            // Gruppo
            // 
            this.Gruppo.HeaderText = "Gruppo";
            this.Gruppo.Name = "Gruppo";
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "Peso";
            this.Peso.FillWeight = 80F;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Width = 80;
            // 
            // Superficie
            // 
            this.Superficie.DataPropertyName = "Superficie";
            this.Superficie.FillWeight = 80F;
            this.Superficie.HeaderText = "Superficie";
            this.Superficie.Name = "Superficie";
            this.Superficie.Width = 80;
            // 
            // Quantita
            // 
            this.Quantita.DataPropertyName = "Quantita";
            this.Quantita.FillWeight = 80F;
            this.Quantita.HeaderText = "Quantità";
            this.Quantita.Name = "Quantita";
            this.Quantita.Width = 80;
            // 
            // PezziOrari
            // 
            this.PezziOrari.DataPropertyName = "PezziOrari";
            this.PezziOrari.FillWeight = 80F;
            this.PezziOrari.HeaderText = "Pezzi orari";
            this.PezziOrari.Name = "PezziOrari";
            this.PezziOrari.Width = 80;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            this.Costo.HeaderText = "Costo orario";
            this.Costo.Name = "Costo";
            // 
            // CostoArticolo
            // 
            this.CostoArticolo.DataPropertyName = "CostoArticolo";
            this.CostoArticolo.HeaderText = "Costo articolo";
            this.CostoArticolo.Name = "CostoArticolo";
            // 
            // Ricarico
            // 
            this.Ricarico.HeaderText = "Ricarico";
            this.Ricarico.Name = "Ricarico";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(464, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 421);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvElementi);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dettaglio elementi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(900, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gruppi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnAggiorna_costiFissi);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.lstCostiFissi);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(900, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Costi fissi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnAggiorna_costiFissi
            // 
            this.btnAggiorna_costiFissi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAggiorna_costiFissi.Location = new System.Drawing.Point(6, 358);
            this.btnAggiorna_costiFissi.Name = "btnAggiorna_costiFissi";
            this.btnAggiorna_costiFissi.Size = new System.Drawing.Size(292, 33);
            this.btnAggiorna_costiFissi.TabIndex = 2;
            this.btnAggiorna_costiFissi.Text = "Crea nuova versione";
            this.btnAggiorna_costiFissi.UseVisualStyleBackColor = true;
            this.btnAggiorna_costiFissi.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(347, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 346);
            this.dataGridView1.TabIndex = 1;
            // 
            // lstCostiFissi
            // 
            this.lstCostiFissi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCostiFissi.FormattingEnabled = true;
            this.lstCostiFissi.ItemHeight = 15;
            this.lstCostiFissi.Location = new System.Drawing.Point(6, 21);
            this.lstCostiFissi.Name = "lstCostiFissi";
            this.lstCostiFissi.Size = new System.Drawing.Size(292, 334);
            this.lstCostiFissi.TabIndex = 0;
            // 
            // CostoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CostoFrm";
            this.Text = "Preventivo";
            this.Load += new System.EventHandler(this.PreventivoFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProdottoFinitoUC prodottoFinitoUC1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNotaPreventivo;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnCreaNuovaVersione;
        private System.Windows.Forms.ComboBox ddlPreventivi;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvElementi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEelementoPreventivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncludiPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrizione;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reparto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gruppo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Superficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantita;
        private System.Windows.Forms.DataGridViewTextBoxColumn PezziOrari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoArticolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ricarico;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotaPrevetivoCosto;
        private System.Windows.Forms.ComboBox ddlPreventivoCosto;
        private System.Windows.Forms.Button btnAggiorna_costiFissi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstCostiFissi;
    }
}