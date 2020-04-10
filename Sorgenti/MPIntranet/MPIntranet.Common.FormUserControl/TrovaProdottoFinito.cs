using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Entities;
using MPIntranet.Business;
using MPIntranet.Models.Articolo;

namespace MPIntranet.Common.FormUserControl
{
    public partial class TrovaProdottoFinitoUC : UserControl
    {
        public TrovaProdottoFinitoUC()
        {
            InitializeComponent();
        }

        public event EventHandler RicercaTerminata;

        List<ProdottoFinitoModel> _risultati = new List<ProdottoFinitoModel>();

        private void TrovaProdottoFinito_Load(object sender, EventArgs e)
        {
            Anagrafica anagrafica = new Anagrafica();
            lblMessaggio.Text = string.Empty;

            List<BrandModel> brand = anagrafica.CreaListaBrandModel();
            ddlBrand.Items.AddRange(brand.ToArray());

            //List<TipoProdottoModel> tipoProdotto = anagrafica.CreaListaTipoProdottoModel();
            //ddlTipoProdotto.Items.AddRange(tipoProdotto.ToArray());
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            //decimal idColore = ElementiVuoti.ColoreVuoto;
            //decimal idBrand = ElementiVuoti.BrandVuoto;
            //decimal idTipoProdotto = ElementiVuoti.TipoProdottoVuoto;

            //if (ddlBrand.SelectedIndex != -1)
            //    idBrand = (ddlBrand.SelectedItem as BrandModel).IdBrand;

            //if (ddlColore.SelectedIndex != -1)
            //    idColore = (ddlColore.SelectedItem as ColoreModel).IdColore;

            //if (ddlTipoProdotto.SelectedIndex != -1)
            //    idTipoProdotto = (ddlTipoProdotto.SelectedItem as TipoProdottoModel).IdTipoProdotto;


            //string codice = txtCodice.Text.Trim().ToUpper();
            //string modello = txtModello.Text.Trim().ToUpper();
            //string descrizione = txtDescrizione.Text.Trim().ToUpper();
            //string codiceProvvisorio = txtCodiceProvvisorio.Text.Trim().ToUpper();
            //string codiceDefinitivo = txtCodiceDefinitivo.Text.Trim().ToUpper();
            //bool preventivo = chkPreventivo.Checked;
            //bool preserie = chkPreserie.Checked;
            //bool produzione = chkProduzione.Checked;

            //Articolo a = new Articolo(string.Empty);
            //_risultati = a.TrovaProdottiFiniti(idBrand, idColore, idTipoProdotto, codice, modello, descrizione, codiceProvvisorio, codiceDefinitivo, preventivo, preserie, produzione);
            //OnRicercaTerminata(EventArgs.Empty);
        }
        protected virtual void OnRicercaTerminata(EventArgs e)
        {
            RicercaTerminata?.Invoke(this, e);
        }

        private void CaricaListaColori(decimal idBrand)
        {
            //ddlColore.Items.Clear();
            //Anagrafica anagrafica = new Anagrafica();
            //List<ColoreModel> colori = anagrafica.CreaListaColoreModel(string.Empty, string.Empty, string.Empty, string.Empty, idBrand);

            //ddlColore.Items.AddRange(colori.OrderByDescending(x => x.CodiceFigurativo).ToArray());
        }

        private void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == -1) return;
            BrandModel brand = (BrandModel)ddlBrand.SelectedItem;
            if (brand != null)
                CaricaListaColori(brand.IdBrand);
        }
    }
}
