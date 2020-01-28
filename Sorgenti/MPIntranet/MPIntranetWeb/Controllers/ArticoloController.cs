using MPIntranet.Business;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Common;
using MPIntranet.Models.Galvanica;
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

        public ActionResult CreaProcesso(decimal idArticolo)
        {
            Articolo a = new Articolo();
            ArticoloModel model = a.CreaArticoloModel(idArticolo);

            Galvanica g = new Galvanica();
            List<ImpiantoModel> impiantiModel = g.CreaListaImpiantoModel();
            List<MPIntranetListItem> impianti = impiantiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdImpianto.ToString())).ToList();

            ViewData.Add("Impianti", impianti);

            return View(model);
        }

        public ActionResult CaricaListaProcessi(decimal idArticolo, decimal idImpianto)
        {
            ProcessoGalvanico p = new ProcessoGalvanico();
            List<ProcessoModel> processiModel = p.CaricaProcessi(idArticolo, idImpianto);
            List<MPIntranetListItem> processi = processiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdProcesso.ToString())).ToList();
            processi.Insert(processi.Count, new MPIntranetListItem("Nuovo processo", ElementiVuoti.ProcessoGalvanicoNuovo.ToString()));
            processi.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.ProcessoGalvanicoVuoto.ToString()));
            return Json(processi);
        }

        public ActionResult CaricaListaVasche(decimal idImpianto)
        {
            Galvanica g = new Galvanica();
            List<VascaModel> vascheModel = g.CreaListaVascaModel(idImpianto);
            List<MPIntranetListItem> vasche = vascheModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdVasca.ToString())).ToList();
            return Json(vasche);
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
                case (int)MPIntranet.Models.TipoRicerca.Processo:
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

        public ActionResult CaricaProcessiPartial(decimal idArticolo)
        {
            Galvanica g = new Galvanica();
            List<ImpiantoModel> impiantiModel = g.CreaListaImpiantoModel();
            List<MPIntranetListItem> impianti = impiantiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdImpianto.ToString())).ToList();
            ViewData.Add("Impianti", impianti);

            ProcessoGalvanico p = new ProcessoGalvanico();
            List<ProcessoModel> processiModel = p.CaricaProcessi(idArticolo, impiantiModel[0].IdImpianto);
            List<MPIntranetListItem> processi = processiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdProcesso.ToString())).ToList();
            ViewData.Add("Processi", processi);

            return PartialView("ProcessiPartial");
        }

        public ActionResult CaricaProcessoPartial(decimal idArticolo, decimal idProcesso, decimal idImpianto)
        {
            ProcessoModel processoModel = new ProcessoModel();
            Galvanica g = new Galvanica();
            ImpiantoModel impianto = g.CreaListaImpiantoModel().Where(x => x.IdImpianto == idImpianto).FirstOrDefault();
            if (idProcesso == ElementiVuoti.ProcessoGalvanicoNuovo)
            {
                processoModel.Descrizione = string.Empty;
                processoModel.Fasi = new List<FaseProcessoModel>();
                processoModel.IdArticolo = idArticolo;
                processoModel.IdProcesso = idProcesso;
                processoModel.Impianto = impianto;
            }
            else
            {

            }

            return PartialView("MostraProcessoPartial", processoModel);
        }

    }
}