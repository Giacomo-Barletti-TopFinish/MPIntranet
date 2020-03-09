using MPIntranet.Business;
using MPIntranet.Models.Manutenzione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ManutenzioneController : ControllerBase
    {
        //GET: Manutenzione

        public ActionResult Ditte()
        {
            return View();
        }
        public ActionResult CaricaDitte()
        {
            Manutenzione a = new Manutenzione();
            List<DittaModel> lista = a.CreaListaDittaModel();

            return PartialView("CaricaDittePartial", lista);
            
        }

        public ActionResult CreaDitta(string RagioneSociale)
        {
            Manutenzione a = new Manutenzione();
            string messaggio = a.CreaDitta(RagioneSociale, ConnectedUser);

            return Content(messaggio);
        }

        //public ActionResult CaricaDitte()
        //{
        //    Manutenzione m = new Manutenzione();
        //    List<DittaModel> ditte = m.CreaListaDittaModel();

        //    return PartialView("CaricaDittePartial", ditte);
        //}


        public ActionResult CancellaDitta(decimal idDitta)
        {
            Manutenzione a = new Manutenzione();
            a.CancellaDitta(idDitta, ConnectedUser);
            return null;
        }

        public ActionResult ModificaDitta(decimal idDitta, string ragioneSociale)
        {
            Manutenzione a = new Manutenzione();
            a.ModificaDitta(idDitta, ragioneSociale, ConnectedUser);
            return null;
        }


    }
}