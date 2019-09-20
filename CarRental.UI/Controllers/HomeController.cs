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
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        /// <summary>
        /// Get : Affiche le dashboard aux utilisateur connecté qui ont un role disposant de l'action dashboard
        /// </summary>
        /// <returns></returns>
        [Authorize (Roles="dashboard")]
        public ActionResult Index()
        {
         
            return View();
        }

    }
}