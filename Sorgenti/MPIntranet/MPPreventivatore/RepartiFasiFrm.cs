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
    public partial class RepartiFasiFrm : ChildBaseForm
    {

        //  private string _utenteConnesso { get { return (MdiParent as MainForm).Contesto.Utente.DisplayName; } }
        public RepartiFasiFrm()
        {
            InitializeComponent();
        }

        private void RepartiFasiFrm_Load(object sender, EventArgs e)
        {
            CaricaGrigliaReparti();
            lblMessaggio.Text = string.Empty;
        }

        private void CaricaGrigliaReparti()
        {
            Anagrafica a = new Anagrafica();
            List<RepartoModel> reparti = a.CreaListaRepartoModel();
            BindingSource source = new BindingSource();
            source.DataSource = reparti;
            dgvReparti.DataSource = source;
            dgvReparti.Columns[0].Visible = false;
            dgvReparti.Columns[2].HeaderText = "Descrizione breve";
            dgvReparti.Columns[2].Width = 150;
            dgvReparti.Columns[3].Width = 250;

            ((DataGridViewTextBoxColumn)dgvReparti.Columns[1]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvReparti.Columns[2]).MaxInputLength = 15;
            ((DataGridViewTextBoxColumn)dgvReparti.Columns[3]).MaxInputLength = 30;
        }

        private void CaricaGrigliaFasi(decimal idReparto)
        {
            Anagrafica a = new Anagrafica();
            List<FaseModel> fasi = a.CreaListaFaseModel(idReparto);
            BindingSource source = new BindingSource();
            source.DataSource = fasi;
            dgvFasi.DataSource = source;
            dgvFasi.Columns[0].Visible = false;
            dgvFasi.Columns[2].Width = 150;
            dgvFasi.Columns[3].Visible = false;
            dgvFasi.Columns[6].HeaderText = "Includi preventivo";
            dgvFasi.Columns[7].Visible = false;
            dgvFasi.Columns[8].Visible = false;

        }

        private void dgvReparti_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idReparto = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaReparto(idReparto, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaReparti));
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un reparto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvReparti_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaReparto("** NUOVO", string.Empty, string.Empty, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaReparti));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo un reparto", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvReparti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;

                decimal idReparto = (decimal)dgvReparti.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvReparti.Rows[e.RowIndex].Cells[1].Value;
                string descrizioneBreve = (string)dgvReparti.Rows[e.RowIndex].Cells[2].Value;
                string descrizione = (string)dgvReparti.Rows[e.RowIndex].Cells[3].Value;

                if (string.IsNullOrEmpty(descrizione)) descrizione = string.Empty;
                if (string.IsNullOrEmpty(descrizioneBreve)) descrizioneBreve = string.Empty;

                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaReparto(idReparto, codice, descrizioneBreve, descrizione, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaReparti));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando un reparto", ex);
            }

        }

        private void dgvFasi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
             
                if (_disabilitaEdit) return;
                lblMessaggio.Text = string.Empty;

                decimal idFase = (decimal)dgvFasi.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvFasi.Rows[e.RowIndex].Cells[1].Value;
                string descrizione = (string)dgvFasi.Rows[e.RowIndex].Cells[2].Value;
                decimal idReparto = ((RepartoModel)dgvFasi.Rows[e.RowIndex].Cells[3].Value).IdReparto;
                decimal margine = (decimal)dgvFasi.Rows[e.RowIndex].Cells[4].Value;
                decimal costo = (decimal)dgvFasi.Rows[e.RowIndex].Cells[5].Value;
                bool includiPreventivo = (bool)dgvFasi.Rows[e.RowIndex].Cells[6].Value;
                decimal idEsterna = (decimal)dgvFasi.Rows[e.RowIndex].Cells[7].Value;
                string tabellaEsterna = (string)dgvFasi.Rows[e.RowIndex].Cells[8].Value;

                if (string.IsNullOrEmpty(descrizione))
                {
                    lblMessaggio.Text = "La descrizone non può essere vuota";
                    return;
                }

                if (string.IsNullOrEmpty(codice))
                {
                    lblMessaggio.Text = "Il codice non può essere vuoto";
                    return;
                }

                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.ModificaFase(idFase, codice, descrizione, idReparto, margine, costo, includiPreventivo, idEsterna, tabellaEsterna, _utenteConnesso);
                // CaricaGrigliaFasi(idReparto);
                BeginInvoke(new MethodInvoker(() => CaricaGrigliaFasi(idReparto)));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando una fase", ex);
            }

        }

        private decimal EstraiIdRepartoDaGriglia()
        {
            if (dgvReparti.SelectedRows.Count == 0 && dgvReparti.SelectedCells.Count == 0)
                return -1;

            decimal idReparto = -1;
            if (dgvReparti.SelectedRows.Count > 0)
                idReparto = (decimal)dgvReparti.SelectedRows[0].Cells[0].Value;
            if (dgvReparti.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReparti.SelectedCells[0].RowIndex;
                idReparto = (decimal)dgvReparti.Rows[rowIndex].Cells[0].Value;
            }
            return idReparto;
        }

        private void dgvFasi_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            lblMessaggio.Text = string.Empty;
            try
            {
                decimal idReparto = EstraiIdRepartoDaGriglia();
                if (idReparto == -1)
                {
                    lblMessaggio.Text = "Nessun reparto selezionato";
                    return;
                }

                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaFase("** NUOVA", "FASE", idReparto, 0, 0, true, -1, string.Empty, _utenteConnesso);
                CaricaGrigliaFasi(idReparto);
                //    BeginInvoke(new MethodInvoker(() => CaricaGrigliaFasi(idReparto)));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo una fase", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvFasi_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idFase = (decimal)e.Row.Cells[0].Value;
                decimal idReparto = ((RepartoModel)e.Row.Cells[3].Value).IdReparto;

                Anagrafica a = new Anagrafica();
                a.CancellaFase(idFase, _utenteConnesso);
                BeginInvoke(new MethodInvoker(() => CaricaGrigliaFasi(idReparto)));
                //      CaricaGrigliaFasi(idReparto);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando una fase", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvReparti_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReparti.Rows[e.RowIndex].Cells[0].Value == null)
            {
                dgvFasi.DataSource = null;
                return;
            }
            decimal idReparto = (decimal)dgvReparti.Rows[e.RowIndex].Cells[0].Value;

            CaricaGrigliaFasi(idReparto);

        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvFasi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvFasi.CurrentCell.ColumnIndex == 4 || dgvFasi.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
    }
}
