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
        }

        [HttpGet]
        public ActionResult Insert(RequestBookingDTO _requestBooking, int[] passagers, int? driver, int? driver2, StopOverDTO stopOver)
        {
            RequestBookingInsertViewsModel vm = new RequestBookingInsertViewsModel();

            return View(vm);
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
            BookingDTO booking = bookingLogic.Insert(0, "AA00AA", requestBooking2.id);


            // Ajout des passagers
            if(_passagers != null )
            {
                for (int i = 0; i < _passagers.Length; i++)
                {
                    userBookingLogic.Insert(0, 1, booking.Id, _passagers[i]);
                    userBookingLogic.Insert(0, 0, booking.Id, _passagers[i]);
                }
            }


            // Ajout des conducteurs. Ne pas oublier d'jaouter le driver retour.
            userBookingLogic.Insert(1, 1, booking.Id, driver);
            userBookingLogic.Insert(1, 0, booking.Id, driver2);

            // Ajout de l'étape de base
            stopOver.Id_Booking = booking.Id;
            stopOver.Id_Stop_Over_Type = 1;
            stopOver = stopOverLogic.Insert(stopOver);

            stopOverAddressLogic.Insert(addressDeparture, stopOver.Id, 1);
            stopOverAddressLogic.Insert(addressArrival, stopOver.Id, 0);

            List<UserDTO> passagers = utilisateurLogic.ListPassagers(booking.Id);
            StatusDTO status = statusLogic.GetStatus(requestBooking.Id_Status);
            StopOverAddressDTO stopOverAddress = stopOverAddressLogic.GetStopOverAddress(stopOver.Id);
            UserDTO driverAller = utilisateurLogic.GetDriver(booking.Id, 1);
            UserDTO driverRetour = utilisateurLogic.GetDriver(booking.Id, 0);
            AddressDTO addressAller = addressLogic.GetAddress(booking.Id);
            AddressDTO addressRetour = addressLogic.GetAddress(booking.Id);

            Booking _booking = new Booking
            {
                booking = booking,
                requestBooking = requestBooking,
                stopOver = stopOver,
                passagers = passagers,
                status = status,
                stopOverAddress = stopOverAddress,
                driverAller = driverAller,
                driverRetour = driverRetour,
                addressRetour = addressAller,
                addressAller = addressRetour
            };

            return Json(_booking);
        }
    }
}