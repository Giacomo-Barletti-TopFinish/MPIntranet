using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class CostiFissiFrm : ChildBaseForm
    {
        public CostiFissiFrm()
        {
            InitializeComponent();
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TipologiaDocumentiFrm_Load(object sender, EventArgs e)
        {
            CaricaGrigliaCostiFissi();
            lblMessaggio.Text = string.Empty;
        }

        private void CaricaGrigliaCostiFissi()
        {
            Anagrafica a = new Anagrafica();
            List<CostoFissoModel> costoFisso = a.CreaListaCostoFissoModel();
            BindingSource source = new BindingSource();
            source.DataSource = costoFisso;

            dgvCostiFissi.DataSource = source;

            dgvCostiFissi.Columns[0].Visible = false;
            dgvCostiFissi.Columns[1].Width = 120;
            dgvCostiFissi.Columns[2].Width = 200;

            ((DataGridViewTextBoxColumn)dgvCostiFissi.Columns[1]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvCostiFissi.Columns[1]).MaxInputLength = 30;
        }
        private void dgvCostiFissi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;
                _disabilitaEdit = true;
                decimal idCostoFisso = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvCostiFissi.Rows[e.RowIndex].Cells[1].Value;
                string descrizione = (string)dgvCostiFissi.Rows[e.RowIndex].Cells[2].Value;
                decimal costo = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[3].Value;
                decimal ricarico = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[4].Value;

                if (string.IsNullOrEmpty(descrizione)) descrizione = string.Empty;
      
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaCostoFisso(idCostoFisso, codice, descrizione, costo, ricarico, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaCostiFissi));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando un costo fisso", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvCostiFissi_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaCostoFisso("** NUOVO", _utenteConnesso);
                CaricaGrigliaCostiFissi();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo un costo fisso", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvCostiFissi_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idCostoFisso = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaCostoFisso(idCostoFisso, _utenteConnesso);
                CaricaGrigliaCostiFissi();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un costo fisso", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvCostiFissi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvCostiFissi.CurrentCell.ColumnIndex == 3 || dgvCostiFissi.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }
    }
}
