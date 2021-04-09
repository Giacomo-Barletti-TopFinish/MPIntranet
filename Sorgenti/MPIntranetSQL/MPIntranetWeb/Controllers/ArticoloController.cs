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

            //Anagrafica a = new Anagrafica();
            //List<BrandModel> brandModels = a.CreaListaBrandModel();
            //List<MPIntranetListItem> brands = brandModels.Select(x => new MPIntranetListItem(x.Brand, x.IdBrand.ToString())).ToList();
            //brands.Insert(0, new MPIntranetListItem(string.Empty, "-1"));

            //ViewData.Add("Brand", brands);
            //ViewData.Add("TipoRicerca", TipoRicerca);
            return View();
        }

        public ActionResult CreaArticolo()
        {
            List<Brand> brands = Brand.EstraiListaBrand(true);
            List<MPIntranetListItem> brandsItems = brands.Select(x => new MPIntranetListItem(x.Model.Descrizione, x.ID.ToString())).ToList();
            brandsItems.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.Brand.ToString()));

            ViewData.Add("dllBrand", brandsItems);

            return View();
        }

        public ActionResult SalvaArticolo(int idBrand, string anagrafica, string descrizione, string codiceCliente, string codiceColore)
        {
            string messaggio = Articolo.CreaArticolo(idBrand, anagrafica, descrizione, codiceCliente, codiceColore, ConnectedUser);
            return Content(messaggio);
        }
    }


}