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
        public ActionResult SPControlli()
        {
            List<MPIntranetListItem> controlliItems = CreaListaSPControlli();
            ViewData.Add("ddlSPControlli", controlliItems);
            List<MPIntranetListItem> tipiControllo = CreaListaTipoControllo();
            ViewData.Add("ddlTipoControllo", tipiControllo);
            return View();
        }

        public ActionResult GetSPControllo(int IdSPControllo)
        {
            return Json(SPControllo.EstraiSPControllo(IdSPControllo));
        }

        private List<MPIntranetListItem> CreaListaSPControlli()
        {
            List<SPControllo> controlli = SPControllo.EstraiListaSPControlli(true);
            List<MPIntranetListItem> controlliTiems = controlli.Select(x => new MPIntranetListItem(x.Descrizione, x.IdSPControllo.ToString())).ToList();
            controlliTiems.Insert(0, new MPIntranetListItem(" -- CREA NUOVO CONTROLLO -- ", ElementiVuoti.SPControllo.ToString()));

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
    }
}