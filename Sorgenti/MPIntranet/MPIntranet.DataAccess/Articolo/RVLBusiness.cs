
using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using MPIntranet.Models.Articolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articolo
{
    public class RVLBusiness : MPIntranetBusinessBase
    {
        public RVLBusiness() : base() { }


        [DataContext]
        public void FillMagazz(RVLDS ds)
        {
            RVLAdapter a = new RVLAdapter(DbConnection, DbTransaction);
            a.FillMagazz(ds);
        }

        [DataContext]
        public void FillMagazz(RVLDS ds, string modello)
        {
            RVLAdapter a = new RVLAdapter(DbConnection, DbTransaction);
            a.FillMagazz(ds, modello);
        }
    }
}
