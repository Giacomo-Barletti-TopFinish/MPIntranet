using MPIntranet.DataAccess.Report;
using MPIntranet.Entities;
using MPIntranet.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPIntranet.Helpers;

namespace MPIntranet.Business
{
    public class Report
    {
        private ReportDS _ds = new ReportDS();
        //   private string reparto;

        public List<CaricoRepartoModel> CreaListaCaricoReparto(string reparto)
        {
            List<CaricoRepartoModel> caricoLavoro = new List<CaricoRepartoModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillODL_APERTI(_ds, reparto);

            foreach (ReportDS.ODL_APERTIRow odl_aperto in _ds.ODL_APERTI)
                caricoLavoro.Add(CreaCaricoRepartoModel(odl_aperto));

            return caricoLavoro;

        }

        public List<ReportQuantitaModel> CreaListaReportQuantita()
        {
            List<ReportQuantitaModel> reportquantitalist = new List<ReportQuantitaModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillREPORTQUANTITA(_ds);

            foreach (ReportDS.REPORTQUANTITARow reportquantita in _ds.REPORTQUANTITA)
                reportquantitalist.Add(CreaReportQuantitaModel(reportquantita));

            return reportquantitalist;

        }

        public List<BolleVenditaModel> CreaListaReportBolleVendita(DateTime inizio, DateTime fine)
        {
            List<BolleVenditaModel> lista = new List<BolleVenditaModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillBOLLE_VENDITA(inizio, fine, _ds);

            foreach (ReportDS.BOLLE_VENDITARow riga in _ds.BOLLE_VENDITA)
                lista.Add(CreaBolleVenditaModel(riga));

            return lista;

        }
        public List<SaldoUbicazioneModel> CreaListaSaldoUbicazioneModel(string Articolo)
        {
            List<SaldoUbicazioneModel> lista = new List<SaldoUbicazioneModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillSALDIUBICAZIONI(Articolo, _ds);

            foreach (ReportDS.SALDIUBICAZIONIRow riga in _ds.SALDIUBICAZIONI)
                lista.Add(CreaSaldoUbicazioneModel(riga));

            return lista;

        }
        public List<OrdiniAttiviModel> CreaListaOrdiniAttivitModel()
        {
            List<OrdiniAttiviModel> lista = new List<OrdiniAttiviModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillORDINIATTIVI(_ds);

            decimal valoreTotale = _ds.ORDINIATTIVI.Sum(x => x.VALORENOSPE);
            decimal valoreTotaleScaduti = _ds.ORDINIATTIVI.Where(x => x.SCADUTO == "SI").Sum(x => x.VALORENOSPE);

            List<string> segnalatori = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull()).Select(x => x.SEGNALATORE).Distinct().ToList();
            foreach (string segnalatore in segnalatori)
            {
                decimal valore = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.VALORE);
                decimal quantita = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.QTATOT);
                decimal valoreAnnullato = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.VALOREANN);
                decimal quantitaAnnullato = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.QTAANN);
                decimal valoreNonSpedito = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpedita = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore).Sum(x => x.QTANOSPE);
                decimal valoreNonSpeditoScaduto = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore && x.SCADUTO == "SI").Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpeditaScaduto = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore && x.SCADUTO == "SI").Sum(x => x.QTANOSPE);
                decimal valoreNonSpeditoNonScaduto = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore && x.SCADUTO == "NO").Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpeditaNonScaduto = _ds.ORDINIATTIVI.Where(x => !x.IsSEGNALATORENull() && x.SEGNALATORE == segnalatore && x.SCADUTO == "NO").Sum(x => x.QTANOSPE);
                decimal scadutoPerCliente = valoreNonSpedito == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreNonSpedito, 2) * 100;
                decimal scadutoSulTotale = valoreTotaleScaduti == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreTotaleScaduti, 2) * 100;
                OrdiniAttiviModel ordineAttivoModel = new OrdiniAttiviModel();
                ordineAttivoModel.Cliente = segnalatore;
                ordineAttivoModel.Quantita = quantita;
                ordineAttivoModel.QuantitaNonSpedita = quantitaNonSpedita;
                ordineAttivoModel.QuantitaAnnullata = quantitaAnnullato;
                ordineAttivoModel.QuantitaScaduta = quantitaNonSpeditaScaduto;
                ordineAttivoModel.Valore = valore;
                ordineAttivoModel.ValoreNonSpedito = valoreNonSpedito;
                ordineAttivoModel.ValoreAnnullato = valoreAnnullato;
                ordineAttivoModel.ValoreScaduto = valoreNonSpeditoScaduto;
                ordineAttivoModel.ValoreNonScaduto = valoreNonSpeditoNonScaduto;
                ordineAttivoModel.PercScadutoCliente = scadutoPerCliente;
                ordineAttivoModel.PercScadutoSulTotale = scadutoSulTotale;

                lista.Add(ordineAttivoModel);
            }

            //foreach (string cliente in _ds.ORDINIATTIVI.Where(x => x.IsSEGNALATORENull()).Select(x => x.SEGNALATORE))
            //{
            //    decimal valore = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALORE);
            //    decimal quantita = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTATOT);
            //    decimal valoreAnnullato = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALOREANN);
            //    decimal quantitaAnnullato = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTAANN);
            //    decimal valoreNonSpedito = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALORENOSPE);
            //    decimal quantitaNonSpedita = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTANOSPE);
            //    decimal valoreNonSpeditoScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "SI").Sum(x => x.VALORENOSPE);
            //    decimal quantitaNonSpeditaScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "SI").Sum(x => x.QTANOSPE);
            //    decimal valoreNonSpeditoNonScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "NO").Sum(x => x.VALORENOSPE);
            //    decimal quantitaNonSpeditaNonScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "NO").Sum(x => x.QTANOSPE);
            //    decimal scadutoPerCliente = valoreNonSpedito == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreNonSpedito, 2) * 100;
            //    decimal scadutoSulTotale = valoreTotaleScaduti == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreTotaleScaduti, 2) * 100;
            //    OrdiniAttiviModel ordineAttivoModel = new OrdiniAttiviModel();
            //    ordineAttivoModel.Cliente = cliente;
            //    ordineAttivoModel.Quantita = quantita;
            //    ordineAttivoModel.QuantitaNonSpedita = quantitaNonSpedita;
            //    ordineAttivoModel.QuantitaAnnullata = quantitaAnnullato;
            //    ordineAttivoModel.Valore = valore;
            //    ordineAttivoModel.ValoreNonSpedito = valoreNonSpedito;
            //    ordineAttivoModel.ValoreAnnullato = valoreAnnullato;
            //    ordineAttivoModel.ValoreScaduto = valoreNonSpeditoScaduto;
            //    ordineAttivoModel.ValoreNonScaduto = valoreNonSpeditoNonScaduto;
            //    ordineAttivoModel.PercScadutoCliente = scadutoPerCliente;
            //    ordineAttivoModel.PercScadutoSulTotale = scadutoSulTotale;

            //    lista.Add(ordineAttivoModel);
            //}

            return lista;


        }

        private ReportQuantitaModel CreaReportQuantitaModel(ReportDS.REPORTQUANTITARow reportquantita)
        {
            ReportQuantitaModel reportQuantitaModel = new ReportQuantitaModel();
            reportQuantitaModel.Codiceclifo = reportquantita.CODICECLIFO;
            reportQuantitaModel.Ragionesoc = reportquantita.RAGIONESOC;
            reportQuantitaModel.Somma = reportquantita.SOMMA;
            reportQuantitaModel.Perc = reportquantita.PERC;
            reportQuantitaModel.ElencoFasi = reportquantita.IsELENCOFASINull() ? string.Empty : reportquantita.ELENCOFASI;
            return reportQuantitaModel;
        }

        private BolleVenditaModel CreaBolleVenditaModel(ReportDS.BOLLE_VENDITARow riga)
        {
            BolleVenditaModel bolla = new BolleVenditaModel();
            bolla.Azienda = riga.AZIENDA;
            bolla.CodiceTipoO = riga.CODICETIPOO;
            bolla.DescrizioneTipoO = riga.DESTABTIPOO;
            bolla.Causale = riga.CODICECAUTR;
            bolla.DescrizioneCausale = riga.DESTABCAUTR;
            bolla.FullNumDoc = riga.FULLNUMDOC;
            bolla.DataDocumento = riga.DATDOC;
            bolla.Numero = riga.NUMDOC;
            bolla.Segnalatore = riga.IsSEGNALATORE_RSNull() ? String.Empty : riga.SEGNALATORE_RS.Trim();
            bolla.Cliente = riga.RAGIONESOC.Trim();
            bolla.NumeroRiga = riga.NRRIGA;
            bolla.Modello = riga.MODELLO;
            bolla.Quantita = riga.QTATOT;
            bolla.Prezzo = riga.PREZZOTOT;
            bolla.Valore = riga.VALORE;
            bolla.Ordine = riga.IsFULLNUMDOC_OCNull() ? string.Empty : riga.FULLNUMDOC_OC;
            bolla.DataOrdine = riga.IsDATDOC_OCNull() ? string.Empty : riga.DATDOC_OC.ToString("dd/MM/yyyy");
            bolla.DataRichiesta = riga.IsDATA_RICHIESTANull() ? string.Empty : riga.DATA_RICHIESTA.ToString("dd/MM/yyyy");
            bolla.DataConferma = riga.IsDATA_CONFERMANull() ? string.Empty : riga.DATA_CONFERMA.ToString("dd/MM/yyyy");
            bolla.Riferimento = riga.IsRIFERIMENTONull() ? string.Empty : riga.RIFERIMENTO;

            return bolla;
        }

        private SaldoUbicazioneModel CreaSaldoUbicazioneModel(ReportDS.SALDIUBICAZIONIRow riga)
        {
            SaldoUbicazioneModel saldo = new SaldoUbicazioneModel();

            saldo.Modello = riga.MODELLO;
            saldo.CodiceMagazzino = riga.CODICEMAG;
            saldo.Costo = riga.IsCOSTO1Null()?0:riga.COSTO1;
            saldo.Quantita = riga.QESI;
            saldo.Valore = riga.IsVALORENull()?0:riga.VALORE;
            saldo.QuantitaNettaDisponibile = riga.IsQTOT_DISP_ESINull()?0:riga.QTOT_DISP_ESI;
            return saldo;
        }
        private CaricoRepartoModel CreaCaricoRepartoModel(ReportDS.ODL_APERTIRow odl_aperto)
        {
            CaricoRepartoModel caricoRepartoModel = new CaricoRepartoModel();
            caricoRepartoModel.Azienda = odl_aperto.IsAZIENDANull() ? string.Empty : odl_aperto.AZIENDA;
            caricoRepartoModel.Destipolancio = odl_aperto.IsDESTIPOLANCIONull() ? string.Empty : odl_aperto.DESTIPOLANCIO;
            caricoRepartoModel.Codicetipoo = odl_aperto.IsCODICETIPOONull() ? string.Empty : odl_aperto.CODICETIPOO;
            caricoRepartoModel.Ragionesoc = odl_aperto.IsRAGIONESOCNull() ? string.Empty : odl_aperto.RAGIONESOC.Trim();
            caricoRepartoModel.Nummovfase = odl_aperto.IsNUMMOVFASENull() ? string.Empty : odl_aperto.NUMMOVFASE;
            caricoRepartoModel.Nomecommessa = odl_aperto.IsNOMECOMMESSANull() ? string.Empty : odl_aperto.NOMECOMMESSA;
            caricoRepartoModel.Segnalatore = odl_aperto.IsSEGNALATORENull() ? string.Empty : odl_aperto.SEGNALATORE;
            caricoRepartoModel.Codtipomovfase = odl_aperto.IsCODTIPOMOVFASENull() ? string.Empty : odl_aperto.CODTIPOMOVFASE;
            caricoRepartoModel.Modello_Lancio = odl_aperto.IsMODELLO_LANCIONull() ? string.Empty : odl_aperto.MODELLO_LANCIO;
            caricoRepartoModel.Modello_Wip = odl_aperto.IsMODELLO_WIPNull() ? string.Empty : odl_aperto.MODELLO_WIP;
            caricoRepartoModel.Elencofasi = odl_aperto.IsELENCOFASINull() ? string.Empty : odl_aperto.ELENCOFASI;
            caricoRepartoModel.Datamovfase = odl_aperto.IsDATAMOVFASENull() ? new DateTime(1900, 1, 1) : odl_aperto.DATAMOVFASE;
            caricoRepartoModel.Qta = odl_aperto.IsQTANull() ? 0 : odl_aperto.QTA;
            caricoRepartoModel.Qtadater = odl_aperto.IsQTADATERNull() ? 0 : odl_aperto.QTADATER;
            return caricoRepartoModel;
        }

        public byte[] CreaExcelCaricoLavoro(string reparto)
        {

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillODL_APERTI(_ds, reparto);

            ExcelHelper eh = new ExcelHelper();
            return eh.CaricoLavoroExcel(_ds);

        }

        public byte[] CreaExcelBolleVendite(DateTime inizio, DateTime fine)
        {

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillBOLLE_VENDITA(inizio, fine, _ds);

            ExcelHelper eh = new ExcelHelper();
            return eh.BolleVenditaExcel(_ds);

        }

        public byte[] CreaExcelReportQuantita()
        {
            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillREPORTQUANTITA(_ds);

            ExcelHelper eh = new ExcelHelper();
            return eh.ReportQuantitaExcel(_ds);
        }

        public byte[] CreaExcelOrdiniAttivi(List<OrdiniAttiviModel> lista)
        {
            ExcelHelper eh = new ExcelHelper();
            return eh.ReportOrdiniAttiviExcel(lista);
        }
        public List<string> EstraiRepartiODL_Aperti()
        {

            using (ReportBusiness bReport = new ReportBusiness())
                return bReport.EstraiReportQuantita(_ds);
        }

        public List<string> EstraiReportQuantita()
        {

            using (ReportBusiness bReport = new ReportBusiness())
                return bReport.EstraiReportQuantita(_ds);
        }



    }
}
