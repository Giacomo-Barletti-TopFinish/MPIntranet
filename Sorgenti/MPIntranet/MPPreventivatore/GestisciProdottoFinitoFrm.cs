using MPIntranet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPIntranet.Business;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Anagrafica;
using MPIntranet.DataAccess;
using MPIntranet.DataAccess.Anagrafica;
using System.Data;
using MPIntranet.Entities;
using MPIntranet.Models.Common;

namespace MPPreventivatore
{
    public partial class GestisciProdottoFinitoFrm : ChildBaseForm
    {
        Anagrafica _anagrafica = new Anagrafica();
        Articolo _articolo = new Articolo(string.Empty);

        public GestisciProdottoFinitoFrm()
        {
            InitializeComponent();
        }

        private void GestisciProdottoFinitoFrm_Load(object sender, EventArgs e)
        {
            lblMessaggio.Text = string.Empty;

            List<BrandModel> brand = _anagrafica.CreaListaBrandModel();
            List<MPIntranetListItem> elementiBrand = brand.Select(x => new MPIntranetListItem(x.Brand, x.IdBrand.ToString())).ToList();
            elementiBrand.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.BrandVuoto.ToString()));
            ddlBrand.Items.AddRange(elementiBrand.ToArray());

            List<TipoProdottoModel> tipoProdotto = _anagrafica.CreaListaTipoProdottoModel();
            List<MPIntranetListItem> elementiTipoProdotto = tipoProdotto.Select(x => new MPIntranetListItem(x.ToString(), x.IdTipoProdotto.ToString())).ToList();
            elementiTipoProdotto.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.TipoProdottoVuoto.ToString()));
            ddlTipoProdotto.Items.AddRange(elementiTipoProdotto.ToArray());
        }

        private void CaricaListaColori(decimal idBrand)
        {
            ddlColore.Items.Clear();
            List<ColoreModel> colori = _anagrafica.CreaListaColoreModel(string.Empty, string.Empty, string.Empty, string.Empty, idBrand);
            List<MPIntranetListItem> elementi = colori.Select(x => new MPIntranetListItem(x.ToString(), x.IdColore.ToString())).ToList();
            elementi.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.ColoreVuoto.ToString()));
            ddlColore.Items.AddRange(elementi.ToArray());
        }

        private void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == -1) return;
            BrandModel brand = (BrandModel)ddlBrand.SelectedItem;
            if (brand != null)
                CaricaListaColori(brand.IdBrand);
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblMessaggio.Text = string.Empty;
                decimal idColore = ElementiVuoti.ColoreVuoto;
                decimal idBrand = ElementiVuoti.BrandVuoto;
                decimal idTipoProdotto = ElementiVuoti.TipoProdottoVuoto;

                if (ddlBrand.SelectedIndex != -1)
                    idBrand = decimal.Parse((ddlBrand.SelectedItem as MPIntranetListItem).Value);

                if (ddlColore.SelectedIndex != -1)
                    idColore = decimal.Parse((ddlColore.SelectedItem as MPIntranetListItem).Value);

                if (ddlTipoProdotto.SelectedIndex != -1)
                    idTipoProdotto = decimal.Parse((ddlTipoProdotto.SelectedItem as MPIntranetListItem).Value);


                string codice = txtCodice.Text.Trim().ToUpper();
                string modello = txtModello.Text.Trim().ToUpper();
                string descrizione = txtDescrizione.Text.Trim().ToUpper();
                string codiceProvvisorio = txtCodiceProvvisorio.Text.Trim().ToUpper();
                string codiceDefinitivo = txtCodiceDefinitivo.Text.Trim().ToUpper();
                bool preventivo = chkPreventivo.Checked;
                bool preserie = chkPreserie.Checked;
                bool produzione = chkProduzione.Checked;

                Articolo a = new Articolo(string.Empty);
                List<ProdottoFinitoModel> risultati = a.TrovaProdottiFiniti(idBrand, idColore, idTipoProdotto, codice, modello, descrizione, codiceProvvisorio, codiceDefinitivo, preventivo, preserie, produzione);

                BindingSource source = new BindingSource();
                source.DataSource = risultati;
                dgvRisultati.DataSource = source;
                dgvRisultati.Columns[0].Visible = false;
                dgvRisultati.Columns[2].Width = 200;
                dgvRisultati.Columns[3].Width = 150;
                dgvRisultati.Columns[4].Width = 150;
                dgvRisultati.Columns[5].Width = 200;
                dgvRisultati.Columns[5].HeaderText = "Tipo prodotto";
                dgvRisultati.Columns[6].Width = 200;
                dgvRisultati.Columns[7].Width = 100;
                dgvRisultati.Columns[7].HeaderText = "Cod. definitivo";
                dgvRisultati.Columns[8].Width = 100;
                dgvRisultati.Columns[8].HeaderText = "Cod. provvisorio";
                dgvRisultati.Columns[9].Width = 80;
                dgvRisultati.Columns[10].Width = 80;
                dgvRisultati.Columns[11].Width = 80;

            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in cerca prodotto finito", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnNuovoProdottoFinito_Click(object sender, EventArgs e)
        {
            try
            {
                CreaProdottoFinitoFrm form = new CreaProdottoFinitoFrm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea prodottofinito", ex);
            }

        }
    }

}
