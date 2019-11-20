using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.ViewsModels.RequestBooking
{
    public class RequestBookingInsertViewsModel
    {
        RequestBookingDTO RequestBooking { get; set; }
        StopOverDTO StopOver { get; set; }

        public List<SelectListItem> Addresses { get; set; }
        public List<SelectListItem> Users { get; set; }
        public string userIdDriver { get; set; }
        public string userIdDriver2 { get; set; }
        public string[] userIdPassagers { get; set; }
        public int AddressDepartureId { get; set; }
        public int AddressArrivalId { get; set; }
    }
}