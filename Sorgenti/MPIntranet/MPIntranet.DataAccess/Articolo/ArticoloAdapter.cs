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
    public class ArticoloAdapter : MPIntranetAdapterBase
    {
        public ArticoloAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
            base(connection, transaction)
        { }

        public void FillArticoli(ArticoloDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM ARTICOLO ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N' ";

            select += "ORDER BY MODELLO";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.ARTICOLI);
            }
        }

        public void UpdateTable(string tablename, ArticoloDS ds)
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
