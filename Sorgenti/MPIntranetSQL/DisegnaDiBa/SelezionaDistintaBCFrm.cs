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
    public partial class SelezionaDistintaBCFrm : Form
    {
        private Articolo _articolo;
        public DistintaBC DistintaSelezionata;
        private List<DistintaBC> distinte;
        public SelezionaDistintaBCFrm(Articolo articolo)
        {
            InitializeComponent();
            _articolo = articolo;
        }

        private void SelezionaDistintaFrm_Load(object sender, EventArgs e)
        {
            if(_articolo==null)
                this.Close();

            Text = string.Format("Cerca distinte BC per l'articolo {0}", _articolo.ToString());
            distinte = DistintaBC.EstraiListaDistinteBase(_articolo.Anagrafica);

            if (distinte.Count == 1)
            {
                DistintaSelezionata = distinte[0];
                DialogResult = DialogResult.OK;
            }

            BindingList<DistintaBC> bl = new BindingList<DistintaBC>(distinte);
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
