using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class BookingLogic
    {
        private readonly IBookingEngine bookingEngine;

        public BookingLogic()
        {
            bookingEngine = new BookingEngine();
        }

        public BookingDTO Get(int id)
        {
            return bookingEngine.Get(id);
        }

        public BookingDTO GetByRequestBooking(int idRequestBooking)
        {
            return bookingEngine.GetByRequestBooking(idRequestBooking);
        }

        public List<BookingDTO> List(string licence_plate)
        {
            return bookingEngine.List(licence_plate);
        }

        public BookingDTO Insert(byte isPersonalCarUsed, string licencePlate, int idRequestBooking)
        {
            BookingDTO booking = new BookingDTO
            {
                id_Request_Booking = idRequestBooking,
                is_Personal_Car_Used = isPersonalCarUsed,
                Licence_Plate = licencePlate
            };

            return bookingEngine.Insert(booking);
        }

        public void Update(int idBooking, string licencePlate)
        {
            bookingEngine.Update(idBooking, licencePlate);
        }
    }
}
