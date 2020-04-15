using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Articolo;
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
    public partial class NuovoPreventivoFrm : Form
    {
        private ProdottoFinitoModel _prodottoFinito;
        private int _versioni;
        private string _account;
        public NuovoPreventivoFrm(ProdottoFinitoModel prodottoFinitoModel, int versioni, string account)
        {
            _prodottoFinito = prodottoFinitoModel;
            _versioni = versioni + 1;
            _account = account;
            InitializeComponent();
        }

        private void NuovoPreventivoFrm_Load(object sender, EventArgs e)
        {
            lblArticolo.Text = _prodottoFinito.ToString();
            lblMessaggio.Text = string.Empty;
            txtVersione.Text = _versioni.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescrizione.Text))
            {
                lblMessaggio.Text = "La descrizione è obbligaoria";
                return;
            }
            lblMessaggio.Text = string.Empty;
            Articolo articolo = new Articolo(string.Empty);
            lblMessaggio.Text = articolo.CreaPreventivo(_versioni, txtDescrizione.Text, _prodottoFinito.IdProdottoFinito, txtNota.Text, _account);
        }
    }
}
