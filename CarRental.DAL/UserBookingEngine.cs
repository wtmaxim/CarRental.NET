using CarRental.Model;

namespace CarRental.DAL
{
    public class UserBookingEngine : IUserBookingEngine
    {
        public void Insert(UserBookingDTO userBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_UserBooking_Insert(userBooking.is_Driver, userBooking.is_Going, userBooking.Id_Booking, userBooking.Id_User);
            }
        }
    }
}
