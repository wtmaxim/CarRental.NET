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

        public void Insert(RequestBookingDTO requestBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_RequestBooking_Insert(requestBooking.is_Personal_Car_Available, requestBooking.Reason, requestBooking.Id_Status);
            }
        }
    }
}
