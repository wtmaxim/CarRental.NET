using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IBookingEngine
    {
        BookingDTO Insert(BookingDTO booking);
        BookingDTO Get(int id);
        List<BookingDTO> List(string licence_plate);
        BookingDTO GetByRequestBooking(int idRequestBooking);
    }
}
