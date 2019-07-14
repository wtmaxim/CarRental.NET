using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL
{
    public class BookingMapping
    {
        public BookingDTO MapToBookingDTO(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                id_Request_Booking = booking.id_Request_Booking,
                is_Personal_Car_Used = booking.is_Personal_Car_Used,
                Licence_Plate = booking.Licence_Plate,
            };
        }

        public List<BookingDTO> MapToListBookingDTO(List<Booking> bookings)
        {
            List<BookingDTO> retour = new List<BookingDTO>();

            foreach (Booking booking in bookings)
            {
                BookingDTO newBooking = new BookingDTO
                {
                    Id = booking.Id,
                    id_Request_Booking = booking.id_Request_Booking,
                    is_Personal_Car_Used = booking.is_Personal_Car_Used,
                    Licence_Plate = booking.Licence_Plate,
                };

                retour.Add(newBooking);
            }

            return retour;
        }
    }
}
