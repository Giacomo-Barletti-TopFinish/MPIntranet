
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
using MPIntranet.Common;

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

            anagraficaToolStripMenuItem.Enabled = _contesto.Utente.AbilitaAnagrafica;
            distintaBaseToolStripMenuItem.Enabled = _contesto.Utente.AbilitaDistintaBase;
            costiToolStripMenuItem.Enabled = _contesto.Utente.AbilitaCosti;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close();
        }

        protected override void MPIBaseForm_Load(object sender, EventArgs e)
        {
            base.MPIBaseForm_Load(sender, e);
            AbilitaMenu();
        }
    }
}
