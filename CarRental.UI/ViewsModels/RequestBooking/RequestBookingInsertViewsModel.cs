using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.RequestBooking
{
    public class RequestBookingInsertViewsModel
    {
        RequestBookingDTO RequestBooking { get; set; }
        int[] Passagers { get; set; }
        int? Driver { get; set; }
        int? Driver2 { get; set; }
        StopOverDTO StopOver { get; set; }
    }
}