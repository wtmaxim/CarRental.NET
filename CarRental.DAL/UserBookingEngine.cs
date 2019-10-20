using System.Collections.Generic;
using System.Linq;
using CarRental.Model;
using UserBookingRental.DAL.Mapping;

namespace CarRental.DAL
{
    public class UserBookingEngine : IUserBookingEngine
    {
        private UserBookingMapping userBookingMapping;

        public UserBookingEngine()
        {
            userBookingMapping = new UserBookingMapping();
        }

        public List<UserBookingDTO> GetPassagersByBooking(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<UserBooking> userBookings = context.usp_UserBooking_ListPassagers_IdBooking(idBooking).ToList();
                return userBookingMapping.MapToListUserBookingDTO(userBookings);
            }
        }

        public void Insert(UserBookingDTO userBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_UserBooking_Insert(userBooking.is_Driver, userBooking.is_Going, userBooking.Id_Booking, userBooking.Id_User);
            }
        }
    }
}
