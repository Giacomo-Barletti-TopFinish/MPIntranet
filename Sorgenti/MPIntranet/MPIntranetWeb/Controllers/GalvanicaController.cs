using MPIntranet.Business;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Common;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class GalvanicaController : ControllerBase
    {
        public ActionResult Impianti()
        {
            return View();
        }

        public ActionResult CaricaImpianti()
        {
            Galvanica a = new Galvanica();
            List<ImpiantoModel> lista = a.CreaListaImpiantoModel();

            return PartialView("CaricaImpiantiPartial", lista);
        }

        public ActionResult RimuoviImpianto(decimal idImpianto)
        {
            Galvanica a = new Galvanica();
            a.CancellaImpianto(idImpianto, ConnectedUser);
            return null;
        }

        public ActionResult CreaImpianto(string descrizione)
        {
            Galvanica a = new Galvanica();
            string messaggio = a.CreaImpianto(descrizione, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaImpianto(decimal idImpianto, string descrizione)
        {
            Galvanica a = new Galvanica();
            a.ModificaImpianto(idImpianto, descrizione, ConnectedUser);
            return null;
        }

        public ActionResult Vasche()
        {
            Galvanica g = new Galvanica();
            List<ImpiantoModel> impiantiModel = g.CreaListaImpiantoModel();
            List<MPIntranetListItem> impianti = impiantiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdImpianto.ToString())).ToList();

            Anagrafica a = new Anagrafica();
            List<MaterialeModel> materialiModel = a.CreaListaMaterialeModel();
            List<MPIntranetListItem> materiali = materialiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdMateriale.ToString())).ToList();
            materiali.Add(new MPIntranetListItem(string.Empty, "-1"));

            ViewData.Add("Impianti", impianti);
            ViewData.Add("Materiali", materiali);

            return View();
        }

        public ActionResult CaricaVasche(decimal idImpianto)
        {
            Galvanica a = new Galvanica();
            List<VascaModel> lista = a.CreaListaVascaModel(idImpianto);

            return PartialView("CaricaVaschePartial", lista);
        }

        public ActionResult RimuoviVasca(decimal idVasca)
        {
            Galvanica a = new Galvanica();
            a.CancellaVasca(idVasca, ConnectedUser);
            return null;
        }

        public ActionResult CreaVasca(string descrizioneBreve, string descrizione, bool abilitaStrato, decimal idImpianto, decimal idMateriale)
        {
            Galvanica a = new Galvanica();
            string messaggio = a.CreaVasca(descrizioneBreve, descrizione, abilitaStrato, idImpianto, idMateriale, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaVasca(decimal idVasca, string descrizioneBreve, string descrizione, bool abilitaStrato)
        {
            Galvanica a = new Galvanica();
            a.ModificaVasca(idVasca, descrizioneBreve, descrizione, abilitaStrato, ConnectedUser);
            return null;
        }

        public ActionResult CaricaVascaModel(decimal idVasca)
        {
            Galvanica a = new Galvanica();
            List<VascaModel> lista = a.CreaListaVascaModel();
            VascaModel vasca = lista.Where(x => x.IdVasca == idVasca).FirstOrDefault();
            return Json(vasca);
        }

        public ActionResult PROCESSISTANDARD()
        {
            Anagrafica a = new Anagrafica();
            Galvanica g = new Galvanica();
            List<ImpiantoModel> impiantiModel = g.CreaListaImpiantoModel();
            List<MPIntranetListItem> impianti = impiantiModel.Select(x => new MPIntranetListItem(x.Descrizione, x.IdImpianto.ToString())).ToList();
            List<ColoreModel> coloriModel = a.CreaListaColoreModel();
            List<MPIntranetListItem> colori = coloriModel.OrderBy(x=>x.CodiceFigurativo).Select(x => new MPIntranetListItem(x.ToString(), x.IdColore.ToString())).ToList();

            ViewData.Add("Impianti", impianti);
            ViewData.Add("Colori", colori);

            return View();
        }

        public ActionResult Telai()
        {
            List<MPIntranetListItem> tipiMontaggio = new List<MPIntranetListItem>();
            tipiMontaggio.Add(new MPIntranetListItem(string.Empty,string.Empty));
            tipiMontaggio.Add(new MPIntranetListItem("MONTATO", "MONTATO"));
            tipiMontaggio.Add(new MPIntranetListItem("LEGATO", "LEGATO"));
            ViewData.Add("TipiMontaggio", tipiMontaggio);
            return View();
        }

        public ActionResult CaricaTelai()
        {
            Galvanica a = new Galvanica();
            List<TelaioModel> lista = a.CreaListaTelaioModel();

            return PartialView("CaricaTelaiPartial", lista);
        }

        public ActionResult RimuoviTelaio(decimal IdTelaio)
        {
            Galvanica a = new Galvanica();
            a.CancellaTelaio(IdTelaio, ConnectedUser);
            return null;
        }

        public ActionResult CreaTelaio(string Codice, decimal Pezzi, string TipoMontaggio, decimal Costo)
        {
            Galvanica a = new Galvanica();
            string messaggio = a.CreaTelaio(Codice, Pezzi, TipoMontaggio, Costo, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult ModificaTelaio(decimal IdTelaio, decimal Costo)
        {
            Galvanica a = new Galvanica();
            a.ModificaTelaio(IdTelaio, Costo, ConnectedUser);
            return null;
        }
    }
}