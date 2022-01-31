using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.FattureAcquisto
{
    public class FattureAcquistoBusiness : MPIntranetBusinessBase
    {
        public FattureAcquistoBusiness() : base() { }

        [DataContext]
        public void FillFornitoriFattureAcquisto(FattureAcquistoDS ds)
        {
            FattureAcquistoAdapter a = new FattureAcquistoAdapter(DbConnection, DbTransaction);
            a.FillFornitoriFattureAcquisto(ds);
        }

    }
}
