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
                ordineAttivoModel.Valore = valore;
                ordineAttivoModel.ValoreNonSpedito = valoreNonSpedito;
                ordineAttivoModel.ValoreAnnullato = valoreAnnullato;
                ordineAttivoModel.ValoreScaduto = valoreNonSpeditoScaduto;
                ordineAttivoModel.ValoreNonScaduto = valoreNonSpeditoNonScaduto;
                ordineAttivoModel.PercScadutoCliente = scadutoPerCliente;
                ordineAttivoModel.PercScadutoSulTotale = scadutoSulTotale;

                lista.Add(ordineAttivoModel);
            }

            foreach (string cliente in _ds.ORDINIATTIVI.Where(x => x.IsSEGNALATORENull()).Select(x => x.CLIENTE))
            {
                decimal valore = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALORE);
                decimal quantita = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTATOT);
                decimal valoreAnnullato = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALOREANN);
                decimal quantitaAnnullato = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTAANN);
                decimal valoreNonSpedito = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpedita = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente).Sum(x => x.QTANOSPE);
                decimal valoreNonSpeditoScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "SI").Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpeditaScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "SI").Sum(x => x.QTANOSPE);
                decimal valoreNonSpeditoNonScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "NO").Sum(x => x.VALORENOSPE);
                decimal quantitaNonSpeditaNonScaduto = _ds.ORDINIATTIVI.Where(x => x.CLIENTE == cliente && x.SCADUTO == "NO").Sum(x => x.QTANOSPE);
                decimal scadutoPerCliente = valoreNonSpedito == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreNonSpedito, 2) * 100;
                decimal scadutoSulTotale = valoreTotaleScaduti == 0 ? 0 : Math.Round(valoreNonSpeditoScaduto / valoreTotaleScaduti, 2) * 100;
                OrdiniAttiviModel ordineAttivoModel = new OrdiniAttiviModel();
                ordineAttivoModel.Cliente = cliente;
                ordineAttivoModel.Quantita = quantita;
                ordineAttivoModel.QuantitaNonSpedita = quantitaNonSpedita;
                ordineAttivoModel.QuantitaAnnullata = quantitaAnnullato;
                ordineAttivoModel.Valore = valore;
                ordineAttivoModel.ValoreNonSpedito = valoreNonSpedito;
                ordineAttivoModel.ValoreAnnullato = valoreAnnullato;
                ordineAttivoModel.ValoreScaduto = valoreNonSpeditoScaduto;
                ordineAttivoModel.ValoreNonScaduto = valoreNonSpeditoNonScaduto;
                ordineAttivoModel.PercScadutoCliente = scadutoPerCliente;
                ordineAttivoModel.PercScadutoSulTotale = scadutoSulTotale;

                lista.Add(ordineAttivoModel);
            }

            return lista;


        }

        private ReportQuantitaModel CreaReportQuantitaModel(ReportDS.REPORTQUANTITARow reportquantita)
        {
            ReportQuantitaModel reportQuantitaModel = new ReportQuantitaModel();
            reportQuantitaModel.Codiceclifo = reportquantita.CODICECLIFO;
            reportQuantitaModel.Ragionesoc = reportquantita.RAGIONESOC;
            reportQuantitaModel.Somma = reportquantita.SOMMA;
            reportQuantitaModel.Perc = reportquantita.PERC;
            return reportQuantitaModel;
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

        public byte[] CreaExcelReportQuantita()
        {
            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillREPORTQUANTITA(_ds);

            ExcelHelper eh = new ExcelHelper();
            return eh.ReportQuantitaExcel(_ds);
        }

        public byte[] CreaExcelOrdiniAttivi(List<OrdiniAttiviModel>lista)
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
