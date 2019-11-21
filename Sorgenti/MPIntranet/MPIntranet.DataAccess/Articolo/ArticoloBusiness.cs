using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using MPIntranet.Models.Articolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articolo
{
    public class ArticoloBusiness : MPIntranetBusinessBase
    {
        public ArticoloBusiness() : base() { }


        [DataContext]
        public void FillArticoli(ArticoloDS ds, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillArticoli(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillArticoli(ArticoloDS ds, List<decimal> idArticoli, bool soloNonCancellati)
        {
            List<decimal> articoliPresenti = ds.ARTICOLI.Select(x => x.IDARTICOLO).Distinct().ToList();
            List<decimal> articoliMancanti = idArticoli.Except(articoliPresenti).ToList();

            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            while (articoliMancanti.Count > 0)
            {
                List<decimal> articoliDaCaricare;
                if (articoliMancanti.Count > 999)
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, 999);
                    articoliMancanti.RemoveRange(0, 999);
                }
                else
                {
                    articoliDaCaricare = articoliMancanti.GetRange(0, articoliMancanti.Count);
                    articoliMancanti.RemoveRange(0, articoliMancanti.Count);
                }
                a.FillArticoli(ds, articoliDaCaricare, soloNonCancellati);
            }
        }

        [DataContext]
        public void FillArticoli(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
        {
            FillArticoli(ds, new List<decimal>(new decimal[] { idArticolo }), soloNonCancellati);
        }

        [DataContext]
        public List<decimal> TrovaArticoli(bool soloNonCancellati, decimal idBrand, string codiceSam, string modello, string codiceCliente, string codiceProvvisorio)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            return a.TrovaArticoli(soloNonCancellati, idBrand, codiceSam, modello, codiceCliente, codiceProvvisorio);
        }

        [DataContext]
        public List<decimal> TrovaArticoliPerColore(bool soloNonCancellati, string codiceColoreInterno, string codiceColoreCliente)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            return a.TrovaArticoliPerColore(soloNonCancellati, codiceColoreInterno, codiceColoreCliente);
        }


        [DataContext(true)]
        public void UpdateTable(string tablename, ArticoloDS ds)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

    }
}
