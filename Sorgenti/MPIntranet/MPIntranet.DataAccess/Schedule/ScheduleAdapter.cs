using MPIntranet.DataAccess;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Schedule
{
    public class ScheduleAdapter : MPIntranetAdapterBase
    {
        public ScheduleAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :

            base(connection, transaction)
            { }


        public void FillSchedule(ScheduleServicesDS ds, bool soloNonEseguiti)
        {
            string query = @"SELECT * FROM SCHEDULE";
            if (soloNonEseguiti)
                query += "WHERE ESEGUITA ='N' ";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.SCHEDULE);
            }

        }

        internal void UpdateTable(string tablename, ScheduleServicesDS ds)
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
   
    

