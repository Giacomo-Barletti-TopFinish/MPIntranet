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
                bReport.FillODL_APERTI(_ds,reparto);

            foreach (ReportDS.ODL_APERTIRow odl_aperto in _ds.ODL_APERTI)
                caricoLavoro.Add(CreaCaricoRepartoModel(odl_aperto));

                return caricoLavoro;

        }

        public List<ReportQuantitaModel> CreaListaReportQuantita(string ragionesoc)
        {
            List<ReportQuantitaModel> reportquantitalist = new List<ReportQuantitaModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillREPORTQUANTITA(_ds, ragionesoc);

            //foreach (ReportDS.REPORTQUANTITARow reportquantita in _ds.REPORTQUANTITA)
            //    reportquantitalist.Add(ReportQuantitaModel(reportquantita));

            return reportquantitalist;

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
            caricoRepartoModel.Azienda = odl_aperto.IsAZIENDANull()?string.Empty:odl_aperto.AZIENDA;
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
            caricoRepartoModel.Datamovfase = odl_aperto.IsDATAMOVFASENull() ? new DateTime (1900,1,1): odl_aperto.DATAMOVFASE;
            caricoRepartoModel.Qta = odl_aperto.IsQTANull() ? 0: odl_aperto.QTA;
            caricoRepartoModel.Qtadater = odl_aperto.IsQTADATERNull() ? 0: odl_aperto.QTADATER;
            return caricoRepartoModel;
        }

        public byte[] CreaExcelCaricoLavoro(string reparto)
        {

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillODL_APERTI(_ds,reparto);

            ExcelHelper eh = new ExcelHelper();
            return eh.CaricoLavoroExcel(_ds);

        }

        public byte[] CreaExcelReportQuantita(string ragionesoc)
        {
            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillREPORTQUANTITA(_ds, ragionesoc);

            ExcelHelper eh = new ExcelHelper();
            return eh.ReportQuantitaExcel(_ds);
        }

        public List<string> EstraiRepartiODL_Aperti()
        {

            using (ReportBusiness bReport = new ReportBusiness())
               return bReport.EstraiRepartiODL_Aperti(_ds);
        }

    }
}
