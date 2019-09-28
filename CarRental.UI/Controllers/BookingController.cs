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
        private readonly AdressLogic addressLogic;

        public BookingController()
        {
            bookingLogic = new BookingLogic();
            addressLogic = new AdressLogic();
        }

        public ActionResult Index()
        {

            BookingIndexViewsModel vm = new BookingIndexViewsModel();

            vm.Addresses = PopulateAddress();

            return View(vm);
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
    }
}