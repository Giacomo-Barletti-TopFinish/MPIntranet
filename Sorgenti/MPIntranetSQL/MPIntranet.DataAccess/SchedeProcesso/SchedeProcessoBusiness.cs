using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.SchedeProcesso
{
    public class SchedeProcessoBusiness : MPIntranetBusinessBase
    {
        public SchedeProcessoBusiness() : base() { }

        [DataContext]
        public void FillSPControlli(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPControlli(ds, soloNonCancellati);
        }

        [DataContext]
        public void GetControllo(SchedeProcessoDS ds, int idSPControllo)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetControllo(ds, idSPControllo);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}
