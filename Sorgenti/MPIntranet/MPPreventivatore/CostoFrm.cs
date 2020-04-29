using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class CostoFrm : ChildBaseForm
    {
        public decimal IdProdottoFinito;
        //    private Articolo _articolo = new Articolo(string.Empty);
        private Documenti _documenti = new Documenti();
        private Anagrafica _anagrafica = new Anagrafica();
        private List<ElementoCostoPreventivoModel> _elementiCostoPreventivo = new List<ElementoCostoPreventivoModel>();
        private BindingSource _sourceCostiFissi = new BindingSource();
        private BindingSource _source = new BindingSource();
        private List<CostoFissoPreventivoModel> _costiFissiPreventivoModel = new List<CostoFissoPreventivoModel>();

        private List<GruppoRepartoModel> _gruppiRepartiModel;

        private PreventivoModel _preventivoSelezionato
        {
            get
            {
                if (ddlPreventivi.SelectedIndex == -1) return null;
                return (PreventivoModel)ddlPreventivi.SelectedItem;
            }
        }
        private PreventivoCostoModel _preventivoCostoSelezionato
        {
            get
            {
                if (ddlPreventivoCosto.SelectedIndex == -1) return null;
                return (PreventivoCostoModel)ddlPreventivoCosto.SelectedItem;
            }
        }
        public CostoFrm()
        {
            InitializeComponent();
        }

        private void CostoFrm_Load(object sender, EventArgs e)
        {
            Articolo articolo = new Articolo();
            string filename;
            prodottoFinitoUC1.ProdottoFinitoModel = articolo.CreaProdottoFinitoModel(IdProdottoFinito);
            prodottoFinitoUC1.Immagine = _documenti.EstraiImmagineStandard(IdProdottoFinito, TabelleEsterne.ProdottiFiniti, out filename);
            prodottoFinitoUC1.Refresh();
            _gruppiRepartiModel = articolo.CreaListaGruppoRepartoModel(prodottoFinitoUC1.ProdottoFinitoModel.Brand.IdBrand);
            caricaDdlPreventivi();

            caricaListaCostiFissi();
            caricaGrigliaElementiPreventivo();
            caricaGrigliaCostiFissi();
            this.Text = prodottoFinitoUC1.ProdottoFinitoModel.ToString();
        }

        private void caricaListaCostiFissi()
        {
            Anagrafica anagrafica = new Anagrafica();
            List<CostoFissoModel> costiFissiModel = anagrafica.CreaListaCostoFissoModel();
            lstCostiFissi.Items.Clear();
            lstCostiFissi.Items.AddRange(costiFissiModel.ToArray());
        }
        private void caricaGrigliaElementiPreventivo()
        {
            dgvElementi.AutoGenerateColumns = false;

            _source.DataSource = _elementiCostoPreventivo;
            dgvElementi.DataSource = _source;
        }
        private void RefreshGridViewCostiFissi()
        {
            _sourceCostiFissi.ResetBindings(false);
            dgvCostiFissi.Update();
            dgvCostiFissi.Refresh();
        }
        private void caricaGrigliaCostiFissi()
        {
            dgvCostiFissi.AutoGenerateColumns = false;

            _sourceCostiFissi.DataSource = _costiFissiPreventivoModel;
            dgvCostiFissi.DataSource = _sourceCostiFissi;
        }
        private void caricaDdlPreventivi()
        {
            Articolo articolo = new Articolo();
            ddlPreventivi.Items.Clear();
            ddlPreventivi.Items.AddRange(articolo.CreaListaPreventivoModel(IdProdottoFinito).ToArray());
            if (ddlPreventivi.Items.Count > 0)
                ddlPreventivi.SelectedIndex = 0;
        }


        private void btnCreaNuovaVersione_Click(object sender, EventArgs e)
        {
            try
            {
                NuovoPreventivoCostoFrm form = new NuovoPreventivoCostoFrm(_preventivoSelezionato, ddlPreventivoCosto.Items.Count, _utenteConnesso);
                form.ShowDialog();
                caricaPreventiviCosti(_preventivoSelezionato.IdPreventivo);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea nuovo preventivo costo", ex);
            }
        }

        private void ddlPreventivi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            txtNotaPreventivo.Text = _preventivoSelezionato.Nota;

            treeView1.Nodes.Clear();

            caricaPreventiviCosti(_preventivoSelezionato.IdPreventivo);

            if (ddlPreventivoCosto.Items.Count == 0)
                btnCreaNuovaVersione_Click(null, null);

        }

        private void caricaPreventiviCosti(decimal idPreventivo)
        {
            if (idPreventivo == -1) return;
            Articolo a = new Articolo();
            List<PreventivoCostoModel> lista = a.CreaListaPreventivoCostiModel(idPreventivo);
            ddlPreventivoCosto.Items.Clear();
            ddlPreventivoCosto.Items.AddRange(lista.ToArray());

            if (lista.Count > 0)
                ddlPreventivoCosto.SelectedIndex = 0;
        }

        private void creaAlberoDistinta(TreeNode radice)
        {
            List<ElementoCostoPreventivoModel> nodibase = _elementiCostoPreventivo.Where(x => x.ElementoPreventivo.IdPadre == -1).ToList();
            foreach (ElementoCostoPreventivoModel nodobase in nodibase)
                aggiungiFiglio(radice, nodobase);
        }
        private TreeNode aggungiNodo(TreeNode nodoRadice, ElementoCostoPreventivoModel elemento)
        {
            TreeNode nodoAggiunto = nodoRadice.Nodes.Add(elemento.IdElementoCosto.ToString(), elemento.ToString());
            nodoAggiunto.Tag = elemento;
            return nodoAggiunto;
        }
        private void aggiungiFiglio(TreeNode nodoPadre, ElementoCostoPreventivoModel elementoDaAggiungere)
        {
            TreeNode nodoAggiunto = aggungiNodo(nodoPadre, elementoDaAggiungere);
            foreach (ElementoCostoPreventivoModel figlio in _elementiCostoPreventivo.Where(x => x.ElementoPreventivo.IdPadre == elementoDaAggiungere.ElementoPreventivo.IdElementoPreventivo))
                aggiungiFiglio(nodoAggiunto, figlio);
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            try
            {
                //decimal idProcesso = ElementiVuoti.ProcessoGalvanicoVuoto;

                //_articolo.ModificaPreventivo(_preventivoSelezionato.IdPrevenivo, _preventivoSelezionato., txtNota.Text, _utenteConnesso);
                //_articolo.SalvaElementiPreventivo(_elementiPreventivo, _preventivoSelezionato.IdPrevenivo, _utenteConnesso);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in modifica preventivo", ex);
            }
        }

        private void dgvElementi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvElementi.CurrentCell.ColumnIndex >= 10 && dgvElementi.CurrentCell.ColumnIndex <= 13)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_disabilitaEdit) return;
            try
            {
                if (e.Node.Tag is ProdottoFinitoModel) return;
                ElementoCostoPreventivoModel elemento = (ElementoCostoPreventivoModel)e.Node.Tag;
                decimal idElementoCosto = elemento.IdElementoCosto;

                dgvElementi.ClearSelection();

                foreach (DataGridViewRow riga in dgvElementi.Rows)
                {
                    decimal idCella = (decimal)riga.Cells[0].Value;
                    if (idCella == idElementoCosto)
                    {
                        riga.Selected = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione("", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }

        }

        private void dgvElementi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_disabilitaEdit) return;
            try
            {
                _disabilitaEdit = true;
                decimal idElemento = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
                TreeNode[] nodi = treeView1.Nodes.Find(idElemento.ToString(), true);
                if (nodi.Length == 1)
                {
                    TreeNode nodo = nodi[0];
                    treeView1.SelectedNode = nodo;
                    treeView1.Focus();
                }
            }
            catch (Exception ex)
            {
                MostraEccezione("", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvElementi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_disabilitaEdit) return;
            try
            {
                _disabilitaEdit = true;

                if (e.ColumnIndex == 1)
                {
                    decimal idElementoCosto = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
                    TreeNode[] nodi = treeView1.Nodes.Find(idElementoCosto.ToString(), true);
                    if (nodi.Length == 1)
                    {
                        TreeNode nodo = nodi[0];
                        nodo.Text = ((ElementoPreventivoModel)(nodo.Tag)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione("", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvElementi_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvElementi.Rows[e.RowIndex].Cells[0].Value == null) return;

            decimal idElementoCosto = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
            ElementoCostoPreventivoModel elementoCosto = _elementiCostoPreventivo.Where(x => x.IdElementoCosto == idElementoCosto).FirstOrDefault();
            if (elementoCosto == null) return;

            dgvElementi.Rows[e.RowIndex].Cells[2].Value = elementoCosto.ElementoPreventivo.Articolo;
            dgvElementi.Rows[e.RowIndex].Cells[3].Value = elementoCosto.ElementoPreventivo.Codice;
            dgvElementi.Rows[e.RowIndex].Cells[4].Value = elementoCosto.ElementoPreventivo.Descrizione;

            dgvElementi.Rows[e.RowIndex].Cells[7].Value = elementoCosto.ElementoPreventivo.Peso;
            dgvElementi.Rows[e.RowIndex].Cells[8].Value = elementoCosto.ElementoPreventivo.Superficie;
            dgvElementi.Rows[e.RowIndex].Cells[9].Value = elementoCosto.ElementoPreventivo.Quantita;

            dgvElementi.Rows[e.RowIndex].Cells[14].Value = elementoCosto.ElementoPreventivo.PezziOrari;
            dgvElementi.Rows[e.RowIndex].Cells[15].Value = elementoCosto.ElementoPreventivo.CostoOrario;
            dgvElementi.Rows[e.RowIndex].Cells[16].Value = elementoCosto.ElementoPreventivo.Ricarico;

            RepartoModel reparto = elementoCosto.ElementoPreventivo.Reparto;
            dgvElementi.Rows[e.RowIndex].Cells[5].Value = elementoCosto.ElementoPreventivo.Reparto;

            if (reparto == null) return;
            GruppoRepartoModel grm = _gruppiRepartiModel.Where(x => x.Reparto.IdReparto == reparto.IdReparto).FirstOrDefault();
            if (grm == null) return;
            dgvElementi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromName(grm.Gruppo.Colore);
            dgvElementi.Rows[e.RowIndex].Cells[6].Value = grm.Gruppo.Codice;
        }


        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            caricaListaCostiFissi();
        }

        private void ddlPreventivoCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (ddlPreventivoCosto.SelectedIndex == -1) return;

            Articolo articolo = new Articolo();
            TreeNode radice = treeView1.Nodes.Add("-1", prodottoFinitoUC1.ProdottoFinitoModel.ToString());
            radice.Tag = prodottoFinitoUC1.ProdottoFinitoModel;
            txtNotaPrevetivoCosto.Text = _preventivoCostoSelezionato.Nota;

            _elementiCostoPreventivo = articolo.CreaListaElementoCostoPreventivoModel(_preventivoCostoSelezionato.IdPreventivoCosto);
            creaAlberoDistinta(radice);
            treeView1.ExpandAll();
            caricaGrigliaElementiPreventivo();
        }

        private void dgvCostiFissi_DragDrop(object sender, DragEventArgs e)
        {
            CostoFissoModel costoFisso = (CostoFissoModel)e.Data.GetData(typeof(CostoFissoModel));
            if (costoFisso == null) return;

            CostoFissoPreventivoModel costoFissoPreventivoModel = new CostoFissoPreventivoModel();
            costoFissoPreventivoModel.IdCostoFissoPreventivo = MPIntranet.Business.Articolo.EstraId();
            costoFissoPreventivoModel.IdPreventivoCosto = costoFisso.IdCostoFisso;
            costoFissoPreventivoModel.Codice = costoFisso.Codice;
            costoFissoPreventivoModel.Descrizione = costoFisso.Descrizione;
            costoFissoPreventivoModel.Ricarico = costoFisso.Ricarico;
            costoFissoPreventivoModel.Costo = costoFisso.Costo;
            costoFissoPreventivoModel.Prezzo = (1 + costoFisso.Ricarico / 100) * costoFisso.Costo;

            _costiFissiPreventivoModel.Add(costoFissoPreventivoModel);
            RefreshGridViewCostiFissi();
            calcolaTotaliCostiFissi();
        }

        private void dgvCostiFissi_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvCostiFissi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvCostiFissi.CurrentCell.ColumnIndex >= 3 && dgvCostiFissi.CurrentCell.ColumnIndex <= 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }

        private void calcolaTotaliCostiFissi()
        {
            decimal costi = 0;
            decimal prezzi = 0;

            foreach (DataGridViewRow riga in dgvCostiFissi.Rows)
            {
                decimal costo = (decimal)riga.Cells[CostoCostoFisso.Index].Value;
                decimal prezzo = (decimal)riga.Cells[PressoCostoFisso.Index].Value;
                costi += costo;
                prezzi += prezzo;
            }
            txtTotaliCostiFissiCosto.Text = txtCostiFissiCosto.Text = costi.ToString();
            txtTotaliCostiFissiPrezo.Text = txtCostiFissiPrezzo.Text = prezzi.ToString();
            txtTotaliCostiFissiMargine.Text = txtCostiFissiRicarico.Text = (prezzi - costi).ToString();
        }

        private void dgvCostiFissi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 3 && e.ColumnIndex <= 4)
            //{
            //    decimal margine = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[3].Value;
            //    decimal costo = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[4].Value;

            //    decimal prezzo = (1 + margine / 100) * costo;
            //    dgvCostiFissi.Rows[e.RowIndex].Cells[5].Value = prezzo;
            //}

        }

        private void dgvCostiFissi_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex >= 3 && e.ColumnIndex <= 4)
                {

                    decimal margine = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[RicaricoCostoFisso.Index].Value;
                    decimal costo = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[CostoCostoFisso.Index].Value;

                    decimal prezzo = (1 + margine / 100) * costo;
                    dgvCostiFissi.Rows[e.RowIndex].Cells[PressoCostoFisso.Index].Value = prezzo;
                    calcolaTotaliCostiFissi();
                }
            }
        }
    }
}
