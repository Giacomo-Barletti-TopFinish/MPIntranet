using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.FattureAcquisto
{
    public class FattureAcquistoAdapter : MPIntranetAdapterBase
    {
        public FattureAcquistoAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void FillFornitoriFattureAcquisto(FattureAcquistoDS ds)
        {
            string select = @"SELECT * FROM FornitoriFattureAquisto order by [EOS Pay-to Name]";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FornitoriFattureAquisto);
            }
        }

        public void FillFattureAcquisto(FattureAcquistoDS ds, string codiceFornitore)
        {
            string select = @"SELECT * FROM FattureAcquistoTestata where [EOS Pay-to Vendor No_] = $P<CODICE>  order by [EOS Receipt Date] desc";

            ParamSet ps = new ParamSet();
            ps.AddParam("CODICE", DbType.String, codiceFornitore);
            using (DbDataAdapter da = BuildDataAdapter(select,ps))
            {
                da.Fill(ds.FattureAcquistoTestata);
            }
        }

        public void FillFattureAcquistoDettaglio(FattureAcquistoDS ds, int IdDocumento, int tipoDocumento)
        {
            string select = @"SELECT * FROM FattureAcquistoDettaglio where [EOS Source Doc_ Entry No_] = $P<IDDOCUMENTO> AND [EOS Document Type] = $P<TIPODOCUMENTO> order by [EOS Line No_] ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDDOCUMENTO", DbType.Int32, IdDocumento);
            ps.AddParam("TIPODOCUMENTO", DbType.Int32, tipoDocumento);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.FattureAcquistoDettaglio);
            }
        }
    }
}
