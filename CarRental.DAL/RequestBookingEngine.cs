using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;
using System.Linq;

namespace CarRental.DAL
{
    public class RequestBookingEngine : IRequestBookingEngine
    {
        private RequestBookingMapping requestBookingMapping;

        public RequestBookingEngine()
        {
            requestBookingMapping = new RequestBookingMapping();
        }

        public RequestBookingDTO Get(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                RequestBooking requestBooking = context.usp_RequestBooking_Get_IdBooking(idBooking).FirstOrDefault();
                return requestBookingMapping.MapToRequestBookingDTO(requestBooking);
            }
        }

        public RequestBookingDTO Insert(RequestBookingDTO _requestBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                RequestBooking requestBooking = context.usp_RequestBooking_Insert(_requestBooking.is_Personal_Car_Available, _requestBooking.Reason, _requestBooking.Id_Status).FirstOrDefault();
                return requestBookingMapping.MapToRequestBookingDTO(requestBooking);
            }
        }
    }
}
