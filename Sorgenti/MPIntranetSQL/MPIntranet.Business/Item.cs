using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    /// <summary>Class <c>Item</c> rappresenta le anagrafiche di Business Central. 
    /// Accede alla tabella Item del gestionale
    /// </summary>
    public class Item
    {
        public string Anagrafica { get; set; }
        public string Descrizione { get; set; }
        private Guid Picture { get; set; }
        public string UM { get; set; }
        private CaratteristicheItem _caratteristiche;
        public CaratteristicheItem Caratteristiche
        {
            get
            {
                if (_caratteristiche == null)
                {
                    _caratteristiche = new CaratteristicheItem(Anagrafica);
                }
                return _caratteristiche;
            }
        }
        public static List<Item> EstraiListaItems()
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillItems(ds);
            }

            List<Item> tasks = new List<Item>();
            foreach (ArticoliDS.ItemsRow riga in ds.Items)
            {
                Item item = CreaItem(riga);
                tasks.Add(item);
            }
            return tasks;
        }

        private static Item CreaItem(ArticoliDS.ItemsRow riga)
        {
            if (riga == null) return null;
            Item item = new Item();
            item.Anagrafica = riga.No_;
            item.Descrizione = riga.Description;
            item.UM = riga.Base_Unit_of_Measure;
            item.Picture = riga.Picture;
            return item;
        }
        public static bool VerificaEsistenzaItem(string anagrafica)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetItem(ds, anagrafica);
            }

            return ds.Items.Any(x => x.No_ == anagrafica);
        }
        public static Item EstraiItem(string anagrafica)
        {
            anagrafica = anagrafica.Trim();
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetItem(ds, anagrafica);
            }

            ArticoliDS.ItemsRow riga = ds.Items.Where(x => x.No_ == anagrafica).FirstOrDefault();
            if (riga == null) return null;


            return CreaItem(riga);
        }
        public override string ToString()
        {
            return Anagrafica;
        }

        public byte[] EstraiImmagine(out string fileName)
        {
            fileName = string.Empty;
            if(Picture != Guid.Empty)
            {
                ArticoliDS ds = new ArticoliDS();
                using (ArticoliBusiness bArticolo = new ArticoliBusiness())
                {
                    bArticolo.GetBCMedia(ds, Picture);
                }
                ArticoliDS.BCMediaRow media = ds.BCMedia.Where(x => x.MediaSetID == Picture).FirstOrDefault();
                fileName = media.File_Name;
                return media.Content;
            }
            return null;
        }
    }

    public class CaratteristicheItem
    {
        public List<CaratteristicaItem> Caratteristiche;
        public string Anagrafica;
        public CaratteristicheItem(string Anagrafica)
        {
            this.Anagrafica = Anagrafica;
            Caratteristiche = CaratteristicaItem.EstraiListaCaratteristiche(Anagrafica);
        }
        private CaratteristicaItem estraiCaratteristica(string codiceCaratteristica)
        {
            CaratteristicaItem c = Caratteristiche.Where(x => x.Codice == codiceCaratteristica).FirstOrDefault();
            if (c == null)
                c = new CaratteristicaItem(string.Empty, string.Empty, string.Empty, string.Empty);
            return c;

        }
        public CaratteristicaItem Brand
        {
            get
            {
                return estraiCaratteristica("TBRAND");
            }
        }
        public CaratteristicaItem Colore
        {
            get
            {
                return estraiCaratteristica("TCOLORE/GV");
            }
        }
        public CaratteristicaItem Stato
        {
            get
            {
                return estraiCaratteristica("TSTATO");
            }
        }
        public CaratteristicaItem Materiale
        {
            get
            {
                return estraiCaratteristica("TMATERIALE");
            }
        }
        public CaratteristicaItem Serie
        {
            get
            {
                return estraiCaratteristica("NPROGR_ANE");
            }
        }
    }

    /// <summary>
    /// Class <c>CaratteristicaItem</c> rappresenta la caratteristica del configuratore di Business Central associate ad un item. 
    /// Accede alla tabella caratteristiche del gestionale.
    /// </summary> 
    public class CaratteristicaItem
    {
        public string Caratteristica { get; set; }
        public string Valore { get; set; }
        public string Descrizione { get; set; }
        public string Codice { get; set; }

        private static string[] codiciCaratteristiche = new string[] { "NPROGR_ANE", "NVERS1", "NVERS2", "TARTICOLO2", "TBRAND", "TCOLORE/GV", "TCOSTO", "TFASECONT", "TFORMA", "TFUNZIONE", "TMATERIALE", "TSTATO" };

        public static List<CaratteristicaItem> EstraiListaCaratteristiche(string anagrafica)
        {
            List<CaratteristicaItem> caratteristiche = new List<CaratteristicaItem>();

            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillCARATTERISTICHE_ANAGRAFICA(ds, anagrafica);
            }

            foreach (string caratteristica in codiciCaratteristiche)
            {
                ArticoliDS.CARATTERISTICHE_ANAGRAFICARow c = ds.CARATTERISTICHE_ANAGRAFICA.Where(x => x.CARATTERISTICA == caratteristica).FirstOrDefault();
                if (c != null)
                {
                    caratteristiche.Add(new CaratteristicaItem(c.DESCARATTERISTICA, c.CARATTERISTICA, c.DESVALORE, c.VALORE));
                }
            }

            return caratteristiche;
        }

        public CaratteristicaItem(string caratteristica, string codice, string descrizione, string valore)
        {
            Caratteristica = caratteristica;
            Descrizione = descrizione;
            Valore = valore;
            Codice = codice;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Valore, Descrizione);
        }
    }
}
