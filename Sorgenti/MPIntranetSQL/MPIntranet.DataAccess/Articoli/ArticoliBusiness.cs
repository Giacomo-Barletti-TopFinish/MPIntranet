using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articoli
{
    public class ArticoliBusiness : MPIntranetBusinessBase
    {
        public ArticoliBusiness() : base() { }

        [DataContext]
        public void FillArticoli(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillArticoli(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillArticoli(string anagrafica, ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillArticoli(anagrafica, ds, soloNonCancellati);
        }

        [DataContext]
        public void FillBrand(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillBrand(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}
