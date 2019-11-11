using MPIntranet.Models.Common;
using MPIntranet.Models.Security;
using MPIntranet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MPIntranetWeb.Controllers
{
    public class AccountController : ControllerBase
    {
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account a = new Account();
                string token = a.VerificaAccount(model.Account.ToLower().Trim(), model.Password.Trim(), ClientIPAddress);

                if (string.IsNullOrWhiteSpace(token))
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(model);
                }

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                           1,
                           token,
                           DateTime.Now,
                           DateTime.Now.AddMinutes(30),
                           false,
                           "Account"
                     );

                string formsCookieStr = FormsAuthentication.Encrypt(ticket);
                HttpCookie formsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, formsCookieStr);
                HttpContext.Response.Cookies.Add(formsCookie);
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(string.Empty, "User or password incorrect.");
            return View(model);
        }

        public ActionResult AbilitaMenu()
        {
            Account a = new Account();
            List<string> utenti = a.EstraiListaUtentiAbilitati();
            List<MPIntranetListItem> UtentiAbilitati = utenti.Select(x => new MPIntranetListItem(x, x)).ToList();
            UtentiAbilitati.Insert(0, new MPIntranetListItem("** NESSUN UTENTE **", string.Empty));
            ViewData.Add("ListaUtenti", UtentiAbilitati);
            return View();
        }

        public ActionResult GetMenuUtente(string account)
        {
            Account a = new Account();
            List<MenuModel> menu = a.CreateMenuModel(account, true);

            return PartialView("GetMenuUtentePartial", menu);
        }

        public ActionResult SalvaMenuUtente(string account, int[] idMenu)
        {
            Account a = new Account();
            a.SalvaMenuUtente(account, idMenu);
            return null;
        }

        public ActionResult RimuoviAccount(string account)
        {
            Account a = new Account();
            a.RimuoviAccount(account);
            return null;
        }

        public ActionResult CreaNuovoAccount(string account, bool copia, string daCopiare)
        {
            account = account.ToLower();
            if (!Dominio.VerificaAccountEsiste(account))
            {
                return Content("Account non trovato sul dominio");
            }

            Account a = new Account();
            if (a.EstraiListaUtentiAbilitati().Contains(account))
                return Content("Account esiste già");

            a.CreaAccount(account, copia, daCopiare);
            return Content("Account creato");
        }

    }
}