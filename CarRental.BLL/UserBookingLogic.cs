using System.Collections.Generic;
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

        public void Insert(byte is_Driver, byte is_Going, int Id_Booking, int Id_User)
        {
            UserBookingDTO userBooking = new UserBookingDTO
            {
                is_Driver = is_Driver,
                is_Going = is_Going,
                Id_Booking = Id_Booking,
                Id_User = Id_User
            };

            userBookingEngine.Insert(userBooking);
        }

        public List<UserBookingDTO> GetPassagersByBooking(int idBooking)
        {
            return userBookingEngine.GetPassagersByBooking(idBooking);
        }
    }
}
