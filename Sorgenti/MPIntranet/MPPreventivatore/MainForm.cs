
using MPIntranet.Common;
using MPPreventivatore.Properties;
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
    public partial class MainForm : MPIBaseForm
    {
        public string RvlImageSite
        {
            get
            {
                return Settings.Default.RvlImageSite;
            }
        }
        public MainForm() : base()
        {
            InitializeComponent();
        }

        private void AbilitaMenu()
        {
            DisabilitaElementiMenu(MPMenu.Items, true);
            exitToolStripMenuItem.Enabled = true;
            fileToolStripMenuItem.Enabled = true;

            anagraficaToolStripMenuItem.Enabled = Contesto.Utente.AbilitaAnagrafica;
            distintaBaseToolStripMenuItem.Enabled = Contesto.Utente.AbilitaDistintaBase;
            costiToolStripMenuItem.Enabled = Contesto.Utente.AbilitaCosti;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in fase di chiusura", ex);
            }
        }

        protected override void MPIBaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                base.MPIBaseForm_Load(sender, e);
                AbilitaMenu();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in fase di load", ex);
            }
        }

        private void repartiEFasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RepartiFasiFrm form = new RepartiFasiFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in reparti e fasi", ex);
            }
        }

        private void tipologieProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TipologiaArticoliFrm form = new TipologiaArticoliFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in tipologie prodotto", ex);
            }
        }

        private void materiePrimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MateriePrimeFrm form = new MateriePrimeFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in materie prime", ex);
            }
        }

        private void tipologieDocumentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TipologiaDocumentiFrm form = new TipologiaDocumentiFrm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in tipologia documenti", ex);
            }
        }

        private void gestisciProdottoFinitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GestisciProdottoFinitoFrm form = new GestisciProdottoFinitoFrm(TipoRicerca.ProdottoFinito);
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea prodotti finiti", ex);
            }
        }

        public void ApriFinestraProdottoFinito(decimal idProdottoFinito)
        {
            try
            {
                ProdottoFinitoFrm form = new ProdottoFinitoFrm();
                form.IdProdottoFinito = idProdottoFinito;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in apri prodotti finiti", ex);
            }
        }

        public void ApriFinestraPreventivo(decimal idProdottoFinito)
        {
            try
            {
                PreventivoFrm form = new PreventivoFrm();
                form.IdProdottoFinito = idProdottoFinito;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in apri prodotti finiti", ex);
            }
        }
        public void ApriFinestraCopiaProdotto(decimal idProdottoFinito)
        {
            try
            {
                CreaProdottoFinitoFrm form = new CreaProdottoFinitoFrm();
                form.IdProdottoFinito = idProdottoFinito;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in apri prodotti finiti", ex);
            }
        }

        private void preventiviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GestisciProdottoFinitoFrm form = new GestisciProdottoFinitoFrm(TipoRicerca.Preventivo);
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea prodotti finiti", ex);
            }
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void orizzontaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
      
    }
}
