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

namespace DisegnaDiBa
{
    public partial class EsportaDiBaFrm : Form
    {
        private List<ExpDistintaBusinessCentral> _distinteExport = new List<ExpDistintaBusinessCentral>();
        private List<ExpCicloBusinessCentral> _cicliExport = new List<ExpCicloBusinessCentral>();

        private List<ExpComponenteDistintaBusinessCentral> _componentiExport = new List<ExpComponenteDistintaBusinessCentral>();
        private List<ExpFaseCicloBusinessCentral> _fasiExport = new List<ExpFaseCicloBusinessCentral>();

        private BindingSource _sourceFasi;
        private BindingSource _sourceComponenti;

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
            if (e.UserState == null)
            {
                lblAvanzamento.Text = e.ProgressPercentage.ToString();
                if (e.ProgressPercentage > pbEsportazione.Maximum)
                    pbEsportazione.Maximum = e.ProgressPercentage;
                pbEsportazione.Value = e.ProgressPercentage;
                return;
            }

            string messaggio = (string)e.UserState;
            AggiornaMessaggio(messaggio);
        }

        private void AggiornaMessaggio(string messaggio)
        {
            string str = string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), messaggio);
            txtEsportazione.Text = str + Environment.NewLine + txtEsportazione.Text;
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
                AggiornaMessaggio("*** CALCOLA COSTI CANCELLATA ***");
                btnAvviaEsportazione.Text = etichettaStart;
            }
            else
            {
                WorkerDTO dto = (WorkerDTO)e.Result;
                _fasiExport = dto.FasiExport;
                _componentiExport = dto.ComponentiExport;

                PopolaGrigliaComponenti();
                PopolaGrigliaFasi();

                AggiornaMessaggio("*** CALCOLA COSTI COMPLETATA ***");
                pbEsportazione.Value = pbEsportazione.Maximum;
                btnAvviaEsportazione.Text = etichettaStart;
            }
        }

        private void _bwEsportazione_DoWork(object sender, DoWorkEventArgs e)
        {
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


            BCServices bc = new BCServices();
            bc.CreaConnessione();

            foreach (string distinta in distinte)
            {
                TestataDIBA testata = bc.EstraiTestataDIBA(distinta);
                if (testata != null)
                {
                    bc.CambiaStatoDB(distinta, Stato.InSviluppo);
                    List<RigheDIBA> righe = bc.EstraiRigheDIBA(distinta);
                    foreach (RigheDIBA riga in righe)
                        bc.RimuoviComponente(distinta, string.Empty, riga.Line_No, riga.No);

                    righe = bc.EstraiRigheDIBA(distinta);
                    int numeroRiga = righe.Max(x => x.Line_No);
                    foreach (ExpComponenteDistintaBusinessCentral c in dto.ComponentiExport.Where(x => x.DistintaPadre == distinta))
                    {
                        c.Errore = string.Empty;
                        decimal quantita = (decimal)c.Quantita;
                        decimal scarto = (decimal)c.Scarto;
                        decimal arrotondamento = (decimal)c.Arrotondamento;
                        numeroRiga += 1000;
                        bc.AggiungiComponente(distinta, string.Empty, numeroRiga, c.Tipo, c.Anagrafica, c.Descrizione, c.CodiceUM, quantita, c.Collegamento, scarto, arrotondamento);
                        c.Esito = "OK";
                    }
                    bc.CambiaStatoDB(distinta, Stato.Certificato);
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
                contatore++;
                worker.ReportProgress(contatore, "");
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            foreach (string ciclo in cicli)
            {
                Cicli testata = bc.EstraiTestataCiclo(ciclo);
                if (testata != null)
                {
                    bc.CambiaStatoCiclo(ciclo, Stato.InSviluppo);
                    List<RigheCICLO> righe = bc.EstraiRigheCICLO(ciclo);
                    foreach (RigheCICLO riga in righe)
                    {
                        bc.RimuoviCommento(ciclo, string.Empty, riga.Operation_No);
                        bc.RimuoviFase(ciclo, string.Empty, riga.Operation_No);
                    }

                    foreach (ExpFaseCicloBusinessCentral f in dto.FasiExport.Where(x => x.CodiceCiclo == ciclo).OrderBy(x => x.Operazione))
                    {
                        f.Errore = string.Empty;
                        bc.AggiungiFase(ciclo, string.Empty, f.Operazione.ToString(), f.Tipo, f.AreaProduzione, f.Task, (decimal)f.TempoSetup, f.UMSetup,
                            (decimal)f.TempoLavorazione, f.UMLavorazione,
                            (decimal)f.TempoAttesa, f.UMAttesa, (decimal)f.TempoSpostamento, f.UMSpostamento,
                            (decimal)f.DimensioneLotto, f.Collegamento, f.Condizione, f.LogicheLavorazione, f.Caratteristica);
                        f.Commenti.ForEach(x => bc.AggiungiCommento(ciclo, string.Empty, f.Operazione.ToString(), x));
                        f.Esito = "OK";
                    }
                    bc.CambiaStatoCiclo(ciclo, Stato.Certificato);
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
                contatore++;
                worker.ReportProgress(contatore, "");
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            e.Result = dto;

        }
        public EsportaDiBaFrm(List<ExpDistintaBusinessCentral> distinteExport, List<ExpCicloBusinessCentral> cicliExport)
        {
            InitializeComponent();
            _distinteExport = distinteExport;
            _cicliExport = cicliExport;
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
            PopolaGrigliaComponenti();
            PopolaGrigliaFasi();
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
                dgvEsportaCicli.DataSource = null;
                return;
            }
            dgvEsportaCicli.AutoGenerateColumns = false;

            BindingList<ExpFaseCicloBusinessCentral> bindingList = new BindingList<ExpFaseCicloBusinessCentral>(_fasiExport);
            _sourceFasi = new BindingSource(bindingList, null);
            dgvEsportaCicli.DataSource = _sourceFasi;
            dgvEsportaCicli.Update();
        }

        private void PopolaGrigliaComponenti()
        {
            if (_componentiExport.Count == 0)
            {
                dgvEsportaDistinte.DataSource = null;
                return;
            }
            dgvEsportaDistinte.AutoGenerateColumns = false;

            BindingList<ExpComponenteDistintaBusinessCentral> bindingList = new BindingList<ExpComponenteDistintaBusinessCentral>(_componentiExport);
            _sourceComponenti = new BindingSource(bindingList, null);
            dgvEsportaDistinte.DataSource = _sourceComponenti;
            dgvEsportaDistinte.Update();
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

        private void btnSelezionaTuttoFasi_Click(object sender, EventArgs e)
        {
            bool valore = false;
            if ((sender as Button).Name == btnSelezionaTuttoFasi.Name)
                valore = true;

            _fasiExport.ForEach(x => x.Selezionato = valore);
            dgvEsportaCicli.Refresh();

        }

        private void btnSelezionaTuttoComponenti_Click(object sender, EventArgs e)
        {
            bool valore = false;
            if ((sender as Button).Name == btnSelezionaTuttoComponenti.Name)
                valore = true;

            _componentiExport.ForEach(x => x.Selezionato = valore);
            dgvEsportaDistinte.Refresh();
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
    }

    public class WorkerDTO
    {
        public List<ExpComponenteDistintaBusinessCentral> ComponentiExport { get; set; }
        public List<ExpFaseCicloBusinessCentral> FasiExport { get; set; }

    }
}
