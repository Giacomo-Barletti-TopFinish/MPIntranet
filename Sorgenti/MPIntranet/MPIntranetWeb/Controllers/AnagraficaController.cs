using MPIntranet.Business;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class AnagraficaController : ControllerBase
    {
      
        public ActionResult Brand()
        {
            return View();
        }

        public ActionResult CaricaBrand()
        {
            Anagrafica a = new Anagrafica();
            List<BrandModel> lista = a.CreaListaBrandModel();

            return PartialView("CaricaBrandPartial", lista);
        }

        public ActionResult RimuoviBrand(decimal idBrand)
        {
            Anagrafica a = new Anagrafica();
            a.CancellaBrand(idBrand, ConnectedUser);
            return null;
        }

        public ActionResult CreaBrand(string brand, string codiceGestionale, string prefissoColore)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaBrand(brand, codiceGestionale, prefissoColore, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaBrand(decimal idBrand, string brand, string codiceGestionale, string prefissoColore)
        {
            Anagrafica a = new Anagrafica();
            a.ModificaBrand(idBrand, brand, codiceGestionale, prefissoColore, ConnectedUser);
            return null;
        }
        public ActionResult Colore()
        {
            Anagrafica a = new Anagrafica();
       //     a. AllineaCodiciColori();
            List<BrandModel> listaBrand = a.CreaListaBrandModel();
            List<MPIntranetListItem> ddlBrand = listaBrand.Select(x => new MPIntranetListItem(string.Format("{0} ({1})", x.Brand, x.PrefissoColore), x.IdBrand.ToString())).ToList();
            ddlBrand.Insert(0, new MPIntranetListItem(string.Empty, "-1"));
            ViewData.Add("dllBrand", ddlBrand);

            return View();
        }

        public ActionResult CaricaColori(string codice, string descrizione, string codiceFigurativo, string codiceCliente, decimal idBrand)
        {
            Anagrafica a = new Anagrafica();
            List<ColoreModel> lista = a.CreaListaColoreModel(codice, descrizione, codiceFigurativo, codiceCliente, idBrand);

            return PartialView("CaricaColoriPartial", lista);
        }

        public ActionResult RimuoviColore(decimal idColore)
        {
            Anagrafica a = new Anagrafica();
            a.CancellaColore(idColore, ConnectedUser);
            return null;
        }

        public ActionResult CreaColore(string descrizione, string codiceCliente, decimal idBrand)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaColore(descrizione, codiceCliente, idBrand, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaColore(decimal idColore, string descrizione)
        {
            Anagrafica a = new Anagrafica();
            a.ModificaColore(idColore, descrizione, ConnectedUser);
            return null;
        }

        public ActionResult TipiDocumento()
        {
            return View();
        }

        public ActionResult CaricaTipiDocumento()
        {
            Anagrafica a = new Anagrafica();
            List<TipoDocumentoModel> lista = a.CreaListaTipoDocumentoModel();

            return PartialView("CaricaTipiDocumentoPartial", lista);
        }

        public ActionResult RimuoviTipoDocumento(decimal idTipoDocumento)
        {
            Anagrafica a = new Anagrafica();
            a.CancellaTipoDocumento(idTipoDocumento, ConnectedUser);
            return null;
        }

        public ActionResult CreaTipoDocumento(string descrizione)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaTipoDocumento(descrizione, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult Materiali()
        {
            return View();
        }

        public ActionResult CaricaMateriali()
        {
            Anagrafica a = new Anagrafica();
            List<MaterialeModel> lista = a.CreaListaMaterialeModel();

            return PartialView("CaricaMaterialiPartial", lista);
        }

        public ActionResult RimuoviMateriale(decimal idMateriale)
        {
            Anagrafica a = new Anagrafica();
            a.CancellaMateriale(idMateriale, ConnectedUser);
            return null;
        }

        public ActionResult CreaMateriale(string codice, string descrizione, bool prezioso, decimal pesoSpecifico)
        {
            Anagrafica a = new Anagrafica();
            string messaggio = a.CreaMateriale(codice, descrizione, prezioso,pesoSpecifico, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaMateriale(decimal idMateriale, string codice, string descrizione, bool prezioso, decimal pesoSpecifico)
        {
            Anagrafica a = new Anagrafica();
            a.ModificaMateriale(idMateriale, codice, descrizione, prezioso, pesoSpecifico, ConnectedUser);
            return null;
        }
    }
}