using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class DocumentiController : Controller
    {
        public ActionResult EstraiDocumento()
        {
            return View();
        }
        public ActionResult AggiungiDocumento()
        {
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