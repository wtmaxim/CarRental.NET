using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class VoitureController : Controller
    {
        // GET: Voiture
        public ActionResult Index()
        {
            return View();
        }
    }
}