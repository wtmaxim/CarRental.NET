using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingLogic bookingLogic;

        public BookingController()
        {
            bookingLogic = new BookingLogic();
        }

        public ActionResult Index()
        {
            BookingIndexViewsModel vm = new BookingIndexViewsModel();
            List<BookingDTO> bookings;
            List<RequestBookingDTO> requestBookings;
            List<UserBookingDTO> userBookings;
            List<StatusDTO> status;



            return View(vm);
        }
    }
}