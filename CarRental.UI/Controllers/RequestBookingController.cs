using CarRental.BLL;
using CarRental.Model;
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

        [HttpPost]
        public ActionResult AddRequestBooking(RequestBookingDTO _requestBooking, int[] passagers, int driver, int driver2)
        {
            RequestBookingDTO requestBooking = requestBookingLogic.Insert(_requestBooking);
            BookingDTO booking = bookingLogic.Insert(null, null, requestBooking.id);

            // Ajout des passagers
            for (int i = 0; i < passagers.Length; i++)
            {
                userBookingLogic.Insert(0, 1, booking.Id, passagers[i]);
                userBookingLogic.Insert(0, 0, booking.Id, passagers[i]);
            }

            // Ajout des conducteurs. Ne pas oublier d'jaouter le driver retour.
            userBookingLogic.Insert(1, 1, booking.Id, driver);
            userBookingLogic.Insert(1, 0, booking.Id, driver2);

            return View();
        }
    }
}