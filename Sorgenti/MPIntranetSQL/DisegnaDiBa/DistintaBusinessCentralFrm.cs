using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
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
    public partial class DistintaBusinessCentralFrm : MPIChildForm
    {
        private Articolo _articolo;
        private DistintaBC _distinta;
        private int indiceNodi = 0;
        private BindingSource source;

        protected List<FaseDistinta> FasiDistintaDaCopiare
        {
            get { return (MdiParent as MainForm).FasiDistintaDaCopiare; }
            set { (MdiParent as MainForm).FasiDistintaDaCopiare = value; }
        }
        private int estraiIndice()
        {
            indiceNodi--;
            return indiceNodi;
        }

        public DistintaBusinessCentralFrm()
        {
            InitializeComponent();
        }

        private void DistintaBusinessCentralFrm_Load(object sender, EventArgs e)
        {
            NuovoArticoloFrm nForm = new NuovoArticoloFrm();
            nForm.ShowDialog();
            int _idArticolo = nForm.IDArticolo;
            if (_idArticolo == ElementiVuoti.Articolo)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _articolo = Articolo.EstraiArticolo(_idArticolo);

                if (_articolo != null)
                {
                    txtArticolo.Text = _articolo.ToString();
                }

            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            if (_articolo == null) return;

            SelezionaDistintaBCFrm form = new SelezionaDistintaBCFrm(_articolo);
            form.ShowDialog();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _distinta = form.DistintaSelezionata;

                //popolaCampi();
                //creaAlbero();
                //PopolaGrigliaFasi();
            }
            catch { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
