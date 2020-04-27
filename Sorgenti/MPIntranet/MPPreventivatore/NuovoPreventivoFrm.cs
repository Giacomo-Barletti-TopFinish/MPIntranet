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
    public partial class NuovoPreventivoFrm : Form
    {
        private ProdottoFinitoModel _prodottoFinito;
        private int _versioni;
        private string _account;
        public NuovoPreventivoFrm(ProdottoFinitoModel prodottoFinitoModel, int versioni, string account)
        {
            _prodottoFinito = prodottoFinitoModel;
            _versioni = versioni + 1;
            _account = account;
            InitializeComponent();
        }

        private void NuovoPreventivoFrm_Load(object sender, EventArgs e)
        {
            lblArticolo.Text = _prodottoFinito.ToString();
            lblMessaggio.Text = string.Empty;
            txtVersione.Text = _versioni.ToString();

            caricaPreventivi();
        }


        private void caricaPreventivi()
        {
            Articolo a = new Articolo();
            ddlVersionePrecedente.Items.Clear();
            ddlVersionePrecedente.Items.AddRange(a.CreaListaPreventivoModel(_prodottoFinito.IdProdottoFinito).ToArray());
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
            lblMessaggio.Text = articolo.CreaPreventivo(_versioni, txtDescrizione.Text, _prodottoFinito.IdProdottoFinito, txtNota.Text, _account);

            if (!chkCopiaPrecedente.Checked) return;

            Articolo a = new Articolo();
            List<PreventivoModel> lista = a.CreaListaPreventivoModel(_prodottoFinito.IdProdottoFinito);
            PreventivoModel preventivoCreato = lista.Where(x => x.ProdottoFinito.IdProdottoFinito == _prodottoFinito.IdProdottoFinito && x.Versione == _versioni).FirstOrDefault();

            PreventivoModel preventivoDaCopiare = (PreventivoModel)ddlVersionePrecedente.SelectedItem;
            List<ElementoPreventivoModel> elementiDaCopiare = a.CreaListaElementoPreventivoModel(preventivoDaCopiare.IdPreventivo);
            List<ElementoPreventivoModel> elementiNuovi = new List<ElementoPreventivoModel>();
            foreach (ElementoPreventivoModel elemento in elementiDaCopiare.Where(x => x.IdPadre == -1))
            {
                copiaElemento(elementiNuovi, elemento, -1, preventivoCreato.IdPreventivo, elementiDaCopiare);
            }
            a.SalvaElementiPreventivo(elementiNuovi, preventivoCreato.IdPreventivo, _account);
        }

        private void copiaElemento(List<ElementoPreventivoModel> elementiNuovi, ElementoPreventivoModel elemento, decimal nuovoIdPadre, decimal idPreventivouovo, List<ElementoPreventivoModel> elementiDaCopiare)
        {
            ElementoPreventivoModel elementoNuovo = new ElementoPreventivoModel();
            elementoNuovo.IdElementoPreventivo = Articolo.EstraId();
            elementoNuovo.IdPadre = nuovoIdPadre;
            elementoNuovo.IdPreventivo = idPreventivouovo;
            elementoNuovo.Codice = elemento.Codice;
            elementoNuovo.Reparto = elemento.Reparto;
            elementoNuovo.Ricarico = elemento.Ricarico;
            elementoNuovo.CostoOrario = elemento.CostoOrario;
            elementoNuovo.IncludiPreventivo = elemento.IncludiPreventivo;
            elementoNuovo.IdEsterna = elemento.IdEsterna;
            elementoNuovo.TabellaEsterna = elemento.TabellaEsterna;
            elementoNuovo.PezziOrari = elemento.PezziOrari;
            elementoNuovo.Peso = elemento.Peso;
            elementoNuovo.Superficie = elemento.Superficie;
            elementoNuovo.Quantita = elemento.Quantita;
            elementoNuovo.Descrizione = elemento.Descrizione;
            elementoNuovo.Articolo = elemento.Articolo;
            elementoNuovo.Nota = elemento.Nota;
            elementiNuovi.Add(elementoNuovo);

            foreach (ElementoPreventivoModel elementoFiglio in elementiDaCopiare.Where(x => x.IdPadre == elemento.IdElementoPreventivo))
            {
                copiaElemento(elementiNuovi, elementoFiglio, elementoNuovo.IdElementoPreventivo, idPreventivouovo, elementiDaCopiare);
            }
        }

        private void chkCopiaPrecedente_CheckedChanged(object sender, EventArgs e)
        {
            ddlVersionePrecedente.Enabled = chkCopiaPrecedente.Checked;
        }
    }
}
