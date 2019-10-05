using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface IUserBookingEngine
    {
        void Insert(UserBookingDTO userBooking);
        List<UserBookingDTO> GetPassagersByBooking(int idBooking);
    }
}