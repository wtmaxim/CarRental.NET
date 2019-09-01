using CarRental.DAL;
using CarRental.Model;

namespace CarRental.BLL
{
    public class UserBookingLogic
    {
        private readonly IUserBookingEngine userBookingEngine;

        public UserBookingLogic()
        {
            userBookingEngine = new UserBookingEngine();
        }

        public void Insert(UserBookingDTO userBooking)
        {
            userBookingEngine.Insert(userBooking);
        }
    }
}
