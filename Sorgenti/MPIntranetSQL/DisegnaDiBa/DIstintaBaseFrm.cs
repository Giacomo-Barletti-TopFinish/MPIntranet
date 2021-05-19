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

            _articolo = Articolo.EstraiArticolo(_idArticolo);

            if (_articolo != null)
            {
                txtArticolo.Text = _articolo.ToString();
            }
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
                    FaseDistinta f = (FaseDistinta)n.Tag;
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
            dgvNodi.Update();
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

        }

        private void PopolaGrigliaFasi()
        {
            dgvNodi.AutoGenerateColumns = false;
            var bindingList = new BindingList<FaseDistinta>(_distinta.Fasi);
            var source = new BindingSource(bindingList, null);
            dgvNodi.DataSource = source;
            dgvNodi.Update();
        }
    }
}
