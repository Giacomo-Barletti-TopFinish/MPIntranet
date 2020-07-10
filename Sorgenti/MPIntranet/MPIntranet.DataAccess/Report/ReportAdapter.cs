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

        public void FillODL_APERTI(ReportDS ds, String reparto)
        {
            string select = @"select * from ituser.odl_aperti where datamovfase > to_date('31/12/2019','dd/mm/yyyy') AND CODTIPOMOVFASE <>'ODP'";

            if (reparto != ElementiVuoti.TuttiReparti.ToString())
                select += " AND ragionesoc = $P<REPARTO> ";

            select += " ORDER BY datamovfase";

            ParamSet ps = new ParamSet();
            ps.AddParam("REPARTO", DbType.String, reparto);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ODL_APERTI);
            }
        }

        public List<string> EstraiRepartiODL_Aperti(ReportDS ds)
        {
            string query = @"select distinct ragionesoc from ituser.odl_aperti where datamovfase > to_date('31/12/2019','dd/mm/yyyy') ORDER BY RAGIONESOC";

            using (DbCommand cmd = BuildCommand(query))
            using (IDataReader reader = cmd.ExecuteReader())
            {
                List<string> returnedData = new List<string>();
                while (reader.Read())
                    returnedData.Add(reader.GetString(0));
                return returnedData;
            }
        }

        public void FillREPORTQUANTITA(ReportDS ds)
        {
            string query = @" select CODICECLIFO, trim(ragionesoc) as RAGIONESOC,elencofasi, sum (qtadater) as SOMMA,round(sum (qtadater)/(select sum(qtadater) 
            from ITUSER.odl_aperti where 
            qtadater > 0 AND CODTIPOMOVFASE <>'ODP' and CODICECLIFO <>'02350'
and datamovfase > to_date('31/12/2019','dd/mm/yyyy')),4)*100 as PERC
from ITUSER.odl_aperti
--where substr(codiceclifo,1,1)= '0' 
where datamovfase > to_date('31/12/2019','dd/mm/yyyy')
and qtadater > 0
AND CODTIPOMOVFASE <>'ODP'
and CODICECLIFO <>'02350'
group by codiceclifo , ragionesoc,elencofasi
order by sum(qta) desc";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.REPORTQUANTITA);
            }

        }

        public void FillORDINIATTIVI(ReportDS ds)
        {
            string query = @"select * from ITUSER.ORDINIATTIVI ";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.ORDINIATTIVI);
            }

        }
    }
}