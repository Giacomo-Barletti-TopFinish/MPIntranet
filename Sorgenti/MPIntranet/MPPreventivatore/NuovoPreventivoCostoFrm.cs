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

            List<PreventivoCostoModel> lista = articolo.CreaListaPreventivoCostiModel(_preventivoModel.IdPreventivo);
            PreventivoCostoModel preventivoCreato = lista.Where(x => x.Preventvo.IdPreventivo == _preventivoModel.IdPreventivo && x.Versione == _versioni).FirstOrDefault();
            List<ElementoCostoPreventivoModel> elementiNuovi = creaElementiCostoPreventivo(preventivoCreato.IdPreventivoCosto);

            if (chkCopiaPrecedente.Checked)
            {
                PreventivoCostoModel preventivoDaCopiare = (PreventivoCostoModel)ddlVersionePrecedente.SelectedItem;
                List<ElementoCostoPreventivoModel> elementiDaCopiare = articolo.CreaListaElementoCostoPreventivoModel(preventivoDaCopiare.IdPreventivoCosto);
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
                    elementoNuovo.CostoCompleto = elemento.CostoCompleto;
                    elementoNuovo.CostoFigli = elemento.CostoFigli;
                    elementiNuovi.Add(elementoNuovo);
                }
            }
            articolo.SalvaElementiCostoPreventivo(elementiNuovi, preventivoCreato.IdPreventivoCosto, _account);
        }

        private List<ElementoCostoPreventivoModel> creaElementiCostoPreventivo(decimal idPreventivoCosto)
        {
            Articolo a = new Articolo();
            List<ElementoCostoPreventivoModel> lista = new List<ElementoCostoPreventivoModel>();

            List<ElementoPreventivoModel> elementiPreventivo = a.CreaListaElementoPreventivoModel(_preventivoModel.IdPreventivo);
            foreach (ElementoPreventivoModel elemento in elementiPreventivo)
            {
                ElementoCostoPreventivoModel elementoCosto = new ElementoCostoPreventivoModel();
                elementoCosto.IdElementoCosto = Articolo.EstraId();
                elementoCosto.ElementoPreventivo = elemento;
                elementoCosto.IdPreventivoCosto = idPreventivoCosto;
                elementoCosto.Ricarico = elemento.Ricarico;
                elementoCosto.CostoOrario = elemento.CostoOrario;
                elementoCosto.IncludiPreventivo = elemento.IncludiPreventivo;
                elementoCosto.IdEsterna = elemento.IdEsterna;
                elementoCosto.TabellaEsterna = elemento.TabellaEsterna;
                elementoCosto.PezziOrari = elemento.PezziOrari;
                elementoCosto.Quantita = elemento.Quantita;
               
                decimal costoPezzo = elemento.PezziOrari == 0 ? 0 : elemento.CostoOrario / elemento.PezziOrari;
                elementoCosto.CostoArticolo = (1 + elemento.Ricarico / 100) * costoPezzo;
                elementoCosto.CostoFigli = 0;
                elementoCosto.CostoCompleto = 0;
                lista.Add(elementoCosto);
            }
            Articolo.RicalcolaCostoFigliListaElementiCostoPreventiviModel(lista);
            return lista;
        }

        private void chkCopiaPrecedente_CheckedChanged(object sender, EventArgs e)
        {
            ddlVersionePrecedente.Enabled = chkCopiaPrecedente.Checked;
        }
    }
}
