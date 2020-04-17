using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
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
    public partial class MateriePrimeFrm : ChildBaseForm
    {
        private List<MaterialeModel> _materiali;
        public MateriePrimeFrm()
        {
            InitializeComponent();
        }

        private void dgvMateriePrime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblMessaggio.Text = string.Empty;
                if (_disabilitaEdit) return;

                decimal idMateriaPrima = (decimal)dgvMateriePrime.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvMateriePrime.Rows[e.RowIndex].Cells[1].Value;
                string descrizione = (string)dgvMateriePrime.Rows[e.RowIndex].Cells[2].Value;
                string materiale = (string)dgvMateriePrime.Rows[e.RowIndex].Cells[3].Value;
                decimal margine = (decimal)dgvMateriePrime.Rows[e.RowIndex].Cells[4].Value;
                decimal costo = (decimal)dgvMateriePrime.Rows[e.RowIndex].Cells[5].Value;
                bool includiPreventivo = (bool)dgvMateriePrime.Rows[e.RowIndex].Cells[6].Value;

                decimal idMateriale = _materiali.Where(x => x.ToString() == materiale).FirstOrDefault().IdMateriale;

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
                lblMessaggio.Text = a.ModificaMateriaPrima(idMateriaPrima, codice, descrizione, idMateriale, margine, costo, includiPreventivo,  _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaMateriePrime));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando una fase", ex);
            }
        }

        private void dgvMateriePrime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvMateriePrime.CurrentCell.ColumnIndex == 4 || dgvMateriePrime.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }

        private void dgvMateriePrime_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                Anagrafica a = new Anagrafica();
                lblMessaggio.Text = a.CreaMateriaPrima("** NUOVA", "MATERIA PRIMA", ElementiVuoti.NessunMateriale, 0, 0, true, _utenteConnesso);
                CaricaGrigliaMateriePrime();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo una materia prima", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvMateriePrime_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idMateriaPrima = (decimal)e.Row.Cells[0].Value;

                Anagrafica a = new Anagrafica();
                a.CancellaMateriaPrima(idMateriaPrima, _utenteConnesso);
                CaricaGrigliaMateriePrime();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando una materia prima", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void MateriePrimeFrm_Load(object sender, EventArgs e)
        {
            CaricaMateriali();
            CaricaGrigliaMateriePrime();
            lblMessaggio.Text = string.Empty;
        }

        private void CaricaMateriali()
        {
            Anagrafica a = new Anagrafica();
            _materiali = a.CreaListaMaterialeModel();
        }
        private void CaricaGrigliaMateriePrime()
        {
            Anagrafica a = new Anagrafica();
            List<MateriaPrimaModel> materiePrime = a.CreaListaMateriaPrimaModel();

            BindingSource source = new BindingSource();
            source.DataSource = materiePrime;
            dgvMateriePrime.DataSource = source;
            dgvMateriePrime.Columns[0].Visible = false;
            dgvMateriePrime.Columns[2].Width = 200;

            ((DataGridViewTextBoxColumn)dgvMateriePrime.Columns[1]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvMateriePrime.Columns[2]).MaxInputLength = 30;

            List<string> materiali = _materiali.Select(x => x.ToString()).ToList();

            DataGridViewComboBoxColumn colMateriale = new DataGridViewComboBoxColumn();
            {
                colMateriale.DataPropertyName = "Materiale";
                colMateriale.HeaderText = "Materiale";
                colMateriale.DropDownWidth = 130;
                colMateriale.Width = 130;
                colMateriale.MaxDropDownItems = System.Math.Min(materiali.Count, 10);
                colMateriale.FlatStyle = FlatStyle.Flat;
                colMateriale.Items.AddRange(materiali.ToArray());
            }
            dgvMateriePrime.Columns.RemoveAt(3);
            dgvMateriePrime.Columns.Insert(3, colMateriale);

        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
