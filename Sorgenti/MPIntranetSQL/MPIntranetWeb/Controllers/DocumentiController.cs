using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class DocumentiController : ControllerBase
    {
        public ActionResult EstraiDocumento(int idDocumento)
        {

            Documento documento = Documento.EstraiDocumentoCompleto(idDocumento);
            Response.AppendHeader("content-disposition", string.Format(CultureInfo.InvariantCulture, "inline; filename={0}", documento.Filename));
            return new FileStreamResult(new MemoryStream(documento.Dati), documento.ContentType);
        }

        public ActionResult BloccoDocumento(int idDocumento, bool statoCheckbox, string tipoBlocco)
        {
            Documento documento = Documento.EstraiDocumentoCompleto(idDocumento);
            documento.ModificaBloccoDocumento(idDocumento, statoCheckbox, tipoBlocco, ConnectedUser);
            return null;
        }

        public ActionResult CaricaDocumenti(int idEsterna, string tabellaEsterna)
        {

            List<TipoDocumento> tipiDocumento = TipoDocumento.EstraiListaTipiDocumento(false);
            List<MPIntranetListItem> tipoDocumentoItems = tipiDocumento.Select(x => new MPIntranetListItem(x.Descrizione, x.IdTipoDocumento.ToString())).ToList();
            tipoDocumentoItems.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.TipoDocumento.ToString()));
            ViewData.Add("ddlTipoDocumenti", tipoDocumentoItems);

            List<Documento> documenti = Documento.EstraiListaDocumenti(idEsterna, tabellaEsterna);

            ViewData.Add("IdEsterna", idEsterna);
            ViewData.Add("TabellaEsterna", tabellaEsterna);

            DocumentoCaricatoModel model = new DocumentoCaricatoModel();

            model.Documenti = documenti;
            model.IdEsterna = idEsterna;
            model.TabellaEsterna = tabellaEsterna;
            model.TipiDocumento = tipoDocumentoItems;


            return PartialView("CaricaDocumenti", model);
        }


        [HttpPost]
        public ActionResult AggiungiDocumento(DocumentoCaricatoModel model)
        {

            try
            {

                string filename = model.Attachment.FileName;
                if (filename.Length > 50)
                {
                    string newFilename = Path.GetFileNameWithoutExtension(filename).Replace(Path.GetExtension(filename), string.Empty);
                    if (newFilename.Length > 50 - Path.GetExtension(filename).Length)
                    {
                        newFilename = newFilename.Substring(0, 50 - Path.GetExtension(filename).Length);
                        filename = newFilename + Path.GetExtension(filename);
                    }
                }

                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(model.Attachment.InputStream))
                {
                    fileData = binaryReader.ReadBytes(model.Attachment.ContentLength);
                }

                int tipoDocumento = Int32.Parse(model.SelectedTipoDocumento);


                Documento documento = Documento.SalvaDocumento(tipoDocumento, filename, Path.GetExtension(filename), model.IdEsterna, model.TabellaEsterna, fileData, ConnectedUser);


                string path = documento.CreaPathSalvataggio();
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                model.Attachment.SaveAs(path);
                switch (model.TabellaEsterna)
                {
                    case TabelleEsterne.Articoli:
                        return RedirectToAction("Scheda", "Articolo", new { idArticolo = model.IdEsterna });
                }
                return null;

            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERRORE:" + ex.Message.ToString();
            }
            return null;
        }


    }
}