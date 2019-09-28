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
        private UserBookingLogic userBookingLogic;

        public RequestBookingController()
        {
            requestBookingLogic = new RequestBookingLogic();
            bookingLogic = new BookingLogic();
            userBookingLogic = new UserBookingLogic();
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
        public ActionResult AddRequestBooking(RequestBookingDTO requestBooking, int[] passagers, int driver, int driver2, StopOverDTO stopOver, int addressDeparture, int addressArrival)
        {
            RequestBookingDTO requestBooking2 = requestBookingLogic.Insert(requestBooking);
            BookingDTO booking = bookingLogic.Insert(null, null, requestBooking2.id);

            // Ajout des passagers
            for (int i = 0; i < passagers.Length; i++)
            {
                userBookingLogic.Insert(0, 1, booking.Id, passagers[i]);
                userBookingLogic.Insert(0, 0, booking.Id, passagers[i]);
            }

            // Ajout des conducteurs. Ne pas oublier d'jaouter le driver retour.
            userBookingLogic.Insert(1, 1, booking.Id, driver);
            userBookingLogic.Insert(1, 0, booking.Id, driver2);

            // Ajout de l'étape de base
            stopOver.Id_Booking = booking.Id;

            return View();
        }
    }
}