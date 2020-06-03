using MPIntranet.DataAccess.Report;
using MPIntranet.Entities;
using MPIntranet.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Report
    {
        private ReportDS _ds = new ReportDS();
        public List<CaricoRepartoModel> CreaListaCaricoReparto(int idReparto)
        {
            List<CaricoRepartoModel> caricoLavoro = new List<CaricoRepartoModel>();

            using (ReportBusiness bReport = new ReportBusiness())
                bReport.FillODL_APERTI(_ds);

            foreach (ReportDS.ODL_APERTIRow odl_aperto in _ds.ODL_APERTI)
                caricoLavoro.Add(CreaCaricoRepartoModel(odl_aperto));

                return caricoLavoro;

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

    }
}
