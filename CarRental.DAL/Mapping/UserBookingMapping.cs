using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DAL;
using CarRental.Model;

namespace UserBookingRental.DAL.Mapping
{
    public class UserBookingMapping
    {
        public UserBookingDTO MapToUserBookingDTO(UserBooking userBooking)
        {
            return new UserBookingDTO
            {
                Id_Booking = userBooking.Id_Booking,
                is_Driver = userBooking.is_Driver,
                is_Going = userBooking.is_Going
            };
        }

        public List<UserBookingDTO> MapToListUserBookingDTO(List<UserBooking> userBookings)
        {
            List<UserBookingDTO> retour = new List<UserBookingDTO>();

            foreach (UserBooking userBooking in userBookings)
            {
                UserBookingDTO newUserBooking = new UserBookingDTO
                {
                    Id_Booking = userBooking.Id_Booking,
                    is_Driver = userBooking.is_Driver,
                    is_Going = userBooking.is_Going
                };

                retour.Add(newUserBooking);
            }

            return retour;
        }
    }
}
