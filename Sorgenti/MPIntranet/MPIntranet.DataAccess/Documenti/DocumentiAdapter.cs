using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Documenti
{
   public  class DocumentiAdapter: MPIntranetAdapterBase
    {
        public DocumentiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
base(connection, transaction)
        { }

        public void FillDocumenti(DocumentiDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT IDDOCUMENTO,IDTIPODOCUMENTO,FILENAME,IDESTERNA,TABELLAESTERNA FROM DOCUMENTI ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.DOCUMENTI);
            }
        }
        public void UpdateTable(string tablename, DocumentiDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablename);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                a.ContinueUpdateOnError = false;
                DataTable dt = ds.Tables[tablename];
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();
                a.Update(dt);
            }
        }
    }
}
