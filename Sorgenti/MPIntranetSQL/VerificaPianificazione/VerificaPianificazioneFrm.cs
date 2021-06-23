using MPIntranet.Business;
using MPIntranet.DataAccess.OrdiniProduzione;
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

namespace VerificaPianificazione
{
    public partial class VerificaPianificazioneFrm : Form
    {
        private List<OrdineProduzione> _odp;
        private BindingSource sourceODP;
        private BindingSource sourceFasi;

        public VerificaPianificazioneFrm()
        {
            InitializeComponent();
        }

        private void btnVerifica_Click(object sender, EventArgs e)
        {
            _odp = OrdineProduzione.EstraiListaOrdineProduzione();

            _odp.ForEach(x => x.Verifica(dtDataDaVerificare.Value));

            _odp = _odp.OrderBy(x => x.Avanzamento).ToList();
            PopolaGrigliaODP();
            coloraGriglia();
        }

        private void PopolaGrigliaODP()
        {
            dgvODP.AutoGenerateColumns = false;

            BindingList<OrdineProduzione> bindingList = new BindingList<OrdineProduzione>(_odp);
            sourceODP = new BindingSource(bindingList, null);
            dgvODP.DataSource = sourceODP;
            dgvODP.Update();
        }

        private void coloraGriglia()
        {
            foreach (DataGridViewRow riga in dgvODP.Rows)
            {
                Avanzamento avanzamento = (Avanzamento)riga.Cells[clmAvanzamento.Name].Value;
                if (avanzamento == Avanzamento.InRitardo)
                    riga.DefaultCellStyle.ForeColor = Color.Red;
                if (avanzamento == Avanzamento.RitardoCiclo)
                    riga.DefaultCellStyle.ForeColor = Color.Orange;
                decimal quantita = (decimal)riga.Cells[clmQuantita.Name].Value;
                decimal quantitaFinita = (decimal)riga.Cells[clmQuantitaFinita.Name].Value;
                if (quantita == quantitaFinita)
                    riga.DefaultCellStyle.ForeColor = Color.Green;
            }
        }


        private void VerificaPianificazioneFrm_Load(object sender, EventArgs e)
        {
            dtDataDaVerificare.Value = DateTime.Today;
        }

        private void dgvFasi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string codiceOrdineProduzione = (string)dgvODP.Rows[e.RowIndex].Cells[clmOrdineProduzione.Name].Value;
            List<FaseOrdineProduzione> fasi = FaseOrdineProduzione.EstraiListaFaseOrdineProduzione(codiceOrdineProduzione);
            PopolaGrigliaFasi(fasi);


        }

        private void PopolaGrigliaFasi(List<FaseOrdineProduzione> fasi)
        {
            dgvFasi.AutoGenerateColumns = false;

            BindingList<FaseOrdineProduzione> bindingList = new BindingList<FaseOrdineProduzione>(fasi);
            sourceFasi = new BindingSource(bindingList, null);
            dgvFasi.DataSource = sourceFasi;
            dgvFasi.Update();
        }
    }
}
