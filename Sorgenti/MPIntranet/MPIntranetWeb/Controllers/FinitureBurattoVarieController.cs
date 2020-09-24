using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Common;
using MPIntranet.Models.Finiture_Burattovarie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class FinitureBurattoVarieController : ControllerBase
    {
        // GET: FinitureBurattoVarie

        public ActionResult Proprieta()
        {
            return View();
        }
        public ActionResult CaricaProprieta()
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            List<ProprietaModel> proprietaModel = a.CreaListaProprietaModel();
            return PartialView("CaricaProprietaPartial", proprietaModel);
        }

        public ActionResult CreaProprieta(string Codice, string Descrizione)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            string messaggio = a.CreaProprieta(Codice, Descrizione ,ConnectedUser);

            return Content(messaggio);
        }

        public ActionResult CancellaProprieta(decimal idFbvProprieta)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.CancellaProprieta(idFbvProprieta, ConnectedUser);
            return null;
        }

        public ActionResult ModificaProprieta(decimal idfbvproprieta, string codice, string descrizione)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.ModificaProprieta(idfbvproprieta, codice, descrizione, ConnectedUser);
            return null;
        }
    }
}