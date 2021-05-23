using MPIntranet.Business;
using MPIntranet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisegnaDiBa
{
    public partial class MainForm : MPIBaseForm
    {
        public List<FaseDistinta> FasiDistintaDaCopiare;
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.MdiChildren.Count() > 0)
                {
                    foreach (Form f in MdiChildren)
                        f.Close();
                }

            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in chiusura applicazione");
            }
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void organizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void nuovaDistintaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                DistintaBaseFrm form = new DistintaBaseFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in apertura finestra distinta base");
            }
        }

        private void apriEsistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                DistintaBaseFrm form = new DistintaBaseFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                base.MostraEccezione(ex, "Errore in apertura finestra distinta base");
            }
        }
    }
}
