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
    public class DistintaBase : BaseModel
    {
        public int IdDiba { get; set; }
        public int Versione { get; set; }
        public TipoDistinta TipoDistinta { get; set; }
        public Articolo Articolo { get; set; }
        public string Descrizione { get; set; }
        public bool Standard { get; set; }


        public static DistintaBase EstraiDistintaBase(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetDistintaBase(ds, idDiba);
            }
            ArticoliDS.DIBARow riga = ds.DIBA.Where(x => x.IDDIBA == idDiba).FirstOrDefault();
            return CreaDistintaBase(riga);
        }

        public static List<DistintaBase> EstraiListaDistinteBase(int idArticolo)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillDistintaBase(ds, idArticolo, true);
            }
            List<DistintaBase> distinte = new List<DistintaBase>();
            foreach (ArticoliDS.DIBARow riga in ds.DIBA)
            {
                DistintaBase distinta = CreaDistintaBase(riga);
                distinte.Add(distinta);
            }
            return distinte;
        }
        private static DistintaBase CreaDistintaBase(ArticoliDS.DIBARow riga)
        {

            if (riga == null) return null;
            DistintaBase distinta = new DistintaBase();
            distinta.IdDiba = riga.IDDIBA;
            distinta.TipoDistinta = TipoDistinta.EstraiTipoDistinta(riga.IDTIPODIBA);
            distinta.Articolo = Articolo.EstraiArticolo(riga.IDARTICOLO);
            distinta.Descrizione = riga.DESCRIZIONE;
            distinta.Versione = riga.VERSIONE;
            distinta.Standard = riga.STANDARD;

            distinta.Cancellato = riga.CANCELLATO;
            distinta.DataModifica = riga.DATAMODIFICA;
            distinta.UtenteModifica = riga.UTENTEMODIFICA;

            return distinta;
        }

        public static string CreaDistinta(int idArticolo, int idTipoDistinta, int versione, string descrizione, bool standard, string account, out int idDiba)
        {
            idDiba = ElementiVuoti.DistintaBase;
            Articolo articolo = Articolo.EstraiArticolo(idArticolo);
            if (articolo == null) return "Articolo non valido";

            TipoDistinta tipoDistinta = TipoDistinta.EstraiTipoDistinta(idTipoDistinta);
            if (tipoDistinta == null) return "Tipo distinta non valido";

            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                ArticoliDS.DIBARow dibaNuova = ds.DIBA.NewDIBARow();
                dibaNuova.IDARTICOLO = idArticolo;
                dibaNuova.IDTIPODIBA = idTipoDistinta;
                dibaNuova.DESCRIZIONE = descrizione;
                dibaNuova.VERSIONE = versione;
                dibaNuova.STANDARD = standard;
                dibaNuova.CANCELLATO = false;
                dibaNuova.DATAMODIFICA = DateTime.Now;
                dibaNuova.UTENTEMODIFICA = account;

                ds.DIBA.AddDIBARow(dibaNuova);
                bArticolo.UpdateDistintaBaseTable(ds);
                idDiba = dibaNuova.IDDIBA;
            }
            return "Distinta creata correttamente";
        }
    }
}
