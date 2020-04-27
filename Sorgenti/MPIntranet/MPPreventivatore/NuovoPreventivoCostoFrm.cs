using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Articolo;
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
    public partial class NuovoPreventivoCostoFrm : Form
    {
        private PreventivoModel _preventivoModel;
        private int _versioni;
        private string _account;

        public NuovoPreventivoCostoFrm(PreventivoModel preventivoModel, int versioni, string account)
        {
            _preventivoModel = preventivoModel;
            _versioni = versioni + 1;
            _account = account;
            InitializeComponent();
        }

        private void NuovoPreventivoFrm_Load(object sender, EventArgs e)
        {
            lblArticolo.Text = _preventivoModel.ToString();
            lblMessaggio.Text = string.Empty;
            txtVersione.Text = _versioni.ToString();

            caricaPreventivi();
        }


        private void caricaPreventivi()
        {
            Articolo a = new Articolo();
            ddlVersionePrecedente.Items.Clear();
            ddlVersionePrecedente.Items.AddRange(a.CreaListaPreventivoCostiModel(_preventivoModel.IdPreventivo).ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescrizione.Text))
            {
                lblMessaggio.Text = "La descrizione è obbligaoria";
                return;
            }

            if (chkCopiaPrecedente.Checked && ddlVersionePrecedente.SelectedIndex == -1)
            {
                lblMessaggio.Text = "Selezionare la versione precedente da copiare";
                return;
            }
            lblMessaggio.Text = string.Empty;
            Articolo articolo = new Articolo(string.Empty);
            lblMessaggio.Text = articolo.CreaPreventivoCosto(_versioni, txtDescrizione.Text, _preventivoModel.IdPreventivo, txtNota.Text, _account);

            if (!chkCopiaPrecedente.Checked) return;
            Articolo a = new Articolo();
            List<PreventivoCostoModel> lista = a.CreaListaPreventivoCostiModel(_preventivoModel.IdPreventivo);
            PreventivoCostoModel preventivoCreato = lista.Where(x => x.Preventvo.IdPreventivo == _preventivoModel.IdPreventivo && x.Versione == _versioni).FirstOrDefault();

            PreventivoCostoModel preventivoDaCopiare = (PreventivoCostoModel)ddlVersionePrecedente.SelectedItem;
            List<ElementoCostoPreventivoModel> elementiDaCopiare = a.CreaListaElementoCostoPreventivoModel(preventivoDaCopiare.IdPreventivoCosto);
            List<ElementoCostoPreventivoModel> elementiNuovi = new List<ElementoCostoPreventivoModel>();
            foreach (ElementoCostoPreventivoModel elemento in elementiDaCopiare)
            {
                ElementoCostoPreventivoModel elementoNuovo = new ElementoCostoPreventivoModel();
                elementoNuovo.IdElementoCosto = Articolo.EstraId();
                elementoNuovo.ElementoPreventivo = elemento.ElementoPreventivo;
                elementoNuovo.IdPreventivoCosto = preventivoCreato.IdPreventivoCosto;
                elementoNuovo.Ricarico = elemento.Ricarico;
                elementoNuovo.CostoOrario = elemento.CostoOrario;
                elementoNuovo.IncludiPreventivo = elemento.IncludiPreventivo;
                elementoNuovo.IdEsterna = elemento.IdEsterna;
                elementoNuovo.TabellaEsterna = elemento.TabellaEsterna;
                elementoNuovo.PezziOrari = elemento.PezziOrari;
                elementoNuovo.Quantita = elemento.Quantita;
                elementoNuovo.CostoArticolo = elemento.CostoArticolo;
                elementoNuovo.Prezzo = elemento.Prezzo;
                elementiNuovi.Add(elementoNuovo);
            }
            a.SalvaElementiCostoPreventivo(elementiNuovi, preventivoCreato.IdPreventivoCosto, _account);
        }


        private void chkCopiaPrecedente_CheckedChanged(object sender, EventArgs e)
        {
            ddlVersionePrecedente.Enabled = chkCopiaPrecedente.Checked;
        }
    }
}
