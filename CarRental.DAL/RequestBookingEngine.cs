using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;
using System.Collections.Generic;
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

        public RequestBookingDTO GetByRequestBooking(int idRequestBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                RequestBooking requestBooking = context.usp_RequestBooking_Get(idRequestBooking).FirstOrDefault();
                return requestBookingMapping.MapToRequestBookingDTO(requestBooking);
            }
        }

        public RequestBookingDTO Insert(RequestBookingDTO _requestBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                RequestBooking requestBooking = context.usp_RequestBooking_Insert(_requestBooking.is_Personal_Car_Available, _requestBooking.Reason, _requestBooking.Id_Status, _requestBooking.CreateBy).FirstOrDefault();
                return requestBookingMapping.MapToRequestBookingDTO(requestBooking);
            }
        }

        public List<RequestBookingDTO> List(int idUser)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<RequestBooking> requestBookings = context.usp_RequestBooking_List_IdUser(idUser).ToList();
                return requestBookingMapping.MapToListRequestBookingDTO(requestBookings);
            }
        }

        public IEnumerable<RequestBookingDTO> List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<RequestBooking> requestBookings = context.usp_RequestBooking_List().ToList();
                return requestBookingMapping.MapToListRequestBookingDTO(requestBookings);
            }
        }

        public void Update(int idRequestBooking, int idStatus)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_RequestBooking_Update(idStatus, idRequestBooking);
            }
        }
    }
}
