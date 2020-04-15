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
        public string GetImageNameFile(string idMagazz)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            return a.GetImageNameFile(idMagazz);
        }

        [DataContext]
        public void FillArticoli(ArticoloDS ds, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillArticoli(ds, soloNonCancellati);
        }

        [DataContext]
        public void FillProdottiFiniti(ArticoloDS ds, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillProdottiFiniti(ds, soloNonCancellati);
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
        public void FillProdottiFiniti(ArticoloDS ds, decimal idProdottoFinito, bool soloNonCancellati)
        {
            FillProdottiFiniti(ds, new List<decimal>(new decimal[] { idProdottoFinito }), soloNonCancellati);         
        }

        [DataContext]
        public void FillProdottiFiniti(ArticoloDS ds, List<decimal> idProdottiFinito, bool soloNonCancellati)
        {
            List<decimal> prodottiPresenti = ds.PRODOTTIFINITI.Select(x => x.IDPRODOTTOFINITO).Distinct().ToList();
            List<decimal> prodottiMancanti = idProdottiFinito.Except(prodottiPresenti).ToList();

            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            while (prodottiMancanti.Count > 0)
            {
                List<decimal> prodottiDaCaricare;
                if (prodottiMancanti.Count > 999)
                {
                    prodottiDaCaricare = prodottiMancanti.GetRange(0, 999);
                    prodottiMancanti.RemoveRange(0, 999);
                }
                else
                {
                    prodottiDaCaricare = prodottiMancanti.GetRange(0, prodottiMancanti.Count);
                    prodottiMancanti.RemoveRange(0, prodottiMancanti.Count);
                }
                a.FillProdottiFiniti(ds, prodottiDaCaricare, soloNonCancellati);
            }
        }

        [DataContext]
        public void FillArticolo(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
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

        [DataContext]
        public void FillProcessi(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillProcessi(ds, idArticolo, soloNonCancellati);
        }

        [DataContext]
        public void FillFasiProcesso(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillFasiProcesso(ds, idArticolo, soloNonCancellati);
        }

        [DataContext]
        public void FillPreventivi(ArticoloDS ds, decimal idProdottoFinito, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillPreventivi(ds, idProdottoFinito, soloNonCancellati);
        }
        [DataContext]
        public void FillElementiPreventivo(ArticoloDS ds, decimal idProdottoFinito, bool soloNonCancellati)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.FillElementiPreventivo(ds, idProdottoFinito, soloNonCancellati);
        }

        [DataContext]
        public void EstraiPreventivo(ArticoloDS ds, decimal idPreventivo)
        {
            ArticoloAdapter a = new ArticoloAdapter(DbConnection, DbTransaction);
            a.EstraiPreventivo(ds, idPreventivo);
        }

    }
}
