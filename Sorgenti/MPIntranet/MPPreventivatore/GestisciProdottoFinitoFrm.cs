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
        private TipoRicerca _tipoRicerca;
        public GestisciProdottoFinitoFrm(TipoRicerca TipoRicerca)
        {
            _tipoRicerca = TipoRicerca;
            InitializeComponent();
        }

        private void GestisciProdottoFinitoFrm_Load(object sender, EventArgs e)
        {
            if (_tipoRicerca == TipoRicerca.Preventivo)
            {
                btnNuovoProdottoFinito.Visible = false;
                chkPreventivo.Checked = true;
                chkPreventivo.Enabled = false;
            }
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
            MPIntranetListItem brand = (MPIntranetListItem)ddlBrand.SelectedItem;
            decimal idBrand = decimal.Parse(brand.Value);
            CaricaListaColori(idBrand);
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

                caricaPannello(risultati);
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
        private void caricaPannello(List<ProdottoFinitoModel> risultati)
        {
            Documenti documenti = new Documenti();
            string filename;
            tableLayoutPanel1.RowCount = 5;
            foreach (ProdottoFinitoModel prodottoFinito in risultati)
            {
                byte[] immagine = documenti.EstraiImmagineStandard(prodottoFinito.IdProdottoFinito, TabelleEsterne.ProdottiFiniti, out filename);
                ProdottoFinitoUC uc = new ProdottoFinitoUC();
                uc.ProdottoFinitoModel = prodottoFinito;
                uc.Immagine = immagine;
                uc.Click += Uc_Click;
                tableLayoutPanel1.Controls.Add(uc);
            }
        }

        private void Uc_Click(object sender, EventArgs e)
        {
            try
            {
                ProdottoFinitoUC uc = (ProdottoFinitoUC)sender;
                decimal idProdottoFinito = (decimal)uc.ProdottoFinitoModel.IdProdottoFinito;
                switch (_tipoRicerca)
                {
                    case TipoRicerca.ProdottoFinito:
                        (MdiParent as MainForm).ApriFinestraProdottoFinito(idProdottoFinito);
                        break;
                    case TipoRicerca.Preventivo:
                        (MdiParent as MainForm).ApriFinestraPreventivo(idProdottoFinito);
                        break;
                    case TipoRicerca.Costo:
                        (MdiParent as MainForm).ApriFinestraCosto(idProdottoFinito);
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in vai a finestra successiva", ex);
            }

        }

        private void btnNuovoProdottoFinito_Click(object sender, EventArgs e)
        {
            try
            {
                CreaProdottoFinitoFrm form = new CreaProdottoFinitoFrm();
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea prodottofinito", ex);
            }

        }


        private void tableLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {

        }
    }

}
