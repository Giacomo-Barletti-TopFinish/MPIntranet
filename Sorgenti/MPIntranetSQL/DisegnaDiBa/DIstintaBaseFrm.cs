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
    public partial class DistintaBaseFrm : MPIChildForm
    {
        private Articolo _articolo;
        private DistintaBase _distinta;
        public DistintaBaseFrm()
        {
            InitializeComponent();

        }

        private void DistintaBaseFrm_Load(object sender, EventArgs e)
        {
            NuovoArticoloFrm nForm = new NuovoArticoloFrm();
            nForm.ShowDialog();
            int _idArticolo = nForm.IDArticolo;
            if (_idArticolo == ElementiVuoti.Articolo)
                return;

            _articolo = Articolo.EstraiArticolo(_idArticolo);
            // TBD CREARE ALBERO DA DATABASE

            if (_articolo != null)
            {
                txtArticolo.Text = _articolo.ToString();
            }
        }

        private void btnNuovaDistinta_Click(object sender, EventArgs e)
        {
            if (_articolo == null)
            {
                MessageBox.Show("Nessun articolo selezioanto", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            NuovaDistintaFrm form = new NuovaDistintaFrm(_articolo, _utenteConnesso);
            form.ShowDialog();
            int idDIba = form.IDDIBA_OUT;
            if (idDIba == ElementiVuoti.DistintaBase)
            {
                MessageBox.Show("Errore in fase di creazione della distinta", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _distinta = DistintaBase.EstraiDistintaBase(idDIba);
            if (_distinta == null)
            {
                MessageBox.Show("Errore distinta base nulla", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            popolaCampi();
        }

        private void popolaCampi()
        {
            txtDescrizioneDiba.Text = _distinta.Descrizione;
            txtVersioneDiba.Text = _distinta.Versione.ToString();
            txtTipoDiba.Text = _distinta.TipoDistinta.TipoDiba;
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            SelezionaDistintaFrm form = new SelezionaDistintaFrm(_articolo);
            form.ShowDialog();
            _distinta = form.DistintaSelezionata;
            popolaCampi();
        }
    }
}
