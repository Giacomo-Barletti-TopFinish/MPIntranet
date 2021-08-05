using MPIntranet.Business;
using MPIntranet.Business.SchedeProcesso;
using MPIntranet.Entities;
using MPIntranet.Helpers;
using MPIntranet.Models.Common;
using MPIntranet.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class SchedeProcessoController : ControllerBase
    {
        public ActionResult SPMaster()
        {
            List<SPMasters> masters = SPMasters.EstraiListaSPMaster(true);
            List<MPIntranetListItem> mItems = masters.Select(x => new MPIntranetListItem(x.Descrizione, x.IdSPMaster.ToString())).ToList();
            mItems.Insert(0, new MPIntranetListItem(" -- CREA NUOVO MASTER -- ", ElementiVuoti.SPMaster.ToString()));
            ViewData.Add("ddlSPMasters", mItems);

            List<MPIntranetListItem> controlliItems = CreaListaSPControlli(" -- SELEZIONA UN CONTROLLO -- ");
            ViewData.Add("ddlSPControlli", controlliItems);

            List<TaskArea> tasks = TaskArea.EstraiListaTaskArea(true);
            List<string> AreaProduzione = tasks.OrderBy(x => x.AreaProduzione).Select(x => x.AreaProduzione.Trim()).Distinct().ToList();
            List<MPIntranetListItem> areeProduzione = AreaProduzione.Select(x => new MPIntranetListItem(x, x)).ToList();
            areeProduzione.Insert(0, new MPIntranetListItem(string.Empty, string.Empty));
            ViewData.Add("ddlAreaProduzione", areeProduzione);

            return View();
        }
        public ActionResult SPControlli()
        {
            List<MPIntranetListItem> controlliItems = CreaListaSPControlli(" -- CREA NUOVO CONTROLLO -- ");
            ViewData.Add("ddlSPControlli", controlliItems);
            List<MPIntranetListItem> tipiControllo = CreaListaTipoControllo();
            ViewData.Add("ddlTipoControllo", tipiControllo);
            return View();
        }
        public ActionResult GetSPControllo(int IdSPControllo)
        {
            return Json(SPControllo.EstraiSPControllo(IdSPControllo));
        }

        public ActionResult GetTasks(string AreaProduzione)
        {
            List<TaskArea> tasks = TaskArea.EstraiListaTaskArea(true);
            List<string> t = tasks.Where(x => x.AreaProduzione == AreaProduzione).OrderBy(x => x.Task).Select(x => x.Task.Trim()).Distinct().ToList();
            List<MPIntranetListItem> ts = t.Select(x => new MPIntranetListItem(x, x)).ToList();
            return Json(ts);
        }
        public ActionResult GetSPMaster(int IdSPMaster)
        {
            return Json(SPMasters.EstraiSPMaster(IdSPMaster));
        }
        private List<MPIntranetListItem> CreaListaSPControlli(string etichetta)
        {
            List<SPControllo> controlli = SPControllo.EstraiListaSPControlli(true);
            List<MPIntranetListItem> controlliTiems = controlli.Select(x => new MPIntranetListItem(x.ToString(), x.IdSPControllo.ToString())).ToList();
            controlliTiems.Insert(0, new MPIntranetListItem(etichetta, ElementiVuoti.SPControllo.ToString()));

            return controlliTiems;
        }

        private List<MPIntranetListItem> CreaListaTipoControllo()
        {
            List<MPIntranetListItem> tipoControlli = new List<MPIntranetListItem>();
            tipoControlli.Add(new MPIntranetListItem(TipoSPControllo.CHECKBOX, TipoSPControllo.CHECKBOX));
            tipoControlli.Add(new MPIntranetListItem(TipoSPControllo.DATA, TipoSPControllo.DATA));
            tipoControlli.Add(new MPIntranetListItem(TipoSPControllo.LISTA, TipoSPControllo.LISTA));
            tipoControlli.Add(new MPIntranetListItem(TipoSPControllo.NUMERO, TipoSPControllo.NUMERO));
            tipoControlli.Add(new MPIntranetListItem(TipoSPControllo.TESTO, TipoSPControllo.TESTO));

            tipoControlli.Insert(0, new MPIntranetListItem(string.Empty, ElementiVuoti.TipoSPControllo.ToString()));

            return tipoControlli;
        }

        public ActionResult AggiornaControllo(int IdSPControllo, string Codice, string Descrizione, string Tipo, string Lista)
        {
            Codice = Codice.ToUpper();
            Descrizione = Descrizione.ToUpper();
            Tipo = Tipo.ToUpper();


            ElementoLista[] elementiLista = JSonSerializer.Deserialize<ElementoLista[]>(Lista);

            string messaggio = SPControllo.SalvaControllo(IdSPControllo, Codice, Descrizione, Tipo, 0, 0, 0, elementiLista, ConnectedUser);
            return Content(messaggio);
        }

        public ActionResult AggiornaMaster(int IdSPMaster, string Codice, string Descrizione, string Task, string AreaProduzione, string Lista)
        {
            Codice = Codice.ToUpper();
            Descrizione = Descrizione.ToUpper();
            Task = Task.ToUpper();
            AreaProduzione = AreaProduzione.ToUpper();

            ElementoMaster[] elementiLista = JSonSerializer.Deserialize<ElementoMaster[]>(Lista);

            string messaggio = SPMasters.SalvaMaster(IdSPMaster, Codice, Descrizione, AreaProduzione, Task, elementiLista, ConnectedUser);
            return Content(messaggio);
        }
    }
}