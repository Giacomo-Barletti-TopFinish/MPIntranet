﻿using MPIntranet.Business;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisegnaDiBa
{
    public partial class NuovoArticoloFrm : Form
    {
        public string Utente;
        public int IDArticolo = ElementiVuoti.Articolo;
        private List<Articolo> articoli = new List<Articolo>();
        public NuovoArticoloFrm()
        {
            InitializeComponent();
            lblMessage.Text = string.Empty;
            dgvArticoli.AutoGenerateColumns = false;
        }

        private void NuovoArticoloFrm_Load(object sender, EventArgs e)
        {
            caricaBrand();
        }

        private void caricaBrand()
        {
            List<Brand> brands = MPIntranet.Business.Brand.EstraiListaBrand(true);
            ddlBrands.Items.AddRange(brands.ToArray());
        }

        private void btnCreaArticolo_Click(object sender, EventArgs e)
        {
            convertiTesto();
            lblMessage.Text = string.Empty;
            string messaggio = string.Empty; ;
            if (string.IsNullOrEmpty(txtDescrizione.Text))
            {
                lblMessage.Text = "La descrizione è obbligatoria";
                return;
            }

            if (ddlBrands.SelectedIndex == -1)
            {
                lblMessage.Text = "Selezionare un brand";
                return;
            }
            Brand brand = (Brand)ddlBrands.SelectedItem;
            articoli = Articolo.TrovaArticoli(txtAnagrafica.Text, txtDescrizione.Text, brand.IdBrand, txtCodiceCliente.Text, txtColore.Text);

            if (articoli.Count == 0)
            {
                Articolo.CreaArticolo(brand.IdBrand, txtAnagrafica.Text, txtDescrizione.Text, txtCodiceCliente.Text, txtColore.Text, Utente);
                lblMessage.Text = "Articolo creato correttamente";
                articoli = Articolo.TrovaArticoli(txtAnagrafica.Text, txtDescrizione.Text, brand.IdBrand, txtCodiceCliente.Text, txtColore.Text);
            }
            else
            {
                lblMessage.Text = "Esistono già articoli con queste caratteristiche";
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = articoli;
            dgvArticoli.DataSource = bs;
        }

        private void dgvArticoli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDArticolo = articoli[e.RowIndex].IdArticolo;
            DialogResult = DialogResult.OK;
        }

        private void convertiTesto()
        {
            txtAnagrafica.Text = txtAnagrafica.Text.ToUpper();
            txtDescrizione.Text = txtDescrizione.Text.ToUpper();
            txtCodiceCliente.Text = txtCodiceCliente.Text.ToUpper();
            txtColore.Text = txtColore.Text.ToUpper();

        }

        private void btnTrovaArticolo_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            convertiTesto();
            if (ddlBrands.SelectedIndex == -1)
            {
                lblMessage.Text = "Selezionare un brand";
                return;
            }
            Brand brand = (Brand)ddlBrands.SelectedItem;
            articoli = Articolo.TrovaArticoli(txtAnagrafica.Text, txtDescrizione.Text, brand.IdBrand, txtCodiceCliente.Text, txtColore.Text);
            BindingList<Articolo> bl = new BindingList<Articolo>(articoli);
            BindingSource bs = new BindingSource(bl,null);
            dgvArticoli.DataSource = bs;
            dgvArticoli.Update();
            dgvArticoli.Refresh();
        }
    }
}