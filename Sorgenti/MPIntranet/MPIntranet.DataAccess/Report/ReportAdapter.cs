using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Report
{
    public class ReportAdapter : MPIntranetAdapterBase
    {
        public ReportAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
         base(connection, transaction)
        { }

        public void FillReport(ReportDS ds, bool soloNonCancellati)
        {
            string select = @"select * from odl_aperti where datamovfase > to_date('31/12/2019','dd/mm/yyyy') ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N' ";

            select += "ORDER BY RIFERIMENTI";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
              //  da.Fill(ds.REPORT);
            }
        }
    }
}