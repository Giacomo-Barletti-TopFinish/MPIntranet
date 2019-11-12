using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error(WebException ex)
        {
            if (ex == null) return null;
            var model = new HandleErrorInfo(ex.InnerException, ex.Controller, ex.Action);
            Response.Clear();
            Response.StatusCode = 200;
            return View(model);
        }

        public ActionResult AccountNonAutorizzato(WebException ex)
        {
            if (ex == null) return null;
            var model = new HandleErrorInfo(ex.InnerException, ex.Controller, ex.Action);
            Response.Clear();
            Response.StatusCode = 200;
            return View(model);
        }
    }
}