using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Finiture_Burattovarie
{
    public class FbvBusiness : MPIntranetBusinessBase
    {
        public FbvBusiness() : base() { }

        [DataContext]
        public void FillProcessi(FBVDS ds, bool soloNonCancellati)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.FillProcessi(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillFasi(FBVDS ds, bool soloNonCancellati)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.FillFasi(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillProprieta(FBVDS ds, bool soloNonCancellati)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.FillProprieta(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillAttributi(FBVDS ds, bool soloNonCancellati)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.FillAttributi(ds, soloNonCancellati);
        }
        public void FillGruppi(FBVDS ds, bool soloNonCancellati)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.FillGruppi(ds, soloNonCancellati);
        }
        [DataContext(true)]
        public void UpdateTable(FBVDS ds, string tabella)
        {
            FbvAdapter a = new FbvAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tabella, ds);
        }

    }
    
    
}
