using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Documenti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class ProdottoFinitoFrm : ChildBaseForm
    {
        public decimal IdProdottoFinito;
        private Articolo _articolo = new Articolo(string.Empty);
        public ProdottoFinitoFrm()
        {
            InitializeComponent();
        }

        private void ProdottoFinitoFrm_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessaggio.Text = string.Empty;
                caricaProdottoFinito();

                Anagrafica a = new Anagrafica();
                List<TipoDocumentoModel> tipiDocumento = a.CreaListaTipoDocumentoModel();
                ddlTipoDocumento.Items.AddRange(tipiDocumento.ToArray());
                caricaGrigliaDocumenti();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore caricando prodotto finito", ex);
            }
        }

        private void caricaGrigliaDocumenti()
        {
            Documenti d = new Documenti();
            DocumentoModelContainer documentiContainer = d.CreaDocumentoModelContainer(IdProdottoFinito, TabelleEsterne.ProdottiFiniti);
            BindingSource source = new BindingSource();
            source.DataSource = documentiContainer.Documenti;

            dgvDocumenti.DataSource = source;

            dgvDocumenti.Columns[0].Visible = false;
            dgvDocumenti.Columns[1].Width = 150;
            dgvDocumenti.Columns[1].ReadOnly = true;
            dgvDocumenti.Columns[2].Width = 250;
            dgvDocumenti.Columns[2].ReadOnly = true;

        }
        private void caricaProdottoFinito()
        {
            ProdottoFinitoModel prodottoFinitoModel = _articolo.CreaProdottoFinitoModel(IdProdottoFinito);
            if (prodottoFinitoModel == null)
                throw new ArgumentNullException("Prodotto finito non trovato: " + IdProdottoFinito.ToString());

            txtBrand.Text = prodottoFinitoModel.Brand.ToString();
            txtCodice.Text = prodottoFinitoModel.Codice;
            txtCodiceDefinitivo.Text = prodottoFinitoModel.CodiceDefinitivo;
            txtCodiceProvvisorio.Text = prodottoFinitoModel.CodiceProvvisorio;
            txtColore.Text = prodottoFinitoModel.Colore.ToString();
            txtDescrizione.Text = prodottoFinitoModel.Descrizione;
            txtModello.Text = prodottoFinitoModel.Modello;
            txtTipoProdotto.Text = prodottoFinitoModel.TipoProdotto.ToString();
            chkPreserie.Checked = prodottoFinitoModel.Preserie;
            chkPreventivo.Checked = prodottoFinitoModel.Prevenivo;
            chkProduzione.Checked = prodottoFinitoModel.Produzione;

        }
        private void btnChiudi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvaModifiche_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessaggio.Text = _articolo.ModificaProdottoFinito(IdProdottoFinito, txtDescrizione.Text, txtCodiceProvvisorio.Text, txtCodiceDefinitivo.Text, chkPreventivo.Checked, chkPreserie.Checked, chkProduzione.Checked, _utenteConnesso);
                caricaProdottoFinito();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in modifica prodotto finito", ex);
            }
        }

        private void btnCopiaProdotto_Click(object sender, EventArgs e)
        {
            (MdiParent as MainForm).ApriFinestraCopiaProdotto(IdProdottoFinito);
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtNuovoDocumento.Text = ofd.FileName;
            }
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(txtNuovoDocumento.Text))
                {
                    lblMessaggio.Text = "Indicare il documento da caricare";
                    return;
                }

                if (ddlTipoDocumento.SelectedIndex == -1)
                {
                    lblMessaggio.Text = "Indicare il tipo documento";
                    return;
                }
                if (!File.Exists(txtNuovoDocumento.Text))
                {
                    lblMessaggio.Text = "Il file non esiste";
                    return;
                }
                decimal idTipoProdotto = ((TipoDocumentoModel)(ddlTipoDocumento.SelectedItem)).IdTipoDocumento;

                FileStream fs = new FileStream(txtNuovoDocumento.Text, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();

                Documenti documenti = new Documenti();
                lblMessaggio.Text = documenti.CreaDocumento(IdProdottoFinito, TabelleEsterne.ProdottiFiniti, idTipoProdotto, txtNuovoDocumento.Text, bytes, _utenteConnesso);

            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in associa documento a prodotto finito", ex);
            }
            finally
            {
                caricaGrigliaDocumenti();
                Cursor.Current = Cursors.Default;
            }

        }

        private void dgvDocumenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                decimal idDocumento = (decimal)dgvDocumenti.Rows[e.RowIndex].Cells[0].Value;
                Documenti d = new Documenti();
                string filename;
                byte[] bytes = d.EstraiDocumento(idDocumento, out filename);
                string directory = @"c:\Preventivatore";
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string filePath = Path.Combine(directory, filename);

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
                fs.Close();

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in associa documento a prodotto finito", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }


    }
}
