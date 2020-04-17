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
    public partial class TipologiaArticoliFrm : ChildBaseForm
    {
        public TipologiaArticoliFrm()
        {
            InitializeComponent();
        }

        private void dgvTipologiaArticoli_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;
                _disabilitaEdit = true;
                decimal idTipoProdotto = (decimal)dgvTipologiaArticoli.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvTipologiaArticoli.Rows[e.RowIndex].Cells[1].Value;
                string descrizione = (string)dgvTipologiaArticoli.Rows[e.RowIndex].Cells[2].Value;

                if (string.IsNullOrEmpty(descrizione)) descrizione = string.Empty;

                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaTipoProdotto(idTipoProdotto, codice, descrizione, _utenteConnesso);
        //        CaricaGrigliaTipoProdotto();
                BeginInvoke(new MethodInvoker(CaricaGrigliaTipoProdotto));
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

        private void dgvTipologiaArticoli_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaTipoProdotto("** NUOVO", string.Empty, _utenteConnesso);
                CaricaGrigliaTipoProdotto();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo un tipo prodotto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvTipologiaArticoli_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idTipoProdotto = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaTipoProdotto(idTipoProdotto, _utenteConnesso);
                CaricaGrigliaTipoProdotto();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un tipo prodotto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void TipologiaArticoliFrm_Load(object sender, EventArgs e)
        {
            CaricaGrigliaTipoProdotto();
            lblMessaggio.Text = string.Empty;
        }
        private void CaricaGrigliaTipoProdotto()
        {
            Anagrafica a = new Anagrafica();
            List<TipoProdottoModel> tipoProdotto = a.CreaListaTipoProdottoModel();
            BindingSource source = new BindingSource();
            source.DataSource = tipoProdotto;

            //if (dgvTipologiaArticoli.DataSource != null)
            //{
            //    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvTipologiaArticoli.DataSource];
            //    currencyManager.SuspendBinding();
            //    dgvTipologiaArticoli.DataSource = source;
            //    currencyManager.ResumeBinding();
            //}
            //else
                dgvTipologiaArticoli.DataSource = source;

            dgvTipologiaArticoli.Columns[0].Visible = false;
            dgvTipologiaArticoli.Columns[1].Width = 150;
            dgvTipologiaArticoli.Columns[2].Width = 250;

            ((DataGridViewTextBoxColumn)dgvTipologiaArticoli.Columns[1]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvTipologiaArticoli.Columns[2]).MaxInputLength = 40;
        }
        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
