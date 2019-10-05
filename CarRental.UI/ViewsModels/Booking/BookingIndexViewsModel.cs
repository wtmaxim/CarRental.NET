using System.Collections.Generic;
using System.Web.Mvc;

namespace CarRental.UI.ViewsModels.Booking
{
    public class BookingIndexViewsModel
    {
        public List<SelectListItem> Addresses { get; set; }
        public List<SelectListItem> Users { get; set; }
        public string userIdDriver { get; set; }
        public string userIdDriver2 { get; set; }
        public string[] userIdPassagers { get; set; }
        public int AddressDepartureId { get; set; }
        public int AddressArrivalId { get; set; }

        public List<Model.Booking> Bookings { get; set; }
    }
}