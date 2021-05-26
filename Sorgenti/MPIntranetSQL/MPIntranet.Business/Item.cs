using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Item
    {
        public string Anagrafica { get; set; }
        public string Descrizione { get; set; }
        public string UM { get; set; }

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
            return item;
        }

        public override string ToString()
        {
            return Anagrafica;
        }
    }
}
