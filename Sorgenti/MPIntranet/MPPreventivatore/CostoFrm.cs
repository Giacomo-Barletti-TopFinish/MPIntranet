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
        private Articolo _articolo = new Articolo(string.Empty);
        private Documenti _documenti = new Documenti();
        private Anagrafica _anagrafica = new Anagrafica();
        private List<ElementoCostoPreventivoModel> _elementiCostoPreventivo = new List<ElementoCostoPreventivoModel>();
        private BindingSource _source = new BindingSource();

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
            string filename;
            prodottoFinitoUC1.ProdottoFinitoModel = _articolo.CreaProdottoFinitoModel(IdProdottoFinito);
            prodottoFinitoUC1.Immagine = _documenti.EstraiImmagineStandard(IdProdottoFinito, TabelleEsterne.ProdottiFiniti, out filename);
            prodottoFinitoUC1.Refresh();
            _gruppiRepartiModel = _articolo.CreaListaGruppoRepartoModel(prodottoFinitoUC1.ProdottoFinitoModel.Brand.IdBrand);
            caricaDdlPreventivi();


            caricaGrigliaElementiPreventivo();
            this.Text = prodottoFinitoUC1.ProdottoFinitoModel.ToString();
        }

        private void caricaGrigliaElementiPreventivo()
        {
            dgvElementi.AutoGenerateColumns = false;

            _source.DataSource = _elementiCostoPreventivo;
            dgvElementi.DataSource = _source;
        }

        private void caricaDdlPreventivi()
        {
            ddlPreventivi.Items.Clear();
            ddlPreventivi.Items.AddRange(_articolo.CreaListaPreventivoModel(IdProdottoFinito).ToArray());
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
            TreeNode nodoAggiunto = nodoRadice.Nodes.Add(elemento.ElementoPreventivo.IdElementoPreventivo.ToString(), elemento.ToString());
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
            if (dgvElementi.CurrentCell.ColumnIndex >= 7)
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
                ElementoPreventivoModel elemento = (ElementoPreventivoModel)e.Node.Tag;
                decimal idElemento = elemento.IdElementoPreventivo;

                dgvElementi.ClearSelection();

                foreach (DataGridViewRow riga in dgvElementi.Rows)
                {
                    decimal idCella = (decimal)riga.Cells[0].Value;
                    if (idCella == idElemento)
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
                    decimal idElemento = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
                    TreeNode[] nodi = treeView1.Nodes.Find(idElemento.ToString(), true);
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
            if (dgvElementi.Rows[e.RowIndex].Cells[5].Value == null) return;

            RepartoModel reparto = (RepartoModel)dgvElementi.Rows[e.RowIndex].Cells[5].Value;
            if (reparto == null) return;
            GruppoRepartoModel grm = _gruppiRepartiModel.Where(x => x.Reparto.IdReparto == reparto.IdReparto).FirstOrDefault();
            if (grm == null) return;
            dgvElementi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromName(grm.Gruppo.Colore);
            dgvElementi.Rows[e.RowIndex].Cells[6].Value = grm.Gruppo.Codice;
        }

        private void dgvElementi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow riga = dgvElementi.Rows[e.RowIndex];
            switch (dgvElementi.Columns[e.ColumnIndex].Name)
            {
                case "PezziOrari":
                case "Costo":
                    decimal costoArticolo = 0;
                    decimal pezziOrari = decimal.Parse(riga.Cells[dgvElementi.Columns.IndexOf(dgvElementi.Columns["PezziOrari"])].Value.ToString(), CultureInfo.InvariantCulture);
                    if (pezziOrari > 0 && riga.Cells[dgvElementi.Columns.IndexOf(dgvElementi.Columns["Costo"])].Value != null)
                    {
                        decimal costo = decimal.Parse(riga.Cells[dgvElementi.Columns.IndexOf(dgvElementi.Columns["Costo"])].Value.ToString(), CultureInfo.InvariantCulture);
                        costoArticolo = Math.Round(costo / pezziOrari, 3);
                        riga.Cells[dgvElementi.Columns.IndexOf(dgvElementi.Columns["CostoArticolo"])].Value = costoArticolo;
                    }
                    break;

            }
        }

        private void btnAggiorna_Click(object sender, EventArgs e)
        {

        }

        private void ddlPreventivoCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPreventivoCosto.SelectedIndex == -1) return;

            TreeNode radice = treeView1.Nodes.Add("-1", prodottoFinitoUC1.ProdottoFinitoModel.ToString());
            radice.Tag = prodottoFinitoUC1.ProdottoFinitoModel;

            _elementiCostoPreventivo = _articolo.CreaListaElementoCostoPreventivoModel(_preventivoSelezionato.IdPreventivo);
            creaAlberoDistinta(radice);
            treeView1.ExpandAll();
            caricaGrigliaElementiPreventivo();

        }
    }
}
