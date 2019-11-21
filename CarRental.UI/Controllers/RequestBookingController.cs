using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.RequestBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class RequestBookingController : Controller
    {
        private RequestBookingLogic requestBookingLogic;
        private BookingLogic bookingLogic;
        private AdressLogic addressLogic;
        private StatusLogic statusLogic;
        private UtilisateurLogic utilisateurLogic;
        private UserBookingLogic userBookingLogic;
        private StopOverAddressLogic stopOverAddressLogic;
        private StopOverLogic stopOverLogic;
        private NotificationLogic notificationLogic;
        private RoleLogic roleLogic;

        public RequestBookingController()
        {
            requestBookingLogic = new RequestBookingLogic();
            bookingLogic = new BookingLogic();
            statusLogic = new StatusLogic();
            addressLogic = new AdressLogic();
            utilisateurLogic = new UtilisateurLogic();
            userBookingLogic = new UserBookingLogic();
            stopOverAddressLogic = new StopOverAddressLogic();
            stopOverLogic = new StopOverLogic();
            notificationLogic = new NotificationLogic();
            roleLogic = new RoleLogic();
        }

        [HttpGet]
        public ActionResult Insert(RequestBookingDTO _requestBooking, int[] passagers, int? driver, int? driver2, StopOverDTO stopOver)
        {
            RequestBookingInsertViewsModel vm = new RequestBookingInsertViewsModel();

            vm.Addresses = PopulateAddress();
            vm.Users = PopulateUsers();

            return View(vm);
        }

        private List<SelectListItem> PopulateUsers()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<UserDTO> users = utilisateurLogic.ListAll();

            foreach (UserDTO user in users)
            {
                string fullName = user.Firstname + ' ' + user.Lastname;
                items.Add(new SelectListItem
                {
                    Text = fullName,
                    Value = user.Id.ToString()
                });
            }

            return items;
        }

        private List<SelectListItem> PopulateAddress()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<AddressDTO> addresses = addressLogic.List();

            foreach (AddressDTO address in addresses)
            {
                items.Add(new SelectListItem
                {
                    Text = address.Name,
                    Value = address.Id.ToString()
                });
            }

            return items;
        }

        [HttpPost]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddRequestBooking(RequestBookingDTO requestBooking, int[] _passagers, int driver, int driver2, StopOverDTO stopOver, int addressDeparture, int addressArrival)
        {
            requestBooking.CreateBy = (int)Session["userID"];
            RequestBookingDTO requestBooking2 = requestBookingLogic.Insert(requestBooking);
            BookingDTO booking = bookingLogic.Insert(0, null, requestBooking2.id);
            NotificationDTO notification = new NotificationDTO
            {
                // CreationDateTimestamp default getdate en base
                IdRequestBooking = requestBooking2.id,
                IsForNewRequest = 1,
                IsRead = 0,
                IsForAdmin = 0,
            };


            // Ajout des passagers
            if (_passagers != null )
            {
                for (int i = 0; i < _passagers.Length; i++)
                {
                    userBookingLogic.Insert(0, 1, booking.Id, _passagers[i]);
                    userBookingLogic.Insert(0, 0, booking.Id, _passagers[i]);

                    // Ajout des notification pour chaque passager
                    notification.IdUser = _passagers[i];
                    notificationLogic.Insert(notification);
                }
            }


            // Ajout des conducteurs. Ne pas oublier d'jaouter le driver retour.
            userBookingLogic.Insert(1, 1, booking.Id, driver);
            userBookingLogic.Insert(1, 0, booking.Id, driver2);

            // Ajout des notification pour les conducteurs
            notification.IdUser = driver;
            notificationLogic.Insert(notification);
            if (driver2 != null)
            {
                notification.IdUser = driver2;
                notificationLogic.Insert(notification);
            }

            // Ajout de l'étape de base
            stopOver.Id_Booking = booking.Id;
            stopOver.Id_Stop_Over_Type = 1;
            stopOver = stopOverLogic.Insert(stopOver);

            stopOverAddressLogic.Insert(addressDeparture, stopOver.Id, 1);
            stopOverAddressLogic.Insert(addressArrival, stopOver.Id, 0);

            List<UserDTO> passagersAller = utilisateurLogic.ListPassagers(booking.Id, 1);
            List<UserDTO> passagersRetour = utilisateurLogic.ListPassagers(booking.Id, 0);
            StatusDTO status = statusLogic.GetStatus(requestBooking.Id_Status);
            StopOverAddressDTO stopOverAddress = stopOverAddressLogic.GetStopOverAddress(stopOver.Id);
            UserDTO driverAller = utilisateurLogic.GetDriver(booking.Id, 1);
            UserDTO driverRetour = utilisateurLogic.GetDriver(booking.Id, 0);
            AddressDTO addressAller = addressLogic.GetAddress(booking.Id, 1);
            AddressDTO addressRetour = addressLogic.GetAddress(booking.Id, 0);

            Booking _booking = new Booking
            {
                booking = booking,
                requestBooking = requestBooking,
                stopOver = stopOver,
                passagersAller = passagersAller,
                passagerRetour = passagersRetour,
                status = status,
                stopOverAddress = stopOverAddress,
                driverAller = driverAller,
                driverRetour = driverRetour,
                addressRetour = addressAller,
                addressAller = addressRetour
            };

            // Ajout des notifications pour les administrateurs
            List<UserDTO>  admins = roleLogic.Get_Users_With_Role("Administrateur");
            List<UserDTO> adminsToAdd = roleLogic.Get_Users_With_Role("Admin");
            admins.AddRange(adminsToAdd);

            notification.IsForAdmin = 1;
            if (admins.Count > 0)
            {
                foreach (UserDTO admin in admins)
                {
                    if (admin.Id != requestBooking.CreateBy)
                    {
                        notification.IdUser = admin.Id;
                        notificationLogic.Insert(notification);
                    }
                }
            }
            Session["notifs"] = notificationLogic.ListAllForUser((int)Session["userID"]).FindAll(n => n.IsRead == 0).Count;

            return Json(_booking);
        }
    }
}