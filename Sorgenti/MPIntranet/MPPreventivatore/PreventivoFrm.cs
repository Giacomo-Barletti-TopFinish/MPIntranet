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
    public partial class PreventivoFrm : ChildBaseForm
    {
        public decimal IdProdottoFinito;
        private Articolo _articolo = new Articolo(string.Empty);
        private Documenti _documenti = new Documenti();
        private Anagrafica _anagrafica = new Anagrafica();
        private List<ElementoPreventivoModel> _elementiPreventivo = new List<ElementoPreventivoModel>();
        private BindingSource _source = new BindingSource();

        private PreventivoModel _preventivoSelezionato
        {
            get
            {
                if (ddlPreventivi.SelectedIndex == -1) return null;
                return (PreventivoModel)ddlPreventivi.SelectedItem;
            }
        }
        public PreventivoFrm()
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
            caricaDdlReparti();
            CreaMenuContestualeTreeView();
            caricaMateriePrime();
            caricaGrigliaElementiPreventivo();
        }

        private void caricaGrigliaElementiPreventivo()
        {
            dgvElementi.AutoGenerateColumns = false;

            _source.DataSource = _elementiPreventivo;
            dgvElementi.DataSource = _source;
        }
        private void RimuoviRamoClick(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;

            eliminaElementiFigli(tn);
            ElementoPreventivoModel elemento = (ElementoPreventivoModel)tn.Tag;
            _elementiPreventivo.Remove(elemento);

            tn.Remove();
            RefreshGridView();
        }

        private void eliminaElementiFigli(TreeNode tn)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                ElementoPreventivoModel elementoFiglio = (ElementoPreventivoModel)t.Tag;
                _elementiPreventivo.Remove(elementoFiglio);
                eliminaElementiFigli(t);
            }
        }

        private void RimuoviElementoSingoloClick(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn == null) return;
            TreeNode padre = tn.Parent;
            if (padre == null) return;

            ElementoPreventivoModel elemento = (ElementoPreventivoModel)tn.Tag;
            _elementiPreventivo.Remove(elemento);

            if (tn.Nodes.Count > 0)
            {
                TreeNode[] figli = new TreeNode[tn.Nodes.Count];
                tn.Nodes.CopyTo(figli, 0);
                tn.Remove();
                padre.Nodes.AddRange(figli);

            }
            else
                tn.Remove();

            RefreshGridView();
        }
        private void CreaMenuContestualeTreeView()
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Rimuovi ramo", new EventHandler(RimuoviRamoClick));
            cm.MenuItems.Add("Rimuovi elemento singolo", new EventHandler(RimuoviElementoSingoloClick));
            treeView1.ContextMenu = cm;

        }
        private void caricaDdlReparti()
        {
            ddlReparti.Items.AddRange(_anagrafica.CreaListaRepartoModel().ToArray());
            if (ddlReparti.Items.Count > 0)
                ddlReparti.SelectedIndex = 0;
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
        }

        private void creaAlberoDistinta(TreeNode radice)
        {
            List<ElementoPreventivoModel> nodibase = _elementiPreventivo.Where(x => x.IdPadre == -1).ToList();
            foreach (ElementoPreventivoModel nodobase in nodibase)
                aggiungiFiglio(radice, nodobase);
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

        private void ddlReparti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReparti.SelectedIndex == -1) return;
            RepartoModel repartoSelezionato = (RepartoModel)ddlReparti.SelectedItem;
            List<FaseModel> fasiRepartoSelezionato = _anagrafica.CreaListaFaseModel(repartoSelezionato.IdReparto);
            lstFasi.Items.Clear();
            lstFasi.Items.AddRange(fasiRepartoSelezionato.ToArray());
        }

        private void caricaMateriePrime()
        {
            List<MateriaPrimaModel> materiaPrimaModel = _anagrafica.CreaListaMateriaPrimaModel();
            lstMateriePrime.Items.Clear();
            lstMateriePrime.Items.AddRange(materiaPrimaModel.ToArray());
        }

        private void lstFasi_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstFasi.Items.Count == 0) return;

            lstFasi.DoDragDrop(this.lstFasi.SelectedItem, DragDropEffects.Move);

        }

        private void lstFasi_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));


            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (draggedNode != null)
            {
                if (draggedNode == null)
                    return;

                TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

                if (targetNode == null)
                {
                    draggedNode.Remove();
                    treeView1.Nodes.Add(draggedNode);
                    draggedNode.Expand();
                }
                else
                {
                    TreeNode parentNode = targetNode;

                    if (!draggedNode.Equals(targetNode) && targetNode != null)
                    {
                        bool canDrop = true;
                        while (canDrop && (parentNode != null))
                        {
                            canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                            parentNode = parentNode.Parent;
                        }

                        if (canDrop)
                        {
                            draggedNode.Remove();

                            if (e.KeyState == 4)
                            {
                                if (targetNode.Parent == null)
                                    treeView1.Nodes.Insert(targetNode.Index + 1, draggedNode);
                                else
                                    targetNode.Parent.Nodes.Insert(targetNode.Index + 1, draggedNode);
                            }
                            else
                            {
                                targetNode.Nodes.Add(draggedNode);
                            }
                            targetNode.Expand();
                        }
                    }
                }
            }
            else
            {
                TreeNode nodeToDropIn = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
                if (nodeToDropIn == null) { return; }
                object padre = nodeToDropIn.Tag;
                decimal idPadre = -1;
                if (padre is ProdottoFinitoModel) idPadre = -1;
                if (padre is ElementoPreventivoModel) idPadre = (padre as ElementoPreventivoModel).IdElementoPreventivo;
                decimal idElementoPreventivo = _articolo.EstraId();
                //                object data = e.Data.GetData(typeof(DateTime));
                FaseModel fase = (FaseModel)e.Data.GetData(typeof(FaseModel));
                ElementoPreventivoModel elemento;
                if (fase == null)
                {
                    MateriaPrimaModel materiaPrima = (MateriaPrimaModel)e.Data.GetData(typeof(MateriaPrimaModel));
                    if (materiaPrima == null) return;
                    elemento = convertiMateriaPrimaInElementoPreventivo(materiaPrima, idElementoPreventivo, idPadre);
                }
                else
                {
                    elemento = convertiFaseInElementoPreventivo(fase, idElementoPreventivo, idPadre);
                }
                aggungiNodo(nodeToDropIn, elemento);
                //TreeNode nodoAggiunto = nodeToDropIn.Nodes.Add(idElementoPreventivo.ToString(), elemento.ToString());
                //nodoAggiunto.Tag = elemento;

                if (idPadre == -1)
                    _elementiPreventivo.Add(elemento);
                else
                {
                    int indice = _elementiPreventivo.IndexOf(padre as ElementoPreventivoModel);
                    _elementiPreventivo.Insert(indice + 1, elemento);
                }

                RefreshGridView();
                nodeToDropIn.ExpandAll();
            }
        }

        private TreeNode aggungiNodo(TreeNode nodoRadice, ElementoPreventivoModel elemento)
        {
            TreeNode nodoAggiunto = nodoRadice.Nodes.Add(elemento.IdElementoPreventivo.ToString(), elemento.ToString());
            nodoAggiunto.Tag = elemento;
            return nodoAggiunto;
        }
        private void RefreshGridView()
        {
            _source.ResetBindings(false);
            dgvElementi.Update();
            dgvElementi.Refresh();
        }
        private ElementoPreventivoModel convertiFaseInElementoPreventivo(FaseModel fase, decimal idElementoPreventivo, decimal idPadre)
        {
            ElementoPreventivoModel elemento = new ElementoPreventivoModel();
            elemento.IdElementoPreventivo = idElementoPreventivo;
            elemento.IdPadre = idPadre;
            elemento.IdPreventivo = _preventivoSelezionato.IdPrevenivo;
            elemento.Codice = fase.Codice;
            elemento.Reparto = fase.Reparto;
            elemento.Ricarico = fase.Ricarico;
            elemento.Costo = fase.Costo;
            elemento.IncludiPreventivo = fase.IncludiPreventivo;
            elemento.IdEsterna = -1;
            elemento.TabellaEsterna = string.Empty;
            elemento.PezziOrari = 0;
            elemento.Peso = 0;
            elemento.Superficie = 0;
            elemento.Quantita = 1;
            elemento.Descrizione = fase.Descrizione;
            elemento.Articolo = string.Empty;
            return elemento;
        }

        private ElementoPreventivoModel convertiMateriaPrimaInElementoPreventivo(MateriaPrimaModel materiaPrima, decimal idElementoPreventivo, decimal idPadre)
        {
            ElementoPreventivoModel elemento = new ElementoPreventivoModel();
            elemento.IdElementoPreventivo = idElementoPreventivo;
            elemento.IdPadre = idPadre;
            elemento.IdPreventivo = _preventivoSelezionato.IdPrevenivo;
            elemento.Codice = materiaPrima.Codice;
            elemento.Reparto = null;
            elemento.Ricarico = materiaPrima.Ricarico;
            elemento.Costo = materiaPrima.Costo;
            elemento.IncludiPreventivo = materiaPrima.IncludiPreventivo;
            elemento.IdEsterna = -1;
            elemento.TabellaEsterna = string.Empty;
            elemento.PezziOrari = 0;
            elemento.Peso = 0;
            elemento.Superficie = 0;
            elemento.Quantita = 1;
            elemento.Descrizione = "MATERIA PRIMA";
            elemento.Articolo = materiaPrima.Descrizione;
            return elemento;
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lstMateriePrime_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstMateriePrime.SelectedIndex == -1) return;
            lstMateriePrime.DoDragDrop(lstMateriePrime.SelectedItem, DragDropEffects.Move);
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
    }
}
