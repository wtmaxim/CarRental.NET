using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly NotificationLogic notifLogic;

        public HomeController()
        {
            notifLogic = new NotificationLogic();
        }
        /// <summary>
        /// Get : Affiche le dashboard aux utilisateur connecté qui ont un role disposant de l'action dashboard
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            int idCurrentUser = (int)Session["userId"];
            ViewBag.AdminNotifs = notifLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0 && n.IsForAdmin == 1).Count;
            return View();
        }

    }
}