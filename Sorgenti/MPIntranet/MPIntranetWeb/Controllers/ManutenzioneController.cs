﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class ManutenzioneController : ControllerBase
    {
        // GET: Manutenzione
        public ActionResult Ditte()
        {
            //Manutenzione a = new Manutenzione();
            //List<Ditte> lista = a.CreaListaDitte();

            //return PartialView("CaricaDittePartial", lista);
            return View();
        }

        public ActionResult RimuoviDitta(decimal idDitta)
        {
            //Manutenzione a = new Manutenzione();
            //a.CancellaDitta(idDitta, ConnectedUser);
            return null;
        }

        //public ActionResult CreaDitta(string ragioneSociale, decimal IdRiferimenti)
        //{
        //    Manutenzione a = new Manutenzione();
        //    string messaggio = a.CreaDitta(ragioneSociale, IdRiferimenti, ConnectedUser);
        //    return Content(messaggio);
        //}

        public ActionResult ModificaDitta(decimal idDitta, string ragioneSociale, decimal IdRiferimenti)
        {
            //Manutenzione a = new Manutenzione();
            //a.ModificaBrand(idDitta, ragioneSociale, IdRiferimenti );
            return null;
        }


    }
}