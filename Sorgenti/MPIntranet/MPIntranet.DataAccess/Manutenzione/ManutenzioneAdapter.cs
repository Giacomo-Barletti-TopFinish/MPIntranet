﻿using MPIntranet.Entities;
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

        public void FillDitte(ManutenzioneDS ds)
        {
            string query = "select * from ditte order by ragionesociale";

            using (DbDataAdapter da = BuildDataAdapter(query))
            {
                da.Fill(ds.DITTE);
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