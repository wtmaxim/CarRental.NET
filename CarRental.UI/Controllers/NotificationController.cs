using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationLogic notifLogic;
        private readonly UtilisateurLogic userLogic;

        public NotificationController()
        {
            notifLogic = new NotificationLogic();
            userLogic = new UtilisateurLogic();
        }

        /**
         * GET: Notification
         * Page d'index de la liste des notifications
         */
        public ActionResult Index()
        {
            List<NotificationDTO> notifs = notifLogic.ListAll();
            NotificationIndexViewModel vm = new NotificationIndexViewModel
            {
                Notifications = GetNotificationsTuples(notifLogic.ListAll())
            };
            return View(vm);
        }

        /**
         * GetNotificationsTuples
         * Transforme une list de NotificationDTO en Tuple pour la NotificationIndexViewModel
         */
        private List<(NotificationDTO notification, RequestBookingDTO requestBooking, UserDTO user, string departureCity)> GetNotificationsTuples(List<NotificationDTO> list)
        {
            List<(NotificationDTO notification, RequestBookingDTO requestBooking, UserDTO user, string departureCity)> newList = 
                new List<(NotificationDTO notification, RequestBookingDTO requestBooking, UserDTO user, string departureCity)>();

            if (list != null)
            {
                foreach (NotificationDTO notif in list)
                {
                    RequestBookingDTO reqBooking = new RequestBookingDTO();
                    UserDTO user = userLogic.Get(1021);
                    string departureCity = "Nantes";
                    newList.Add((notif, reqBooking, user, departureCity));
                }
            }
            
            return newList;
        }


    }
}