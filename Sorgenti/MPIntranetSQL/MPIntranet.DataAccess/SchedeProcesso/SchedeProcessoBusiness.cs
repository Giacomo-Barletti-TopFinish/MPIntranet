﻿using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.SchedeProcesso
{
    public class SchedeProcessoBusiness : MPIntranetBusinessBase
    {
        public SchedeProcessoBusiness() : base() { }

        [DataContext]
        public void FillSPControlli(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPControlli(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillSPMaster(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPMaster(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillSPMaster(string areaProduzione, string task, SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPMaster(areaProduzione, task, ds, soloNonCancellati);
        }
        [DataContext]
        public void FillValoriSchede(SchedeProcessoDS ds, int idSPScheda, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillValoriSchede(ds, idSPScheda, soloNonCancellati);
        }
        [DataContext]
        public void FillSPScheda(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPScheda(ds, soloNonCancellati);
        }
        [DataContext]
        public void GetSPScheda(int IDScheda, SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetSPScheda(IDScheda, ds);
        }

        [DataContext]
        public void FillSPScheda(string IDSPMaster, SchedeProcessoDS ds, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillSPScheda(IDSPMaster, ds, soloNonCancellati);
        }
        [DataContext]
        public void GetControllo(SchedeProcessoDS ds, int idSPControllo)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetControllo(ds, idSPControllo);
        }

        [DataContext]
        public void GetSPMaster(SchedeProcessoDS ds, int idSPMaster)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetSPMaster(ds, idSPMaster);
        }

        [DataContext]
        public void GetElemento(SchedeProcessoDS ds, int idSPElemento)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetElemento(ds, idSPElemento);
        }
        [DataContext]
        public void GetValoreScheda(SchedeProcessoDS ds, int idSPValoreScheda)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetValoreScheda(ds, idSPValoreScheda);
        }
        [DataContext]
        public void FillElementi(SchedeProcessoDS ds, int idSPMaster, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillElementi(ds, idSPMaster, soloNonCancellati);
        }

        [DataContext]
        public void FillElementiLista(SchedeProcessoDS ds, int idSPControllo, bool soloNonCancellati)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.FillElementiLista(ds, idSPControllo, soloNonCancellati);
        }
        [DataContext]
        public void GetElementoLista(SchedeProcessoDS ds, int idElementoLista)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetElementoLista(ds, idElementoLista);
        }

        [DataContext]
        public void GetSPScheda(SchedeProcessoDS ds, int idScheda)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.GetSPScheda(idScheda, ds);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
        [DataContext(true)]
        public void UpdateTableSPControlli(SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.UpdateTableSPControlli(ds);
        }
        [DataContext(true)]
        public void UpdateTableSPMaster(SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.UpdateTableSPMaster(ds);
        }

        [DataContext(true)]
        public void UpdateTableSPScheda(SchedeProcessoDS ds)
        {
            SchedeProcessoAdapter a = new SchedeProcessoAdapter(DbConnection, DbTransaction);
            a.UpdateTableSPScheda(ds);
        }
    }
}
