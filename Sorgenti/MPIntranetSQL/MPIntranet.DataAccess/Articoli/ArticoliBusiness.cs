using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articoli
{
    public class ArticoliBusiness : MPIntranetBusinessBase
    {
        public ArticoliBusiness() : base() { }

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
        public void FillBrand(ArticoliDS ds, bool soloNonCancellati)
        {
            ArticoliAdapter a = new ArticoliAdapter(DbConnection, DbTransaction);
            a.FillBrand(ds, soloNonCancellati);
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
    }
}
