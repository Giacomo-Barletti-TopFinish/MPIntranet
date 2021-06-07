using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
using MPIntranet.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisegnaDiBa
{
    public partial class DistintaBaseFrm2 : MPIChildForm
    {
        private Articolo _articolo;
        private DistintaBase _distinta;
        private int indiceNodi = 0;
        private BindingSource sourceFasiCicli;
        private BindingSource sourceComponenti;
        private AutoCompleteStringCollection _autoAreeProduzione = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoTask = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoItems = new AutoCompleteStringCollection();

        private int estraiIndice()
        {
            indiceNodi--;
            return indiceNodi;
        }
        public DistintaBaseFrm2()
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                caricaAreeProduzione();
                caricaTask();
                caricaItems();

                _articolo = Articolo.EstraiArticolo(_idArticolo);

                if (_articolo != null)
                    txtArticolo.Text = _articolo.ToString();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void caricaAreeProduzione()
        {
            List<AreaProduzione> aree = MPIntranet.Business.AreaProduzione.EstraiListaAreeProduzione();

            string[] etichette = aree.Select(x => x.Codice).ToArray();
            _autoAreeProduzione.AddRange(etichette);
        }
        private void caricaItems()
        {
            List<Item> items = Item.EstraiListaItems();

            string[] etichette = items.Select(x => x.Anagrafica).ToArray();
            _autoItems.AddRange(etichette);
        }
        private void caricaTask()
        {
            List<MPIntranet.Business.Task> tasks = MPIntranet.Business.Task.EstraiListaTask();

            string[] etichette = tasks.Select(x => x.Codice).ToArray();
            _autoTask.AddRange(etichette);
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
            PopolaGrigliaComponenti();
            PopolaGrigliaFasi(_distinta.Componenti[0]);
        }
        private void aggiornaNodoAlbero(int IdComponente, string descrizione, string anagrafica)
        {
            string etichettaNodo = string.Empty;
            if (string.IsNullOrEmpty(anagrafica))
                etichettaNodo = string.Format("{0} {1}", IdComponente, descrizione).Trim();
            else
                etichettaNodo = string.Format("{0} {1} ({2})", IdComponente, descrizione, anagrafica).Trim();

            TreeNode nodoCercato = null;

            if (trovaNodo(tvDiBa.Nodes[0], IdComponente, out nodoCercato))
                nodoCercato.Text = etichettaNodo;
        }

        private bool trovaNodo(TreeNode nodoPadre, int IdComponente, out TreeNode nodoTrovato)
        {
            nodoTrovato = null;
            if (nodoPadre.Tag == null) return false;
            Componente componente = (Componente)nodoPadre.Tag;
            if (componente == null) return false;
            if (componente.IdComponente == IdComponente)
            {
                nodoTrovato = nodoPadre;
                return true;
            }

            foreach (TreeNode n in nodoPadre.Nodes)
            {
                bool esito = trovaNodo(n, IdComponente, out nodoTrovato);
                if (esito) return true;
            }
            //foreach (TreeNode n in nodoPadre.Nodes)
            //{
            //    if (n.Tag == null) return false;

            //    componente = (Componente)n.Tag;
            //    if (componente == null) return false;
            //    if (componente.IdComponente == IdComponente)
            //    {
            //        nodoTrovato = n;
            //        return true;
            //    }
            //    bool esito = trovaNodo(n, IdComponente, out nodoTrovato);
            //    if (esito) return true;
            //}
            return false;
        }

        private void creaAlbero()
        {
            if (_distinta == null) return;
            tvDiBa.Nodes.Clear();
            if (_distinta.Fasi.Count() == 0)
                tvDiBa.Nodes.Add(creaNodo(null));
            else
            {
                FaseDistinta faseRoot = _distinta.Fasi.Where(x => x.IdPadre == 0).FirstOrDefault();
                if (faseRoot == null) return;

                string etichettaNodo = string.Format("{0} {1}", faseRoot.IdFaseDiba, faseRoot.Anagrafica);
                TreeNode radice = new TreeNode(etichettaNodo);
                radice.Tag = faseRoot;
                tvDiBa.Nodes.Add(radice);
                aggiungiNodoEsistente(faseRoot.IdFaseDiba, radice);
            }
            tvDiBa.ExpandAll();
        }

        private void aggiungiNodoEsistente(int idFaseDistintaPadre, TreeNode nodoPadre)
        {
            foreach (FaseDistinta faseFiglio in _distinta.Fasi.Where(x => x.IdPadre == idFaseDistintaPadre))
            {
                string etichettaNodo = string.Format("{0} {1} {2}", faseFiglio.IdFaseDiba, faseFiglio.AreaProduzione, faseFiglio.Anagrafica);
                TreeNode nodoFiglio = new TreeNode(etichettaNodo);
                nodoFiglio.Tag = faseFiglio;
                nodoPadre.Nodes.Add(nodoFiglio);

                aggiungiNodoEsistente(faseFiglio.IdFaseDiba, nodoFiglio);
            }
        }

        private TreeNode creaNodo(TreeNode nodoPadre)
        {

            Componente componentePadre = null;
            if (nodoPadre != null && nodoPadre.Tag != null)
                componentePadre = (Componente)nodoPadre.Tag;

            Componente componente = new Componente();
            componente.IdComponente = estraiIndice();
            componente.IdDiba = _distinta.IdDiba;

            if (componentePadre != null) componente.IdPadre = componentePadre.IdComponente;
            componente.Quantita = 1;
            componente.UMQuantita = "NR";
            string etichettaNodo = string.Format("{0} {1}", componente.IdComponente, componente.Anagrafica);
            TreeNode nodo = new TreeNode(etichettaNodo);
            nodo.Tag = componente;
            _distinta.Componenti.Add(componente);
            return nodo;
        }
        private void popolaCampi()
        {
            if (_distinta == null) return;
            this.Text = string.Format("{0} {1} {2}", _distinta.Articolo.ToString(), _distinta.TipoDistinta, _distinta.Versione);
            txtDescrizioneDiba.Text = _distinta.Descrizione;
            txtVersioneDiba.Text = _distinta.Versione.ToString();
            txtTipoDiba.Text = _distinta.TipoDistinta.TipoDiba;
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            if (_articolo == null) return;

            SelezionaDistintaFrm form = new SelezionaDistintaFrm(_articolo);
            form.ShowDialog();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _distinta = form.DistintaSelezionata;
                popolaCampi();
                creaAlbero();
                PopolaGrigliaComponenti();
                PopolaGrigliaFasi(null);
            }
            catch { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
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

            TreeNode nodo = creaNodo(tn.Parent);

            tn.Parent.Nodes.Add(nodo);
            tn.Parent.Nodes.Remove(tn);
            nodo.Nodes.Add(tn);
            rinumeraIdPadreComponentePerRamo(tvDiBa.Nodes[0]);
            nodo.ExpandAll();
            sourceComponenti.ResetBindings(false);

        }

        private void rinumeraIdPadreComponentePerRamo(TreeNode n)
        {
            int idComponentePadre = 0;
            if (n.Tag != null)
            {
                Componente componente = (Componente)n.Tag;
                idComponentePadre = componente.IdComponente;
            }

            foreach (TreeNode nFiglio in n.Nodes)
            {
                if (n.Tag != null)
                {
                    Componente f = (Componente)nFiglio.Tag;
                    f.IdPadre = idComponentePadre;
                }
                rinumeraIdPadreComponentePerRamo(nFiglio);
            }
        }
        private void AggiungiNodoSottoClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;

            TreeNode nodo = creaNodo(tn);
            tn.Nodes.Add(nodo);
            tn.ExpandAll();
            sourceComponenti.ResetBindings(false);

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
                    Componente componente = (Componente)tn.Tag;
                    _distinta.Componenti.Remove(componente);
                }
                tn.Remove();
                padre.Nodes.AddRange(figli);
                rinumeraIdPadreComponentePerRamo(padre);
            }
            else
            {
                if (tn.Tag != null)
                {
                    Componente componente = (Componente)tn.Tag;
                    _distinta.Componenti.Remove(componente);
                }
                tn.Remove();
            }
            sourceComponenti.ResetBindings(false);

        }

        private void PopolaGrigliaFasi(Componente componente)
        {
            if (componente == null)
                dgvFasiCiclo.DataSource = null;
            dgvFasiCiclo.AutoGenerateColumns = false;
            BindingList<FaseCiclo> bindingList = new BindingList<FaseCiclo>(componente.FasiCiclo);
            sourceFasiCicli = new BindingSource(bindingList, null);
            dgvFasiCiclo.DataSource = sourceFasiCicli;
            dgvFasiCiclo.Update();
        }

        private void PopolaGrigliaComponenti()
        {
            if (_distinta == null) return;
            dgvComponenti.AutoGenerateColumns = false;
            BindingList<Componente> bindingList = new BindingList<Componente>(_distinta.Componenti);
            sourceComponenti = new BindingSource(bindingList, null);
            dgvComponenti.DataSource = sourceComponenti;
            dgvComponenti.Update();
        }

        private void dgvNodi_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MPIntranet.Business.Task)))
            {
                MPIntranet.Business.Task item = (MPIntranet.Business.Task)e.Data.GetData(typeof(MPIntranet.Business.Task));
                Point clientPoint = dgvFasiCiclo.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = dgvFasiCiclo.HitTest(clientPoint.X, clientPoint.Y);
                if (info.RowIndex < 0 || info.RowIndex > dgvFasiCiclo.Rows.Count) return;
                dgvFasiCiclo.Rows[info.RowIndex].Cells[Task.Index].Value = item.ToString();
            }

            if (e.Data.GetDataPresent(typeof(MPIntranet.Business.AreaProduzione)))
            {
                MPIntranet.Business.AreaProduzione item = (MPIntranet.Business.AreaProduzione)e.Data.GetData(typeof(MPIntranet.Business.AreaProduzione));
                Point clientPoint = dgvFasiCiclo.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo info = dgvFasiCiclo.HitTest(clientPoint.X, clientPoint.Y);
                if (info.RowIndex < 0 || info.RowIndex > dgvFasiCiclo.Rows.Count) return;
                dgvFasiCiclo.Rows[info.RowIndex].Cells[AreaProduzione.Index].Value = item.ToString();

                int idFaseDistinta = (int)dgvFasiCiclo.Rows[info.RowIndex].Cells[IdFase.Index].Value;
                string anagrafica = (string)dgvFasiCiclo.Rows[info.RowIndex].Cells[Anagrafica.Index].Value;

                aggiornaNodoAlbero(idFaseDistinta, item.ToString(), anagrafica);
            }

        }

        private void btnSalvaDiba_Click(object sender, EventArgs e)
        {
            try
            {
                if (_distinta == null) return;
                if (_distinta.VerificaPerSalvataggio())
                {
                    _distinta.Salva(_utenteConnesso);
                    _distinta = DistintaBase.EstraiDistintaBase(_distinta.IdDiba);
                    creaAlbero();
                }
                else
                {
                    MessageBox.Show("Ci sono errori nelle righe la distinte NON è stata salvata", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                PopolaGrigliaComponenti();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            List<ExpCicloBusinessCentral> cicli;
            List<ExpDistintaBusinessCentral> distinte;
            string errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            try
            {
            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.Message);
                MostraEccezione(ex, "Errore in verifica cicli");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgvNodi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dgvFasiCiclo.CurrentCell.ColumnIndex;

            if (columnIndex == AreaProduzione.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoAreeProduzione;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            if (columnIndex == Task.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoTask;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            if (columnIndex == Anagrafica.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoItems;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }


        private void dgvNodi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idFaseDiba = (int)dgvFasiCiclo.Rows[e.RowIndex].Cells[IdFase.Index].Value;
            string anagrafica = (string)dgvFasiCiclo.Rows[e.RowIndex].Cells[Anagrafica.Index].Value;
            string areaProduzione = (string)dgvFasiCiclo.Rows[e.RowIndex].Cells[AreaProduzione.Index].Value;

            aggiornaNodoAlbero(idFaseDiba, areaProduzione, anagrafica);
        }

        private void tvDiBa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;

            Componente componente = (Componente)e.Node.Tag;

            foreach (DataGridViewRow riga in dgvComponenti.Rows)
            {
                int idComponente = (int)riga.Cells[clmIdComponente.Index].Value;
                if (idComponente == componente.IdComponente)
                    riga.DefaultCellStyle.BackColor = Color.Yellow;
                else
                    riga.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvComponenti_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (tvDiBa.Nodes.Count <= 0) return;

            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            cambiacoloreNodo(idComponente, Color.Yellow);
        }

        private void cambiacoloreNodo(int idComponente, Color colore)
        {
            TreeNode nodoTrovato;
            if (trovaNodo(tvDiBa.Nodes[0], idComponente, out nodoTrovato))
            {
                nodoTrovato.BackColor = colore;
            }
        }

        private void dgvComponenti_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (tvDiBa.Nodes.Count <= 0) return;

            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            cambiacoloreNodo(idComponente, Color.Transparent);
        }

        private void dgvComponenti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            string anagrafica = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value;
            string descrizione = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value;

            aggiornaNodoAlbero(idComponente, descrizione, anagrafica);
        }

    }
}
