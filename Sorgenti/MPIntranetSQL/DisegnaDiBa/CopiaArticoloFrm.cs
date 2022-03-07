using MPIntranet.WS;
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
    public partial class CopiaArticoloFrm : Form
    {
        public CopiaArticoloFrm()
        {
            InitializeComponent();
        }

        private void btnCopiaAnag_Click(object sender, EventArgs e)
        {
            txtMessaggio.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtAnagOrig.Text))
                {
                    txtMessaggio.Text = "Inserire un codice anagrafica di origine";
                    return;
                }
                if (string.IsNullOrEmpty(txtAnagDest.Text))
                {
                    txtMessaggio.Text = "Inserire un codice anagrafica di destinazione";
                    return;
                }
                BCServices bc = new BCServices();
                bc.CreaConnessione();
                string t = txtAnagOrig.Text;
                string tt = txtAnagDest.Text;
                bc.CopiaArticolo(ref t, ref tt);
                txtMessaggio.Text = "Anagrafica Copiata Correttamente";

            }

            catch (Exception ex)
            {
                StringBuilder str = new StringBuilder("ECCEZIONE - operazione non riuscita");
                str.AppendLine(ex.Message);
                txtMessaggio.Text = str.ToString();
            }
        }
    }
}
