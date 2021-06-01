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
    public partial class DistintaBaseFrm : MPIChildForm
    {
        private Articolo _articolo;
        private DistintaBase _distinta;
        private int indiceNodi = 0;
        private BindingSource source;
        private AutoCompleteStringCollection _autoAreeProduzione = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoTask = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoItems = new AutoCompleteStringCollection();
        protected List<FaseDistinta> FasiDistintaDaCopiare
        {
            get { return (MdiParent as MainForm).FasiDistintaDaCopiare; }
            set { (MdiParent as MainForm).FasiDistintaDaCopiare = value; }
        }
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
                }

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
            PopolaGrigliaFasi();
        }
        private void aggiornaNodoAlbero(int idFaseDiba, string areaProduzione, string anagrafica)
        {
            string etichettaNodo = string.Format("{0} {1} {2}", idFaseDiba, areaProduzione, anagrafica).Trim();

            TreeNode nodoCercato = null;

            if (trovaNodo(tvDiBa.Nodes[0], idFaseDiba, out nodoCercato))
            {
                nodoCercato.Text = etichettaNodo;
                coloraNodo(nodoCercato);
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
            if (_distinta == null) return;
            tvDiBa.Nodes.Clear();
            if (_distinta.Fasi.Count() == 0)
                tvDiBa.Nodes.Add(creaNodo(_articolo.Descrizione, _articolo.Anagrafica, null));
            else
            {
                FaseDistinta faseRoot = _distinta.Fasi.Where(x => x.IdPadre == 0).FirstOrDefault();
                if (faseRoot == null) return;

                string etichettaNodo = string.Format("{0} {1}", faseRoot.IdFaseDiba, faseRoot.Anagrafica);
                TreeNode radice = new TreeNode(etichettaNodo);
                radice.Tag = faseRoot;
                coloraNodo(radice);
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

                coloraNodo(nodoFiglio);
                aggiungiNodoEsistente(faseFiglio.IdFaseDiba, nodoFiglio);
            }
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
            fase.Quantita = 1;
            fase.UMQuantita = "NR";
            string etichettaNodo = string.Format("{0} {1}", fase.IdFaseDiba, fase.Anagrafica);
            TreeNode nodo = new TreeNode(etichettaNodo);
            nodo.Tag = fase;
            coloraNodo(nodo);
            _distinta.Fasi.Add(fase);
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
                PopolaGrigliaFasi();
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
            cm.MenuItems.Add("Incolla ramo", new EventHandler(IncollaRamoClick));
            tvDiBa.ContextMenu = cm;

        }

        private void CopiaRamoClick(object sender, EventArgs e)
        {
            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            if (tn.Tag == null) return;
            FasiDistintaDaCopiare = new List<FaseDistinta>();

            FaseDistinta faseSelezionata = (FaseDistinta)tn.Tag;
            copiaFaseDistintaRicorsiva(faseSelezionata, 0);
        }
        private void copiaFaseDistintaRicorsiva(FaseDistinta faseSelezionata, int idPadre)
        {
            FaseDistinta faseCopiata = faseSelezionata.CopiaFase(estraiIndice(), idPadre);
            FasiDistintaDaCopiare.Add(faseCopiata);

            foreach (FaseDistinta faseFiglio in _distinta.Fasi.Where(x => x.IdPadre == faseSelezionata.IdFaseDiba))
            {
                copiaFaseDistintaRicorsiva(faseFiglio, faseCopiata.IdFaseDiba);
            }
        }
        private void IncollaRamoClick(object sender, EventArgs e)
        {
            if (FasiDistintaDaCopiare == null) return;

            TreeNode tn = tvDiBa.SelectedNode;
            if (tn == null) return;
            if (tn.Tag == null) return;

            FaseDistinta faseSelezionata = (FaseDistinta)tn.Tag;
            FaseDistinta faseIniziale = FasiDistintaDaCopiare.Where(x => x.IdPadre == 0).FirstOrDefault();
            incollaFaseDistintaRicorsiva(faseIniziale, faseSelezionata.IdFaseDiba, tn);
            PopolaGrigliaFasi();
            tn.ExpandAll();
        }
        private void incollaFaseDistintaRicorsiva(FaseDistinta faseIniziale, int idPadre, TreeNode nodoPadre)
        {
            if (faseIniziale == null) return;

            FaseDistinta FaseInizialeCopiata = faseIniziale.CopiaFase(estraiIndice(), idPadre);

            string etichettaNodo = string.Format("{0} {1} {2}", FaseInizialeCopiata.IdFaseDiba, FaseInizialeCopiata.AreaProduzione, FaseInizialeCopiata.Anagrafica);
            TreeNode nodoFiglio = new TreeNode(etichettaNodo);
            nodoFiglio.Tag = FaseInizialeCopiata;
            coloraNodo(nodoFiglio);
            nodoPadre.Nodes.Add(nodoFiglio);
            _distinta.Fasi.Add(FaseInizialeCopiata);
            foreach (FaseDistinta figlio in FasiDistintaDaCopiare.Where(x => x.IdPadre == faseIniziale.IdFaseDiba))
            {
                incollaFaseDistintaRicorsiva(figlio, FaseInizialeCopiata.IdFaseDiba, nodoFiglio);
            }
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

        private void coloraNodo(TreeNode nodo)
        {
            if (nodo.Tag != null)
            {
                FaseDistinta fase = (FaseDistinta)nodo.Tag;
                if (!string.IsNullOrEmpty(fase.Anagrafica))
                    nodo.ForeColor = Color.Red;

            }
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
            if (_distinta == null) return;
            dgvNodi.AutoGenerateColumns = false;
            BindingList<FaseDistinta> bindingList = new BindingList<FaseDistinta>(_distinta.Fasi);
            source = new BindingSource(bindingList, null);
            dgvNodi.DataSource = source;
            dgvNodi.Update();
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

        private bool verificaDistintaPerSalvataggio()
        {
            bool esito = true;
            foreach (FaseDistinta fase in _distinta.Fasi)
            {
                fase.Errore = string.Empty;
                if (string.IsNullOrEmpty(fase.AreaProduzione))
                {
                    esito = false;
                    fase.Errore = "Inserire Area Produzione ";
                }
                if (string.IsNullOrEmpty(fase.Task))
                {
                    esito = false;
                    fase.Errore = "Inserire Task ";
                }
                if (fase.Quantita <= 0)
                {
                    esito = false;
                    fase.Errore = "Inserire Quantità ";
                }
            }
            return esito;
        }
        private void btnSalvaDiba_Click(object sender, EventArgs e)
        {
            try
            {
                if (_distinta == null) return;
                if (verificaDistintaPerSalvataggio())
                {
                    _distinta.SalvaListaFasiDistinta(_utenteConnesso);
                    _distinta = DistintaBase.EstraiDistintaBase(_distinta.IdDiba);
                    creaAlbero();
                }
                PopolaGrigliaFasi();
            }
            catch (Exception ex)
            {
                txtNotifiche.Text = ex.Message;
                MostraEccezione(ex, "Errore in verifica cicli");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            List<CicloBusinessCentral> cicli;
            List<DistintaBusinessCentral> distinte;
            string errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!VerificaDistinte(out distinte, out errori))
                {
                    sb.AppendLine(String.Empty);
                    sb.AppendLine(String.Empty);
                    sb.AppendLine("*** ANALISI DISTINTE ***");
                    esito = false;
                    sb.AppendLine(errori);
                }

                if (!VerificaCicli(out cicli, out errori))
                {
                    sb.AppendLine(String.Empty);
                    sb.AppendLine(String.Empty);
                    sb.AppendLine("*** ANALISI cicli ***");
                    esito = false;
                    sb.AppendLine(errori);
                }

                if (esito)
                {
                    salvaCicli(cicli);
                    salvaDistinte(distinte);
                }
            }
            catch (Exception ex)
            {
                txtNotifiche.Text = ex.Message;
                sb.AppendLine(ex.Message);
                MostraEccezione(ex, "Errore in verifica cicli");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                txtNotifiche.Text = sb.ToString();
            }
        }

        private void salvaDistinte(List<DistintaBusinessCentral> distinte)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "INDICARE IL FILE PER SALVARE LE DISTINTE";

            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            string pathCompleto = sfd.FileName;

            if (File.Exists(pathCompleto))
                File.Delete(pathCompleto);

            FileStream fs = new FileStream(pathCompleto, FileMode.Create);
            string errori = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileCompoentiDistinta(distinte, out errori);
                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore nel creare il file");
                Cursor.Current = Cursors.Default;

            }
            finally
            {
                fs.Close();
            }
        }
        private void salvaCicli(List<CicloBusinessCentral> cicli)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "INDICARE IL FILE PER SALVARE I CICLI";
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            string pathCompleto = sfd.FileName;

            if (File.Exists(pathCompleto))
                File.Delete(pathCompleto);

            string errori = string.Empty;
            FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = hExcel.CreaFileFaseCicli(cicli, out errori);

                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore nel creare il file");
                Cursor.Current = Cursors.Default;

            }
            finally
            {
                fs.Close();
            }
        }
        private bool VerificaDistinte(out List<DistintaBusinessCentral> distinte, out string errori)
        {
            bool esito = true;
            errori = string.Empty;
            distinte = new List<DistintaBusinessCentral>();
            StringBuilder sb = new StringBuilder();

            List<FaseDistinta> faseConAnagrafica = _distinta.Fasi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderByDescending(x => x.IdFaseDiba).ToList();
            if (faseConAnagrafica.Count == 0)
            {
                sb.AppendLine("Nessuna anagrafica trovata");
                return false;
            }
            if (faseConAnagrafica.Count == 1)
            {
                sb.AppendLine("Una sola anagrafica");
                return false;
            }

            foreach (FaseDistinta fase in faseConAnagrafica)
            {
                List<FaseDistinta> fasiFiglie = _distinta.Fasi.Where(x => x.IdPadre == fase.IdFaseDiba).ToList();

                while (fasiFiglie.Count > 0)
                {
                    List<ComponenteDistintaBusinessCentral> componenti = new List<ComponenteDistintaBusinessCentral>();
                    bool esitoFiglio = true;
                    if (fasiFiglie.Count > 1)
                    {
                        foreach (FaseDistinta figlio in fasiFiglie)
                        {
                            if (string.IsNullOrEmpty(figlio.Anagrafica))
                            {
                                figlio.Errore = "Anagrafica non definita";
                                sb.AppendLine(string.Format("Fase {0} manca anagrafica", figlio.IdFaseDiba));
                                esitoFiglio = false;
                                esito = false;
                            }
                            if (figlio.Quantita <= 0)
                            {
                                figlio.Errore += " Anagrafica non definita";
                                sb.AppendLine(string.Format("Fase {0} quantità non valida", figlio.IdFaseDiba));
                                esitoFiglio = false;
                                esito = false;

                            }
                            componenti.Add(new ComponenteDistintaBusinessCentral(figlio.Anagrafica, figlio.Quantita, figlio.CollegamentoDiba, figlio.UMQuantita, figlio.IdFaseDiba, fase.Anagrafica));

                        }
                        if (esitoFiglio)
                            distinte.Add(new DistintaBusinessCentral(fase.Anagrafica, componenti));

                        fasiFiglie = new List<FaseDistinta>();
                        continue;

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(fasiFiglie[0].Anagrafica))
                        {
                            componenti.Add(new ComponenteDistintaBusinessCentral(fasiFiglie[0].Anagrafica, fasiFiglie[0].Quantita, fasiFiglie[0].CollegamentoDiba, fasiFiglie[0].UMQuantita, fasiFiglie[0].IdFaseDiba, fase.Anagrafica));
                            distinte.Add(new DistintaBusinessCentral(fase.Anagrafica, componenti));
                            fasiFiglie = new List<FaseDistinta>();
                        }
                        else
                            fasiFiglie = _distinta.Fasi.Where(x => x.IdPadre == fasiFiglie[0].IdFaseDiba).ToList();

                    }
                }

            }

            errori = sb.ToString();
            return esito;
        }

        private bool VerificaCicli(out List<CicloBusinessCentral> cicli, out string errori)
        {
            bool esito = true;
            errori = string.Empty;
            cicli = new List<CicloBusinessCentral>();
            StringBuilder sb = new StringBuilder();

            string messaggioErrore = string.Empty;


            List<FaseDistinta> faseConAnagrafica = _distinta.Fasi.Where(x => !string.IsNullOrEmpty(x.Anagrafica)).OrderByDescending(x => x.IdFaseDiba).ToList();
            if (faseConAnagrafica.Count == 0)
            {
                sb.AppendLine("Nessuna anagrafica trovata");
                return false;
            }
            if (faseConAnagrafica.Count == 1)
            {
                sb.AppendLine("Una sola anagrafica trovata");
                return false;
            }
            foreach (FaseDistinta fase in faseConAnagrafica)
            {
                int operazione = 10;
                CicloBusinessCentral c = new CicloBusinessCentral(fase.Anagrafica);
                c.AggiungiFase(fase, operazione, out errori);
                operazione += 10;
                sb.Append(errori);

                List<FaseDistinta> fasiFiglie = _distinta.Fasi.Where(x => x.IdPadre == fase.IdFaseDiba).ToList();

                while (fasiFiglie.Count == 1 && string.IsNullOrEmpty(fasiFiglie[0].Anagrafica))
                {
                    if (string.IsNullOrEmpty(fasiFiglie[0].Anagrafica))
                    {
                        string erroriFase;
                        c.AggiungiFase(fasiFiglie[0], operazione, out erroriFase);
                        operazione += 10;
                        sb.Append(errori);
                        fasiFiglie = _distinta.Fasi.Where(x => x.IdPadre == fasiFiglie[0].IdFaseDiba).ToList();
                    }
                }

                if (c.Fasi.Count > 0)
                    cicli.Add(c);
            }
            errori = sb.ToString();
            return esito;
        }

        private void dgvNodi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dgvNodi.CurrentCell.ColumnIndex;

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

        private void dgvNodi_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvNodi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idFaseDiba = (int)dgvNodi.Rows[e.RowIndex].Cells[IdFase.Index].Value;
            string anagrafica = (string)dgvNodi.Rows[e.RowIndex].Cells[Anagrafica.Index].Value;
            string areaProduzione = (string)dgvNodi.Rows[e.RowIndex].Cells[AreaProduzione.Index].Value;

            aggiornaNodoAlbero(idFaseDiba, areaProduzione, anagrafica);
        }

        private void tvDiBa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FaseDistinta faseDistinta = (FaseDistinta)e.Node.Tag;

            foreach (DataGridViewRow riga in dgvNodi.Rows)
            {
                int IDRiga = (int)riga.Cells[IdFase.Index].Value;
                if (IDRiga == faseDistinta.IdFaseDiba)
                    riga.DefaultCellStyle.BackColor = Color.Yellow;
                else
                    riga.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
