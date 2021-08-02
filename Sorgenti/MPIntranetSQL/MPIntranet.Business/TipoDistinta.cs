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
    public class TipoDistinta : BaseModel
    {
        public int IdTipoDiBa { get; set; }
        public string TipoDiba { get; set; }
        public static string TipoProduzione = "PRODUZIONE";

        public static TipoDistinta EstraiTipoDistinta(int idTipoDIstinta)
        {
            List<TipoDistinta> lista = EstraiListaTipoDistinta(false);
            return lista.Where(x => x.IdTipoDiBa == idTipoDIstinta).FirstOrDefault();
        }

        public static List<TipoDistinta> EstraiListaTipoDistinta(bool soloNonCancellati)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillTipiDistinta(ds, soloNonCancellati);
            }

            List<TipoDistinta> tDiba = new List<TipoDistinta>();
            foreach (ArticoliDS.TIPIDIBARow riga in ds.TIPIDIBA)
            {
                TipoDistinta TipoDistinta = CreaTipoDistinta(riga);
                tDiba.Add(TipoDistinta);
            }
            return tDiba;
        }

        private static TipoDistinta CreaTipoDistinta(ArticoliDS.TIPIDIBARow riga)
        {
            if (riga == null) return null;
            TipoDistinta tipoDistinta = new TipoDistinta();
            tipoDistinta.IdTipoDiBa = riga.IDTIPODIBA;
            tipoDistinta.Cancellato = riga.CANCELLATO;
            tipoDistinta.DataModifica = riga.DATAMODIFICA;
            tipoDistinta.TipoDiba = riga.TIPODIBA;
            tipoDistinta.UtenteModifica = riga.UTENTEMODIFICA;
            return tipoDistinta;
        }

        public override string ToString()
        {
            return TipoDiba;
        }




    }
}
