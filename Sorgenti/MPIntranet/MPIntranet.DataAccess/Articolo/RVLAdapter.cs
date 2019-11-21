using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articolo
{
    public class RVLAdapter : MPIntranetAdapterBase
    {
        public RVLAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
            base(connection, transaction)
        { }

        public void FillMagazz(RVLDS ds)
        {
            string select = @"SELECT * FROM GRUPPO.MAGAZZ ";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void FillMagazz(RVLDS ds, string modello)
        {
            string select = @"SELECT * FROM GRUPPO.MAGAZZ WHERE MODELLO LIKE $P<MODELLO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("MODELLO", DbType.String, modello);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

    }
}
