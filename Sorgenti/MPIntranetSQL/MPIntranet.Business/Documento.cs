using MPIntranet.DataAccess.Documenti;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public byte[] Dati { get; set; }
        public List<BloccoDocumento> Blocchi { get; set; }
        public static Documento SalvaDocumento(int idTipoDocumento, string filename, string estensione, int idEsterna, string tabellaEsterna, byte[] dati, string utente)
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
            return CreaDocumento(ds.DOCUMENTI.FirstOrDefault());
        }

        public string CreaPathSalvataggio()
        {
            string pathFile = Configurazioni.PathPDM;
            if (!string.IsNullOrEmpty(TabellaEsterna))
                pathFile = Path.Combine(pathFile, TabellaEsterna);

            pathFile = Path.Combine(pathFile, IdEsterna.ToString());

            if (!string.IsNullOrEmpty(TipoDocumento.Cartella))
                pathFile = Path.Combine(pathFile, TipoDocumento.Cartella);

            pathFile = Path.Combine(pathFile, Filename);

            return recuperaFIleNameUnivoco(pathFile);

        }

        private string recuperaFIleNameUnivoco(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            int i = 0;
            while (File.Exists(fileName))
            {
                if (i == 0)
                    fileName = fileName.Replace(extension, "(" + ++i + ")" + extension);
                else
                    fileName = fileName.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
            }

            return fileName;
        }

        public string ContentType
        {
            get
            {
                switch (Estensione)
                {
                    case ".PDF":
                        return "application/pdf";
                    case ".JPG":
                    case ".JPEG":
                    case ".JPE":
                        return "image/jpeg";
                    case ".PNG":
                        return "image/png";
                    case ".AVI":
                        return "video/avi";
                    case ".PPS":
                    case ".PPT":
                        return "application/mspowerpoint";
                    case ".TIF":
                    case ".TIFF":
                        return "image/tiff";
                    case ".BMP":
                        return "image/bmp";
                    case ".RTF":
                        return "application/rtf";
                    case ".DOC":
                    case ".DOT":
                        return "application/msword";
                    case ".XLS":
                    case ".XLSX":
                        return "application/excel";
                    default:
                        return "application/octet-stream";
                }
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
            documento.Blocchi = BloccoDocumento.EstraiBlocchiDocumento(riga.IDDOCUMENTO);
            if (!riga.IsDATINull())
                documento.Dati = riga.DATI;
            documento.Cancellato = riga.CANCELLATO;
            documento.DataModifica = riga.DATAMODIFICA;
            documento.UtenteModifica = riga.UTENTEMODIFICA;

            return documento;
        }

        public void ModificaBloccoDocumento(int idDocumento, bool stato, string tipoBlocco, string utente)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillBlocchiDocumento(ds, idDocumento);

                if (!stato)
                {
                    DocumentiDS.BLOCCHIDOCUMENTORow bloccoAttivo = ds.BLOCCHIDOCUMENTO.Where(x => x.IDDOCUMENTO == idDocumento && x.ATTIVO == true && x.TIPOBLOCCO == tipoBlocco).FirstOrDefault();
                    if (bloccoAttivo != null)
                    {
                        bloccoAttivo.ATTIVO = false;
                        bloccoAttivo.FINEBLOCCO = DateTime.Now;
                        bloccoAttivo.UTENTEFINE = utente;
                    }
                }
                else
                {
                    DocumentiDS.BLOCCHIDOCUMENTORow bloccoAttivo = ds.BLOCCHIDOCUMENTO.Where(x => x.IDDOCUMENTO == idDocumento && x.ATTIVO == true && x.TIPOBLOCCO == tipoBlocco).FirstOrDefault();
                    if (bloccoAttivo == null)
                    {
                        DocumentiDS.BLOCCHIDOCUMENTORow nuovoBlocco = ds.BLOCCHIDOCUMENTO.NewBLOCCHIDOCUMENTORow();
                        nuovoBlocco.ATTIVO = true;
                        nuovoBlocco.IDDOCUMENTO = idDocumento;
                        nuovoBlocco.INIZIOBLOCCO = DateTime.Now;
                        nuovoBlocco.TIPOBLOCCO = tipoBlocco;
                        nuovoBlocco.UTENTEINIZIO = utente;
                        ds.BLOCCHIDOCUMENTO.AddBLOCCHIDOCUMENTORow(nuovoBlocco);
                    }
                }
                bDocumenti.UpdateTable(ds.BLOCCHIDOCUMENTO.TableName, ds);
            }

        }

        public static Documento EstraiDocumentoCompleto(int idDocumento)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.EstraiDocumentoCompleto(ds, idDocumento);
            }
            return CreaDocumento(ds.DOCUMENTI.FirstOrDefault());
        }

    }

}
