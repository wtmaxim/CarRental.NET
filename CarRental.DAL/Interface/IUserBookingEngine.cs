using CarRental.Model;

namespace CarRental.DAL
{
    public interface IUserBookingEngine
    {
        void Insert(UserBookingDTO userBooking);
    }
}