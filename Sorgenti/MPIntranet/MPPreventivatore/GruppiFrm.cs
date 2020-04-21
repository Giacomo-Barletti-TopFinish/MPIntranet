using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class GruppiFrm : ChildBaseForm
    {
        private Articolo _articolo = new Articolo();
        private BrandModel brandSelezionato;
        public GruppiFrm()
        {
            InitializeComponent();
            caricaBrand();
        }

        private void caricaBrand()
        {
            Anagrafica a = new Anagrafica();
            ddlBrand.Items.AddRange(a.CreaListaBrandModel().ToArray());
        }

        private void GruppiFrm_Load(object sender, EventArgs e)
        {
            caricaBrand();
            lblMessaggio.Text = string.Empty;
        }

        public static List<Color> ColorStructToList()
        {
            return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                                .Select(c => (Color)c.GetValue(null, null))
                                .ToList();
        }

        private void CaricaGrigliaGruppi()
        {
            if (brandSelezionato == null) return;

            Articolo a = new Articolo();
            List<GruppoModel> gruppi = _articolo.CreaListaGruppoModel().Where(x => x.Brand.IdBrand == brandSelezionato.IdBrand).ToList();

            BindingSource source = new BindingSource();
            source.DataSource = gruppi;
            dgvGruppi.DataSource = source;
            dgvGruppi.Columns[0].Visible = false;
            dgvGruppi.Columns[2].Width = 200;
            dgvGruppi.Columns[3].Visible = false;

            ((DataGridViewTextBoxColumn)dgvGruppi.Columns[1]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvGruppi.Columns[2]).MaxInputLength = 30;


            List<string> colors = ColorStructToList().Select(x => x.Name).ToList();
            DataGridViewComboBoxColumn colColore = new DataGridViewComboBoxColumn();
            {
                colColore.DataPropertyName = "Colore";
                colColore.HeaderText = "Colore";
                colColore.DropDownWidth = 130;
                colColore.Width = 130;
                colColore.MaxDropDownItems = System.Math.Min(colors.Count, 10);
                colColore.FlatStyle = FlatStyle.Flat;
                colColore.Items.AddRange(colors.ToArray());
            }
            dgvGruppi.Columns.RemoveAt(4);
            dgvGruppi.Columns.Insert(4, colColore);

            CaricaGrigliaReparti();
        }

        private void CaricaGrigliaReparti()
        {
            if (brandSelezionato == null) return;

            dgvRepartiGruppi.DataSource = null;
            dgvRepartiGruppi.Columns.Clear();
            Anagrafica a = new Anagrafica();
            List<GruppoRepartoModel> gruppoRepartoAssociato = _articolo.CreaListaGruppoRepartoModel(brandSelezionato.IdBrand);
            List<RepartoModel> reparti = a.CreaListaRepartoModel();
            List<string> gruppi = _articolo.CreaListaGruppoModel().Where(x => x.Brand.IdBrand == brandSelezionato.IdBrand).Select(x => x.Codice).ToList();
            if (gruppi.Count == 0)
            {
                dgvRepartiGruppi.DataSource = null;
                return;
            }
            gruppi.Insert(0, string.Empty);
            List<GruppoRepartoModel> gruppoReparto = new List<GruppoRepartoModel>();
            foreach (RepartoModel reparto in reparti.OrderBy(x => x.Codice))
            {
                GruppoRepartoModel gr = gruppoRepartoAssociato.Where(x => x.Reparto.IdReparto == reparto.IdReparto).FirstOrDefault();

                if (gr == null)
                {
                    gr = new GruppoRepartoModel();
                    gr.IdGruppoReparto = -1;
                    gr.Gruppo = null;
                    gr.Reparto = reparto;
                }
                gruppoReparto.Add(gr);
            }

            BindingSource source = new BindingSource();
            source.DataSource = gruppoReparto;
            dgvRepartiGruppi.DataSource = source;
            dgvRepartiGruppi.Columns[0].Visible = false;


            dgvRepartiGruppi.Columns[1].Width = 200;
            dgvRepartiGruppi.Columns[2].Width = 200;
        }

        private void dgvGruppi_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                decimal idGruppo = (decimal)e.Row.Cells[0].Value;

                Articolo a = new Articolo();
                a.CancellaGruppo(idGruppo, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaGruppi));
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore cancellando un gruppo", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }

        private void dgvGruppi_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (brandSelezionato == null)
                {
                    lblMessaggio.Text = "Brand non selezionato";
                    return;
                }

                _disabilitaEdit = true;
                lblMessaggio.Text = _articolo.CreaGruppo("** NUOVO", string.Empty, brandSelezionato.IdBrand, Color.White.Name, _utenteConnesso);
                CaricaGrigliaGruppi();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore aggiungendo un gruppo", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }


        private decimal EstraiIdGruppoDaGriglia()
        {
            if (dgvGruppi.SelectedRows.Count == 0 && dgvGruppi.SelectedCells.Count == 0)
                return -1;

            decimal idGruppo = -1;
            if (dgvGruppi.SelectedRows.Count > 0)
                idGruppo = (decimal)dgvGruppi.SelectedRows[0].Cells[0].Value;
            if (dgvGruppi.SelectedCells.Count > 0)
            {
                int rowIndex = dgvGruppi.SelectedCells[0].RowIndex;
                idGruppo = (decimal)dgvGruppi.Rows[rowIndex].Cells[0].Value;
            }
            return idGruppo;
        }

        private void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == -1) return;

            brandSelezionato = (BrandModel)ddlBrand.SelectedItem;
            CaricaGrigliaGruppi();
        }

        private void dgvGruppi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_disabilitaEdit) return;
                if (e.RowIndex < 0) return;

                decimal idGruppo = (decimal)dgvGruppi.Rows[e.RowIndex].Cells[0].Value;
                string codice = (string)dgvGruppi.Rows[e.RowIndex].Cells[1].Value;
                string descrizione = (string)dgvGruppi.Rows[e.RowIndex].Cells[2].Value;
                string colore = (string)dgvGruppi.Rows[e.RowIndex].Cells[4].Value;

                if (string.IsNullOrEmpty(colore)) colore = Color.White.Name;
                if (string.IsNullOrEmpty(descrizione)) descrizione = string.Empty;
                if (string.IsNullOrEmpty(codice))
                {
                    lblMessaggio.Text = "Il codice non può essere vuoto";
                    return;
                }


                lblMessaggio.Text = _articolo.ModificaGruppo(idGruppo, codice, descrizione, colore, _utenteConnesso);
                BeginInvoke(new MethodInvoker(CaricaGrigliaGruppi));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore modificando un gruppo", ex);
            }
        }


        private void btnAssocia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRepartiGruppi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selezionare i reparti a cui si vuole associare il gruppo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvGruppi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selezionare il gruppo che si vuole associare ai reparti", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal idGruppo = (decimal)dgvGruppi.SelectedRows[0].Cells[0].Value;

                foreach (DataGridViewRow row in dgvRepartiGruppi.SelectedRows)
                {
                    decimal idGruppoReparto = (decimal)row.Cells[0].Value;
                    RepartoModel reparto = (RepartoModel)row.Cells[1].Value;
                    if (idGruppoReparto == -1)
                        _articolo.CreaGruppoReparto(reparto.IdReparto, idGruppo, _utenteConnesso);
                    else
                        _articolo.ModificaGruppoReparto(idGruppoReparto, idGruppo, _utenteConnesso);
                }
                BeginInvoke(new MethodInvoker(CaricaGrigliaReparti));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in associa gruppo reparto", ex);
            }

        }

        private void btnDisassocia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRepartiGruppi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selezionare i reparti a cui si vuole associare il gruppo", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in dgvRepartiGruppi.SelectedRows)
                {
                    decimal idGruppoReparto = (decimal)row.Cells[0].Value;
                    _articolo.CancellaGruppoReparto(idGruppoReparto, _utenteConnesso);
                }
                BeginInvoke(new MethodInvoker(CaricaGrigliaReparti));
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in disassocia gruppo reparto", ex);
            }
        }

        private void dgvRepartiGruppi_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            GruppoModel gruppo= (GruppoModel)dgvRepartiGruppi.Rows[e.RowIndex].Cells[2].Value;
            if (gruppo == null) return;
            dgvRepartiGruppi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromName(gruppo.Colore);
        }
    }
}
