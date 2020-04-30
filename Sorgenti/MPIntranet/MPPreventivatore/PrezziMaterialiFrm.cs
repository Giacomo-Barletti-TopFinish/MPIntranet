using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Anagrafica;
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
    public partial class PrezziMaterialiFrm : ChildBaseForm
    {
        private BindingSource _source = new BindingSource();
        List<PrezzoMaterialeModel> _prezzi = new List<PrezzoMaterialeModel>();
        private MaterialeModel _materialeSelezionato
        {
            get
            {
                if (ddlMateriali.SelectedIndex == -1) return null;
                return (MaterialeModel)ddlMateriali.SelectedItem;
            }
        }
        public PrezziMaterialiFrm()
        {
            InitializeComponent();
        }

        private void PrezziMaterialiFrm_Load(object sender, EventArgs e)
        {
            Anagrafica a = new Anagrafica();
            ddlMateriali.Items.AddRange(a.CreaListaMaterialeModel().ToArray());
            caricaGrigliaPrezzi();
            dtDataValidita.MinDate = DateTime.Today;
            dtDataValidita.Value = DateTime.Today;
            lblMessaggio.Text = string.Empty;
        }


        private void caricaGrigliaPrezzi()
        {
            //            dgvMateriali.AutoGenerateColumns = false;
            if (ddlMateriali.SelectedIndex == -1) return;
            Anagrafica a = new Anagrafica();
            List<PrezzoMaterialeModel> prezzi = a.CreaListaPrezzoMaterialeModel();
            _prezzi = prezzi.Where(x => x.Materiale.IdMateriale == _materialeSelezionato.IdMateriale).ToList();

            _source.DataSource = _prezzi;
            dgvMateriali.DataSource = _source;

            dgvMateriali.Columns[0].Visible = false;
            dgvMateriali.Columns[4].Visible = false;

        }
        private void ddlMateriali_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMateriali.SelectedIndex == -1) return;

            Anagrafica a = new Anagrafica();
            List<PrezzoMaterialeModel> prezzi = a.CreaListaPrezzoMaterialeModel();
            _prezzi = prezzi.Where(x => x.Materiale.IdMateriale == _materialeSelezionato.IdMateriale).ToList();
            caricaGrigliaPrezzi();

        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (ddlMateriali.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare il materiale per cui si inserisce il prezzo.", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblMessaggio.Text = string.Empty;
                return;
            }
            Anagrafica a = new Anagrafica();
            lblMessaggio.Text = a.CreaPrezzoMateriale(nuPrezzo.Value, txtNota.Text, _materialeSelezionato.IdMateriale, dtDataValidita.Value, _utenteConnesso);

            List<PrezzoMaterialeModel> prezzi = a.CreaListaPrezzoMaterialeModel();
            _prezzi = prezzi.Where(x => x.Materiale.IdMateriale == _materialeSelezionato.IdMateriale).ToList();
            caricaGrigliaPrezzi();
        }

        private void dgvMateriali_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idPrezzoMateriale = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaPrezzoMateriale(idPrezzoMateriale, _utenteConnesso);
                caricaGrigliaPrezzi();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un prezzo materiale", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvMateriali_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;
                _disabilitaEdit = true;
                decimal idPrezzoMateriale = (decimal)dgvMateriali.Rows[e.RowIndex].Cells[0].Value;
                DateTime data = (DateTime)dgvMateriali.Rows[e.RowIndex].Cells[1].Value;
                decimal prezzo = (decimal)dgvMateriali.Rows[e.RowIndex].Cells[2].Value;
                string nota = (string)dgvMateriali.Rows[e.RowIndex].Cells[3].Value;

                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaPrezzoMateriale(idPrezzoMateriale, nota, prezzo, data, _utenteConnesso);
                BeginInvoke(new MethodInvoker(caricaGrigliaPrezzi));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando un prezzo prodotto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }
    }
}
