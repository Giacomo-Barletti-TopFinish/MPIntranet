using MPIntranet.Business;
using MPIntranet.Models;
using MPIntranet.Models.Common;
using MPIntranet.Models.Manutenzione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ManutenzioneController : ControllerBase
    {
        //GET: Manutenzione

        public ActionResult Ditte()
        {
            return View();
        }
        public ActionResult CaricaDitte()
        {
            Manutenzione a = new Manutenzione();
            List<DittaModel> lista = a.CreaListaDittaModel();

            List<MPIntranetListItem> ddlTipologia = new List<MPIntranetListItem>();
            ddlTipologia.Add(new MPIntranetListItem(TipologiaRiferimento.Email, TipologiaRiferimento.Email));
            ddlTipologia.Add(new MPIntranetListItem(TipologiaRiferimento.Telefono, TipologiaRiferimento.Telefono));

            ViewData.Add("ddlTipologia", ddlTipologia);

            return PartialView("CaricaDittePartial", lista);

        }

        public ActionResult CreaDitta(string RagioneSociale)
        {
            Manutenzione a = new Manutenzione();
            string messaggio = a.CreaDitta(RagioneSociale, ConnectedUser);

            return Content(messaggio);
        }

        public ActionResult CancellaDitta(decimal idDitta)
        {
            Manutenzione a = new Manutenzione();
            a.CancellaDitta(idDitta, ConnectedUser);
            return null;
        }

        public ActionResult ModificaDitta(decimal idDitta, string ragioneSociale)
        {
            Manutenzione a = new Manutenzione();
            a.ModificaDitta(idDitta, ragioneSociale, ConnectedUser);
            return null;
        }

        public ActionResult CreaRiferimento(decimal IdEsterna, string TabellaEsterna, string Tipologia, string Etichetta, string Riferimento)
        {
            Manutenzione a = new Manutenzione();
            string messaggio = a.CreaRiferimento(IdEsterna, TabellaEsterna, Tipologia, Etichetta, Riferimento, ConnectedUser);

            return Content(messaggio);
        }

        public ActionResult CancellaRiferimenti(decimal idRiferimenti)
        {
            Manutenzione a = new Manutenzione();
            a.CancellaRiferimento(idRiferimenti, ConnectedUser);
            return null;
        }

        public ActionResult ModificaRiferimenti(decimal idRiferimenti, string Etichetta, string Riferimento, string Tipologia)
        {
            Manutenzione a = new Manutenzione();
            a.ModificaRiferimenti(idRiferimenti, Etichetta, Riferimento, Tipologia, ConnectedUser);
            return null;
        }

        public ActionResult Manutentori()
        {
            Manutenzione m = new Manutenzione();
            List<DittaModel> ditteModel = m.CreaListaDittaModel();

            List<MPIntranetListItem> ditte = ditteModel.Select(x => new MPIntranetListItem(x.RagioneSociale, x.IdDitta.ToString())).ToList();
            ViewData.Add("Ditte", ditte);

            return View();
        }
        public ActionResult CaricaManutentori()
        {
            Manutenzione a = new Manutenzione();
            List<ManutentoreModel> lista = a.CreaListaManutentoreModel();

            List<MPIntranetListItem> ddlTipologia = new List<MPIntranetListItem>();
            ddlTipologia.Add(new MPIntranetListItem(TipologiaRiferimento.Email, TipologiaRiferimento.Email));
            ddlTipologia.Add(new MPIntranetListItem(TipologiaRiferimento.Telefono, TipologiaRiferimento.Telefono));

            ViewData.Add("ddlTipologia", ddlTipologia);

            return PartialView("CaricaManutentoriPartial", lista);

        }

        public ActionResult CreaManutentore(string NomeCognome, string Account, decimal IdDitta, string Nota)
        {
            Manutenzione a = new Manutenzione();
            string messaggio = a.CreaManutentore(NomeCognome, Account, IdDitta, Nota, ConnectedUser);

            return Content(messaggio);
        }

        public ActionResult CancellaManutentore(decimal IdManutentore)
        {
            Manutenzione a = new Manutenzione();
            a.CancellaManutentore(IdManutentore, ConnectedUser);
            return null;
        }

        public ActionResult ModificaManutentore(decimal IdManutentore, string Account, string Nota)
        {
            Manutenzione a = new Manutenzione();
            a.ModificaManutentore(IdManutentore, Account, Nota, ConnectedUser);
            return null;
        }

        public ActionResult Macchine()
        {
            Manutenzione m = new Manutenzione();

            List<DittaModel> ditteModel = m.CreaListaDittaModel();
            List<MPIntranetListItem> ditte = ditteModel.Select(x => new MPIntranetListItem(x.RagioneSociale, x.IdDitta.ToString())).ToList();
            ViewData.Add("Ditte", ditte);

            List<MacchinaModel> macchineModel = m.CreaListaMacchinaModel();
            List<MPIntranetListItem> macchine = macchineModel.Select(x => new MPIntranetListItem(x.ToString(), x.IdMacchina.ToString())).ToList();
            ViewData.Add("Padre", macchine);

            return View();
        }
        public ActionResult CaricaMacchine()
        {
            Manutenzione a = new Manutenzione();
            List<MacchinaModel> macchineModel = a.CreaListaMacchinaModel();


            return PartialView("CaricaMacchinePartial", macchineModel);

        }

        public ActionResult CreaMacchina(string NumeroSerie, string Descrizione, decimal IdDitta, string Luogo, string Nota, string DataCostruzione, decimal idPadre)
        {
            Manutenzione a = new Manutenzione();
            string messaggio = a.CreaMacchina(NumeroSerie, Descrizione, IdDitta, Luogo, Nota, DataCostruzione, idPadre, ConnectedUser);

            return Content(messaggio);
        }

        public ActionResult CancellaMacchina(decimal IdMacchina)
        {
            Manutenzione a = new Manutenzione();
            a.CancellaMacchina(IdMacchina, ConnectedUser);
            return null;
        }

        public ActionResult ModificaMacchina(decimal IdMacchina, string Luogo, string Nota)
        {
            Manutenzione a = new Manutenzione();
            a.ModificaMacchina(IdMacchina, Luogo, Nota, ConnectedUser);
            return null;
        }
    }
}