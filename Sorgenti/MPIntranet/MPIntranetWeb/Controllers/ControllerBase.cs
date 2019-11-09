using MPIntranet.Models.Security;
using MPIntranet.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MPIntranetWeb.Controllers
{
    public class ControllerBase : Controller
    {
        private string _user;
        protected string ConnectedUser
        {
            get
            {
                return _user.Trim();
            }
            set
            {
                _user = value;
            }
        }
        protected string ClientIPAddress
        {
            get
            {
                var IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(IPAddress))
                {
                    IPAddress = Request.ServerVariables["REMOTE_ADDR"];
                }
                return IPAddress;
            }
        }
        protected static string ConnectionName
        {
            get
            {
                return "MPI";
            }
        }

        protected static string ConnectionString
        {
            get
            {
                ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[ConnectionName];
                return c.ConnectionString;
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            Helpers.LogManager.WriteException(controllerName, actionName, filterContext.Exception);
            throw new WebException(controllerName, actionName, filterContext.Exception);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (controllerName == "Account")
                return;
            switch (controllerName)
            {
                case "Home":

                    HttpCookie coockie = filterContext.RequestContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (coockie == null)
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                    else
                    {
                        try
                        {
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(coockie.Value);
                            string token = ticket.Name;
                            TokenModel tokenModel = Account.GetTokenModel(token);
                            if (tokenModel == null)
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                            if (tokenModel.IpAddress != ClientIPAddress)
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                            ConnectedUser = tokenModel.Account;
                        }
                        catch
                        {
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                        }
                    }
                    break;
            }
        }

        protected void VerificaAbilitazioneUtenteConUscita(int idMenu)
        {
            Account a = new Account();
            if (!a.VerificaAbilitazioneUtente(idMenu, ConnectedUser))
            {
                RedirectToAction("LogOut", "Account");
            }
        }

        protected bool VerificaAbilitazioneUtente(int idMenu)
        {
            Account a = new Account();
            return a.VerificaAbilitazioneUtente(idMenu, ConnectedUser);
        }
    }
}