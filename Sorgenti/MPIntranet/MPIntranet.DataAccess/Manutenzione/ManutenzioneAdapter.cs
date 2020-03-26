using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Manutenzione
{
    public class ManutenzioneAdapter : MPIntranetAdapterBase
    {
        public ManutenzioneAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
    base(connection, transaction)
        { }

        public void FillDitte(ManutenzioneDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT * FROM DITTE ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            query += " order by ragionesociale";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.DITTE);
            }
        }

        public void FillMacchine(ManutenzioneDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT * FROM MACCHINE ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            query += " order by descrizione";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.MACCHINE);
            }
        }

        public void FillInterventi(ManutenzioneDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT * FROM INTERVENTI ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            query += " order by descrizione";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.INTERVENTI);
            }
        }

        public void FillManutentori(ManutenzioneDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT * FROM MANUTENTORI ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            query += " order by nomecognome";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.MANUTENTORI);
            }
        }
        public void FillRiferimenti(ManutenzioneDS ds, bool soloNonCancellati)
        {
            string query = @"SELECT * FROM RIFERIMENTI ";
            if (soloNonCancellati)
                query += "WHERE CANCELLATO = 'N' ";

            query += " order by riferimento";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.RIFERIMENTI);

            }
        }

        public void UpdateTable(string tablename, ManutenzioneDS ds)
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














    

