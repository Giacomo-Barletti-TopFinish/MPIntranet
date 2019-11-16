using MPIntranet.Business;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class GalvanicaController : ControllerBase
    {
        public ActionResult Impianti()
        {
            return View();
        }

        public ActionResult CaricaImpianti()
        {
            Galvanica a = new Galvanica();
            List<ImpiantoModel> lista = a.CreaListaImpiantoModel();

            return PartialView("CaricaImpiantiPartial", lista);
        }

        public ActionResult RimuoviImpianto(decimal idImpianto)
        {
            Galvanica a = new Galvanica();
            a.CancellaImpianto(idImpianto, ConnectedUser);
            return null;
        }

        public ActionResult CreaImpianto(string descrizione)
        {
            Galvanica a = new Galvanica();
            string messaggio = a.CreaImpianto(descrizione, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaImpianto(decimal idImpianto, string descrizione)
        {
            Galvanica a = new Galvanica();
            a.ModificaImpianto(idImpianto, descrizione, ConnectedUser);
            return null;
        }

        public ActionResult Vasche()
        {
            return View();
        }
    }
}