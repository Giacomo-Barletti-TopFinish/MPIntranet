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
    }
}