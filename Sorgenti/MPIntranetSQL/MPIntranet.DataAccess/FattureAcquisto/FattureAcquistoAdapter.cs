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


    }
}
