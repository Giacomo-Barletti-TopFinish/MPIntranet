using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Common;
using MPIntranet.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ReportController : ControllerBase
    {
        public ActionResult CaricoLavoro()
        {

            Report report = new Report();
            List<string> reparti = report.EstraiRepartiODL_Aperti();


            List<MPIntranetListItem> repartiList = reparti.Select(x => new MPIntranetListItem(x, x)).ToList();
            repartiList.Insert(0, new MPIntranetListItem("** TUTTI I REPARTI **", ElementiVuoti.TuttiReparti.ToString()));

            ViewData.Add("Reparti", repartiList);


            return View();
        }

        public ActionResult ReportQuantita()
        {

            Report report = new Report();
            List<string> quantita = report.EstraiReportQuantita();


            List<MPIntranetListItem> quantitaList = quantita.Select(x => new MPIntranetListItem(x, x)).ToList();
            quantitaList.Insert(0, new MPIntranetListItem("** TUTTI LE QUANTITA **", ElementiVuoti.TutteQuantita.ToString()));

            ViewData.Add("Quantita", quantitaList);


            return View();
        }



        public ActionResult CaricaCaricoReparto(string idReparto)
        {
            Report report = new Report();
            List<CaricoRepartoModel> caricoLavoroList = report.CreaListaCaricoReparto(idReparto);


            return PartialView("CaricoLavoroPartial", caricoLavoroList);
        }

        public ActionResult CaricaReportQuantita( )
        {
            Report report = new Report();
            List<ReportQuantitaModel> reportQuantitaList = report.CreaListaReportQuantita();

            return PartialView("ReportQuantitaPartial", reportQuantitaList);
        }



            public FileResult ExportExcel(string idReparto)
            {

            Report report = new Report();
            byte[] fileContents = report.CreaExcelCaricoLavoro(idReparto);
            

            return File(fileContents, "application/excel", "CaricoLavoro.xlsx");
            }

        public FileResult ExportRQExcel( )                              //RQ = reportquantita
        {

            Report report = new Report();
            byte[] fileContents = report.CreaExcelReportQuantita();


            return File(fileContents, "application/excel", "ReportQuantita.xlsx");
        }
    }
}
