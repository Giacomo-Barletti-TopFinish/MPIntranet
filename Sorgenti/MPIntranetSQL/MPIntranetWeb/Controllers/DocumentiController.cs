using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Common;
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
        public ActionResult CaricaDocumenti(int idEsterna, string tabellaEsterna)
        {


            List<TipoDocumento> tipiDocumento = TipoDocumento.EstraiListaTipiDocumento(false);
            List<MPIntranetListItem> tipoDocumentoItems = tipiDocumento.Select(x => new MPIntranetListItem(x.Descrizione, x.IdTipoDocumento.ToString())).ToList();
            tipoDocumentoItems.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.TipoDocumento.ToString()));
            ViewData.Add("ddlTipoDocumenti", tipoDocumentoItems);

            //Galvanica g = new Galvanica();
            //List<ImpiantoModel> impiantiModel = g.CreaListaImpiantoModel();
            //List<MPIntranetListItem> impianti = impiantiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdImpianto.ToString())).ToList();
            //ViewData.Add("Impianti", impianti);

            //ProcessoGalvanico p = new ProcessoGalvanico();
            //List<ProcessoModel> processiModel = p.CaricaProcessi(idArticolo, impiantiModel[0].IdImpianto);
            //List<MPIntranetListItem> processi = processiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdProcesso.ToString())).ToList();
            //ViewData.Add("Processi", processi);
            ViewData.Add("IdEsterna", idEsterna);
            ViewData.Add("TabellaEsterna", tabellaEsterna);
            return PartialView("CaricaDocumenti");
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

                        //Documenti d = new Documenti();
                        //d.CreaDocumento(IdEsterna, TabellaEsterna, IdTipoDocumento, fname, fileData, ConnectedUser);
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
    }
}