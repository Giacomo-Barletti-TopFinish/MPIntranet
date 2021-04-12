using MPIntranet.DataAccess.Core;
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

    public class DocumentiBusiness : MPIntranetBusinessBase
    {
        public DocumentiBusiness() : base() { }

        [DataContext]
        public void FillTipiDocumento(DocumentiDS ds, bool soloNonCancellati)
        {
            DocumentiAdapter a = new DocumentiAdapter(DbConnection, DbTransaction);
            a.FillTipiDocumento(ds, soloNonCancellati);
        }

    }
}
