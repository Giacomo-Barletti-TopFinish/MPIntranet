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

        private List<ExpComponenteDistintaBusinessCentral> _componentiExport = new List<ExpComponenteDistintaBusinessCentral>();
        private List<ExpFaseCicloBusinessCentral> _fasiExport = new List<ExpFaseCicloBusinessCentral>();

        private BindingSource sourceFasi;
        private BindingSource sourceComponenti;

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
            sourceFasi = new BindingSource(bindingList, null);
            dgvEsportaCicli.DataSource = sourceFasi;
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
            sourceComponenti = new BindingSource(bindingList, null);
            dgvEsportaDistinte.DataSource = sourceComponenti;
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
    }
}
