using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPIntranet.Models.Articolo;
using System.IO;

namespace MPPreventivatore
{
    public partial class ProdottoFinitoUC : UserControl
    {
        public ProdottoFinitoModel ProdottoFinitoModel;
        public byte[] Immagine;
        public ProdottoFinitoUC()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                c.Click += new EventHandler(txtCodice_Click);
            }
        }

        private void ProdottoFinitoUC_Load(object sender, EventArgs e)
        {
            if (ProdottoFinitoModel != null)
            {
                txtBrand.Text = ProdottoFinitoModel.Brand.ToString();
                txtCodice.Text = ProdottoFinitoModel.Codice;
                txtCodiceDefinitivo.Text = ProdottoFinitoModel.CodiceDefinitivo;
                txtCodiceProvvisorio.Text = ProdottoFinitoModel.CodiceProvvisorio;
                txtColore.Text = ProdottoFinitoModel.Colore.ToString();
                txtDescrizione.Text = ProdottoFinitoModel.Descrizione;
                txtModello.Text = ProdottoFinitoModel.Modello;
                txtTipoProdotto.Text = ProdottoFinitoModel.TipoProdotto.ToString();
            }

            if (Immagine != null && Immagine.Length > 0)
            {
                Bitmap image;
                using (MemoryStream stream = new MemoryStream(Immagine))
                {
                    image = new Bitmap(stream);
                }
                picImmagine.Image = image;
            }
        }

        private void txtCodice_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
