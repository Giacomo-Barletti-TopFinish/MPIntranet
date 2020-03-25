using MPIntranet.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class DocumentiController : ControllerBase
    {
        public ActionResult EstraiDocumento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiDocumento()
        {
            decimal IdEsterna = decimal.Parse(Request["IdEsterna"]);
            string TabellaEsterna = Request["TabellaEsterna"];
            decimal IdTipoDocumento = decimal.Parse(Request["TipoDocumento"]);
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(file.ContentLength);
                        }
                        if(fname.Length>50)
                        {
                            string estensione = Path.GetExtension(fname);
                            string filename = Path.GetFileNameWithoutExtension(fname);
                            filename = filename.Substring(0, 50 - estensione.Length );
                            fname = string.Format("{0}{1}", filename, estensione);
                        }
                        Documenti d = new Documenti();
                        d.CreaDocumento(IdEsterna, TabellaEsterna, IdTipoDocumento, fname, fileData, ConnectedUser);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File caricato correttamente");
                }
                catch (Exception ex)
                {
                    return Json("Errore impossibile caricare il file: " + ex.Message);
                }
            }
            else
            {
                return Json("Nessun file selezionato.");
            }
            return View();
        }
        public ActionResult RimuoviDocumento()
        {
            return View();
        }

        //[HttpGet]
        //public FileStreamResult GetReport(long id_spasync, long id, string tipoElaborazione, string nomeFile, string SessionId, string nomeReport)
        //{
        //    if (nomeReport == null)
        //        nomeReport = GetInformationService.GetSubOperazione(id_spasync, SpcContext);

        //    ReturnedReportModel rm = GetReportService.GetReport(id_spasync, id, tipoElaborazione, nomeFile, SpcContext, nomeReport);
        //    byte[] fileArray = rm.data;

        //    Response.AppendHeader("content-disposition", string.Format(CultureInfo.InvariantCulture, "inline; filename={0}.pdf", nomeFile));
        //    return new FileStreamResult(new MemoryStream(fileArray), "application/pdf");
        //}
    }
}