using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPPreventivatore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class CreaProdottoFinitoFrm : ChildBaseForm
    {
        private Anagrafica _anagrafica = new Anagrafica();
        public decimal IdProdottoFinito = ElementiVuoti.ProdottoFinitoVuoto;

        public string RvlImageSite
        {
            get
            {
                return Settings.Default.RvlImageSite;
            }
        }
        public CreaProdottoFinitoFrm()
        {
            InitializeComponent();
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreaProdottoFinitoFrm_Load(object sender, EventArgs e)
        {
            lblMessaggio.Text = string.Empty;

            List<BrandModel> brand = _anagrafica.CreaListaBrandModel();
            ddlBrand.Items.AddRange(brand.ToArray());

            List<TipoProdottoModel> tipoProdotto = _anagrafica.CreaListaTipoProdottoModel();
            ddlTipoProdotto.Items.AddRange(tipoProdotto.ToArray());


            if (IdProdottoFinito >= 0)
            {
                Articolo articolo = new Articolo(string.Empty);
                ProdottoFinitoModel prodottoFinitoModel = articolo.CreaProdottoFinitoModel(IdProdottoFinito);
                if (prodottoFinitoModel == null)
                    throw new ArgumentNullException("Prodotto finito non trovato: " + IdProdottoFinito.ToString());

                ddlBrand.SelectedItem = brand.Where(x => x.IdBrand == prodottoFinitoModel.Brand.IdBrand).FirstOrDefault();
                txtCodice.Text = prodottoFinitoModel.Codice;
                txtCodiceDefinitivo.Text = prodottoFinitoModel.CodiceDefinitivo;
                txtCodiceProvvisorio.Text = prodottoFinitoModel.CodiceProvvisorio;
                txtDescrizione.Text = prodottoFinitoModel.Descrizione;
                txtModello.Text = prodottoFinitoModel.Modello;
                ddlTipoProdotto.SelectedItem = tipoProdotto.Where(x => x.IdTipoProdotto == prodottoFinitoModel.TipoProdotto.IdTipoProdotto).FirstOrDefault();
                chkPreserie.Checked = prodottoFinitoModel.Preserie;
                chkPreventivo.Checked = prodottoFinitoModel.Prevenivo;
                chkProduzione.Checked = prodottoFinitoModel.Produzione;
                CaricaListaColori(prodottoFinitoModel.Brand.IdBrand);
                ddlColore.SelectedItem = ddlColore.Items.Cast<ColoreModel>().Where(x => x.IdColore == prodottoFinitoModel.Colore.IdColore).FirstOrDefault();

            }

        }

        private void CaricaListaColori(decimal idBrand)
        {
            ddlColore.Items.Clear();
            List<ColoreModel> colori = _anagrafica.CreaListaColoreModel(string.Empty, string.Empty, string.Empty, string.Empty, idBrand);

            ddlColore.Items.AddRange(colori.OrderByDescending(x => x.CodiceFigurativo).ToArray());
        }

        private void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandModel brand = (BrandModel)ddlBrand.SelectedItem;
            if (brand != null)
                CaricaListaColori(brand.IdBrand);
        }

        private void btnCreaNuovo_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessaggio.Text = string.Empty;
                StringBuilder sb = new StringBuilder();
                bool esito = true;
                if (string.IsNullOrEmpty(txtCodice.Text))
                {
                    esito = false;
                    sb.AppendLine("Il campo CODICE è obbligatorio");
                }
                if (string.IsNullOrEmpty(txtModello.Text))
                {
                    esito = false;
                    sb.AppendLine("Il campo MODELLO è obbligatorio");
                }
                if (ddlBrand.SelectedIndex == -1)
                {
                    esito = false;
                    sb.AppendLine("Il campo BRAND è obbligatorio");
                }
                if (ddlColore.SelectedIndex == -1)
                {
                    esito = false;
                    sb.AppendLine("Il campo COLORE è obbligatorio");
                }
                if (ddlTipoProdotto.SelectedIndex == -1)
                {
                    esito = false;
                    sb.AppendLine("Il campo TIPO PRODOTTO è obbligatorio");
                }
                lblMessaggio.Text = sb.ToString();
                if (!esito) return;

                decimal idColore = (ddlColore.SelectedItem as ColoreModel).IdColore;
                decimal idBrand = (ddlBrand.SelectedItem as BrandModel).IdBrand;
                decimal idTipoProdotto = (ddlTipoProdotto.SelectedItem as TipoProdottoModel).IdTipoProdotto;

                string codice = txtCodice.Text.Trim().ToUpper();
                string modello = txtModello.Text.Trim().ToUpper();
                string descrizione = txtDescrizione.Text.Trim().ToUpper();
                string codiceProvvisorio = txtCodiceProvvisorio.Text.Trim().ToUpper();
                string codiceDefinitivo = txtCodiceDefinitivo.Text.Trim().ToUpper();
                bool preventivo = chkPreventivo.Checked;
                bool preserie = chkPreserie.Checked;
                bool produzione = chkProduzione.Checked;

                Articolo a = new Articolo(RvlImageSite);
                string messaggio;
                esito = a.EsistonoProdottiFinitiDuplicati(txtCodice.Text, txtModello.Text, idColore, idBrand, out messaggio);
                if (esito)
                {
                    lblMessaggio.Text = messaggio;
                    return;
                }

                lblMessaggio.Text = a.CreaProdottoFinito(idBrand, idColore, idTipoProdotto, codice, modello, descrizione, codiceProvvisorio, codiceDefinitivo, preventivo, preserie, produzione, _utenteConnesso);


            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea nuovo prodotto", ex);
            }
        }


    }
}
