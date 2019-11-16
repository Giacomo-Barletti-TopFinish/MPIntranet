using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articolo
{
    public class ArticoloBusiness : MPIntranetBusinessBase
    {
        public ArticoloBusiness() : base() { }


        [DataContext]
        public void FillArticoli(ArticoloDS ds, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillArticoli(ds,soloNonCancellati);
        }


        [DataContext(true)]
        public void UpdateTable(string tablename, ArticoloDS ds)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

    }
}
