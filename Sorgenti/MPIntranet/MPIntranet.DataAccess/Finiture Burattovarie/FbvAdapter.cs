using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Finiture_Burattovarie
{
    public class FbvAdapter : MPIntranetAdapterBase
    {
        public FbvAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
          base(connection, transaction)
        { }

        public void FillAttributi(FBVDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FBVATTRIBUTI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FBVATTRIBUTI);
            }
        }

        public void FillFasi(FBVDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FBVFASI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FBVFASI);
            }
        }
        public void FillProcessi(FBVDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FBVPROCESSI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FBVPROCESSI);
            }

        }

        public void FillProprieta(FBVDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FBVPROPRIETA ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FBVPROPRIETA);
            }
        }

        public void FillGruppi(FBVDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FBVGRUPPIPROPRIETA ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FBVGRUPPIPROPRIETA);
            }
        }



        public void UpdateTable(string tablename, FBVDS ds)
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

