using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class BookingEngine : IBookingEngine
    {
        private BookingMapping bookingMapping;

        public BookingEngine()
        {
            bookingMapping = new BookingMapping();
        }

        public void Insert(BookingDTO booking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                //context.usp_Booking_Insert(booking.Id, booking.id_Request_Booking, booking.is_Personal_Car_Used, booking.Licence_Plate);
            }
        }

        public BookingDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                Booking booking = context.usp_Booking_Get_Id(id).FirstOrDefault();
                return bookingMapping.MapToBookingDTO(booking);
            }
        }

        public List<BookingDTO> List(string licence_plate)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<Booking> bookings = context.usp_Booking_List_LicencePlate(licence_plate).ToList();
                return bookingMapping.MapToListBookingDTO(bookings);
            }
        }

    }
}
