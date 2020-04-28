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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTotali = new System.Windows.Forms.TabPage();
            this.tabDettaglio = new System.Windows.Forms.TabPage();
            this.tabGriglie = new System.Windows.Forms.TabPage();
            this.tabCostiFissi = new System.Windows.Forms.TabPage();
            this.btnAggiorna_costiFissi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstCostiFissi = new System.Windows.Forms.ListBox();
            this.IdElementoCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Ricarico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pezziorari_std = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costostd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ricarico_std = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottoFinitoUC1 = new MPPreventivatore.ProdottoFinitoUC();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDettaglio.SuspendLayout();
            this.tabCostiFissi.SuspendLayout();
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
            this.dgvElementi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElementi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElementi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdElementoCosto,
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
            this.Ricarico,
            this.Prezzo,
            this.pezziorari_std,
            this.costostd,
            this.ricarico_std});
            this.dgvElementi.Location = new System.Drawing.Point(3, 3);
            this.dgvElementi.MultiSelect = false;
            this.dgvElementi.Name = "dgvElementi";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElementi.Size = new System.Drawing.Size(894, 385);
            this.dgvElementi.TabIndex = 9;
            this.dgvElementi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellClick);
            this.dgvElementi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementi_CellEndEdit);
            this.dgvElementi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvElementi_EditingControlShowing);
            this.dgvElementi.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvElementi_RowPrePaint);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabTotali);
            this.tabControl1.Controls.Add(this.tabDettaglio);
            this.tabControl1.Controls.Add(this.tabGriglie);
            this.tabControl1.Controls.Add(this.tabCostiFissi);
            this.tabControl1.Location = new System.Drawing.Point(464, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 421);
            this.tabControl1.TabIndex = 10;
            // 
            // tabTotali
            // 
            this.tabTotali.Location = new System.Drawing.Point(4, 24);
            this.tabTotali.Name = "tabTotali";
            this.tabTotali.Padding = new System.Windows.Forms.Padding(3);
            this.tabTotali.Size = new System.Drawing.Size(900, 393);
            this.tabTotali.TabIndex = 3;
            this.tabTotali.Text = "Totali";
            this.tabTotali.UseVisualStyleBackColor = true;
            // 
            // tabDettaglio
            // 
            this.tabDettaglio.Controls.Add(this.dgvElementi);
            this.tabDettaglio.Location = new System.Drawing.Point(4, 24);
            this.tabDettaglio.Name = "tabDettaglio";
            this.tabDettaglio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettaglio.Size = new System.Drawing.Size(900, 393);
            this.tabDettaglio.TabIndex = 0;
            this.tabDettaglio.Text = "Dettaglio elementi";
            this.tabDettaglio.UseVisualStyleBackColor = true;
            // 
            // tabGriglie
            // 
            this.tabGriglie.Location = new System.Drawing.Point(4, 24);
            this.tabGriglie.Name = "tabGriglie";
            this.tabGriglie.Padding = new System.Windows.Forms.Padding(3);
            this.tabGriglie.Size = new System.Drawing.Size(900, 393);
            this.tabGriglie.TabIndex = 1;
            this.tabGriglie.Text = "Gruppi";
            this.tabGriglie.UseVisualStyleBackColor = true;
            // 
            // tabCostiFissi
            // 
            this.tabCostiFissi.Controls.Add(this.btnAggiorna_costiFissi);
            this.tabCostiFissi.Controls.Add(this.dataGridView1);
            this.tabCostiFissi.Controls.Add(this.lstCostiFissi);
            this.tabCostiFissi.Location = new System.Drawing.Point(4, 24);
            this.tabCostiFissi.Name = "tabCostiFissi";
            this.tabCostiFissi.Padding = new System.Windows.Forms.Padding(3);
            this.tabCostiFissi.Size = new System.Drawing.Size(900, 393);
            this.tabCostiFissi.TabIndex = 2;
            this.tabCostiFissi.Text = "Costi fissi";
            this.tabCostiFissi.UseVisualStyleBackColor = true;
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
            // IdElementoCosto
            // 
            this.IdElementoCosto.DataPropertyName = "IdElementoCosto";
            this.IdElementoCosto.HeaderText = "IdElementoCosto";
            this.IdElementoCosto.Name = "IdElementoCosto";
            this.IdElementoCosto.Visible = false;
            // 
            // IncludiPreventivo
            // 
            this.IncludiPreventivo.DataPropertyName = "IncludiPreventivo";
            this.IncludiPreventivo.HeaderText = "Includi";
            this.IncludiPreventivo.Name = "IncludiPreventivo";
            // 
            // Articolo
            // 
            this.Articolo.DataPropertyName = "ElementoPreventivo.Articolo";
            this.Articolo.HeaderText = "Articolo";
            this.Articolo.MaxInputLength = 30;
            this.Articolo.Name = "Articolo";
            this.Articolo.ReadOnly = true;
            // 
            // Codice
            // 
            this.Codice.DataPropertyName = "ElementoPreventivo.Codice";
            this.Codice.HeaderText = "Codice";
            this.Codice.Name = "Codice";
            this.Codice.ReadOnly = true;
            // 
            // Descrizione
            // 
            this.Descrizione.DataPropertyName = "ElementoPreventivo.Descrizione";
            this.Descrizione.HeaderText = "Descrizione";
            this.Descrizione.Name = "Descrizione";
            this.Descrizione.ReadOnly = true;
            // 
            // Reparto
            // 
            this.Reparto.DataPropertyName = "ElementoPreventivo.Reparto";
            this.Reparto.HeaderText = "Reparto";
            this.Reparto.Name = "Reparto";
            this.Reparto.ReadOnly = true;
            // 
            // Gruppo
            // 
            this.Gruppo.HeaderText = "ElementoPreventivo.Gruppo";
            this.Gruppo.Name = "Gruppo";
            this.Gruppo.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "ElementoPreventivo.Peso";
            this.Peso.FillWeight = 80F;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            this.Peso.Width = 80;
            // 
            // Superficie
            // 
            this.Superficie.DataPropertyName = "ElementoPreventivo.Superficie";
            this.Superficie.FillWeight = 80F;
            this.Superficie.HeaderText = "Superficie";
            this.Superficie.Name = "Superficie";
            this.Superficie.ReadOnly = true;
            this.Superficie.Width = 80;
            // 
            // Quantita
            // 
            this.Quantita.DataPropertyName = "ElementoPreventivo.Quantita";
            this.Quantita.FillWeight = 80F;
            this.Quantita.HeaderText = "Quantità";
            this.Quantita.Name = "Quantita";
            this.Quantita.ReadOnly = true;
            this.Quantita.Width = 80;
            // 
            // PezziOrari
            // 
            this.PezziOrari.DataPropertyName = "PZ/H";
            this.PezziOrari.FillWeight = 80F;
            this.PezziOrari.HeaderText = "Pezzi orari";
            this.PezziOrari.Name = "PezziOrari";
            this.PezziOrari.Width = 80;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "ElementoPreventivo.Costo";
            this.Costo.HeaderText = "CostoHH";
            this.Costo.Name = "Costo";
            // 
            // Ricarico
            // 
            this.Ricarico.DataPropertyName = "Ricarico";
            this.Ricarico.HeaderText = "Ricarico";
            this.Ricarico.Name = "Ricarico";
            // 
            // Prezzo
            // 
            this.Prezzo.HeaderText = "Prezzo";
            this.Prezzo.Name = "Prezzo";
            // 
            // pezziorari_std
            // 
            this.pezziorari_std.HeaderText = "PZ/H std";
            this.pezziorari_std.Name = "pezziorari_std";
            this.pezziorari_std.ReadOnly = true;
            // 
            // costostd
            // 
            this.costostd.HeaderText = "CostoHH std";
            this.costostd.Name = "costostd";
            this.costostd.ReadOnly = true;
            // 
            // ricarico_std
            // 
            this.ricarico_std.HeaderText = "Ricarico std";
            this.ricarico_std.Name = "ricarico_std";
            this.ricarico_std.ReadOnly = true;
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
            this.Load += new System.EventHandler(this.CostoFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementi)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDettaglio.ResumeLayout(false);
            this.tabCostiFissi.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDettaglio;
        private System.Windows.Forms.TabPage tabGriglie;
        private System.Windows.Forms.TabPage tabCostiFissi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotaPrevetivoCosto;
        private System.Windows.Forms.ComboBox ddlPreventivoCosto;
        private System.Windows.Forms.Button btnAggiorna_costiFissi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstCostiFissi;
        private System.Windows.Forms.TabPage tabTotali;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEelementoPreventivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdElementoCosto;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Ricarico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pezziorari_std;
        private System.Windows.Forms.DataGridViewTextBoxColumn costostd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ricarico_std;
    }
}