using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articoli
{
    public class ArticoliBusiness : MPIntranetBusinessBase
    {
        public ArticoliBusiness() : base() { }

        [DataContext]
        public void GetCicliBCDettaglio(ArticoliDS ds, string codiceTestata)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetCicliBCDettaglio(ds, codiceTestata);
        }

        [DataContext]
        public void GetCicliBCCommenti(ArticoliDS ds, string codiceTestata)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetCicliBCCommenti(ds, codiceTestata);
        }
        [DataContext]
        public void GetCicliBCTestata(ArticoliDS ds, string codiceTestata)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetCicliBCTestata(ds, codiceTestata);
        }

        [DataContext]
        public void GetDistinteBCDettaglio(ArticoliDS ds, string codiceTestata)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetDistinteBCDettaglio(ds, codiceTestata);
        }

        [DataContext]
        public void GetDistinteBCTestata(ArticoliDS ds, string codiceTestata)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetDistinteBCTestata(ds, codiceTestata);
        }

        [DataContext]
        public void FillArticoli(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillArticoli(ds, soloNonCancellati);
        }

        [DataContext]
        public void GetDistintaBase(ArticoliDS ds, int idDiba)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetDistintaBase(ds, idDiba);
        }
     
        [DataContext]
        public void FillDistintaBase(ArticoliDS ds, int idArticolo, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillDistintaBase(ds, idArticolo, soloNonCancellati);
        }
        [DataContext]
        public void FillArticoli(string anagrafica, ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillArticoli(anagrafica, ds, soloNonCancellati);
        }
        [DataContext]
        public void FillTask(ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillTask(ds);
        }
        [DataContext]
        public void FillItems(ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillItems(ds);
        }
        [DataContext]
        public void GetItem(ArticoliDS ds, string anagrafica)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetItem(ds,anagrafica);
        }
        [DataContext]
        public void FillAreeProduzione(ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillAreeProduzione(ds);
        }
        [DataContext]
        public void FillBrand(ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillBrand(ds);
        }

        [DataContext]
        public void FillTaskArea(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillTaskArea(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillTipiDistinta(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillTipiDistinta(ds, soloNonCancellati);
        }

        [DataContext]
        public void GetArticolo(ArticoliDS ds, int idArticolo)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetArticolo(ds, idArticolo);
        }
        [DataContext]
        public void TrovaArticoli(ArticoliDS ds, bool soloNonCancellati, int idBrand, string anagrafica, string descrizione, string codiceCliente, string colore)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.TrovaArticoli(ds, soloNonCancellati, idBrand, anagrafica, descrizione, codiceCliente, colore);
        }
        [DataContext]
        public void GetFASICICLO(ArticoliDS ds, int IdDiba, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetFASICICLO(ds, IdDiba,soloNonCancellati);
        }
        [DataContext]
        public void GetFASICICLOPERCOMPONENTE(ArticoliDS ds, int IdComponente, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetFASICICLOPERCOMPONENTE(ds, IdComponente, soloNonCancellati);
        }
        [DataContext]
        public void GetCOMPONENTI(ArticoliDS ds, int IdDiba, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.GetCOMPONENTI(ds, IdDiba,soloNonCancellati);
        }
        [DataContext(true)]
        public void UpdateTable(string tablename, ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
        [DataContext(true)]
        public void UpdateDistintaBaseTable(ArticoliDS ds)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.UpdateDistintaBaseTable(ds);
        }
        [DataContext(true)]
        public void UpdateComponentiTable(string tablename, DataRow[] drs)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.UpdateComponentiTable(tablename, drs);
        }
    }
}
