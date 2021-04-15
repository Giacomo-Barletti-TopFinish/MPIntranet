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
    public class Documento : BaseModel
    {
        public int IdDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Filename { get; set; }
        public string Estensione { get; set; }
        public int IdEsterna { get; set; }
        public string TabellaEsterna { get; set; }
        public Blocco Blocco { get; set; }
        public static void SalvaDocumento(int idTipoDocumento, string filename, string estensione, int idEsterna, string tabellaEsterna, byte[] dati, string utente)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                DocumentiDS.DOCUMENTIRow documento = ds.DOCUMENTI.NewDOCUMENTIRow();
                documento.CANCELLATO = false;
                documento.DATAMODIFICA = DateTime.Now;
                documento.DATI = dati;
                documento.ESTENSIONE = estensione;
                documento.FILENAME = filename;
                documento.IDESTERNA = idEsterna;
                documento.IDTIPODOCUMENTO = idTipoDocumento;
                documento.TABELLAESTERNA = tabellaEsterna;
                documento.UTENTEMODIFICA = utente;

                ds.DOCUMENTI.AddDOCUMENTIRow(documento);
                bDocumenti.UpdateTable(ds.DOCUMENTI.TableName, ds);
            }
        }

        public static List<Documento> EstraiListaDocumenti(int idEsterna, string tabellaEsterna)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillDocumenti(ds, idEsterna, tabellaEsterna, false);
            }
            List<Documento> documenti = new List<Documento>();
            foreach (DocumentiDS.DOCUMENTIRow riga in ds.DOCUMENTI)
            {
                Documento documento = CreaDocumento(riga);
                documenti.Add(documento);
            }
            return documenti;
        }

        private static Documento CreaDocumento(DocumentiDS.DOCUMENTIRow riga)
        {

            if (riga == null) return null;
            Documento documento = new Documento();
            documento.IdDocumento = riga.IDDOCUMENTO;
            documento.TipoDocumento = TipoDocumento.EstraiTipoDocumento(riga.IDTIPODOCUMENTO);
            documento.Filename = riga.IsFILENAMENull() ? string.Empty : riga.FILENAME;
            documento.Estensione = riga.IsESTENSIONENull() ? string.Empty : riga.ESTENSIONE;
            documento.IdEsterna = riga.IsIDESTERNANull() ? -1 : riga.IDESTERNA;
            documento.TabellaEsterna = riga.TABELLAESTERNA;

            documento.Cancellato = riga.CANCELLATO;
            documento.DataModifica = riga.DATAMODIFICA;
            documento.UtenteModifica = riga.UTENTEMODIFICA;

            return documento;
        }

    }
}
