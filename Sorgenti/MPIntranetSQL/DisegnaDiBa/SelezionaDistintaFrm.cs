using MPIntranet.Business;
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
    public partial class SelezionaDistintaFrm : Form
    {
        private Articolo _articolo;
        public DistintaBase DistintaSelezionata;
        private List<DistintaBase> distinte;
        public SelezionaDistintaFrm(Articolo articolo)
        {
            InitializeComponent();
            _articolo = articolo;
        }

        private void SelezionaDistintaFrm_Load(object sender, EventArgs e)
        {
            Text = string.Format("Cerca distinte base per l'articolo {0}", _articolo.ToString());
            distinte = DistintaBase.EstraiListaDistinteBase(_articolo.IdArticolo);

            if (distinte.Count == 1)
            {
                DistintaSelezionata = distinte[0];
                DialogResult = DialogResult.OK;
            }

            BindingList<DistintaBase> bl = new BindingList<DistintaBase>(distinte);
            BindingSource bs = new BindingSource(bl, null);
            dgvDistinte.DataSource = bs;
            dgvDistinte.Update();
        }

        private void dgvDistinte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DistintaSelezionata = distinte[e.RowIndex];
            DialogResult = DialogResult.OK;
        }
    }
}
