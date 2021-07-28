using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
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
    public partial class DistintaBusinessCentralFrm : MPIChildForm
    {
        private DistintaBC _distinta;
        private int indiceComponenti = 0;
        private int indiceFaseCiclo = 0;
        private BindingSource sourceFasiCicli;
        private BindingSource sourceComponenti;
        private AutoCompleteStringCollection _autoAreeProduzione = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoTask = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _autoItems = new AutoCompleteStringCollection();
        private int _idComponenteSelezionato;
        private bool _newrow = false;
        private List<TaskArea> _taskAreaProduzione = new List<TaskArea>();

        protected List<Componente> ComponentiDaCopiare
        {
            get { return (MdiParent as MainForm).ComponentiDaCopiare; }
            set { (MdiParent as MainForm).ComponentiDaCopiare = value; }
        }

        private int estraiIndiceComponenti()
        {
            indiceComponenti--;
            return indiceComponenti;
        }
        private int estraiIndiceFasiCiclo()
        {
            indiceFaseCiclo--;
            return indiceFaseCiclo;
        }

        public DistintaBusinessCentralFrm()
        {
            InitializeComponent();
        }

        private void DistintaBusinessCentralFrm_Load(object sender, EventArgs e)
        {
        }

        private void btnCercaDiBa_Click(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            if (string.IsNullOrEmpty(txtArticolo.Text)) return;
            txtArticolo.Text = txtArticolo.Text.ToUpper();

            SelezionaDistintaBCFrm form = new SelezionaDistintaBCFrm(txtArticolo.Text);
            form.ShowDialog();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _distinta = form.DistintaSelezionata;

                _distinta.CaricaDistintaCompleta();

                creaAlbero();
                PopolaGrigliaComponenti();
//                PopolaGrigliaFasi(null);
            }
            catch { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void creaAlbero()
        {
            if (_distinta == null) return;
            tvDiBa.Nodes.Clear();
            if (_distinta.Componenti.Count() == 0)
                tvDiBa.Nodes.Add(creaNodo(null));
            else
            {
                ComponenteBC componenteBase = _distinta.Componenti.Where(x => x.IdPadre == string.Empty).FirstOrDefault();
                if (componenteBase == null) return;

                string etichettaNodo = componenteBase.CreaEtichetta();
                TreeNode radice = new TreeNode(etichettaNodo);
                radice.Tag = componenteBase;
                tvDiBa.Nodes.Add(radice);
                aggiungiNodoEsistente(componenteBase.Anagrafica, radice);
            }
            tvDiBa.ExpandAll();
        }

        private TreeNode creaNodo(TreeNode nodoPadre)
        {

            ComponenteBC componentePadre = null;
            if (nodoPadre != null && nodoPadre.Tag != null)
                componentePadre = (ComponenteBC)nodoPadre.Tag;

            ComponenteBC componente = new ComponenteBC();
            componente.CollegamentoDiBa = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
            if (componentePadre != null) componente.IdPadre = componentePadre.Anagrafica;
            componente.Quantita = 1;
            componente.UMQuantita = "NR";
            string etichettaNodo = componente.Anagrafica;
            TreeNode nodo = new TreeNode(etichettaNodo);
            nodo.Tag = componente;
            _distinta.Componenti.Add(componente);
            return nodo;
        }

        private void aggiungiNodoEsistente(string  codice, TreeNode nodoPadre)
        {
            foreach (ComponenteBC componente in _distinta.Componenti.Where(x => x.IdPadre == codice))
            {
                string etichettaNodo = componente.CreaEtichetta();
                TreeNode nodoFiglio = new TreeNode(etichettaNodo);
                nodoFiglio.Tag = componente;
                nodoPadre.Nodes.Add(nodoFiglio);

                aggiungiNodoEsistente(componente.Anagrafica, nodoFiglio);
            }
        }

        private void PopolaGrigliaFasi(ComponenteBC componente)
        {
            if (componente == null)
            {
                dgvFasiCiclo.DataSource = null;
                return;
            }
            dgvFasiCiclo.AutoGenerateColumns = false;
            if (componente.FasiCiclo == null) componente.FasiCiclo = new List<FaseCicloBC>();

            BindingList<FaseCicloBC> bindingList = new BindingList<FaseCicloBC>(componente.FasiCiclo);
            sourceFasiCicli = new BindingSource(bindingList, null);
            dgvFasiCiclo.DataSource = sourceFasiCicli;
            dgvFasiCiclo.Update();
        }

        private void PopolaGrigliaComponenti()
        {
            if (_distinta == null) return;
            dgvComponenti.AutoGenerateColumns = false;
            BindingList<ComponenteBC> bindingList = new BindingList<ComponenteBC>(_distinta.Componenti);
            sourceComponenti = new BindingSource(bindingList, null);
            dgvComponenti.DataSource = sourceComponenti;
            dgvComponenti.Update();
        }
    }
}
