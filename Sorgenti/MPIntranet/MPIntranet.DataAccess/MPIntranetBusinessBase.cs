﻿using MPIntranet.DataAccess.Core;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess
{
    public class MPIntranetBusinessBase:BusinessBase
    {
        protected static string ConnectionName
        {
            get
            {
                return "MPI";
            }
        }

        protected static string ConnectionString
        {
            get
            {
                ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[ConnectionName];
                return c.ConnectionString;
            }
        }
        protected string _connectionString;
        public MPIntranetBusinessBase()
        {
            _connectionString = ConnectionString;
        }

        protected override IDbConnection OpenConnection(string contextName)
        {
            //  SqlConnection con = new SqlConnection(_connectionString);
            OracleConnection con = new OracleConnection(_connectionString);
            con.Open();
            return con;
        }

        public void Rollback()
        {
            SetAbort();
        }

        //[DataContext]
        //public long GetID()
        //{
        //    MPIntranetAdapterBase a = new MPIntranetAdapterBase(DbConnection, DbTransaction);
        //    return a.GetID();
        //}
    }
}
