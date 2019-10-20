using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Interface
{
    public interface IRequestBookingEngine
    {
        RequestBookingDTO Insert(RequestBookingDTO requestBooking);
        RequestBookingDTO Get(int idBooking);
        List<RequestBookingDTO> List(int idUser);
        IEnumerable<RequestBookingDTO> List();
        RequestBookingDTO GetByRequestBooking(int idRequestBooking);
    }
}
