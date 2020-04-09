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
    public partial class TipologiaDocumentiFrm : ChildBaseForm
    {
        public TipologiaDocumentiFrm()
        {
            InitializeComponent();
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TipologiaDocumentiFrm_Load(object sender, EventArgs e)
        {
            CaricaGrigliaTipoDocumento();
            lblMessaggio.Text = string.Empty;
        }

        private void CaricaGrigliaTipoDocumento()
        {
            Anagrafica a = new Anagrafica();
            List<TipoDocumentoModel> tipoDocumento = a.CreaListaTipoDocumentoModel();
            BindingSource source = new BindingSource();
            source.DataSource = tipoDocumento;

            dgvTipologiaDocumenti.DataSource = source;

            dgvTipologiaDocumenti.Columns[0].Visible = false;
            dgvTipologiaDocumenti.Columns[1].Width = 350;
            dgvTipologiaDocumenti.Columns[2].Visible = false;
            dgvTipologiaDocumenti.Columns[3].Visible = false;

            ((DataGridViewTextBoxColumn)dgvTipologiaDocumenti.Columns[1]).MaxInputLength = 25;
        }
        private void dgvTipologiaDocumenti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;
                _disabilitaEdit = true;
                decimal idTipoDocumento = (decimal)dgvTipologiaDocumenti.Rows[e.RowIndex].Cells[0].Value;
                string descrizione = (string)dgvTipologiaDocumenti.Rows[e.RowIndex].Cells[1].Value;

                if (string.IsNullOrEmpty(descrizione)) descrizione = string.Empty;

                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaTipoDocumento(idTipoDocumento,  descrizione, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaTipoDocumento));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando un tipo prodotto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvTipologiaDocumenti_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaTipoDocumento("** NUOVO",  _utenteConnesso);
                CaricaGrigliaTipoDocumento();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo un tipo documento", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvTipologiaDocumenti_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idTipoDocumento = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaTipoDocumento(idTipoDocumento, _utenteConnesso);
                CaricaGrigliaTipoDocumento();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un tipo documento", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }
    }
}
