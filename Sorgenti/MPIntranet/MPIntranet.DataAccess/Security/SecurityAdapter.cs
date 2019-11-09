﻿using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Security
{
    public class SecurityAdapter : MPIntranetAdapterBase
    {
        public SecurityAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
            base(connection, transaction)
        { }


        public void SaveToken(string account, string token, int durata, string ipAddress)
        {
            string insert = @"insert into $T{TOKEN} (UTENTE,DATACREAZIONE,TOKEN,DURATA,IPADDRESS)
                                values ($P{UTENTE},$P{DATACREAZIONE},$P{TOKEN},$P{DURATA},$P{IPADDRESS})";

            ParamSet ps = new ParamSet();
            ps.AddParam("UTENTE", DbType.String, account);
            ps.AddParam("DATACREAZIONE", DbType.DateTime, DateTime.Now);
            ps.AddParam("TOKEN", DbType.String, token);
            ps.AddParam("DURATA", DbType.Int32, durata);
            ps.AddParam("IPADDRESS", DbType.String, ipAddress);
            using (DbCommand cmd = BuildCommand(insert, ps))
            {
                object o = cmd.ExecuteNonQuery();
            }
        }

        public void GetToken(SecurityDS ds, string token)
        {
            string select = @"SELECT * FROM TOKEN where TOKEN = $P{token}";
            ParamSet ps = new ParamSet();
            ps.AddParam("token", DbType.String, token);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.TOKEN);
            }
        }

        public void FillMenu(SecurityDS ds)
        {
            string select = @"SELECT * FROM MENU ORDER BY SEQUENZA";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MENU);
            }
        }

        public void FillAccountMenu(string account, SecurityDS ds)
        {
            string select = @"SELECT * FROM ABILITAZIONI WHERE UTENTE = $P{UTENTE}";

            ParamSet ps = new ParamSet();
            ps.AddParam("UTENTE", DbType.String, account);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ABILITAZIONI);
            }
        }

        public void UpdateSecurityDSTable(string tablename, SecurityDS ds)
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
