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
            List<MPIntranetListItem> proprieta = proprietaModel.OrderBy(x => x.Codice).Select(x => new MPIntranetListItem(x.ToString(),x.IdFbvProprieta.ToString())).ToList();

            ViewData.Add("Proprieta", proprieta);
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

        public ActionResult Attributi()
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            List<ProprietaModel> proprietaModel = a.CreaListaProprietaModel();
            List<MPIntranetListItem> proprieta = proprietaModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdFbvProprieta.ToString())).ToList();

            ViewData.Add("Proprieta", proprieta);
            return View();
        }

        public ActionResult CaricaAttributi()
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            List<AttributiModel> attributi = a.CreaListaAttributiModel();

            return PartialView("CaricaAttributiPartial", attributi);
        }

        public ActionResult CancellaAttributi(decimal IdFbvAttributi)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.CancellaAttributi(IdFbvAttributi, ConnectedUser);
            return null;
        }

        public ActionResult CreaAttributi(string codice, string descrizione, decimal IdFbvProprieta)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            string messaggio = a.CreaAttributi(codice, descrizione, IdFbvProprieta, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaAttributi(decimal IdFbvAttributi, string codice, string descrizione)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.ModificaAttributi(IdFbvAttributi, codice, descrizione, ConnectedUser);
            return null;
        }
        public ActionResult Fasi()
        {
            return View();
        }
        public ActionResult CaricaFasi()
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            List<FasiModel> fasiModel = a.CreaListaFasiModel();
            return PartialView("CaricaFasiPartial", fasiModel);
        }

        public ActionResult CreaFasi(string Codice, string Descrizione, decimal Ricarico, decimal CostoOrario)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            string messaggio = a.CreaFasi(Codice, Descrizione, Ricarico, CostoOrario, ConnectedUser);

            return Content(messaggio);
        }
        public ActionResult CancellaFasi(decimal IdFbvFasi)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.CancellaFasi(IdFbvFasi, ConnectedUser);
            return null;
        }

        public ActionResult ModificaFasi(decimal IdFbvFasi, string Codice, string Descrizione, decimal Ricarico, decimal CostoOrario)
        {
            FinitureBurattovarie a = new FinitureBurattovarie();
            a.ModificaFasi(IdFbvFasi, Codice, Descrizione, Ricarico, CostoOrario, ConnectedUser);
            return null;
        }

    }

}