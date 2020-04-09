using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Anagrafica
{
    public class AnagraficaBusiness : MPIntranetBusinessBase
    {
        public AnagraficaBusiness() : base() { }

        [DataContext]
        public void FillBrand(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillBrand(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillReparti(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillReparti(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillFasi(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillFasi(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillColori(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillColori(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillTipiDocumento(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillTipiDocumento(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillMateriali(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillMateriali(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillTipiProdotto(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillTipiProdotto(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillMateriePrime(AnagraficaDS ds, bool soloNonCancellati)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.FillMateriePrime(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void UpdateTable(AnagraficaDS ds, string tabella)
        {
            AnagraficaAdapter a = new AnagraficaAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tabella, ds);
        }
    }
}
