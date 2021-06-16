using MPIntranet.Business;
using MPIntranet.Common;
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
    public partial class EsportaDiBaFrm : Form
    {
        private List<ExpDistintaBusinessCentral> _distinteExport = new List<ExpDistintaBusinessCentral>();
        private List<ExpCicloBusinessCentral> _cicliExport = new List<ExpCicloBusinessCentral>();

        public EsportaDiBaFrm(List<ExpDistintaBusinessCentral> distinteExport, List<ExpCicloBusinessCentral> cicliExport)
        {
            InitializeComponent();
            _distinteExport = distinteExport;
            _cicliExport = cicliExport;
        }

        private void EsportaDiBaFrm_Load(object sender, EventArgs e)
        {
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
    }
}
