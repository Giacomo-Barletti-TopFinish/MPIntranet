using MPIntranet.Business;
using MPIntranet.Common;
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
    public partial class CollegamentoTaskAreaFrm : MPIChildForm
    {
        private BindingSource sourceTaskArea;
        private bool _newrow = false;
        private AutoCompleteStringCollection _autoAreeProduzione = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoTask = new AutoCompleteStringCollection();
        private int indiceFaseCiclo = 0;
        private List<TaskArea> _tasksArea = new List<TaskArea>();

        public CollegamentoTaskAreaFrm()
        {
            InitializeComponent();
        }

        private void CollegamentoTaskAreaFrm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                caricaAreeProduzione();
                caricaTask();
                popolaGriglia();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void popolaGriglia()
        {
            _tasksArea = TaskArea.EstraiListaTaskArea(true);
            dgvTaskArea.AutoGenerateColumns = false;
            BindingList<TaskArea> bindingList = new BindingList<TaskArea>(_tasksArea);
            sourceTaskArea = new BindingSource(bindingList, null);
            dgvTaskArea.DataSource = sourceTaskArea;
            dgvTaskArea.Update();
        }

        private void dgvTaskArea_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            _newrow = true;
        }

        private void caricaAreeProduzione()
        {
            List<AreaProduzione> aree = MPIntranet.Business.AreaProduzione.EstraiListaAreeProduzione();

            string[] etichette = aree.Select(x => x.Codice).ToArray();
            _autoAreeProduzione.AddRange(etichette);
        }
        private void caricaTask()
        {
            List<MPIntranet.Business.Task> tasks = MPIntranet.Business.Task.EstraiListaTask();

            string[] etichette = tasks.Select(x => x.Codice).ToArray();
            _autoTask.AddRange(etichette);
        }

        private int estraiIndiceFasiCiclo()
        {
            indiceFaseCiclo--;
            return indiceFaseCiclo;
        }
        private void dgvTaskArea_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (!_newrow) return;
                if (e.RowIndex == 0) return;

                int idFaseCiclo = -1;
                idFaseCiclo = estraiIndiceFasiCiclo();
                
                DataGridViewRow row = dgvTaskArea.Rows[e.RowIndex - 1];                
                row.Cells[clmIdTaskArea.Index].Value = idFaseCiclo;
                row.Cells[clmTask.Index].Value = string.Empty;
                row.Cells[clmAreaProduzione.Index].Value = string.Empty;
                row.Cells[clmPeriodo.Index].Value = 1;
                row.Cells[clmPezziPeriodo.Index].Value = 100;

                _newrow = false;
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in verifica cicli");
            }
        }

        private void dgvTaskArea_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void dgvTaskArea_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmTask.Index)
            {
                string task = (string)dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                task = task.ToUpper();
                dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = task;

                if (dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show("Valori nulli per il TASK non sono ammessi", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> tasks = new List<string>();
                for (int i = 0; i < dgvTaskArea.Rows.Count - 2; i++)
                {
                    string valore = (string)dgvTaskArea.Rows[i].Cells[clmTask.Index].Value;
                    tasks.Add(valore);
                }

                if (tasks.Contains(task))
                {
                    MessageBox.Show("TASK già presente nella griglia", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                    return;
                }

            }

            if (e.ColumnIndex == clmAreaProduzione.Index)
            {
                string area = (string)dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                area = area.ToUpper();
                dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = area;
                if (dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show("Valori nulli per AREA PRODUZIONE non sono ammessi", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (e.ColumnIndex == clmPeriodo.Index)
            {
                if (dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show("Valori nulli per PERIODO non sono ammessi", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double periodo = (double)dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (periodo <= 0)
                {
                    MessageBox.Show("PERIODO deve essere positivo", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (e.ColumnIndex == clmPezziPeriodo.Index)
            {
                if (dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    MessageBox.Show("Valori nulli per PEZZI PERIODO non sono ammessi", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double pezziPeriodo = (double)dgvTaskArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (pezziPeriodo <= 0)
                {
                    MessageBox.Show("PEZZI PERIODO deve essere positivo", "ATTEZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvTaskArea.Rows[e.RowIndex].Cells[clmUtenteModifica.Index].Value = _utenteConnesso;

        }

        private void btnSalvaModifiche_Click(object sender, EventArgs e)
        {
            if (TaskArea.Salva(_tasksArea, _utenteConnesso))
            {
                MessageBox.Show("Salvataggio riuscito", "INFORMAZIONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                popolaGriglia();
            }
            else
                MessageBox.Show("SALVATAGGIO NON RIUSCITO. Ci sono campi vuoti o valori minori di zero", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
