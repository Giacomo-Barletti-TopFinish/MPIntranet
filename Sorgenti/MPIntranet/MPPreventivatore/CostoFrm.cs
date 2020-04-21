using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Anagrafica;
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
    public partial class CostoFrm : ChildBaseForm
    {
        public decimal IdProdottoFinito;
        private Articolo _articolo = new Articolo(string.Empty);
        private Documenti _documenti = new Documenti();
        private Anagrafica _anagrafica = new Anagrafica();
        private List<ElementoPreventivoModel> _elementiPreventivo = new List<ElementoPreventivoModel>();
        private BindingSource _source = new BindingSource();

        public TreeNode _nodoDaCopiare
        {
            get { return (MdiParent as MainForm).NodoDaCopiare; }
            set { (MdiParent as MainForm).NodoDaCopiare = value; }
        }
        private PreventivoModel _preventivoSelezionato
        {
            get
            {
                if (ddlPreventivi.SelectedIndex == -1) return null;
                return (PreventivoModel)ddlPreventivi.SelectedItem;
            }
        }
        public CostoFrm()
        {
            InitializeComponent();
        }

        private void PreventivoFrm_Load(object sender, EventArgs e)
        {
            string filename;
            prodottoFinitoUC1.ProdottoFinitoModel = _articolo.CreaProdottoFinitoModel(IdProdottoFinito);
            prodottoFinitoUC1.Immagine = _documenti.EstraiImmagineStandard(IdProdottoFinito, TabelleEsterne.ProdottiFiniti, out filename);
            prodottoFinitoUC1.Refresh();

            caricaDdlPreventivi();
            caricaGrigliaElementiPreventivo();
            this.Text = prodottoFinitoUC1.ProdottoFinitoModel.ToString();
        }

        private void caricaGrigliaElementiPreventivo()
        {
            dgvElementi.AutoGenerateColumns = false;

            _source.DataSource = _elementiPreventivo;
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
                NuovoPreventivoFrm form = new NuovoPreventivoFrm(prodottoFinitoUC1.ProdottoFinitoModel, ddlPreventivi.Items.Count, _utenteConnesso);
                form.ShowDialog();
                caricaDdlPreventivi();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in modifica prodotto finito", ex);
            }
        }

        private void ddlPreventivi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            txtNota.Text = _preventivoSelezionato.Nota;

            treeView1.Nodes.Clear();
            TreeNode radice = treeView1.Nodes.Add("-1", prodottoFinitoUC1.ProdottoFinitoModel.ToString());
            radice.Tag = prodottoFinitoUC1.ProdottoFinitoModel;
            _elementiPreventivo = _articolo.CreaListaElementoPreventivoModel(_preventivoSelezionato.IdPrevenivo);
            creaAlberoDistinta(radice);
            treeView1.ExpandAll();
            caricaGrigliaElementiPreventivo();
        }

        private void creaAlberoDistinta(TreeNode radice)
        {
            List<ElementoPreventivoModel> nodibase = _elementiPreventivo.Where(x => x.IdPadre == -1).ToList();
            foreach (ElementoPreventivoModel nodobase in nodibase)
                aggiungiFiglio(radice, nodobase);
        }
        private TreeNode aggungiNodo(TreeNode nodoRadice, ElementoPreventivoModel elemento)
        {
            TreeNode nodoAggiunto = nodoRadice.Nodes.Add(elemento.IdElementoPreventivo.ToString(), elemento.ToString());
            nodoAggiunto.Tag = elemento;
            return nodoAggiunto;
        }
        private void aggiungiFiglio(TreeNode nodoPadre, ElementoPreventivoModel elementoDaAggiungere)
        {
            TreeNode nodoAggiunto = aggungiNodo(nodoPadre, elementoDaAggiungere);
            foreach (ElementoPreventivoModel figlio in _elementiPreventivo.Where(x => x.IdPadre == elementoDaAggiungere.IdElementoPreventivo))
                aggiungiFiglio(nodoAggiunto, figlio);
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            try
            {
                _articolo.ModificaPreventivo(_preventivoSelezionato.IdPrevenivo, txtNota.Text, _utenteConnesso);
                _articolo.SalvaElementiPreventivo(_elementiPreventivo, _preventivoSelezionato.IdPrevenivo, _utenteConnesso);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in modifica prodotto finito", ex);
            }
        }

      
    
        private void RefreshGridView()
        {
            _source.ResetBindings(false);
            dgvElementi.Update();
            dgvElementi.Refresh();
        }
    
        private void dgvElementi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvElementi.CurrentCell.ColumnIndex >= 4)
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
    }
}
