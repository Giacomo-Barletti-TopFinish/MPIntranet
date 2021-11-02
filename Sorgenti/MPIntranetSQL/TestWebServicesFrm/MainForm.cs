using MPIntranet.Business;
using MPIntranet.WS;
using NAV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWebServicesFrm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnApriDistinta_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                TestataDIBA testata = bc.EstraiTestataDIBA(txtDistintaNo.Text);
                txtDistintaDescrizione.Text = testata.Description;
                txtCodiceVersioneDistinta.Text = testata.Version_Nos;
                txtMessaggio.Text = string.Format("{0} {1} {2}", testata.No, testata.Version_Nos, testata.Description);
                txtStatoDistinta.Text = testata.Status;

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiRigheDiba_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                StringBuilder sb = new StringBuilder();
                List<RigheDIBA> righe = bc.EstraiRigheDIBA(txtDistintaNo.Text);
                sb.AppendLine(string.Format("Trovate {0} righe", righe.Count));
                foreach (RigheDIBA r in righe)
                {
                    sb.AppendLine(string.Format("{0} {1} {2} {3}", r.Line_No, r.No, r.Quantity_per, r.Description));
                }
                txtMessaggio.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private string estraiErrore(Exception ex)
        {
            string errore = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                errore = Environment.NewLine + ex.Message;
            }
            return errore;
        }
        public string estraiComponenti(Exception cm)
        {
            string componente = cm.Message;
            while (cm.InnerException != null)
            {
                cm = cm.InnerException;
                componente = Environment.NewLine + cm.Message;
            }
            return componente;
        }

        private void btnDistintaInSviluppo_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoDB(txtDistintaNo.Text, MPIntranet.WS.Stato.InSviluppo);
                txtMessaggio.Text = "Stato cambiato: In sviluppo";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnDistintaCertificata_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoDB(txtDistintaNo.Text, MPIntranet.WS.Stato.Certificato);
                txtMessaggio.Text = "Stato cambiato: Certificato";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnCambiaDescrizioneDistinta_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaDescrizioneDB(txtDistintaNo.Text, txtDistintaDescrizione.Text);
                txtMessaggio.Text = "Descrizione cambiata";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnAggiungiComponente_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.InSviluppo);
                bc.AggiungiComponente(txtDistintaNo.Text, txtCodiceVersioneDistinta.Text, (int)nNRRigaComponente.Value, txtTipoCoponente.Text, txtNRComponente.Text, txtDescrizioneComponente.Text,
                    txtUnitàMisuraComponente.Text, nQuantitaPerCompoente.Value, txtCodiceCollegamentoCicliDiBa.Text, nScartoComponente.Value, nArrotondamentoComponente.Value);
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.Certificato);
                txtMessaggio.Text = "Componente aggiunto";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnRimuoviComponente_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.InSviluppo);
                bc.RimuoviComponente(txtDistintaNo.Text, txtCodiceVersioneDistinta.Text, (int)nNRRigaComponente.Value, txtNRComponente.Text, true);
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.Certificato);
                txtMessaggio.Text = "Componente rimosso";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnModificaComponente_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.InSviluppo);
                bc.ModificaComponente(txtDistintaNo.Text, txtCodiceVersioneDistinta.Text, (int)nNRRigaComponente.Value, txtNRComponente.Text, txtDescrizioneComponente.Text,
                    nQuantitaPerCompoente.Value, txtCodiceCollegamentoCicliDiBa.Text, nScartoComponente.Value, nArrotondamentoComponente.Value);
                bc.CambiaStatoDB(txtDistintaNo.Text, Stato.Certificato);
                txtMessaggio.Text = "Componente modificato";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiCiclo_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDistintaNo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                Cicli testata = bc.EstraiTestataCiclo(txtNoCiclo.Text);
                txtDescrizioneCiclo.Text = testata.Description;
                txtVersioneCiclo.Text = testata.Version_Nos;
                txtMessaggio.Text = string.Format("{0} {1} {2}", testata.No, testata.Version_Nos, testata.Description);
                txtStatoCiclo.Text = testata.Status;

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiFasi_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice distinta";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                StringBuilder sb = new StringBuilder();
                List<RigheCICLO> righe = bc.EstraiRigheCICLO(txtNoCiclo.Text);
                sb.AppendLine(string.Format("Trovate {0} righe", righe.Count));
                foreach (RigheCICLO r in righe)
                {
                    sb.AppendLine(string.Format("{0} {1} {2} {3} {4}", r.Operation_No, r.Routing_No, r.No, r.Standard_Task_Code, r.Description));
                }
                txtMessaggio.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnCicloInSviluppo_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoCiclo(txtNoCiclo.Text, MPIntranet.WS.Stato.InSviluppo);
                txtMessaggio.Text = "Stato cambiato: In sviluppo";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnCicloCerficato_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoCiclo(txtNoCiclo.Text, MPIntranet.WS.Stato.Certificato);
                txtMessaggio.Text = "Stato cambiato: Certificato";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnCambiaDescrizioneCiclo_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaDescrizioneCiclo(txtNoCiclo.Text, txtDescrizioneCiclo.Text);
                txtMessaggio.Text = "Descrizione cambiata";

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            List<AreaProduzione> aree = MPIntranet.Business.AreaProduzione.EstraiListaAreeProduzione();
            ddlAreaProduzione.Items.AddRange(aree.ToArray());
            estraiAziende();
        }
        private void estraiAziende()
        {
            ddlAziende.Items.Clear();
            ddlAziende.Items.Add("METALPLUS");
            ddlAziende.Items.Add("METALPLUS 08092021");
            ddlAziende.Items.Add("METALPLUS_210621");
        }
        private void estraiTipoMovimento()
        {
            ddlTipoMovimento.Items.Clear();
            ddlTipoMovimento.Items.Add("Rettifica Positiva");
            ddlTipoMovimento.Items.Add("Rettifica Negativa");
        }
        private void estraiBinCode()
        {
            ddlCodCollRegMag.Items.Clear();
            ddlCodCollRegMag.Items.Add("A1");
        }

        private void ddlAreaProduzione_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTask.Items.Clear();
            AreaProduzione a = (AreaProduzione)ddlAreaProduzione.SelectedItem;
            List<TaskArea> tasks = TaskArea.EstraiListaTaskArea(true);
            tasks = tasks.Where(x => x.AreaProduzione == a.Codice).ToList();
            ddlTask.Items.AddRange(tasks.ToArray());
        }

        private void btnAggiuntiFase_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                if (ddlAreaProduzione.SelectedIndex == -1)
                {
                    txtMessaggio.Text = "Selezionare un area produzione";
                    return;
                }
                if (ddlTask.SelectedIndex == -1)
                {
                    txtMessaggio.Text = "Selezionare un task";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.InSviluppo);
                int operazione = (int)nOperazioneFase.Value;

                AreaProduzione area = (AreaProduzione)ddlAreaProduzione.SelectedItem;
                TaskArea task = (TaskArea)ddlTask.SelectedItem;

                bc.AggiungiFase(txtNoCiclo.Text, txtVersioneCiclo.Text, operazione.ToString(), txtTipoFase.Text, area.Codice, task.Task, nSetupFase.Value, txtUMSetupFase.Text,
                    nLavorazioneFase.Value, txtUMLavorazioneFase.Text, nAttesaFase.Value, txtUMAttesaFase.Text, nSpostamentoFase.Value, txtUMSpostamentoFase.Text,
                    nDimensioneLottoFase.Value, txtCollegmentoFase.Text,
                    txtCodiceCondizioneFase.Text, txtCodiceLogicheFase.Text, txtCodiceCaratteristicaFase.Text, string.Empty);

                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.Certificato);
                txtMessaggio.Text = "Fase aggiunta";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnRimuoviFase_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }

                int operazione = (int)nOperazioneFase.Value;

                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.InSviluppo);
                bc.RimuoviFase(txtNoCiclo.Text, txtVersioneCiclo.Text, operazione.ToString(), true);
                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.InSviluppo);
                txtMessaggio.Text = "Fase rimossa";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnModificaFase_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }
                if (ddlAreaProduzione.SelectedIndex == -1)
                {
                    txtMessaggio.Text = "Selezionare un area produzione";
                    return;
                }
                if (ddlTask.SelectedIndex == -1)
                {
                    txtMessaggio.Text = "Selezionare un task";
                    return;
                }
                int operazione = (int)nOperazioneFase.Value;
                AreaProduzione area = (AreaProduzione)ddlAreaProduzione.SelectedItem;
                TaskArea task = (TaskArea)ddlTask.SelectedItem;

                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.InSviluppo);
                bc.ModificaFase(txtNoCiclo.Text, txtVersioneCiclo.Text, operazione.ToString(), txtTipoFase.Text, area.Codice, task.Task,
                    nSetupFase.Value, txtUMSetupFase.Text,
                    nLavorazioneFase.Value, txtUMLavorazioneFase.Text, nAttesaFase.Value, txtUMAttesaFase.Text, nSpostamentoFase.Value, txtUMSpostamentoFase.Text,
                    nDimensioneLottoFase.Value, txtCollegmentoFase.Text,
                    txtCodiceCondizioneFase.Text, txtCodiceLogicheFase.Text, txtCodiceCaratteristicaFase.Text, string.Empty);
                bc.CambiaStatoCiclo(txtNoCiclo.Text, Stato.Certificato);
                txtMessaggio.Text = "Fase modificata";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnModificaCommentoFase_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice fase";
                    return;
                }

                int operazione = (int)nOperazioneFase.Value;


                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<CommentiFasi> commenti = bc.EstraiCommenti(txtNoCiclo.Text, txtVersioneCiclo.Text);
                StringBuilder sb = new StringBuilder();

                commenti.ForEach(x => sb.AppendLine(string.Format("{0} {1} {2} {3}", x.Routing_No, x.Operation_No, x.Line_No, x.Comment)));
                txtMessaggio.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiCommenti_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoCiclo.Text))
                {
                    txtMessaggio.Text = "Inserire un codice ciclo";
                    return;
                }

                int operazione = (int)nOperazioneFase.Value;


                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<CommentiFasi> commenti = bc.EstraiCommenti(txtNoCiclo.Text, txtVersioneCiclo.Text);
                StringBuilder sb = new StringBuilder();

                commenti.ForEach(x => sb.AppendLine(string.Format("{0} {1} {2} {3}", x.Routing_No, x.Operation_No, x.Line_No, x.Comment)));
                txtMessaggio.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiAnagrafica_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtAnagrafica.Text))
                {
                    txtMessaggio.Text = "Inserire il codice anagrafica";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                Articoli articolo = bc.EstraiArticolo(txtAnagrafica.Text);
                txtDescrizioneArticolo.Text = articolo.Description;
                txtMessaggio.Text = string.Format("{0} {1} {2}", articolo.No, articolo.Description, articolo.Description_2);

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnConfrontaAnagrafiche_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAnagrafica.Text) || string.IsNullOrEmpty(txtAnagraficaDestinazione.Text))
            {
                txtMessaggio.Text = "Inserire il codice anagrafica o il codice anagrafica destinazione";
                return;
            }
            BCServices bc = new BCServices();
            bc.CreaConnessione();
            Articoli articolo = bc.EstraiArticolo(txtAnagrafica.Text);
            Articoli articoloDestinazione = bc.EstraiArticolo(txtAnagraficaDestinazione.Text);
            if (articolo == null)
            {
                txtMessaggio.Text = "Articolo non trovato " + txtAnagrafica.Text;
                return;
            }
            if (articoloDestinazione == null)
            {
                txtMessaggio.Text = "Articolo non trovato " + txtAnagraficaDestinazione.Text;
                return;
            }
            Type type = articolo.GetType();
            PropertyInfo[] props = type.GetProperties();

            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo pi in props.OrderBy(X => X.Name))
            {
                object valore1 = pi.GetValue(articolo);
                object valore2 = pi.GetValue(articoloDestinazione);
                bool uguali = false;
                if (valore1.ToString() == valore2.ToString()) uguali = true;

                string messaggio = string.Format("{0}  {1}  {2} - {3}", uguali ? "SI" : "NO", pi.Name, valore1.ToString(), valore2.ToString());
                sb.AppendLine(messaggio);
            }
            txtMessaggio.Text = sb.ToString();
        }

        private void btnEstraiAllegato_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtAnagrafica.Text))
                {
                    txtMessaggio.Text = "Inserire il codice anagrafica";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<Allegati> allegati = bc.EstraiAllegati(txtAnagrafica.Text);

            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void btnCreaOdP_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            if(ddlAziende.SelectedIndex==-1)
            {
                txtMessaggio.Text = "Selezionare un'azienda";
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(txtAnagraficaOdP.Text))
                {
                    txtMessaggio.Text = "Inserire un codice Anagrafica";
                    return;
                }
                if (string.IsNullOrEmpty(txtLocationOdP.Text))
                {
                    txtMessaggio.Text = "Inserire una ubicazione";
                    return;
                }
                string azienda = (string)ddlAziende.SelectedItem;
                BCServices bc = new BCServices();
                bc.CreaConnessione(azienda);
                bc.CreaOdDPConfermato(txtAnagraficaOdP.Text, dtScadenzaOdP.Value, nQuntitàOdP.Value, txtLocationOdP.Text, txtDescrizioneOdP.Text, txtDescrizione2.Text);
                txtMessaggio.Text = "Ordine Crato Correttamente";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }
        private void txtRegMag(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtAnagRegMag.Text))
                {
                    txtMessaggio.Text = "Inserire un codice Anagrafica";
                    return;
                }
                if (string.IsNullOrEmpty(txtNrDocRegMag.Text))
                {
                    txtMessaggio.Text = "Inserire un numero documento";
                    return;
                }
                /*
                if (string.IsNullOrEmpty(txtUbiRegMag.Text))
                {
                    txtMessaggio.Text = "Inserire un ubicazione";
                    return;
                }

                if (string.IsNullOrEmpty(ddlCodCollRegMag.Text))
                    {
                    txtMessaggio.Text = "Selezionare una collocazione";
                    return;
                    }
                */
                BCServices bc = new BCServices();
                bc.CreaConnessione();
             //   bc.RegMag(txtAnagRegMag.Text, txtUbiRegMag.Text, ddlCodCollRegMag.Text);
                txtMessaggio.Text = "Rettifica registrata correttamente";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiOdP_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {

                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<ODPRilasciato> odps = bc.EstraiOdPRilasciati();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Trovati {0} odp rilasciati", odps.Count));
                sb.AppendLine(string.Empty);
                foreach (ODPRilasciato o in odps)
                {
                    sb.AppendLine(string.Format("{0} # {1}", o.No, o.Source_No));
                }
                txtMessaggio.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnCambiaDescrizioneOdP_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoOdP.Text))
                {
                    txtMessaggio.Text = "Indicare un ODP";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                bc.ModificaDescrizioneOdp(txtNoOdP.Text, txtDescrizioneOdP.Text, txtDescrizione2.Text);

                txtDescrizioneOdP.Text = String.Empty;
                txtDescrizione2.Text = String.Empty;
                txtMessaggio.Text = "Descrizione Cambiata Correttamente";
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

        private void btnEstraiSingoloOdp_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtNoOdP.Text))
                {
                    txtMessaggio.Text = "Indicare un ODP";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                ODPRilasciato odp = bc.EstraiOdPRilasciato(txtNoOdP.Text);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("{0} # {1} {2}", odp.No, odp.Source_No, odp.Description));
                txtMessaggio.Text = sb.ToString();
                txtDescrizioneOdP.Text = odp.Description;
                txtDescrizione2.Text = odp.Description_2;
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }

        }

        private void btnEstraiMag_Click(object sender, EventArgs e)
        {

            txtMessaggio.Text = string.Empty;
            try
            {

                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<RegMagazzino> maga = bc.EstraiMagazzino();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Trovate {0} righe di magazzino", maga.Count));
                sb.AppendLine(string.Empty);
                txtMessaggio.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtMessaggio.Text = estraiErrore(ex);
            }
        }

    }
}
