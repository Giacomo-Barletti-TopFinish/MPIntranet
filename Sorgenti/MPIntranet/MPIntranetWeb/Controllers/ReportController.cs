using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Common;
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
            Anagrafica anagrafica = new Anagrafica();
            List<RepartoModel>reparti = anagrafica.CreaListaRepartoModel();

            List<MPIntranetListItem> repartiList = reparti.Select(x => new MPIntranetListItem(x.Descrizione, x.IdReparto.ToString())).ToList();
            repartiList.Insert(0,new MPIntranetListItem("** TUTTI I REPARTI **", ElementiVuoti.TuttiReparti.ToString() ));

            ViewData.Add("Reparti", repartiList);


            return View();
        }

        public ActionResult CaricaCaricoReparto (decimal idReparto)
        {

        }
    }
}