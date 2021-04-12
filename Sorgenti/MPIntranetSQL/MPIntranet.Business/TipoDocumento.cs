using MPIntranet.DataAccess.Documenti;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class TipoDocumento : BaseModel
    {
        public int IdTipoDocumento { get; set; }
        public string Descrizione { get; set; }
        public string Cartella { get; set; }

        public static TipoDocumento EstraiTipoDocumento(int idTipoDocumento)
        {
            List<TipoDocumento> lista = EstraiListaTipiDocumento(false);
            return lista.Where(x => x.IdTipoDocumento == idTipoDocumento).FirstOrDefault();
        }

        public static List<TipoDocumento> EstraiListaTipiDocumento(bool soloNonCancellati)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillTipiDocumento(ds, soloNonCancellati);
            }

            List<TipoDocumento> tipoDocumento = new List<TipoDocumento>();
            foreach (DocumentiDS.TIPIDOCUMENTORow riga in ds.TIPIDOCUMENTO)
            {
                TipoDocumento td = CreaTipoDocumento(riga);
                tipoDocumento.Add(td);
            }
            return tipoDocumento;
        }

        private static TipoDocumento CreaTipoDocumento(DocumentiDS.TIPIDOCUMENTORow riga)
        {
            if (riga == null) return null;
            TipoDocumento td = new TipoDocumento();
            td.IdTipoDocumento = riga.IDTIPODOCUMENTO;
            td.Cartella = riga.CARTELLA;
            td.Cancellato = riga.CANCELLATO;
            td.DataModifica = riga.DATAMODIFICA;
            td.Descrizione = riga.DESCRIZIONE;
            td.UtenteModifica = riga.UTENTEMODIFICA;
            return td;
        }
    }
}
