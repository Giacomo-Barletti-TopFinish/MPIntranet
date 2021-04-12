using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Documenti
{
    public class DocumentiAdapter : MPIntranetAdapterBase
    {
        public DocumentiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
        base(connection, transaction)
        { }

        public void FillTipiDocumento(DocumentiDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM TIPIDOCUMENTO ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += " ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TIPIDOCUMENTO);
            }
        }

    }
}
