using MPIntranet.Business;
using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class AnagraficaController : ControllerBase
    {
        // GET: Anagrafica
        public ActionResult Brand()
        {
            return View();
        }

        public ActionResult Colore()
        {
            return View();
        }

        public ActionResult TipiDocumento()
        {
            return View();
        }

        public ActionResult CaricaTipiDocumento()
        {
            Anagrafica a = new Anagrafica();
            List<TipoDocumentoModel> lista = a.CreaListaTipoDocumento();

            return PartialView("CaricaTipiDocumentoPartial", lista);
        }

        public ActionResult RimuoviTipoDocumento(decimal idTipoDocumento)
        {
            Anagrafica a = new Anagrafica();
            a.CancellatipoDocumento(idTipoDocumento);
            return null;
        }

        public ActionResult CreaTipoDocumento(string descrizione)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaTipoDocumento(descrizione, ConnectedUser);
            return Content(messaggio);
        }
    }
}