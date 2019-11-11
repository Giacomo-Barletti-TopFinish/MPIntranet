using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class GalvanicaController : ControllerBase
    {
        // GET: Galvanica
        public ActionResult Impianti()
        {
            return View();
        }

        public ActionResult Materiali()
        {
            return View();
        }

        public ActionResult Vasche()
        {
            return View();
        }
    }
}