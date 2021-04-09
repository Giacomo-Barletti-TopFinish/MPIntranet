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
        protected BrandModel _model;
        public BrandModel Model
        {
            get
            {
                return _model;
            }
        }

        public int ID
        {
            get
            {
                if (_model == null) return ElementiVuoti.Brand;
                return _model.IdBrand;
            }
        }

        public static Brand EstraiBrand(int idBrand)
        {
            List<Brand> lista = EstraiListaBrand(false);
            return lista.Where(x => x.ID == idBrand).FirstOrDefault();
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
                BrandModel model = CreaModello(riga);
                Brand brand = new Brand();
                brand._model = model;
                brands.Add(brand);
            }
            return brands;
        }

        private static BrandModel CreaModello(ArticoliDS.BRANDSRow riga)
        {
            if (riga == null) return null;
            BrandModel model = new BrandModel();
            model.IdBrand = riga.IDBRAND;
            model.Cancellato = riga.CANCELLATO;
            model.DataModifica = riga.DATAMODIFICA;
            model.Descrizione = riga.DESCRIZIONE;
            model.UtenteModifica = riga.UTENTEMODIFICA;

            return model;
        }

    }
}
