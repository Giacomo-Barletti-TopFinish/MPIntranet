//using Microsoft.VisualStudio.DebuggerVisualizers;
using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System.Collections.Generic;

namespace MPIntranet.DataAccess.Report
{
    public class ReportBusiness : MPIntranetBusinessBase
    {
        public ReportBusiness() : base() { }

        [DataContext]
        public void FillODL_APERTI(ReportDS ds, string reparto)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            a.FillODL_APERTI(ds, reparto);
        }

        [DataContext]
        public List<string> EstraiRepartiODL_Aperti(ReportDS ds)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            return a.EstraiRepartiODL_Aperti(ds);
        }
    }

}