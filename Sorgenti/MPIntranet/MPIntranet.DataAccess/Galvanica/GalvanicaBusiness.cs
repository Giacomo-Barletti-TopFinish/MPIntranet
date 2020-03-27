using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Galvanica
{
    public class GalvanicaBusiness : MPIntranetBusinessBase
    {
        public GalvanicaBusiness() : base() { }

        [DataContext]
        public void FillImpianti(GalvanicaDS ds, bool soloNonCancellati)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillImpianti(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillTelai(GalvanicaDS ds, bool soloNonCancellati)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillTelai(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillVasche(GalvanicaDS ds, bool soloNonCancellati)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.FillVasche(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void UpdateTable(GalvanicaDS ds, string tabella)
        {
            GalvanicaAdapter a = new GalvanicaAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tabella, ds);
        }
    }

}
