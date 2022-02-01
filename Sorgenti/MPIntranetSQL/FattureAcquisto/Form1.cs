using MPIntranet.Business;
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

namespace FattureAcquisto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caricaElencoFornitori();
        }

        private BindingSource sourceFatture;
        List<FatturaAcquisto> _fatture = new List<FatturaAcquisto>();

        private void caricaElencoFornitori()
        {
            List<FornitoriFattureAcquisto> fornitori = FornitoriFattureAcquisto.EstraiListaFornitoriFattureAcquisto();
            ddlFornitori.Items.AddRange(fornitori.ToArray());
        }

        private void btnTrova_Click(object sender, EventArgs e)
        {
            if (ddlFornitori.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare un fornitore", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FornitoriFattureAcquisto fornitore = (FornitoriFattureAcquisto)ddlFornitori.SelectedItem;
            PopolaGriglia(fornitore);
        }

        private void PopolaGriglia(FornitoriFattureAcquisto fornitore)
        {
            _fatture = FatturaAcquisto.EstraiListaFattureAcquisto(fornitore.Codice);
            if (_fatture.Count == 0)
            {
                dgrRisultati.DataSource = null;
                dgrRisultati.Update();
                return;
            }
            dgrRisultati.AutoGenerateColumns = false;
            BindingList<FatturaAcquisto> bindingList = new BindingList<FatturaAcquisto>(_fatture);
            sourceFatture = new BindingSource(bindingList, null);
            dgrRisultati.DataSource = sourceFatture;
            dgrRisultati.Update();
        }

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrRisultati.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selezionare una fattura", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idDocumento = (int)dgrRisultati.SelectedRows[0].Cells[IDDocumentoClm.Index].Value;
                int tipoDocumento = (int)dgrRisultati.SelectedRows[0].Cells[TipoDocumentoClm.Index].Value;

                List<FatturaAcquistoDettaglio> dettagli = FatturaAcquistoDettaglio.EstraiListaFatturaAcquistoDettaglio(idDocumento, tipoDocumento);
                if (dettagli.Count == 0)
                {
                    MessageBox.Show("Nessun dettaglio trovato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "INDICARE IL FILE PER SALVARE LA FATTURA";

                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.DefaultExt = "csv";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == DialogResult.Cancel) return;

                string fileName = sfd.FileName;

                FileStream sf = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(sf);
                foreach (FatturaAcquistoDettaglio dettaglio in dettagli)
                    sw.WriteLine(dettaglio.EstraiRiga());
                sw.Flush();
                sf.Flush();
                sf.Close();
                MessageBox.Show("Operazione conclusa con successo", "INFORMAZIONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
