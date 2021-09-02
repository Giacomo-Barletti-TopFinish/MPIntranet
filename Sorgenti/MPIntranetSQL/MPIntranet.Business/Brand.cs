using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Brand 
    {

        public int IdBrand { get; set; }
        public string Descrizione { get; set; }
        public string Codice { get; set; }

        public static Brand EstraiBrand(int idBrand)
        {
            List<Brand> lista = EstraiListaBrand(false);
            return lista.Where(x => x.IdBrand == idBrand).FirstOrDefault();
        }

        public static List<Brand> EstraiListaBrand(bool soloNonCancellati)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillBrand(ds, soloNonCancellati);
            }

            List<Brand> brands = new List<Brand>();
            foreach (ArticoliDS.BRANDSRow riga in ds.BRANDS)
            {
                Brand brand = CreaBrand(riga);
                brands.Add(brand);
            }
            return brands;
        }

        private static Brand CreaBrand(ArticoliDS.BRANDSRow riga)
        {
            if (riga == null) return null;
            Brand brand = new Brand();
            brand.IdBrand = riga.IDBRAND;
            brand.Descrizione = riga.DESCRIZIONE;
            brand.Codice= riga.CODICE;
            return brand;
        }

        public static Brand CreaBrandVuoto()
        {
            Brand brand = new Brand();
            brand.IdBrand = ElementiVuoti.Brand;
            brand.Descrizione = string.Empty;
            return brand;
        }

        public override string ToString()
        {
            return Descrizione;
        }

    }
}
