using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Helpers;
using MPIntranet.WS;
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
using NAV;
using System.Threading;

namespace DisegnaDiBa
{
    public partial class EsportaDiBaFrm : MPIChildForm
    {
        private List<ExpDistintaBusinessCentral> _distinteExport = new List<ExpDistintaBusinessCentral>();
        private List<ExpCicloBusinessCentral> _cicliExport = new List<ExpCicloBusinessCentral>();

        private List<ExpComponenteDistintaBusinessCentral> _componentiExport = new List<ExpComponenteDistintaBusinessCentral>();
        private List<ExpFaseCicloBusinessCentral> _fasiExport = new List<ExpFaseCicloBusinessCentral>();

        private BindingSource _sourceFasi;
        private BindingSource _sourceComponenti;
        private BindingSource _sourceDistinte;
        private BindingSource _sourceCicli;

        private BackgroundWorker _bwEsportazione = new BackgroundWorker();

        private const string etichettaStart = "Esporta";
        private const string etichettaStop = "Annulla";


        private void InizializzaBackgroundWorker()
        {
            _bwEsportazione.WorkerReportsProgress = true;
            _bwEsportazione.WorkerSupportsCancellation = true;

            _bwEsportazione.DoWork += _bwEsportazione_DoWork;
            _bwEsportazione.RunWorkerCompleted += _bwEsportazione_RunWorkerCompleted;
            _bwEsportazione.ProgressChanged += _bwEsportazione_ProgressChanged;
        }

        private void _bwEsportazione_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > pbEsportazione.Value)
            {
                if (e.ProgressPercentage > pbEsportazione.Maximum)
                    pbEsportazione.Maximum = e.ProgressPercentage;
                lblAvanzamento.Text = e.ProgressPercentage.ToString();
                pbEsportazione.Value = e.ProgressPercentage;
            }
            string messaggio = (string)e.UserState;
            AggiornaMessaggio(messaggio);
        }

        private void AggiornaMessaggio(string messaggio)
        {
            if (!string.IsNullOrEmpty(messaggio))
            {
                string str = string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), messaggio);
                txtEsportazione.Text = txtEsportazione.Text + Environment.NewLine + str;
            }
        }

        private void _bwEsportazione_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                btnAvviaEsportazione.Text = etichettaStart;
            }
            else if (e.Cancelled)
            {
                AggiornaMessaggio("*** OPERAZIONE CANCELLATA ***");
                btnAvviaEsportazione.Text = etichettaStart;
            }
            else
            {
                WorkerDTO dto = (WorkerDTO)e.Result;
                _fasiExport = dto.FasiExport;
                _componentiExport = dto.ComponentiExport;

                PopolaGrigliaComponenti();
                PopolaGrigliaFasi();
                PopolaGrigliaDistinte();
                PopolaGrigliaCicli();

                AggiornaMessaggio("*** OPERAZIONE COMPLETATA ***");
                pbEsportazione.Value = pbEsportazione.Maximum;
                btnAvviaEsportazione.Text = etichettaStart;
            }
        }

        private void esportaCicli(List<string> cicli, BackgroundWorker worker, DoWorkEventArgs e, ref int contatore)
        {
            BCServices bc = new BCServices();
            bc.CreaConnessione();
            WorkerDTO dto = (WorkerDTO)e.Argument;

            foreach (string ciclo in cicli)
            {
                try
                {
                    Cicli testata = bc.EstraiTestataCiclo(ciclo);
                    if (testata != null)
                    {
                        bc.CambiaDescrizioneCiclo(ciclo, testata.Description);

                        testata = bc.EstraiTestataCiclo(ciclo);

                        if (testata.Status != Stato.InSviluppo)
                            continue;

                        List<RigheCICLO> righe = bc.EstraiRigheCICLO(ciclo);
                        foreach (RigheCICLO riga in righe)
                        {
                            bc.RimuoviCommento(ciclo, string.Empty, riga.Operation_No);
                            bc.RimuoviFase(ciclo, string.Empty, riga.Operation_No);
                        }

                        foreach (ExpFaseCicloBusinessCentral f in dto.FasiExport.Where(x => x.CodiceCiclo == ciclo).OrderBy(x => x.Operazione))
                        {
                            try
                            {

                            }
                            catch (Exception ex)
                            {
                                string messaggio = string.Format("Ciclo {0} operazione {1} non esportato per il seguente errore: {2}", ciclo, f.Operazione, ex.Message);
                                {
                                    f.Errore = ex.Message;
                                    f.Esito = "KO";
                                }
                                worker.ReportProgress(contatore, messaggio);
                            }

                            f.Errore = string.Empty;
                            bc.AggiungiFase(ciclo, string.Empty, f.Operazione.ToString(), f.Tipo, f.AreaProduzione, f.Task, (decimal)f.TempoSetup, f.UMSetup,
                                (decimal)f.TempoLavorazione, f.UMLavorazione,
                                (decimal)f.TempoAttesa, f.UMAttesa, (decimal)f.TempoSpostamento, f.UMSpostamento,
                                (decimal)f.DimensioneLotto, f.Collegamento, f.Condizione, f.LogicheLavorazione, f.Caratteristica);
                            f.Commenti.ForEach(x => bc.AggiungiCommento(ciclo, string.Empty, f.Operazione.ToString(), x));
                            f.Esito = "OK";
                        }
                    }
                    else
                    {
                        string messaggio = string.Format("Il ciclo {0} non è stato trovato", ciclo);
                        foreach (ExpFaseCicloBusinessCentral c in dto.FasiExport.Where(x => x.CodiceCiclo == ciclo))
                        {
                            c.Errore = messaggio;
                            c.Esito = "KO";
                        }
                        worker.ReportProgress(contatore, messaggio);
                    }
                }
                catch (Exception ex)
                {
                    string messaggio = string.Format("Ciclo {0} non esportato per il seguente errore: {1}", ciclo, ex.Message);
                    foreach (ExpFaseCicloBusinessCentral f in dto.FasiExport.Where(x => x.CodiceCiclo == ciclo).OrderBy(x => x.Operazione))
                    {
                        f.Errore = "Eccezione";
                        f.Esito = "KO";
                    }
                    worker.ReportProgress(contatore, messaggio);
                }
                finally
                {
                    bc.CreaConnessione();
                }

                contatore++;
                worker.ReportProgress(contatore, string.Format("Ciclo {0} terminato", ciclo));
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void esportaDistinte(List<string> distinte, BackgroundWorker worker, DoWorkEventArgs e, ref int contatore)
        {
            BCServices bc = new BCServices();
            bc.CreaConnessione();
            WorkerDTO dto = (WorkerDTO)e.Argument;

            foreach (string distinta in distinte)
            {
                try
                {
                    TestataDIBA testata = bc.EstraiTestataDIBA(distinta);
                    if (testata != null)
                    {
                        bc.CambiaDescrizioneDB(distinta, testata.Description);
                        testata = bc.EstraiTestataDIBA(distinta);
                        if (testata.Status != Stato.InSviluppo)
                            continue;
                        List<RigheDIBA> righe = bc.EstraiRigheDIBA(distinta);
                        foreach (RigheDIBA riga in righe)
                            bc.RimuoviComponente(distinta, string.Empty, riga.Line_No, riga.No);

                        int numeroRiga = 0;
                        foreach (ExpComponenteDistintaBusinessCentral c in dto.ComponentiExport.Where(x => x.DistintaPadre == distinta))
                        {
                            try
                            {
                                c.Errore = string.Empty;
                                decimal quantita = (decimal)c.Quantita;
                                decimal scarto = (decimal)c.Scarto;
                                decimal arrotondamento = (decimal)c.Arrotondamento;
                                numeroRiga += 1000;
                                bc.AggiungiComponente(distinta, string.Empty, numeroRiga, c.Tipo, c.Anagrafica, c.Descrizione, c.CodiceUM, quantita, c.Collegamento, scarto, arrotondamento);
                                c.Esito = "OK";
                            }
                            catch (Exception ex)
                            {
                                string messaggio = string.Format("Distinta {0} componente {1} non esportata per il seguente errore: {2}", distinta, c.Anagrafica, ex.Message);
                                {
                                    c.Errore = ex.Message;
                                    c.Esito = "KO";
                                }
                                worker.ReportProgress(contatore, messaggio);
                            }
                        }
                    }
                    else
                    {
                        string messaggio = string.Format("La distinta {0} non è stata trovata", distinta);
                        foreach (ExpComponenteDistintaBusinessCentral c in dto.ComponentiExport.Where(x => x.DistintaPadre == distinta))
                        {
                            c.Errore = messaggio;
                            c.Esito = "KO";
                        }
                        worker.ReportProgress(contatore, messaggio);
                    }
                }
                catch (Exception ex)
                {
                    string messaggio = string.Format("Distinta {0} non esportata per il seguente errore: {1}", distinta, ex.Message);
                    foreach (ExpComponenteDistintaBusinessCentral c in dto.ComponentiExport.Where(x => x.DistintaPadre == distinta))
                    {
                        c.Errore = "Eccezione";
                        c.Esito = "KO";
                    }
                    worker.ReportProgress(contatore, messaggio);
                }
                finally
                {
                    bc.CreaConnessione();
                }


                contatore++;
                worker.ReportProgress(contatore, string.Format("Distinta {0} terminata", distinta));
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void _bwEsportazione_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dataRiferimento = new DateTime(2000, 1, 1);
            BackgroundWorker worker = sender as BackgroundWorker;
            WorkerDTO dto = (WorkerDTO)e.Argument;

            worker.ReportProgress(0, string.Format("Inizio esportazione componenti"));
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            List<string> distinte = dto.ComponentiExport.Select(x => x.DistintaPadre).Distinct().ToList();
            List<string> cicli = dto.FasiExport.Select(x => x.CodiceCiclo).Distinct().ToList();

            int elementiTotali = distinte.Count + cicli.Count;
            int contatore = 0;

            esportaCicli(cicli, worker, e, ref contatore);

            esportaDistinte(distinte, worker, e, ref contatore);

            e.Result = dto;

        }
        public EsportaDiBaFrm(List<ExpDistintaBusinessCentral> distinteExport, List<ExpCicloBusinessCentral> cicliExport, string etichettaFinestra)
        {
            InitializeComponent();
            _distinteExport = distinteExport;
            _cicliExport = cicliExport;
            Text = etichettaFinestra;
        }

        private void EsportaDiBaFrm_Load(object sender, EventArgs e)
        {
            lblAvanzamento.Text = string.Empty;
            lblElementi.Text = string.Empty;

            InizializzaBackgroundWorker();
            btnAvviaEsportazione.Text = etichettaStart;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DISTINTE INDIVIDUATE");
            sb.AppendLine("********************");
            sb.AppendLine(" ");
            _distinteExport.ForEach(x => sb.AppendLine(x.ToString()));

            sb.AppendLine("CICLI INDIVIDUATI");
            sb.AppendLine("*****************");
            sb.AppendLine(" ");
            _cicliExport.ForEach(x => sb.AppendLine(x.ToString()));

            txtMessaggio.Text = sb.ToString();

            PreparaListaComponentiPerGriglia();
            PulisciGriglie();

        }

        private void PreparaListaComponentiPerGriglia()
        {
            _distinteExport.ForEach(x => _componentiExport.AddRange(x.Componenti));
            _cicliExport.ForEach(x => _fasiExport.AddRange(x.Fasi));
        }

        private void PopolaGrigliaFasi()
        {
            if (_fasiExport.Count == 0)
            {
                dgvEsportaFasi.DataSource = null;
                return;
            }
            dgvEsportaFasi.AutoGenerateColumns = false;

            BindingList<ExpFaseCicloBusinessCentral> bindingList = new BindingList<ExpFaseCicloBusinessCentral>(_fasiExport);
            _sourceFasi = new BindingSource(bindingList, null);
            dgvEsportaFasi.DataSource = _sourceFasi;
            dgvEsportaFasi.Update();
        }

        private void AggiornaStatoDistinte()
        {
            BCServices bc = new BCServices();
            bc.CreaConnessione();
            List<string> ds = (from distinte in _distinteExport where distinte.Componenti.Count > 0 select distinte.Codice).ToList();
            foreach (ExpDistintaBusinessCentral d in _distinteExport)
            {
                if (!ds.Contains(d.Codice)) continue;
                TestataDIBA testata = bc.EstraiTestataDIBA(d.Codice);
                if (testata != null)
                {
                    d.Stato = testata.Status;
                }
                else
                {
                    d.Errore = "Distinta non trovata";
                }
            }
        }

        private void AggiornaStatoCicli()
        {
            BCServices bc = new BCServices();
            bc.CreaConnessione();
            foreach (ExpCicloBusinessCentral c in _cicliExport)
            {
                Cicli testata = bc.EstraiTestataCiclo(c.Codice);
                if (testata != null)
                {
                    c.Stato = testata.Status;
                }
                else
                {
                    c.Errore = "Ciclo non trovato";
                }
            }
        }
        private void PopolaGrigliaDistinte()
        {
            if (_distinteExport.Count == 0)
            {
                dgvEsportaDistinte.DataSource = null;
                return;
            }
         //   dgvEsportaFasi.AutoGenerateColumns = false;

            AggiornaStatoDistinte();

            BindingList<ExpDistintaBusinessCentral> bindingList = new BindingList<ExpDistintaBusinessCentral>(_distinteExport);
            _sourceDistinte = new BindingSource(bindingList, null);
            dgvEsportaDistinte.DataSource = _sourceDistinte;
            dgvEsportaDistinte.Update();
        }

        private void PopolaGrigliaCicli()
        {
            if (_cicliExport.Count == 0)
            {
                dgvEsportaCicli.DataSource = null;
                return;
            }
            dgvEsportaCicli.AutoGenerateColumns = false;

            AggiornaStatoCicli();

            BindingList<ExpCicloBusinessCentral> bindingList = new BindingList<ExpCicloBusinessCentral>(_cicliExport);
            _sourceCicli = new BindingSource(bindingList, null);
            dgvEsportaCicli.DataSource = _sourceCicli;
            dgvEsportaCicli.Update();
        }
        private void PopolaGrigliaComponenti()
        {
            if (_componentiExport.Count == 0)
            {
                dgvEsportaComponenti.DataSource = null;
                return;
            }
            dgvEsportaComponenti.AutoGenerateColumns = false;

            BindingList<ExpComponenteDistintaBusinessCentral> bindingList = new BindingList<ExpComponenteDistintaBusinessCentral>(_componentiExport);
            _sourceComponenti = new BindingSource(bindingList, null);
            dgvEsportaComponenti.DataSource = _sourceComponenti;
            dgvEsportaComponenti.Update();
        }

        private void btnTrovaFile_Click(object sender, EventArgs e)
        {
            Button pulsante = (Button)sender;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "INDICARE IL FILE PER SALVARE I CICLI"; ;
            if (pulsante.Name == btnTrovaFileDistinte.Name)
                sfd.Title = "INDICARE IL FILE PER SALVARE LE DISTINTE";

            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.DefaultExt = "xlsx";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            if (pulsante.Name == btnTrovaFileDistinte.Name)
                txtFileDistinte.Text = sfd.FileName;
            else if (pulsante.Name == btnTrovaFileCicli.Name)
                txtFileCicli.Text = sfd.FileName;
        }

        private void btnSalvaFile_Click(object sender, EventArgs e)
        {
            Button pulsante = (Button)sender;
            string pathCompleto = string.Empty;

            if (pulsante.Name == btnSalvaFileDistinte.Name)
                pathCompleto = txtFileDistinte.Text;
            else if (pulsante.Name == btnSalvaCicli.Name)
                pathCompleto = txtFileCicli.Text;
            else
                return;

            if (File.Exists(pathCompleto))
                File.Delete(pathCompleto);


            FileStream fs = new FileStream(pathCompleto, FileMode.Create);
            string errori = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ExcelHelper hExcel = new ExcelHelper();
                byte[] filedata = null;

                if (pulsante.Name == btnSalvaFileDistinte.Name)
                    filedata = hExcel.CreaFileCompoentiDistinta(_distinteExport, out errori);
                else if (pulsante.Name == btnSalvaCicli.Name)
                    filedata = hExcel.CreaFileFaseCicli(_cicliExport, out errori);
                else return;

                fs.Write(filedata, 0, filedata.Length);
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {

                ExceptionFrm frm = new ExceptionFrm(ex);
                frm.ShowDialog();
            }
            finally
            {
                fs.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void PulisciGriglie()
        {
            _componentiExport.ForEach(x => x.Errore = string.Empty);
            _componentiExport.ForEach(x => x.Esito = string.Empty);
            _fasiExport.ForEach(x => x.Errore = string.Empty);
            _fasiExport.ForEach(x => x.Esito = string.Empty);
            _cicliExport.ForEach(x => x.Errore = string.Empty);
            _cicliExport.ForEach(x => x.Esito = string.Empty);
            _distinteExport.ForEach(x => x.Errore = string.Empty);
            _distinteExport.ForEach(x => x.Esito = string.Empty);

            PopolaGrigliaComponenti();
            PopolaGrigliaFasi();
            PopolaGrigliaDistinte();
            PopolaGrigliaCicli();

        }

        private void btnAvviaEsportazione_Click(object sender, EventArgs e)
        {

            if (btnAvviaEsportazione.Text == etichettaStart)
            {
                List<string> distinte = _componentiExport.Select(x => x.DistintaPadre).Distinct().ToList();
                List<string> cicli = _fasiExport.Select(x => x.CodiceCiclo).Distinct().ToList();

                int elementi = distinte.Count + cicli.Count;

                if (elementi <= 0)
                {
                    MessageBox.Show("Non ci sono elementi da esportare", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblElementi.Text = elementi.ToString();

                btnAvviaEsportazione.Text = etichettaStop;

                pbEsportazione.Value = 0;
                txtEsportazione.Text = string.Empty;
                PulisciGriglie();

                if (_bwEsportazione.IsBusy != true)
                {
                    WorkerDTO dto = new WorkerDTO();
                    dto.ComponentiExport = _componentiExport;
                    dto.FasiExport = _fasiExport;

                    _bwEsportazione.RunWorkerAsync(dto);
                    return;
                }
            }
            else
            {
                if (_bwEsportazione.WorkerSupportsCancellation == true && _bwEsportazione.IsBusy)
                {
                    // Cancel the asynchronous operation.
                    _bwEsportazione.CancelAsync();
                }
                btnAvviaEsportazione.Text = etichettaStart;
            }
        }

        private void EsportaDiBaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnAvviaEsportazione.Text == etichettaStop)
            {
                MessageBox.Show("E' in corso un'esportazione, impossibile procedere", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnPulisciMessaggi_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
        }
    }

    public class WorkerDTO
    {
        public List<ExpComponenteDistintaBusinessCentral> ComponentiExport { get; set; }
        public List<ExpFaseCicloBusinessCentral> FasiExport { get; set; }

    }
    public class ElementoGrigliaComponenti
    {
        public bool? Selezionato { get; set; }
        public string Errore { get; set; }
        public string Distinta { get; set; }
        public string Anagrafica { get; set; }
        public string Stato { get; set; }

        public ElementoGrigliaComponenti(string distinta, string anagrafica, string errore, string stato, bool? selezionato)
        {
            Errore = errore;
            Distinta = distinta;
            Anagrafica = anagrafica;
            Stato = stato;
            Selezionato = selezionato;
        }
    }
}
