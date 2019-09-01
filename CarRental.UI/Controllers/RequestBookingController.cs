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
        private UserBookingLogic userBookingLogic;

        public RequestBookingController()
        {
            requestBookingLogic = new RequestBookingLogic();
            userBookingLogic = new UserBookingLogic();
        }

        [HttpPost]
        public ActionResult AddRequestBooking(RequestBookingDTO requestBooking, string[] passagers, string driver)
        {
            //requestBookingLogic.Insert(requestBooking);

            var po = 2;

            //foreach (UserBookingDTO userBooking in usersBooking)
            //{
            //    userBookingLogic.Insert(userBooking);
            //}


            return View();
        }
    }
}