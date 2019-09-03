using CarRental.DAL;
using CarRental.DAL.Interface;
using CarRental.Model;

namespace CarRental.BLL
{
    public class RequestBookingLogic
    {
        private readonly IRequestBookingEngine requestBookingEngine;

        public RequestBookingLogic()
        {
            requestBookingEngine = new RequestBookingEngine();
        }

        public RequestBookingDTO Insert(RequestBookingDTO requestBooking)
        {
            requestBooking.Id_Status = 1;
            return requestBookingEngine.Insert(requestBooking);
        }

        public RequestBookingDTO Get(int idBooking)
        {
            return requestBookingEngine.Get(idBooking);
        }
    }
}
