using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Documenti
{
    public class DocumentiBusiness: MPIntranetBusinessBase
    {
        public DocumentiBusiness() : base() { }

        [DataContext]
        public void FillDocumenti(DocumentiDS ds, bool soloNonCancellati)
        {
            DocumentiAdapter a = new DocumentiAdapter(DbConnection, DbTransaction);
            a.FillDocumenti(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, DocumentiDS ds)
        {
            DocumentiAdapter a = new DocumentiAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}
