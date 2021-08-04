using MPIntranet.Business;
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
    public partial class NuovaDistintaFrm : Form
    {
        public Articolo Articolo;
        private string Utente;
        public int IDDIBA_OUT;
        public NuovaDistintaFrm(Articolo articolo, string utente)
        {
            InitializeComponent();
            Articolo = articolo;
            Utente = utente;
        }

        private void NuovaDistintaFrm_Load(object sender, EventArgs e)
        {
            this.Text = "Nuova distinta per " + Articolo.ToString();

            List<TipoDistinta> tipiDistinta = TipoDistinta.EstraiListaTipoDistinta(true);

            ddlTipoDistinta.Items.AddRange(tipiDistinta.ToArray());
        }

        private void ddlTipoDistinta_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDistinta tipoDistinta = (TipoDistinta)ddlTipoDistinta.SelectedItem;
            List<DistintaBase> distinte = DistintaBase.EstraiListaDistinteBase(Articolo.IdArticolo);

            distinte = distinte.Where(x => x.TipoDistinta.IdTipoDiBa == tipoDistinta.IdTipoDiBa).ToList();
            if (distinte.Count > 0)
            {
                int versione = distinte.Max(x => x.Versione);
                txtVersione.Text = (versione++).ToString();
            }
            else
                txtVersione.Text = "1";
        }

        private void btnCreaDistinta_Click(object sender, EventArgs e)
        {
            txtDescrizione.Text = txtDescrizione.Text.ToUpper();
            StringBuilder sb = new StringBuilder();
            bool esito = false;

            if (string.IsNullOrEmpty(txtDescrizione.Text))
            {
                esito = true;
                sb.AppendLine("La descrizione è obbligatoria");
            }
            if (ddlTipoDistinta.SelectedIndex == -1)
            {
                esito = true;
                sb.AppendLine("Indicare il tipo di distinta");
            }

            if (esito)
            {
                lblMessage.Text = sb.ToString();
                return;
            }
            TipoDistinta tipoDistinta = (TipoDistinta)ddlTipoDistinta.SelectedItem;
            int versione = 1;
            if (!Int32.TryParse(txtVersione.Text, out versione)) versione = 1;

            int idDiba = ElementiVuoti.DistintaBase;
            DistintaBase.CreaDistinta(Articolo.IdArticolo, tipoDistinta.IdTipoDiBa, versione, txtDescrizione.Text, false, Utente, out idDiba);
            IDDIBA_OUT = idDiba;
            DialogResult = DialogResult.OK;
        }
    }
}
