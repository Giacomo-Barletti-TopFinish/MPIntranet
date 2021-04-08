using MPIntranet.Models.Security;
using MPIntranet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeftMenu()
        {
            Account a = new Account();
            List<MenuModel> menu = a.CreateMenuModel(ConnectedUser,false);
            return PartialView(menu);
        }
    }
}