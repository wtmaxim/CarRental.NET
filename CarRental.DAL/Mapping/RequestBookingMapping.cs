using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Mapping
{
    public class RequestBookingMapping
    {
        public RequestBookingDTO MapToRequestBookingDTO(RequestBooking requestBooking)
        {
            return new RequestBookingDTO
            {
                Date = requestBooking.Date,
                id = requestBooking.id,
                Id_Status = requestBooking.Id_Status,
                is_Personal_Car_Available = requestBooking.is_Personal_Car_Available,
                Reason = requestBooking.Reason
            };
        }

        public List<RequestBookingDTO> MapToListRequestBookingDTO(List<RequestBooking> requestsBooking)
        {
            List<RequestBookingDTO> retour = new List<RequestBookingDTO>();

            foreach (RequestBooking requestBooking in requestsBooking)
            {
                RequestBookingDTO newRequestBooking = new RequestBookingDTO
                {
                    Date = requestBooking.Date,
                    id = requestBooking.id,
                    Id_Status = requestBooking.Id_Status,
                    is_Personal_Car_Available = requestBooking.is_Personal_Car_Available,
                    Reason = requestBooking.Reason
                };

                retour.Add(newRequestBooking);
            }

            return retour;
        }
    }
}
