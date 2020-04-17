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
    public partial class ChildBaseForm : Form
    {
        protected string _utenteConnesso { get { return (MdiParent as MPIBaseForm).Contesto.Utente.DisplayName; } }
        protected bool _disabilitaEdit = false;
        protected void MostraEccezione(string messagioLog, Exception ex)
        {
            MPIBaseForm form = (MdiParent as MPIBaseForm);
            form.MostraEccezione(messagioLog, ex);
        }

        public ChildBaseForm()
        {
            InitializeComponent();
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

    }
}
