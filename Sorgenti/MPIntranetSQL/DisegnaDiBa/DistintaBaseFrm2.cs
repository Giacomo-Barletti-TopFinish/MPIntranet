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
        private int indiceComponenti = 0;
        private int indiceFaseCiclo = 0;
        private BindingSource sourceFasiCicli;
        private BindingSource sourceComponenti;
        private AutoCompleteStringCollection _autoAreeProduzione = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoTask = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoItems = new AutoCompleteStringCollection();
        private int _idComponenteSelezionato;
        private bool _newrow = false;

        protected List<Componente> ComponentiDaCopiare
        {
            get { return (MdiParent as MainForm).ComponentiDaCopiare; }
            set { (MdiParent as MainForm).ComponentiDaCopiare = value; }
        }

        private int estraiIndiceComponenti()
        {
            indiceComponenti--;
            return indiceComponenti;
        }
        public DistintaBaseFrm2()
        {
            InitializeComponent();
            CreaMenuContestualeTreeView();
        }

        private void DistintaBaseFrm_Load(object sender, EventArgs e)
        {
            NuovoArticoloFrm nForm = new NuovoArticoloFrm();
            nForm.Utente = _utenteConnesso;
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

            return false;
        }

        private void creaAlbero()
        {
            if (_distinta == null) return;
            tvDiBa.Nodes.Clear();
            if (_distinta.Componenti.Count() == 0)
                tvDiBa.Nodes.Add(creaNodo(null));
            else
            {
                Componente componenteBase = _distinta.Componenti.Where(x => x.IdPadre == 0).FirstOrDefault();
                if (componenteBase == null) return;

                string etichettaNodo = componenteBase.CreaEtichetta();
                TreeNode radice = new TreeNode(etichettaNodo);
                radice.Tag = componenteBase;
                tvDiBa.Nodes.Add(radice);
                aggiungiNodoEsistente(componenteBase.IdComponente, radice);
            }
            tvDiBa.ExpandAll();
        }

        private void aggiungiNodoEsistente(int IdComponente, TreeNode nodoPadre)
        {
            foreach (Componente componente in _distinta.Componenti.Where(x => x.IdPadre == IdComponente))
            {
                string etichettaNodo = componente.CreaEtichetta();
                TreeNode nodoFiglio = new TreeNode(etichettaNodo);
                nodoFiglio.Tag = componente;
                nodoPadre.Nodes.Add(nodoFiglio);

                aggiungiNodoEsistente(componente.IdComponente, nodoFiglio);
            }
        }

        private TreeNode creaNodo(TreeNode nodoPadre)
        {

            Componente componentePadre = null;
            if (nodoPadre != null && nodoPadre.Tag != null)
                componentePadre = (Componente)nodoPadre.Tag;

            Componente componente = new Componente();
            componente.IdComponente = estraiIndiceComponenti();
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
            cm.MenuItems.Add("Copia ramo", new EventHandler(CopiaRamoClick));
            cm.MenuItems.Add("Incolla ramo", new EventHandler(IncollaRamoClick)); tvDiBa.ContextMenu = cm;
        }

        private void CopiaRamoClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            if (tn.Tag == null) return;
            ComponentiDaCopiare = new List<Componente>();

            Componente componenteSelezionato = (Componente)tn.Tag;
            copiaComponenteRicorsivo(componenteSelezionato, 0);
        }
        private void copiaComponenteRicorsivo(Componente componenteSelezionato, int idPadre)
        {
            Componente componenteCopiato = componenteSelezionato.Copia(estraiIndiceComponenti(), idPadre);
            ComponentiDaCopiare.Add(componenteCopiato);

            foreach (Componente componenteFiglio in _distinta.Componenti.Where(x => x.IdPadre == componenteSelezionato.IdComponente))
            {
                copiaComponenteRicorsivo(componenteFiglio, componenteCopiato.IdComponente);
            }
        }
        private void IncollaRamoClick(object sender, EventArgs e)
        {
            if (ComponentiDaCopiare == null) return;

            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            if (tn.Tag == null) return;

            Componente componenteSelezionato = (Componente)tn.Tag;
            Componente componenteIniziale = ComponentiDaCopiare.Where(x => x.IdPadre == 0).FirstOrDefault();
            incollaFaseDistintaRicorsiva(componenteIniziale, componenteSelezionato.IdComponente, tn);
            PopolaGrigliaComponenti();
            tn.ExpandAll();
        }
        private void incollaFaseDistintaRicorsiva(Componente componenteIniziale, int idPadre, TreeNode nodoPadre)
        {
            if (componenteIniziale == null) return;

            Componente componenteInizialeCopiato = componenteIniziale.Copia(estraiIndiceComponenti(), idPadre);

            TreeNode nodoFiglio = new TreeNode(componenteInizialeCopiato.CreaEtichetta());
            nodoFiglio.Tag = componenteInizialeCopiato;
            nodoPadre.Nodes.Add(nodoFiglio);
            _distinta.Componenti.Add(componenteInizialeCopiato);
            foreach (Componente figlio in ComponentiDaCopiare.Where(x => x.IdPadre == componenteIniziale.IdComponente))
            {
                incollaFaseDistintaRicorsiva(figlio, componenteInizialeCopiato.IdComponente, nodoFiglio);
            }
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
            if (componente.FasiCiclo == null) componente.FasiCiclo = new List<FaseCiclo>();

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

        private void dgvNodi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dgvFasiCiclo.CurrentCell.ColumnIndex;

            if (columnIndex == clmAreaProduzioneFaseCiclo.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoAreeProduzione;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            if (columnIndex == clmTaskFaseCiclo.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoTask;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }


        private void tvDiBa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;

            Componente componente = (Componente)e.Node.Tag;
            _idComponenteSelezionato = componente.IdComponente;

            foreach (DataGridViewRow riga in dgvComponenti.Rows)
            {
                int idComponente = (int)riga.Cells[clmIdComponente.Index].Value;
                if (idComponente == componente.IdComponente)
                    riga.DefaultCellStyle.BackColor = Color.Yellow;
                else
                    riga.DefaultCellStyle.BackColor = Color.White;
            }
            PopolaGrigliaFasi(componente);
        }

        private void dgvComponenti_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (tvDiBa.Nodes.Count <= 0) return;

            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            cambiaColoreNodo(idComponente, Color.Yellow);

            Componente componenteTrovato;
            if (_distinta.TrovaComponente(idComponente, out componenteTrovato))
                PopolaGrigliaFasi(componenteTrovato);
        }

        private void cambiaColoreNodo(int idComponente, Color colore)
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
            _idComponenteSelezionato = idComponente;

            cambiaColoreNodo(idComponente, Color.Transparent);
        }

        private void dgvComponenti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            string anagrafica = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value;
            string descrizione = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value;

            aggiornaNodoAlbero(idComponente, descrizione, anagrafica);
        }

        private void dgvComponenti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string anagrafica = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value;
            dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value = anagrafica.ToUpper();
            string descrizione = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value;
            dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value = descrizione.ToUpper();
            string collegamento = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmCollegamentoDibaComponente.Index].Value;
            dgvComponenti.Rows[e.RowIndex].Cells[clmCollegamentoDibaComponente.Index].Value = collegamento.ToUpper();
            string UM = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value;
            dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value = UM.ToUpper();

        }

        private void dgvFasiCiclo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            if (!_newrow) return;
            if (e.RowIndex == 0) return;

            Componente componenteTrovato;
            _distinta.TrovaComponente(_idComponenteSelezionato, out componenteTrovato);

            int operazione = 10;
            int idFaseCiclo = -1;
            if (componenteTrovato != null && componenteTrovato.FasiCiclo.Count > 0)
            {
                operazione = componenteTrovato.FasiCiclo.Max(x => x.Operazione) + 10;
                int min = componenteTrovato.FasiCiclo.Min(x => x.IdFaseCiclo);
                idFaseCiclo = min < 0 ? min - 1 : -1;
            }
            DataGridViewRow row = dgvFasiCiclo.Rows[e.RowIndex - 1];

            row.Cells[clmIDFaseCiclo.Index].Value = idFaseCiclo;
            row.Cells[clmIdDibaFaseCiclo.Index].Value = _distinta.IdDiba;
            row.Cells[clmIdComponenteFaseCiclo.Index].Value = _idComponenteSelezionato;
            row.Cells[clmOperazioneFaseCiclo.Index].Value = operazione;
            row.Cells[clmAreaProduzioneFaseCiclo.Index].Value = string.Empty;
            row.Cells[clmTaskFaseCiclo.Index].Value = string.Empty;
            row.Cells[clmSchedaProcessoFaseCiclo.Index].Value = string.Empty;
            row.Cells[clmCollegamentoCicloFaseCiclo.Index].Value = string.Empty;
            row.Cells[clmPeriodoFaseCiclo.Index].Value = 1;
            row.Cells[clmSetupFaseCiclo.Index].Value = 0;
            row.Cells[clmPezziOrariFaseCiclo.Index].Value = 0;
            row.Cells[clmAttesaFaseCiclo.Index].Value = 0;
            row.Cells[clmMovimentazioneFaseCiclo.Index].Value = 0;
            row.Cells[clmErroreFaseCiclo.Index].Value = string.Empty;
            _newrow = false;
        }

        private void dgvFasiCiclo_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _newrow = true;
        }

        private void dgvComponenti_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvFasiCiclo.CurrentCell.ColumnIndex == clmAnagraficaComponente.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoItems;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }
    }
}

