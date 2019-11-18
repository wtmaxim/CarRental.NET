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
        private readonly AdressLogic addressLogic;
        private readonly BookingLogic bookingLogic;
        private readonly RequestBookingLogic requestBookingLogic;

        public NotificationController()
        {
            notifLogic = new NotificationLogic();
            userLogic = new UtilisateurLogic();
            addressLogic = new AdressLogic();
            bookingLogic = new BookingLogic();
            requestBookingLogic = new RequestBookingLogic();
        }

        /**
         * GET: Notification
         * Page d'index de la liste des notifications
         */
        public ActionResult Index()
        {
            int idCurrentUser = (int)Session["userId"];
            List<NotificationDTO> notifs = notifLogic.ListAllForUser(idCurrentUser);
            NotificationIndexViewModel vm = new NotificationIndexViewModel
            {
                Notifications = GetNotificationsTuples(notifLogic.ListAllForUser(idCurrentUser))
            };
            Session["notifs"] = notifLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;
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
                    reqBooking = requestBookingLogic.Get(notif.IdRequestBooking);

                    UserDTO user = new UserDTO();
                    user = userLogic.Get(reqBooking.CreateBy);

                    int idBooking = bookingLogic.GetByRequestBooking(reqBooking.id).Id;
                    AddressDTO address = addressLogic.GetAddress(idBooking);
                    string departureCity = "Non précisé";
                    if (address.Name != null)
                    {
                        departureCity = address.Name;
                    }
                    else if (address.Locality != null)
                    {
                        departureCity = address.Locality;
                    }

                    newList.Add((notif, reqBooking, user, departureCity));
                    if (notif.IsRead == 0)
                    {
                        notifLogic.MarkAsRead(notif.Id);
                    }
                }
            }
            
            return newList;
        }


    }
}