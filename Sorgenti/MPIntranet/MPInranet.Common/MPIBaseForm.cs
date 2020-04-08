using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPIntranet.Security;

namespace MPIntranet.Common
{
    public partial class MPIBaseForm : Form
    {
        public MPContext Contesto = new MPContext();
        public MPIBaseForm()
        {
            InitializeComponent();
        }

        private void MPIBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MdiChildren.Count() > 0)
            {
                foreach (Form f in MdiChildren)
                    f.Close();
            }
        }

        protected virtual void MPIBaseForm_Load(object sender, EventArgs e)
        {
            Contesto = MPContext.CreaContesto();
            stUser.Text = Contesto.Utente.DisplayName;            
        }

        protected void DisabilitaElementiMenu(ToolStripItemCollection elementi, bool abilita)
        {
            foreach (ToolStripItem elemento in elementi)
            {
                if (elemento is ToolStripMenuItem)
                {
                    (elemento as ToolStripMenuItem).Enabled = abilita;
                    if ((elemento as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        DisabilitaElementiMenu((elemento as ToolStripMenuItem).DropDownItems, abilita);
                    }
                }

            }
        }

        public void MostraEccezione(string messaggioLog, Exception ex)
        {
            LogMessaggi.ScriviErrore(ex.Message, ex.StackTrace, string.Empty);
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();

        }
    }
}
