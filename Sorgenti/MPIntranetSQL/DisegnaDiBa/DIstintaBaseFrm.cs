using MPIntranet.Business;
using MPIntranet.Common;
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
    public partial class DistintaBaseFrm : MPIChildForm
    {
        private Articolo _articolo;
        private DistintaBase _distinta;
        private int indiceNodi = 0;
        private BindingSource source;
        private int estraiIndice()
        {
            indiceNodi--;
            return indiceNodi;
        }
        public DistintaBaseFrm()
        {
            InitializeComponent();
            CreaMenuContestualeTreeView();
        }

        private void DistintaBaseFrm_Load(object sender, EventArgs e)
        {
            NuovoArticoloFrm nForm = new NuovoArticoloFrm();
            nForm.ShowDialog();
            int _idArticolo = nForm.IDArticolo;
            if (_idArticolo == ElementiVuoti.Articolo)
                return;

            caricaAreeProduzione();
            caricaTask();

            _articolo = Articolo.EstraiArticolo(_idArticolo);

            if (_articolo != null)
            {
                txtArticolo.Text = _articolo.ToString();
            }
        }

        private void caricaAreeProduzione()
        {
            List<AreaProduzione> aree = MPIntranet.Business.AreaProduzione.EstraiListaAreeProduzione();
            lstAreeProduzione.Items.AddRange(aree.ToArray());
        }

        private void caricaTask()
        {
            List<MPIntranet.Business.Task> tasks = MPIntranet.Business.Task.EstraiListaTask();
            lstTask.Items.AddRange(tasks.ToArray());
        }

        private void btnNuovaDistinta_Click(object sender, EventArgs e)
        {
            if (_articolo == null)
            {
                MessageBox.Show("Nessun articolo selezioanto", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            NuovaDistintaFrm form = new NuovaDistintaFrm(_articolo, _utenteConnesso);
            form.ShowDialog();
            int idDIba = form.IDDIBA_OUT;
            if (idDIba == ElementiVuoti.DistintaBase)
            {
                MessageBox.Show("Errore in fase di creazione della distinta", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _distinta = DistintaBase.EstraiDistintaBase(idDIba);
            if (_distinta == null)
            {
                MessageBox.Show("Errore distinta base nulla", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            popolaCampi();

            creaAlbero();
            PopolaGrigliaFasi();
        }
        private void aggiornaNodoAlbero(int idFaseDiba, string areaProduzione, string anagrafica)
        {
            string etichettaNodo = string.Format("{0} {1} {2}", idFaseDiba, areaProduzione, anagrafica);
            etichettaNodo = etichettaNodo.Trim();

            TreeNode nodoCercato = null;

            if (trovaNodo(tvDiBa.Nodes[0], idFaseDiba, out nodoCercato))
            {
                nodoCercato.Text = etichettaNodo;
            }

        }

        private bool trovaNodo(TreeNode nodoPadre, int idFaseDistinta, out TreeNode nodoTrovato)
        {
            nodoTrovato = null;
            foreach (TreeNode n in nodoPadre.Nodes)
            {
                if (n.Tag == null) return false;

                FaseDistinta fd = (FaseDistinta)n.Tag;
                if (fd == null) return false;
                if (fd.IdFaseDiba == idFaseDistinta)
                {
                    nodoTrovato = n;
                    return true;
                }
                bool esito = trovaNodo(n, idFaseDistinta, out nodoTrovato);
                if (esito) return true;
            }
            return false;
        }

        private void creaAlbero()
        {
            tvDiBa.Nodes.Add(creaNodo(_articolo.Descrizione, _articolo.Anagrafica, null));

        }

        private TreeNode creaNodo(string descrizione, string anagrafica, TreeNode nodoPadre)
        {

            FaseDistinta fasePadre = null;
            if (nodoPadre != null && nodoPadre.Tag != null)
                fasePadre = (FaseDistinta)nodoPadre.Tag;

            FaseDistinta fase = new FaseDistinta(_distinta.IdDiba);
            fase.IdFaseDiba = estraiIndice();
            if (fasePadre != null) fase.IdPadre = fasePadre.IdFaseDiba;
            fase.Descrizione = descrizione;
            fase.Anagrafica = anagrafica;
            string etichettaNodo = string.Format("{0} {1}", fase.IdFaseDiba, fase.Anagrafica);
            TreeNode nodo = new TreeNode(etichettaNodo);
            nodo.Tag = fase;
            _distinta.Fasi.Add(fase);
            return nodo;
        }
        private void popolaCampi()
        {
            txtDescrizioneDiba.Text = _distinta.Descrizione;
            txtVersioneDiba.Text = _distinta.Versione.ToString();
            txtTipoDiba.Text = _distinta.TipoDistinta.TipoDiba;
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            SelezionaDistintaFrm form = new SelezionaDistintaFrm(_articolo);
            form.ShowDialog();
            _distinta = form.DistintaSelezionata;
            popolaCampi();
            creaAlbero();
            PopolaGrigliaFasi();
        }

        private void CreaMenuContestualeTreeView()
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Aggiungi nodo sopra", new EventHandler(AggiungiNodoSopraClick));
            cm.MenuItems.Add("Aggiungi nodo sotto", new EventHandler(AggiungiNodoSottoClick));
            cm.MenuItems.Add("Rimuovi nodo", new EventHandler(RimuoviElementoSingoloClick));
            tvDiBa.ContextMenu = cm;

        }

        private void AggiungiNodoSopraClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            if (tn.Parent == null) return;
            TreeNode nodo = creaNodo(string.Empty, string.Empty, tn.Parent);

            tn.Parent.Nodes.Add(nodo);
            tn.Parent.Nodes.Remove(tn);
            nodo.Nodes.Add(tn);
            rinumeraIdPadreFaseDistinta(tvDiBa.Nodes[0]);
            nodo.ExpandAll();
            source.ResetBindings(false);

        }

        private void rinumeraIdPadreFaseDistinta(TreeNode n)
        {
            int idFasePadre = 0;
            if (n.Tag != null)
            {
                FaseDistinta fasePadre = (FaseDistinta)n.Tag;
                idFasePadre = fasePadre.IdFaseDiba;
            }

            foreach (TreeNode nFiglio in n.Nodes)
            {
                if (n.Tag != null)
                {
                    FaseDistinta f = (FaseDistinta)nFiglio.Tag;
                    f.IdPadre = idFasePadre;
                }
                rinumeraIdPadreFaseDistinta(nFiglio);
            }
        }
        private void AggiungiNodoSottoClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;

            TreeNode nodo = creaNodo(string.Empty, string.Empty, tn);
            tn.Nodes.Add(nodo);
            tn.ExpandAll();
            source.ResetBindings(false);

        }
        private void RimuoviElementoSingoloClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            TreeNode padre = tn.Parent;
            if (padre == null) return;

            if (tn.Nodes.Count > 0)
            {
                TreeNode[] figli = new TreeNode[tn.Nodes.Count];
                tn.Nodes.CopyTo(figli, 0);
                if (tn.Tag != null)
                {
                    FaseDistinta fd = (FaseDistinta)tn.Tag;
                    _distinta.Fasi.Remove(fd);
                }
                tn.Remove();
                padre.Nodes.AddRange(figli);
            }
            else
            {
                if (tn.Tag != null)
                {
                    FaseDistinta fd = (FaseDistinta)tn.Tag;
                    _distinta.Fasi.Remove(fd);
                }
                tn.Remove();
            }
            source.ResetBindings(false);

        }

        private void PopolaGrigliaFasi()
        {
            dgvNodi.AutoGenerateColumns = false;
            BindingList<FaseDistinta> bindingList = new BindingList<FaseDistinta>(_distinta.Fasi);
            source = new BindingSource(bindingList, null);
            dgvNodi.DataSource = source;
            dgvNodi.Update();
        }

        private void lstTask_MouseDown(object sender, MouseEventArgs e)
        {
            lstTask.DoDragDrop(lstTask.SelectedItem, DragDropEffects.Copy);
        }

        private void dgvNodi_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MPIntranet.Business.Task)))
            {
                MPIntranet.Business.Task item = (MPIntranet.Business.Task)e.Data.GetData(typeof(MPIntranet.Business.Task));
                Point clientPoint = dgvNodi.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = dgvNodi.HitTest(clientPoint.X, clientPoint.Y);
                if (info.RowIndex < 0 || info.RowIndex > dgvNodi.Rows.Count) return;
                dgvNodi.Rows[info.RowIndex].Cells[Task.Index].Value = item.ToString();
            }

            if (e.Data.GetDataPresent(typeof(MPIntranet.Business.AreaProduzione)))
            {
                MPIntranet.Business.AreaProduzione item = (MPIntranet.Business.AreaProduzione)e.Data.GetData(typeof(MPIntranet.Business.AreaProduzione));
                Point clientPoint = dgvNodi.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = dgvNodi.HitTest(clientPoint.X, clientPoint.Y);
                if (info.RowIndex < 0 || info.RowIndex > dgvNodi.Rows.Count) return;
                dgvNodi.Rows[info.RowIndex].Cells[AreaProduzione.Index].Value = item.ToString();

                int idFaseDistinta = (int)dgvNodi.Rows[info.RowIndex].Cells[IdFase.Index].Value;
                string anagrafica = (string)dgvNodi.Rows[info.RowIndex].Cells[Anagrafica.Index].Value;

                aggiornaNodoAlbero(idFaseDistinta, item.ToString(), anagrafica);
            }

        }

        private void dgvNodi_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MPIntranet.Business.Task)))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(typeof(MPIntranet.Business.AreaProduzione)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lstAreeProduzione_MouseDown(object sender, MouseEventArgs e)
        {
            lstAreeProduzione.DoDragDrop(lstAreeProduzione.SelectedItem, DragDropEffects.Copy);
        }

        private void btnSalvaDiba_Click(object sender, EventArgs e)
        {
            _distinta.SalvaListaFasiDistinta(_utenteConnesso);
        }
    }
}
