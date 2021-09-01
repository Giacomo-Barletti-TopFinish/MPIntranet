using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class AreaProduzione
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public static List<AreaProduzione> EstraiListaAreeProduzione()
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillAreeProduzione(ds);
            }

            List<AreaProduzione> areeProduzione = new List<AreaProduzione>();
            foreach (ArticoliDS.AreeProduzioneRow riga in ds.AreeProduzione)
            {
                AreaProduzione areaProduzione = CreaTask(riga);
                areeProduzione.Add(areaProduzione);
            }
            return areeProduzione;
        }

        private static AreaProduzione CreaTask(ArticoliDS.AreeProduzioneRow riga)
        {
            if (riga == null) return null;
            AreaProduzione areaProduzione = new AreaProduzione();
            areaProduzione.Codice = riga.No_;
            areaProduzione.Descrizione = riga.Name;
            return areaProduzione;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Codice, Descrizione);
        }
    }
}
