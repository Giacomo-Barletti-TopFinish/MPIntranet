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
        }
        private void RimuoviRamoClick(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            tn.Remove();
        }
        private void RimuoviElementoSingoloClick(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn == null) return;
            TreeNode padre = tn.Parent;
            if (padre == null) return;

            if (tn.Nodes.Count > 0)
            {
                TreeNode[] figli = new TreeNode[tn.Nodes.Count];
                tn.Nodes.CopyTo(figli, 0);
                tn.Remove();
                padre.Nodes.AddRange(figli);
            }
            else
                tn.Remove();
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

            treeView1.Nodes.Add(prodottoFinitoUC1.ProdottoFinitoModel.ToString());
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            try
            {
                _articolo.ModificaPreventivo(_preventivoSelezionato.IdPrevenivo, txtNota.Text, _utenteConnesso);
                caricaDdlPreventivi();

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

                object data = e.Data.GetData(typeof(DateTime));
                if (data == null) { return; }


                nodeToDropIn.Nodes.Add(data.ToString());
                nodeToDropIn.ExpandAll();

            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
    }
}
