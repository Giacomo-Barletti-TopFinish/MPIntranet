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

        public ActionResult CaricaBrand()
        {
            Anagrafica a = new Anagrafica();
            List<BrandModel> lista = a.CreaListaBrandModel();

            return PartialView("CaricaBrandPartial", lista);
        }

        public ActionResult RimuoviBrand(decimal idBrand)
        {
            Anagrafica a = new Anagrafica();
            a.CancellaBrand(idBrand, ConnectedUser);
            return null;
        }

        public ActionResult CreaBrand(string brand, string codiceGestionale, string prefissoColore)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaBrand(brand, codiceGestionale, prefissoColore, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaBrand(decimal idBrand, string brand, string codiceGestionale, string prefissoColore)
        {
            Anagrafica a = new Anagrafica();
            a.ModificaBrand(idBrand, brand, codiceGestionale, prefissoColore, ConnectedUser);
            return null;
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
            a.CancellaTipoDocumento(idTipoDocumento, ConnectedUser);
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