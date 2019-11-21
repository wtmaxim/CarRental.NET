using CarRental.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class ReservationController : Controller
    {
        private NotificationLogic notificationLogic;

        public ReservationController()
        {
            notificationLogic = new NotificationLogic();
        }

        // GET: Reservation
        public ActionResult Index()
        {
            int idCurrentUser = (int)Session["userId"];
            Session["notifs"] = notificationLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;

            return View();
        }
    }
}