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

namespace TestPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreaPdfTest_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilename.Text))
            {
                MessageBox.Show("Indicare il nome del file", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (File.Exists(txtFilename.Text))
                File.Delete(txtFilename.Text);

            PDFHelper pdfHelper = new PDFHelper();
            pdfHelper.CreaScheda("RagioneSociale", "5", DateTime.Today.ToShortDateString(),
             "prefisso", "parte", "colore", "quantita",
             "descrizione", "commessa", false, false, false,
             false, false, true, "altro", "certificati", null);

            pdfHelper.SalvaPdf(txtFilename.Text);
        }

        private void btnSalvaFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "INDICARE IL FILE PER SALVARE IL PDF"; ;

            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.DefaultExt = "pdf";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            txtFilename.Text = sfd.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreaPdfScheda_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilename.Text))
            {
                MessageBox.Show("Indicare il nome del file", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
