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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPreventivatore
{
    public partial class CostoFrm : ChildBaseForm
    {
        public decimal IdProdottoFinito;
        //    private Articolo _articolo = new Articolo(string.Empty);
        private Documenti _documenti = new Documenti();
        private Anagrafica _anagrafica = new Anagrafica();
        private List<ElementoCostoPreventivoModel> _elementiCostoPreventivo = new List<ElementoCostoPreventivoModel>();
        private BindingSource _sourceCostiFissi = new BindingSource();
        private BindingSource _source = new BindingSource();
        private List<CostoFissoPreventivoModel> _costiFissiPreventivoModel = new List<CostoFissoPreventivoModel>();

        private List<GruppoRepartoModel> _gruppiRepartiModel;

        private PreventivoModel _preventivoSelezionato
        {
            get
            {
                if (ddlPreventivi.SelectedIndex == -1) return null;
                return (PreventivoModel)ddlPreventivi.SelectedItem;
            }
        }
        private PreventivoCostoModel _preventivoCostoSelezionato
        {
            get
            {
                if (ddlPreventivoCosto.SelectedIndex == -1) return null;
                return (PreventivoCostoModel)ddlPreventivoCosto.SelectedItem;
            }
        }
        public CostoFrm()
        {
            InitializeComponent();
        }

        private void CostoFrm_Load(object sender, EventArgs e)
        {
            Articolo articolo = new Articolo();
            string filename;
            prodottoFinitoUC1.ProdottoFinitoModel = articolo.CreaProdottoFinitoModel(IdProdottoFinito);
            prodottoFinitoUC1.Immagine = _documenti.EstraiImmagineStandard(IdProdottoFinito, TabelleEsterne.ProdottiFiniti, out filename);
            prodottoFinitoUC1.Refresh();
            _gruppiRepartiModel = articolo.CreaListaGruppoRepartoModel(prodottoFinitoUC1.ProdottoFinitoModel.Brand.IdBrand);
            caricaDdlPreventivi();

            caricaListaCostiFissi();
            caricaGrigliaElementiPreventivo();
            caricaGrigliaCostiFissi();
            this.Text = prodottoFinitoUC1.ProdottoFinitoModel.ToString();
       
        }

        private void calcolaCostiGalvanica()
        {
            List<ElementoGrigliaCostoGalvanica> elementiCostiGalvanica = new List<ElementoGrigliaCostoGalvanica>();

            List<ElementoCostoPreventivoModel> elementiGalvanici = _elementiCostoPreventivo.Where(x => x.ElementoPreventivo.Reparto.Codice == "GALVA").ToList();
            if (elementiGalvanici.Count == 0)
            {
                MessageBox.Show("Non sono presenti elementi associati al reparto galvanica GALVA", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Anagrafica a = new Anagrafica();
            List<PrezzoMaterialeModel> prezzi = a.CreaListaPrezzoMaterialeModel();
            foreach (ElementoCostoPreventivoModel elementoGalvanico in elementiGalvanici)
            {
                
         
          
                decimal dm2 = 0.1M * 0.1M;
                decimal micron = (1M / 1000) * (1M / 1000);
                ElementoPreventivoModel elementoPreventivo = elementoGalvanico.ElementoPreventivo;
               
                ProcessoModel processoGalvanico = _preventivoCostoSelezionato.Preventvo.Processo;
                decimal costo = 0;
                foreach (FaseProcessoModel fase in processoGalvanico.Fasi)
                {

                    if (fase.Vasca.AbilitaStrato )
                    {
                        if (fase.Vasca.Materiale.IdMateriale == ElementiVuoti.NessunMateriale) continue;
                        ElementoGrigliaCostoGalvanica elementoCostoGalvanica = new ElementoGrigliaCostoGalvanica();
                        elementiCostiGalvanica.Add(elementoCostoGalvanica);
                        elementoCostoGalvanica.Articolo = elementoPreventivo.Articolo;
                        elementoCostoGalvanica.Elemento = elementoPreventivo.Codice;
                        elementoCostoGalvanica.Superficie = elementoPreventivo.Superficie;
                        elementoCostoGalvanica.Materiale = fase.Vasca.Materiale.Descrizione;
                        elementoCostoGalvanica.Spessore = fase.SpessoreNominale;
                        elementoCostoGalvanica.PesoSpecifico = fase.Vasca.Materiale.PesoSpecifico;

                        decimal volumeMetriCubi = (elementoPreventivo.Superficie* dm2) * (fase.SpessoreNominale*micron);
                        decimal volumeDecimetriCubi = volumeMetriCubi*1000;
                        elementoCostoGalvanica.Volume = volumeDecimetriCubi;
                        decimal pesoInKg = volumeDecimetriCubi * fase.Vasca.Materiale.PesoSpecifico;// peso speficifico espresso in kg/dm3
                        decimal pesoInGr = pesoInKg * 1000;
                        elementoCostoGalvanica.Peso = pesoInGr;
                        decimal prezzoGrammo = 0;
                        PrezzoMaterialeModel prezzo = prezzi.Where(x => x.Materiale.IdMateriale == fase.Vasca.Materiale.IdMateriale).FirstOrDefault();
                        if (prezzo == null)
                        {
                            string messaggio = string.Format("Prezzo materiale {0} non presente. Il prezzo sarà pre-impostato a zero", fase.Vasca.Materiale);
                            MessageBox.Show(messaggio, "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            prezzoGrammo = prezzo.Prezzo;
                        elementoCostoGalvanica.PrezzoGrammo = prezzoGrammo;
                        decimal costoFase = Math.Round(prezzoGrammo * pesoInGr, 4);
                        costo += costoFase;
                        elementoCostoGalvanica.Costo = costoFase;
                    }
                }
                elementoGalvanico.CostoOrario = costo;
                elementoGalvanico.CostoArticolo = costo*(1+elementoGalvanico.Ricarico/100);

            }

            dgvCostiGalvanica.DataSource = elementiCostiGalvanica;
            RefreshGridViewElementi();
        }

        private void caricaProcessoGalvanico()
        {
            dgvProcessoGalvanico.Rows.Clear();
            if (_preventivoSelezionato.Processo == null)
            {
                MessageBox.Show("In questo preventivo non è stato definito il processo galvanico", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtProcessoGalvanico.Text = _preventivoSelezionato.Processo.ToString();

            dgvProcessoGalvanico.Rows.Clear();
            foreach (FaseProcessoModel fase in _preventivoSelezionato.Processo.Fasi)
            {
                int indiceRiga = dgvProcessoGalvanico.Rows.Add(new object[] { fase.Vasca.DescrizioneBreve, fase.Vasca.Materiale.Descrizione, fase.SpessoreMinimo, fase.SpessoreNominale, fase.SpessoreMassimo });
                if (fase.Vasca.Materiale.Prezioso == SiNo.Si)
                    dgvProcessoGalvanico.Rows[indiceRiga].DefaultCellStyle.ForeColor = Color.Green;
            }
            
        }

        private void caricaListaCostiFissi()
        {
            Anagrafica anagrafica = new Anagrafica();
            List<CostoFissoModel> costiFissiModel = anagrafica.CreaListaCostoFissoModel();
            lstCostiFissi.Items.Clear();
            lstCostiFissi.Items.AddRange(costiFissiModel.ToArray());
        }
        private void caricaGrigliaElementiPreventivo()
        {
            dgvElementi.AutoGenerateColumns = false;

            _source.DataSource = _elementiCostoPreventivo;
            dgvElementi.DataSource = _source;
        }
        private void RefreshGridViewCostiFissi()
        {
            _sourceCostiFissi.ResetBindings(false);
            dgvCostiFissi.Update();
            dgvCostiFissi.Refresh();
        }
        private void RefreshGridViewElementi()
        {
            _source.ResetBindings(false);
            dgvElementi.Update();
            dgvElementi.Refresh();
        }
        private void caricaGrigliaCostiFissi()
        {
            dgvCostiFissi.AutoGenerateColumns = false;

            _sourceCostiFissi.DataSource = _costiFissiPreventivoModel;
            dgvCostiFissi.DataSource = _sourceCostiFissi;
        }
        private void caricaDdlPreventivi()
        {
            Articolo articolo = new Articolo();
            ddlPreventivi.Items.Clear();
            ddlPreventivi.Items.AddRange(articolo.CreaListaPreventivoModel(IdProdottoFinito).ToArray());
            if (ddlPreventivi.Items.Count > 0)
                ddlPreventivi.SelectedIndex = 0;
        }


        private void btnCreaNuovaVersione_Click(object sender, EventArgs e)
        {
            try
            {
                NuovoPreventivoCostoFrm form = new NuovoPreventivoCostoFrm(_preventivoSelezionato, ddlPreventivoCosto.Items.Count, _utenteConnesso);
                form.ShowDialog();
                caricaPreventiviCosti(_preventivoSelezionato.IdPreventivo);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in crea nuovo preventivo costo", ex);
            }
        }

        private void ddlPreventivi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            txtNotaPreventivo.Text = _preventivoSelezionato.Nota;
            caricaProcessoGalvanico();
            treeView1.Nodes.Clear();

            caricaPreventiviCosti(_preventivoSelezionato.IdPreventivo);

            if (ddlPreventivoCosto.Items.Count == 0)
                btnCreaNuovaVersione_Click(null, null);

        }

        private void caricaPreventiviCosti(decimal idPreventivo)
        {
            if (idPreventivo == -1) return;
            Articolo a = new Articolo();
            List<PreventivoCostoModel> lista = a.CreaListaPreventivoCostiModel(idPreventivo);
            ddlPreventivoCosto.Items.Clear();
            ddlPreventivoCosto.Items.AddRange(lista.ToArray());

            if (lista.Count > 0)
                ddlPreventivoCosto.SelectedIndex = 0;
        }

        private void creaAlberoDistinta(TreeNode radice)
        {
            List<ElementoCostoPreventivoModel> nodibase = _elementiCostoPreventivo.Where(x => x.ElementoPreventivo.IdPadre == -1).ToList();
            foreach (ElementoCostoPreventivoModel nodobase in nodibase)
                aggiungiFiglio(radice, nodobase);
        }
        private TreeNode aggungiNodo(TreeNode nodoRadice, ElementoCostoPreventivoModel elemento)
        {
            TreeNode nodoAggiunto = nodoRadice.Nodes.Add(elemento.IdElementoCosto.ToString(), elemento.ToString());
            nodoAggiunto.Tag = elemento;
            return nodoAggiunto;
        }
        private void aggiungiFiglio(TreeNode nodoPadre, ElementoCostoPreventivoModel elementoDaAggiungere)
        {
            TreeNode nodoAggiunto = aggungiNodo(nodoPadre, elementoDaAggiungere);
            foreach (ElementoCostoPreventivoModel figlio in _elementiCostoPreventivo.Where(x => x.ElementoPreventivo.IdPadre == elementoDaAggiungere.ElementoPreventivo.IdElementoPreventivo))
                aggiungiFiglio(nodoAggiunto, figlio);
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ddlPreventivi.SelectedIndex == -1) return;
            try
            {
                //decimal idProcesso = ElementiVuoti.ProcessoGalvanicoVuoto;

                //_articolo.ModificaPreventivo(_preventivoSelezionato.IdPrevenivo, _preventivoSelezionato., txtNota.Text, _utenteConnesso);
                //_articolo.SalvaElementiPreventivo(_elementiPreventivo, _preventivoSelezionato.IdPrevenivo, _utenteConnesso);
            }
            catch (Exception ex)
            {
                MostraEccezione("Errore in modifica preventivo", ex);
            }
        }

        private void dgvElementi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvElementi.CurrentCell.ColumnIndex >= 10 && dgvElementi.CurrentCell.ColumnIndex <= 13)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_disabilitaEdit) return;
            try
            {
                if (e.Node.Tag is ProdottoFinitoModel) return;
                ElementoCostoPreventivoModel elemento = (ElementoCostoPreventivoModel)e.Node.Tag;
                decimal idElementoCosto = elemento.IdElementoCosto;

                dgvElementi.ClearSelection();

                foreach (DataGridViewRow riga in dgvElementi.Rows)
                {
                    decimal idCella = (decimal)riga.Cells[0].Value;
                    if (idCella == idElementoCosto)
                    {
                        riga.Selected = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione("", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }

        }

        private void dgvElementi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_disabilitaEdit) return;
            try
            {
                _disabilitaEdit = true;
                decimal idElemento = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
                TreeNode[] nodi = treeView1.Nodes.Find(idElemento.ToString(), true);
                if (nodi.Length == 1)
                {
                    TreeNode nodo = nodi[0];
                    treeView1.HighlightNode(nodo);
                }
            }
            catch (Exception ex)
            {
                MostraEccezione("", ex);
            }
            finally
            {
                _disabilitaEdit = false;
            }
        }


        private void dgvElementi_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvElementi.Rows[e.RowIndex].Cells[0].Value == null) return;

            decimal idElementoCosto = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
            ElementoCostoPreventivoModel elementoCosto = _elementiCostoPreventivo.Where(x => x.IdElementoCosto == idElementoCosto).FirstOrDefault();
            if (elementoCosto == null) return;

            dgvElementi.Rows[e.RowIndex].Cells[2].Value = elementoCosto.ElementoPreventivo.Articolo;
            dgvElementi.Rows[e.RowIndex].Cells[3].Value = elementoCosto.ElementoPreventivo.Codice;
            dgvElementi.Rows[e.RowIndex].Cells[4].Value = elementoCosto.ElementoPreventivo.Descrizione;

            dgvElementi.Rows[e.RowIndex].Cells[7].Value = elementoCosto.ElementoPreventivo.Peso;
            dgvElementi.Rows[e.RowIndex].Cells[8].Value = elementoCosto.ElementoPreventivo.Superficie;
            dgvElementi.Rows[e.RowIndex].Cells[9].Value = elementoCosto.ElementoPreventivo.Quantita;

            RepartoModel reparto = elementoCosto.ElementoPreventivo.Reparto;
            dgvElementi.Rows[e.RowIndex].Cells[5].Value = elementoCosto.ElementoPreventivo.Reparto;


            if (reparto.Codice == "GALVA")
            {
                dgvElementi.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                dgvElementi.Rows[e.RowIndex].Cells[11].ReadOnly = true;
                dgvElementi.Rows[e.RowIndex].Cells[12].ReadOnly = true;

            }

            if (reparto == null) return;
            GruppoRepartoModel grm = _gruppiRepartiModel.Where(x => x.Reparto.IdReparto == reparto.IdReparto).FirstOrDefault();
            if (grm == null) return;
            dgvElementi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromName(grm.Gruppo.Colore);
            dgvElementi.Rows[e.RowIndex].Cells[6].Value = grm.Gruppo.Codice;
        }


        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            caricaListaCostiFissi();
        }

        private void ddlPreventivoCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (ddlPreventivoCosto.SelectedIndex == -1) return;

            Articolo articolo = new Articolo();
            TreeNode radice = treeView1.Nodes.Add("-1", prodottoFinitoUC1.ProdottoFinitoModel.ToString());
            radice.Tag = prodottoFinitoUC1.ProdottoFinitoModel;
            txtNotaPrevetivoCosto.Text = _preventivoCostoSelezionato.Nota;

            _elementiCostoPreventivo = articolo.CreaListaElementoCostoPreventivoModel(_preventivoCostoSelezionato.IdPreventivoCosto);
            creaAlberoDistinta(radice);
            treeView1.ExpandAll();
            caricaProcessoGalvanico();
            calcolaCostiGalvanica();
            MPIntranet.Business.Articolo.RicalcolaCostoFigliListaElementiCostoPreventiviModel(_elementiCostoPreventivo);
            caricaGrigliaElementiPreventivo();
        }

        private void dgvCostiFissi_DragDrop(object sender, DragEventArgs e)
        {
            CostoFissoModel costoFisso = (CostoFissoModel)e.Data.GetData(typeof(CostoFissoModel));
            if (costoFisso == null) return;

            CostoFissoPreventivoModel costoFissoPreventivoModel = new CostoFissoPreventivoModel();
            costoFissoPreventivoModel.IdCostoFissoPreventivo = MPIntranet.Business.Articolo.EstraId();
            costoFissoPreventivoModel.IdPreventivoCosto = costoFisso.IdCostoFisso;
            costoFissoPreventivoModel.Codice = costoFisso.Codice;
            costoFissoPreventivoModel.Descrizione = costoFisso.Descrizione;
            costoFissoPreventivoModel.Ricarico = costoFisso.Ricarico;
            costoFissoPreventivoModel.Costo = costoFisso.Costo;
            costoFissoPreventivoModel.Prezzo = (1 + costoFisso.Ricarico / 100) * costoFisso.Costo;

            _costiFissiPreventivoModel.Add(costoFissoPreventivoModel);
            RefreshGridViewCostiFissi();
            calcolaTotaliCostiFissi();
        }

        private void dgvCostiFissi_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvCostiFissi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
            if (dgvCostiFissi.CurrentCell.ColumnIndex >= 3 && dgvCostiFissi.CurrentCell.ColumnIndex <= 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                }
            }
        }

        private void calcolaTotaliCostiFissi()
        {
            decimal costi = 0;
            decimal prezzi = 0;

            foreach (DataGridViewRow riga in dgvCostiFissi.Rows)
            {
                decimal costo = (decimal)riga.Cells[CostoCostoFisso.Index].Value;
                decimal prezzo = (decimal)riga.Cells[PressoCostoFisso.Index].Value;
                costi += costo;
                prezzi += prezzo;
            }
            txtTotaliCostiFissiCosto.Text = txtCostiFissiCosto.Text = costi.ToString();
            txtTotaliCostiFissiPrezo.Text = txtCostiFissiPrezzo.Text = prezzi.ToString();
            txtTotaliCostiFissiMargine.Text = txtCostiFissiRicarico.Text = (prezzi - costi).ToString();
        }

        private void dgvCostiFissi_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex >= 3 && e.ColumnIndex <= 4)
                {

                    decimal margine = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[RicaricoCostoFisso.Index].Value;
                    decimal costo = (decimal)dgvCostiFissi.Rows[e.RowIndex].Cells[CostoCostoFisso.Index].Value;

                    decimal prezzo = (1 + margine / 100) * costo;
                    dgvCostiFissi.Rows[e.RowIndex].Cells[PressoCostoFisso.Index].Value = prezzo;
                    calcolaTotaliCostiFissi();
                }
            }
        }

        private void dgvCostiFissi_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calcolaTotaliCostiFissi();
        }

        private void dgvElementi_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _disabilitaEdit = true;
                if (e.RowIndex > -1)
                {


                    decimal idElementoCosto = (decimal)dgvElementi.Rows[e.RowIndex].Cells[0].Value;
                    ElementoCostoPreventivoModel elementoCosto = _elementiCostoPreventivo.Where(x => x.IdElementoCosto == idElementoCosto).FirstOrDefault();
                    if (elementoCosto == null) return;

                    RepartoModel reparto = elementoCosto.ElementoPreventivo.Reparto;
                    if (reparto.Codice == "GALVA")
                    {
                        return;
                    }
                    if (e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12)
                    {

                        decimal margine = (decimal)dgvElementi.Rows[e.RowIndex].Cells[12].Value;
                        decimal costoOrario = (decimal)dgvElementi.Rows[e.RowIndex].Cells[11].Value;
                        decimal pezziOrari = (decimal)dgvElementi.Rows[e.RowIndex].Cells[10].Value;
                        decimal costoPezzo = pezziOrari == 0 ? 0 : costoOrario / pezziOrari;
                        decimal costoArticolo = (1 + margine / 100) * costoPezzo;
                        dgvElementi.Rows[e.RowIndex].Cells[colCostoArticolo.Index].Value = costoArticolo;

                        MPIntranet.Business.Articolo.RicalcolaCostoFigliListaElementiCostoPreventiviModel(_elementiCostoPreventivo);

                        RefreshGridViewElementi();
                    }
                }

            }
            finally
            {
                _disabilitaEdit = false;
            }
        }
    }

    public class ElementoGrigliaCostoGalvanica
    {
        public string Articolo { get; set; }
        public string Elemento { get; set; }
        public string Materiale { get; set; }
        public decimal Superficie { get; set; }
        public decimal Spessore { get; set; }
        public decimal Volume { get; set; }
        public decimal PesoSpecifico { get; set; }
        public decimal Peso { get; set; }
        public decimal PrezzoGrammo { get; set; }
        public decimal Costo { get; set; }

    }
}
