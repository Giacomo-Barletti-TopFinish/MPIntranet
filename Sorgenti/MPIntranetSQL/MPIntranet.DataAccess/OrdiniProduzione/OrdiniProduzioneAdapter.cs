using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.OrdiniProduzione
{
    public class OrdiniProduzioneAdapter : MPIntranetAdapterBase
    {
        public OrdiniProduzioneAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void FillArticoliOrdiniProduzione(OrdiniProduzioneDS ds)
        {
            string select = @"SELECT * FROM ArticoliOrdiniProduzione WHERE STATUS =$P<STATUS> order by [Prod_ Order No_] ";


            ParamSet ps = new ParamSet();
            ps.AddParam("STATUS", DbType.Int32, StatoOrdiniProduzione.rilasciato);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ArticoliOrdiniProduzione);
            }
        }

        public void FillFasiOrdiniProduzione(OrdiniProduzioneDS ds, string codiceOrdineProduzione)
        {
            string select = @"SELECT * FROM FasiOrdiniProduzione WHERE [Prod_ Order No_] = $P<CODICE>";


            ParamSet ps = new ParamSet();
            ps.AddParam("CODICE", DbType.String, codiceOrdineProduzione);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.FasiOrdiniProduzione);
            }
        }
        public void FillVersamentiFasiOrdiniProduzione(OrdiniProduzioneDS ds, string codiceOrdineProduzione)
        {
            string select = @"SELECT * FROM VersamentiFasiOrdiniProduzione WHERE [Document No_] = $P<CODICE>";


            ParamSet ps = new ParamSet();
            ps.AddParam("CODICE", DbType.String, codiceOrdineProduzione);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.VersamentiFasiOrdiniProduzione);
            }
        }
    }
}
