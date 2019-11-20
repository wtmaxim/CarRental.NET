using CarRental.Model;
using System;
using System.Collections.Generic;

namespace CarRental.UI.ViewsModels.Booking
{
    public class BookingAssignationViewsModel
    {
        public List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>> Cars { get; set; }
        public BookingDTO Booking { get; set; }
    }
}