using MPIntranet.Business;
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
        public ActionResult EstraiDocumento(decimal IdDocumento)
        {
            Documenti d = new Documenti();
            string filename;
            byte[] fileArray = d.EstraiDocumento(IdDocumento, out filename);
            if (fileArray.Length == 0) return null;

            string contentType = string.Empty;
            switch (Path.GetExtension(filename).ToUpper())
            {
                case ".PDF":
                    contentType = "application/pdf";
                    break;
                case ".JPG":
                case ".JPEG":
                case ".JPE":
                    contentType = "image/jpeg";
                    break;
                case ".PNG":
                    contentType = "image/png";
                    break;
                case ".AVI":
                    contentType = "video/avi";
                    break;
                case ".PPS":
                case ".PPT":
                    contentType = "application/mspowerpoint";
                    break;
                case ".TIF":
                case ".TIFF":
                    contentType = "image/tiff";
                    break;
                case ".BMP":
                    contentType = "image/bmp";
                    break;
                case ".RTF":
                    contentType = "application/rtf";
                    break;
                case ".DOC":
                case ".DOT":
                    contentType = "application/msword";
                    break;
                case ".XLS":
                case ".XLSX":
                    contentType = "application/excel";
                    break;
            }

            Response.AppendHeader("content-disposition", string.Format(CultureInfo.InvariantCulture, "inline; filename={0}", filename));
            return new FileStreamResult(new MemoryStream(fileArray), contentType);
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
                        if (fname.Length > 50)
                        {
                            string estensione = Path.GetExtension(fname);
                            string filename = Path.GetFileNameWithoutExtension(fname);
                            filename = filename.Substring(0, 50 - estensione.Length);
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
           
        }
        public ActionResult CancellaDocumento(decimal IdDocumento)
        {
            Documenti a = new Documenti();
            a.CancellaDocumento(IdDocumento, ConnectedUser);
            return null;
        }

       
    }
}