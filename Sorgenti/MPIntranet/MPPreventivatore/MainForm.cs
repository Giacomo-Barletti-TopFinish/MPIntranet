
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

namespace MPPreventivatore
{
    public partial class MainForm : MPIBaseForm
    {

        public MainForm() : base()
        {
            InitializeComponent();
        }



        private void AbilitaMenu()
        {
            DisabilitaElementiMenu(MPMenu.Items, true);
            exitToolStripMenuItem.Enabled = true;
            fileToolStripMenuItem.Enabled = true;

            anagraficaToolStripMenuItem.Enabled = Contesto.Utente.AbilitaAnagrafica;
            distintaBaseToolStripMenuItem.Enabled = Contesto.Utente.AbilitaDistintaBase;
            costiToolStripMenuItem.Enabled = Contesto.Utente.AbilitaCosti;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in fase di chiusura", ex);
            }
        }

        protected override void MPIBaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                base.MPIBaseForm_Load(sender, e);
                AbilitaMenu();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in fase di load", ex);
            }
        }

        private void repartiEFasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RepartiFasiFrm form = new RepartiFasiFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in reparti e fasi", ex);
            }
        }
    }
}
