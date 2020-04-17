using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPIntranet.Models.Documenti;
using MPIntranet.DataAccess.Documenti;
using MPIntranet.Models;
using MPIntranet.Common;
using System.IO;

namespace MPIntranet.Business
{
    public class Documenti : BusinessBase
    {
        private DocumentiDS _ds = new DocumentiDS();
        private const decimal IdImmagineStandard = 23;
        public byte[] EstraiDocumento(decimal IdDocumento, out string Filename)
        {
            Filename = string.Empty;
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillDocumenti(IdDocumento, _ds);
                DocumentiDS.DOCUMENTIRow documento = _ds.DOCUMENTI.Where(x => x.IDDOCUMENTO == IdDocumento).FirstOrDefault();

                if (documento == null) return null;
                Filename = documento.FILENAME;
                return documento.DATI;
            }
        }

        public byte[] EstraiImmagineStandard(decimal IdEsterna, string TabellaEsterna, out string Filename)
        {
            Filename = string.Empty;

            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                if (!_ds.DOCUMENTI.Any(x => x.IDESTERNA == IdEsterna && x.TABELLAESTERNA == TabellaEsterna && x.IDTIPODOCUMENTO == IdImmagineStandard))
                    bDocumenti.FillDocumenti(IdEsterna, TabellaEsterna, _ds);
                DocumentiDS.DOCUMENTIRow documento = _ds.DOCUMENTI.Where(x => x.IDESTERNA == IdEsterna && x.TABELLAESTERNA == TabellaEsterna && x.IDTIPODOCUMENTO == IdImmagineStandard).FirstOrDefault();

                if (documento == null) return null;
                Filename = documento.FILENAME;
                return documento.DATI;
            }
        }
        private DocumentoModel CreaDocumentoModel(DocumentiDS.DOCUMENTIRow documento, AnagraficaDS ds)
        {
            Anagrafica a = new Anagrafica();
            DocumentoModel rm = new DocumentoModel();
            rm.Filename = documento.FILENAME;
            rm.IdDocumento = documento.IDDOCUMENTO;
            rm.TipoDocumento = a.EstraiTipoDocumentoModel(documento.IDTIPODOCUMENTO);

            return rm;
        }

        public DocumentoModelContainer CreaDocumentoModelContainer(decimal IdEsterna, string TabellaEstera)
        {
            AnagraficaDS ds = new AnagraficaDS();
            DocumentoModelContainer dc = new DocumentoModelContainer();
            dc.IdEsterna = IdEsterna;
            dc.TabellaEsterna = TabellaEstera;
            dc.Documenti = new List<DocumentoModel>();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillDocumentiNoData(_ds, true);
                foreach (DocumentiDS.DOCUMENTIRow documento in _ds.DOCUMENTI.Where(x => x.IDESTERNA == IdEsterna && x.TABELLAESTERNA == TabellaEstera))
                    dc.Documenti.Add(CreaDocumentoModel(documento, ds));
            }
            return dc;
        }

        public string CreaDocumento(decimal IdEsterna, string TabellaEsterna, decimal IdTipoDocumento, string Filename, byte[] Dati, string account)
        {
            string estensione = Path.GetExtension(Filename);
            string filename = Path.GetFileNameWithoutExtension(Filename);
            Filename = string.Format("{0}{1}", filename, estensione);
            if (Filename.Length > 50)
            {
                filename = filename.Substring(0, 50 - estensione.Length);
                Filename = string.Format("{0}{1}", filename, estensione);
            }

            Filename = Filename.ToUpper().Trim();
            TabellaEsterna = TabellaEsterna.ToUpper().Trim();

            if (string.IsNullOrEmpty(Filename))
                return "Filename assente";
            if (string.IsNullOrEmpty(TabellaEsterna))
                return "Tabella esterna assente";
            if (Dati.Length == 0)
                return "Dati file assenti";

            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillDocumentiNoData(_ds, false);

                if (_ds.DOCUMENTI.Any(x => x.FILENAME.Trim() == Filename && x.IDESTERNA == IdEsterna && x.TABELLAESTERNA == TabellaEsterna))
                    return "Documento già inserito a sistema";

                DocumentiDS.DOCUMENTIRow documento = _ds.DOCUMENTI.NewDOCUMENTIRow();
                documento.FILENAME = Filename;
                documento.CANCELLATO = SiNo.No;
                documento.DATAMODIFICA = DateTime.Now;
                documento.UTENTEMODIFICA = account;
                documento.IDTIPODOCUMENTO = IdTipoDocumento;
                documento.IDESTERNA = IdEsterna;
                documento.DATI = Dati;
                documento.TABELLAESTERNA = correggiString(TabellaEsterna, 45);
                _ds.DOCUMENTI.AddDOCUMENTIRow(documento);

                bDocumenti.UpdateTable(_ds.DOCUMENTI.TableName, _ds);
            }

            return string.Empty;
        }

        public void CancellaDocumento(decimal IdDocumento, string account)
        {
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillDocumenti(IdDocumento, _ds);
                DocumentiDS.DOCUMENTIRow documento = _ds.DOCUMENTI.Where(x => x.IDDOCUMENTO == IdDocumento).FirstOrDefault();
                if (documento != null)
                {
                    documento.CANCELLATO = SiNo.Si;
                    documento.DATAMODIFICA = DateTime.Now;
                    documento.UTENTEMODIFICA = account;

                    bDocumenti.UpdateTable(_ds.DOCUMENTI.TableName, _ds);
                }
            }
        }

    }
}
