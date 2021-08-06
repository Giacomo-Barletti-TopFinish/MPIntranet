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
        private string separatoreAutocomplete = " ## ";
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
        private List<TaskArea> _taskAreaProduzione = new List<TaskArea>();
        private List<Item> _items;

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
        private int estraiIndiceFasiCiclo()
        {
            indiceFaseCiclo--;
            return indiceFaseCiclo;
        }
        public DistintaBaseFrm2()
        {
            InitializeComponent();
            CreaMenuContestualeTreeView();
        }

        private void DistintaBaseFrm_Load(object sender, EventArgs e)
        {
            tmrSalvataggio.Interval = 10 * 60 * 1000;
            avviaTimerAutoSalvataggio();
            impostaColorePulsanteAutosave();

            NuovoArticoloFrm nForm = new NuovoArticoloFrm();
            nForm.Utente = _utenteConnesso;
            nForm.ShowDialog();
            int _idArticolo = nForm.IDArticolo;
            if (_idArticolo == ElementiVuoti.Articolo)
            {
                MessageBox.Show("Nessun articolo selezionato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                caricaAreeProduzione();
                caricaTask();
                caricaItems();

                _articolo = Articolo.EstraiArticolo(_idArticolo);

                if (_articolo != null)
                {
                    txtArticolo.Text = _articolo.ToString();
                    txtCodiceEsteso.Text = _articolo.CodiceClienteEsteso;
                }
                _taskAreaProduzione = TaskArea.EstraiListaTaskArea(true);
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
            _items = Item.EstraiListaItems();

            string[] etichette = _items.Select(x => x.Anagrafica + separatoreAutocomplete + x.Descrizione).ToArray();
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
            try
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

                Cursor.Current = Cursors.WaitCursor;
                popolaCampi();

                creaAlbero();
                PopolaGrigliaComponenti();
                PopolaGrigliaFasi(_distinta.Componenti[0]);
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
            tvDiBa.Nodes.Clear();
            if (_distinta == null) return;
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
            componente.CollegamentoDiBa = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
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

            txtDescrizioneDiba.Text = string.Empty;
            txtVersioneDiba.Text = string.Empty;
            txtTipoDiba.Text = string.Empty;

            if (_distinta == null) return;
            this.Text = string.Format("{0} {1} {2}", _distinta.Articolo.ToString(), _distinta.TipoDistinta, _distinta.Versione);
            txtDescrizioneDiba.Text = _distinta.Descrizione;
            txtVersioneDiba.Text = _distinta.Versione.ToString();
            txtTipoDiba.Text = _distinta.TipoDistinta.TipoDiba;

            toolCreaDiBaProduzione.Enabled = true;
            if (_distinta.TipoDistinta.TipoDiba == TipoDistinta.TipoProduzione)
                toolCreaDiBaProduzione.Enabled = false;

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

                if (_distinta == null)
                    MessageBox.Show("Nessuna distinta selezionata", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                popolaCampi();
                creaAlbero();
                PopolaGrigliaComponenti();
                PopolaGrigliaFasi(null);
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
            try
            {
                TreeNode tn = tvDiBa.SelectedNode;
                if (tn == null) return;
                if (tn.Tag == null) return;
                ComponentiDaCopiare = new List<Componente>();

                Componente componenteSelezionato = (Componente)tn.Tag;
                copiaComponenteRicorsivo(componenteSelezionato, 0);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
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
            try
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
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }

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
            {
                dgvFasiCiclo.DataSource = null;
                return;
            }
            dgvFasiCiclo.AutoGenerateColumns = false;
            if (componente.FasiCiclo == null) componente.FasiCiclo = new List<FaseCiclo>();

            BindingList<FaseCiclo> bindingList = new BindingList<FaseCiclo>(componente.FasiCiclo);
            sourceFasiCicli = new BindingSource(bindingList, null);
            dgvFasiCiclo.DataSource = sourceFasiCicli;
            dgvFasiCiclo.Update();
        }

        private void PopolaGrigliaComponenti()
        {
            if (_distinta == null)
            {
                dgvComponenti.DataSource = null;
                dgvComponenti.Update();
                return;
            }
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
                Cursor.Current = Cursors.WaitCursor;
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

            TextBox tb1 = e.Control as TextBox;
            {
                tb1.AutoCompleteCustomSource = null;
            }

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
            if (columnIndex == clmAnagraficaFaseCiclo.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoItems;
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
            try
            {
                if (e.RowIndex < 0) return;
                if (tvDiBa.Nodes.Count <= 0) return;

                int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
                cambiaColoreNodo(idComponente, Color.Yellow);

                Componente componenteTrovato;
                if (_distinta.TrovaComponente(idComponente, out componenteTrovato))
                    PopolaGrigliaFasi(componenteTrovato);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }

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
            if (dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value == null) return;
            int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
            _idComponenteSelezionato = idComponente;

            cambiaColoreNodo(idComponente, Color.Transparent);
        }

        private void dgvComponenti_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                int idComponente = (int)dgvComponenti.Rows[e.RowIndex].Cells[clmIdComponente.Index].Value;
                string anagrafica = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value;
                string descrizione = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value;

                aggiornaNodoAlbero(idComponente, descrizione, anagrafica);
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }

        }

        private void dgvComponenti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (!string.IsNullOrEmpty((string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value))
                {
                    string anagrafica = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value;
                    anagrafica = anagrafica.ToUpper();
                    if (string.IsNullOrEmpty(anagrafica)) return;
                    int posizione = anagrafica.IndexOf(separatoreAutocomplete);
                    anagrafica = anagrafica.Substring(0, posizione);
                    dgvComponenti.Rows[e.RowIndex].Cells[clmAnagraficaComponente.Index].Value = anagrafica;

                    Item item = _items.Where(x => x.Anagrafica == anagrafica).FirstOrDefault();
                    if (item != null) dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value = item.UM;

                }
                if (!string.IsNullOrEmpty((string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value))
                {
                    string descrizione = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value;
                    dgvComponenti.Rows[e.RowIndex].Cells[clmDescrizioneComponente.Index].Value = descrizione.ToUpper();
                }
                if (!string.IsNullOrEmpty((string)dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value))
                {
                    string UM = (string)dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value;
                    dgvComponenti.Rows[e.RowIndex].Cells[clmUMQuantitaComponente.Index].Value = UM.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
        }

        private void dgvFasiCiclo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
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
                    idFaseCiclo = estraiIndiceFasiCiclo();
                }
                DataGridViewRow row = dgvFasiCiclo.Rows[e.RowIndex - 1];

                row.Cells[clmIDFaseCiclo.Index].Value = idFaseCiclo;
                row.Cells[clmIdDibaFaseCiclo.Index].Value = _distinta.IdDiba;
                row.Cells[clmIdComponenteFaseCiclo.Index].Value = _idComponenteSelezionato;
                row.Cells[clmOperazioneFaseCiclo.Index].Value = operazione;
                row.Cells[clmAreaProduzioneFaseCiclo.Index].Value = string.Empty;
                row.Cells[clmTaskFaseCiclo.Index].Value = string.Empty;
                row.Cells[clmSchedaProcessoFaseCiclo.Index].Value = string.Empty;
                row.Cells[clmSchedaProcessoFaseCiclo.Index].Value = string.Empty;
                row.Cells[clmCollegamentoCicloFaseCiclo.Index].Value = string.Empty;
                row.Cells[clmPeriodoFaseCiclo.Index].Value = 1;
                row.Cells[clmSetupFaseCiclo.Index].Value = 0;
                row.Cells[clmPezziOrariFaseCiclo.Index].Value = 0;
                row.Cells[clmAttesaFaseCiclo.Index].Value = 0;
                row.Cells[clmMovimentazioneFaseCiclo.Index].Value = 0;
                row.Cells[clmErroreFaseCiclo.Index].Value = string.Empty;

                row.Cells[clmQuantitaFaseCiclo.Index].Value = 1;
                row.Cells[clmUMQuantitaFaseCiclo.Index].Value = "NR";
                //                row.Cells[clmCollegamentoDiBAFaseCiclo.Index].Value = ExpCicloBusinessCentral.CodiceStandard;

                _newrow = false;
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
        }

        private void dgvFasiCiclo_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _newrow = true;
        }

        private void dgvComponenti_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvComponenti.CurrentCell.ColumnIndex == clmAnagraficaComponente.Index)
            {
                TextBox tb = e.Control as TextBox;
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _autoItems;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }


        private void btnEsporta_Click(object sender, EventArgs e)
        {

            try
            {
                List<ExpDistintaBusinessCentral> distinteExport = new List<ExpDistintaBusinessCentral>();
                List<ExpCicloBusinessCentral> cicliExport = new List<ExpCicloBusinessCentral>();
                string errori;
                if (_distinta == null)
                {
                    MessageBox.Show("Nessuna distinta selezionata", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_distinta.Esporta(distinteExport, cicliExport, out errori))
                {
                    EsportaDiBaFrm form = new EsportaDiBaFrm(distinteExport, cicliExport);
                    form.ShowDialog();
                }
                else
                {
                    string messagio = "VERIFICARE I SEGUENTI ERRORI" + Environment.NewLine + errori;
                    MessageBox.Show(messagio, "ERRORI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }

        }

        private void dgvFasiCiclo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                convertiContenutoMaiuscolo(dgvFasiCiclo, clmAnagraficaFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmCollegamentoDiBAFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmCollegamentoCicloFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmUMQuantitaFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmAreaProduzioneFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmTaskFaseCiclo, e.RowIndex);
                convertiContenutoMaiuscolo(dgvFasiCiclo, clmSchedaProcessoFaseCiclo, e.RowIndex);

                if (e.ColumnIndex == clmOperazioneFaseCiclo.Index) riordinaFasiCiclo();

                if (e.ColumnIndex == clmAnagraficaFaseCiclo.Index)
                {
                    string anagrafica = (dgvFasiCiclo.Rows[e.RowIndex].Cells[clmAnagraficaFaseCiclo.Index].Value as string);
                    if (string.IsNullOrEmpty(anagrafica)) return;
                    int posizione = anagrafica.IndexOf(separatoreAutocomplete);
                        anagrafica = anagrafica.Substring(0, posizione);
                        dgvFasiCiclo.Rows[e.RowIndex].Cells[clmAnagraficaFaseCiclo.Index].Value = anagrafica;

                    Item item = _items.Where(x => x.Anagrafica == anagrafica).FirstOrDefault();
                    if (item != null) dgvFasiCiclo.Rows[e.RowIndex].Cells[clmUMQuantitaFaseCiclo.Index].Value = item.UM;


                    if (!string.IsNullOrEmpty(dgvFasiCiclo.Rows[e.RowIndex].Cells[clmAnagraficaFaseCiclo.Index].Value as string) &&
                        string.IsNullOrEmpty(dgvFasiCiclo.Rows[e.RowIndex].Cells[clmCollegamentoDiBAFaseCiclo.Index].Value as string))
                        dgvFasiCiclo.Rows[e.RowIndex].Cells[clmCollegamentoDiBAFaseCiclo.Index].Value = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
                }


                if (e.ColumnIndex == clmTaskFaseCiclo.Index)
                {
                    if (string.IsNullOrEmpty(dgvFasiCiclo.Rows[e.RowIndex].Cells[clmAreaProduzioneFaseCiclo.Index].Value as string) &&
                        !string.IsNullOrEmpty(dgvFasiCiclo.Rows[e.RowIndex].Cells[clmTaskFaseCiclo.Index].Value as string))
                    {
                        string task = (string)dgvFasiCiclo.Rows[e.RowIndex].Cells[clmTaskFaseCiclo.Index].Value;
                        TaskArea taskArea = _taskAreaProduzione.Where(x => x.Task == task).FirstOrDefault();
                        if (taskArea != null)
                        {
                            dgvFasiCiclo.Rows[e.RowIndex].Cells[clmAreaProduzioneFaseCiclo.Index].Value = taskArea.AreaProduzione;
                            if (dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPezziOrariFaseCiclo.Index].Value == null)
                            {
                                dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPezziOrariFaseCiclo.Index].Value = taskArea.PezziPeriodo;
                                dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPeriodoFaseCiclo.Index].Value = taskArea.Periodo;
                            }
                            else
                            {
                                double pezzi = (double)dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPezziOrariFaseCiclo.Index].Value;
                                if (pezzi == 0)
                                {
                                    dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPezziOrariFaseCiclo.Index].Value = taskArea.PezziPeriodo;
                                    dgvFasiCiclo.Rows[e.RowIndex].Cells[clmPeriodoFaseCiclo.Index].Value = taskArea.Periodo;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
        }

        private void riordinaFasiCiclo()
        {

            Componente componenteTrovato;
            if (_distinta.TrovaComponente(_idComponenteSelezionato, out componenteTrovato))
            {
                componenteTrovato.FasiCiclo = componenteTrovato.FasiCiclo.OrderByDescending(x => x.Operazione).ToList();
                PopolaGrigliaFasi(componenteTrovato);
            }

        }

        private void convertiContenutoMaiuscolo(DataGridView dgv, DataGridViewTextBoxColumn clm, int indiceRiga)
        {
            if (!string.IsNullOrEmpty((string)dgv.Rows[indiceRiga].Cells[clm.Index].Value))
            {
                string testo = (string)dgv.Rows[indiceRiga].Cells[clm.Index].Value;
                dgv.Rows[indiceRiga].Cells[clm.Index].Value = testo.ToUpper();
            }
        }

        private void tmrSalvataggio_Tick(object sender, EventArgs e)
        {
            if (_distinta == null) return;
            if (_articolo == null) return;

            if (toolAutosalvataggio.Checked)
                btnSalvaDiba_Click(null, null);
        }

        private void avviaTimerAutoSalvataggio()
        {
            if (toolAutosalvataggio.Checked)
                tmrSalvataggio.Start();
            else
                tmrSalvataggio.Stop();
        }


        private void impostaColorePulsanteAutosave()
        {
            if (toolAutosalvataggio.Checked)
                toolAutosalvataggio.Font = new Font(this.Font, FontStyle.Bold);
            else
                toolAutosalvataggio.Font = new Font(this.Font, FontStyle.Regular);
        }
        private void toolAutosalvataggio_Click(object sender, EventArgs e)
        {
            toolAutosalvataggio.Checked = !toolAutosalvataggio.Checked;
            impostaColorePulsanteAutosave();
            avviaTimerAutoSalvataggio();
        }

        private void toolCollegamento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Questa operazione resettera tutte le impostazioni manuali fatte ai codici di collegamento. Vuoi procedere ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string errori;
                    if (_distinta.CorreggiCollegamentoDibaCiclo(out errori))
                        MessageBox.Show("Operazione completata", "INFORMAZIONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string msg = "Operazione terminata con errori: ";
                        msg = msg + Environment.NewLine;
                        msg = msg + errori;
                        MessageBox.Show(msg, "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
        }

        private void toolCreaDiBaProduzione_Click(object sender, EventArgs e)
        {
            if (_distinta.TipoDistinta.TipoDiba == TipoDistinta.TipoProduzione)
            {
                MessageBox.Show("La distinta è già una distinta di produzione", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int idDiba = ElementiVuoti.DistintaBase;
                int IdTipoDiBa = TipoDistinta.EstraiListaTipoDistinta(true).Where(x => x.TipoDiba == TipoDistinta.TipoProduzione).Select(x => x.IdTipoDiBa).FirstOrDefault();
                DistintaBase.CreaDistinta(_articolo.IdArticolo, IdTipoDiBa, 1, _distinta.Descrizione, false, _utenteConnesso, out idDiba);

                if (idDiba == ElementiVuoti.DistintaBase)
                {
                    MessageBox.Show("ERRORE NELLA CREAZIONE DELLA DISTINTA", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DistintaBase nuovaDistinta = DistintaBase.EstraiDistintaBase(idDiba);
                _distinta.Copia(nuovaDistinta, _utenteConnesso);
                nuovaDistinta.ConvertiAnagraficaInProduzione();
                _distinta = nuovaDistinta;
                popolaCampi();
                creaAlbero();
                PopolaGrigliaComponenti();
                PopolaGrigliaFasi(null);
                MessageBox.Show("Operazione completata con successo", "INFORMAZIONE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in crea diba produzione");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgvFasiCiclo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Formato del dato sbagliato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
            e.Cancel = false;

        }

        private void toolCancellaDiBa_Click(object sender, EventArgs e)
        {
            if (_distinta == null) return;
            _distinta.Cancella(_utenteConnesso);
            _distinta = null;
            popolaCampi();
            creaAlbero();
            PopolaGrigliaComponenti();
            PopolaGrigliaFasi(null);


        }
    }
}

