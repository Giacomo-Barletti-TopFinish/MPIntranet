﻿using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Security
{
    public class SecurityBusiness : MPIntranetBusinessBase
    {
        public SecurityBusiness() : base() { }

        [DataContext(true)]
        public void SaveToken(string account, string token, int durata, string ipAddress)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.SaveToken(account, token, durata, ipAddress);
        }

        [DataContext(true)]
        public void SaveMessaggioLog(string messaggio, string stack, string modulo, string tipoMessaggio)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.SaveMessaggioLog(messaggio, stack, modulo, tipoMessaggio);
        }
        [DataContext]
        public void GetToken(SecurityDS ds, string token)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.GetToken(ds, token);
        }

        [DataContext]
        public void EstraiConfigurazioni(SecurityDS ds, string codice)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.EstraiConfigurazioni(ds, codice);
        }
        [DataContext]
        public void FillMenu(SecurityDS ds)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.FillMenu(ds);
        }

        [DataContext]
        public void FillAccountMenu(string account, SecurityDS ds)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.FillAccountMenu(account, ds);
        }

        [DataContext(true)]
        public void SalvaMenuUtente(SecurityDS ds)
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            a.UpdateSecurityDSTable(ds.ABILITAZIONI.TableName, ds);
        }

        [DataContext]
        public List<string> EstraiListaUtentiAbilitati()
        {
            SecurityAdapter a = new SecurityAdapter(DbConnection, DbTransaction);
            return a.EstraiListaUtentiAbilitati();
        }
    }
}
