using MPIntranet.Business;
using MPIntranet.Entities;
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
        public ActionResult RicercaArticolo(int TipoRicerca)
        {
            List<MPIntranetListItem> brandsItems = CreaListaBrand();
            ViewData.Add("Brand", brandsItems);

            ViewData.Add("TipoRicerca", TipoRicerca);
            return View();
        }

        public ActionResult CreaArticolo()
        {
            List<MPIntranetListItem> brandsItems = CreaListaBrand();
            ViewData.Add("dllBrand", brandsItems);

            return View();
        }

        private List<MPIntranetListItem> CreaListaBrand()
        {
            List<Brand> brands = Brand.EstraiListaBrand();
            List<MPIntranetListItem> brandsItems = brands.Select(x => new MPIntranetListItem(x.Descrizione, x.IdBrand.ToString())).ToList();
            brandsItems.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.Brand.ToString()));

            return brandsItems;

        }

        public ActionResult SalvaArticolo(int idBrand, string anagrafica, string descrizione, string codiceCliente, string codiceColore)
        {
            string messaggio = Articolo.CreaArticolo(idBrand, anagrafica.ToUpper(), descrizione.ToUpper(), codiceCliente.ToUpper(), codiceColore.ToUpper(), ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult TrovaArticolo(string anagrafica, string descrizione, int idBrand, string codiceCliente, string colore, int TipoRicerca)
        {

            List<Articolo> articoli = Articolo.TrovaArticoli(anagrafica, descrizione, idBrand, codiceCliente, colore);

            switch (TipoRicerca)
            {
                case (int)MPIntranet.Common.TipoRicerca.Scheda:
                    ViewData.Add("ControllerName", "Articolo");
                    ViewData.Add("ActionName", "Scheda");
                    break;
                case (int)MPIntranet.Common.TipoRicerca.Processo:
                    ViewData.Add("ControllerName", "Articolo");
                    ViewData.Add("ActionName", "CreaProcesso");
                    break;
                default:
                    ViewData.Add("ControllerName", string.Empty);
                    ViewData.Add("ActionName", string.Empty);
                    break;
            }
            return PartialView("CaricaArticoliModel", articoli);
        }
        public ActionResult Scheda(int idArticolo)
        {
            Articolo articolo = Articolo.EstraiArticolo(idArticolo);
            return View(articolo);
        }

        public ActionResult CancellaArticolo(int idArticolo)
        {
            Articolo a = Articolo.EstraiArticolo(idArticolo);
            a.Cancella();
            return null;
        }

     
    }

}