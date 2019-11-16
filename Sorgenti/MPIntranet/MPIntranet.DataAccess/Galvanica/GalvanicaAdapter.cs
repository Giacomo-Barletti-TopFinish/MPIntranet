using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Galvanica
{
    public class GalvanicaAdapter : MPIntranetAdapterBase
    {
        public GalvanicaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
          base(connection, transaction)
        { }

        public void FillImpianti(GalvanicaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM IMPIANTI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.IMPIANTI);
            }
        }

        public void FillVasche(GalvanicaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM VASCHE ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N' ";

            select += "ORDER BY DESCRIZIONEBREVE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.VASCHE);
            }
        }

      
        public void UpdateTable(string tablename, GalvanicaDS ds)
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

