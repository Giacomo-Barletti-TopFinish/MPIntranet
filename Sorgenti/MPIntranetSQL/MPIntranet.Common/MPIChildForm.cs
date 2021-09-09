using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPIntranet.Common
{
    public partial class MPIChildForm : Form
    {
        protected bool daSalvare = false;
        public MPIChildForm()
        {
            InitializeComponent();
        }

        public void ResetAutoScrollPosition()
        {
            this.AutoScrollPosition = new Point(0, 0);
        }
        protected string _utenteConnesso { get { return (MdiParent as MPIBaseForm).Contesto.Utente.DisplayName; } }
        protected ContestoBase Contesto { get { return (MdiParent as MPIBaseForm).Contesto; } }

        protected bool _disabilitaEdit = false;
        protected void MostraEccezione(Exception ex, string messagioLog)
        {
            MPIBaseForm form = (MdiParent as MPIBaseForm);
            form.MostraEccezione(ex, messagioLog);
        }


        protected void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void MPIChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (daSalvare)
            {
                if (MessageBox.Show("CI sono dati da salvare, sei sicuro di vole chiudere senza salvare ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
