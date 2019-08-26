using CarRental.DAL;
using CarRental.DAL.Interface;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class RequestBookingLogic
    {
        private readonly IRequestBookingEngine requestBookingEngine;

        public RequestBookingLogic()
        {
            requestBookingEngine = new RequestBookingEngine();
        }

        public RequestBookingDTO Get(int idBooking)
        {
            return requestBookingEngine.Get(idBooking);
        }
    }
}
