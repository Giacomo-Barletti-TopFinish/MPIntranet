using MPIntranet.WS;
using NAV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWebServicesFrm
{
    public partial class Form1 : Form
    {
        public Form1()
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
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                TestataDIBA testata = bc.EstraiTestataDIBA(txtDistintaNo.Text);
                txtMessaggio.Text = testata.Description;
                txtDistintaDescrizione.Text = testata.Description;

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
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                List<RigheDIBA> righe = bc.EstraiRigheDIBA(txtDistintaNo.Text);
                txtMessaggio.Text = string.Format("Trovate {0} righe", righe.Count);
                List<RigheDIBA> componente = bc.EstraiComponenti(txtNRComponente.Text);
                txtMessaggio.Text = string.Format("Il componente è ", componente);

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
    }
}
