//using Microsoft.VisualStudio.DebuggerVisualizers;
using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPIntranet.DataAccess.Report
{
    public class ReportBusiness : MPIntranetBusinessBase
    {
        public ReportBusiness() : base() { }

        [DataContext]
        public void FillODL_APERTI(ReportDS ds)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            a.FillODL_APERTI(ds);
        }
    }

}