using MPIntranet.Business;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ArticoloController : ControllerBase
    {
        public ActionResult Scheda(decimal idArticolo)
        {
            Articolo a = new Articolo();
            ArticoloModel model = a.CreaArticoloModel(idArticolo);
            return View(model);
        }

        public ActionResult RicercaArticolo(int TipoRicerca)
        {

            Anagrafica a = new Anagrafica();
            List<BrandModel> brandModels = a.CreaListaBrandModel();
            List<MPIntranetListItem> brands = brandModels.Select(x => new MPIntranetListItem(x.Brand, x.IdBrand.ToString())).ToList();
            brands.Insert(0, new MPIntranetListItem(string.Empty, "-1"));

            ViewData.Add("Brand", brands);
            ViewData.Add("TipoRicerca", TipoRicerca);
            return View();
        }

        public ActionResult TrovaArticolo(string modello, string codiceSam, string coloreInterno, decimal idBrand, string codiceCliente, string coloreCliente, string codiceProvvisorio, int TipoRicerca)
        {
            Articolo articolo = new Articolo();

            List<ArticoloModel> articoli = articolo.TrovaArticoli(modello, codiceSam, coloreInterno, idBrand, codiceCliente, coloreCliente, codiceProvvisorio);

            switch (TipoRicerca)
            {
                case (int)MPIntranet.Models.TipoRicerca.Scheda:
                    ViewData.Add("ControllerName", "Articolo");
                    ViewData.Add("ActionName", "Scheda");
                    break;
                case (int)MPIntranet.Models.TipoRicerca.Impianto:
                    ViewData.Add("ControllerName", "Articolo");
                    ViewData.Add("ActionName", "Scheda");
                    break;
                default:
                    ViewData.Add("ControllerName", string.Empty);
                    ViewData.Add("ActionName", string.Empty);
                    break;
            }
            return PartialView("CaricaArticoliModel", articoli);
        }

        public ActionResult CreaArticolo()
        {
            Anagrafica a = new Anagrafica();
            List<BrandModel> brandModels = a.CreaListaBrandModel();
            List<MPIntranetListItem> brands = brandModels.Select(x => new MPIntranetListItem(x.Brand, x.IdBrand.ToString())).ToList();
            brands.Insert(0, new MPIntranetListItem(string.Empty, "-1"));

            ViewData.Add("dllBrand", brands);

            return View();
        }

        public ActionResult SalvaArticolo(decimal idBrand, string codiceSAM, decimal progressivo, string modello, string descrizione, string codiceCliente, string provvisorio, string codiceColore)
        {

            Articolo a = new Articolo();
            string messaggio = a.CreaArticolo(idBrand, codiceSAM, progressivo, modello, descrizione, codiceCliente, provvisorio, codiceColore, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult RimuoviArticolo(decimal idArticolo)
        {
            Articolo a = new Articolo();

            a.RimuoviArticolo(idArticolo, ConnectedUser);
            return null;
        }

    }
}