using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.ViewsModels.Booking
{
    public class BookingIndexViewsModel
    {
        public List<SelectListItem> Addresses { get; set; }
        public List<SelectListItem> Users { get; set; }
        public int AddressDepartureId { get; set; }
        public int AddressArrivalId { get; set; }
    }
}