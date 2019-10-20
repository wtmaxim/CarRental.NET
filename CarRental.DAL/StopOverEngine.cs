using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class StopOverEngine : IStopOverEngine
    {
        private StopOverMapping stopOverMapping;

        public StopOverEngine()
        {
            stopOverMapping = new StopOverMapping();
        }

        public StopOverDTO Add(StopOverDTO _stopOver)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                StopOver stopOver = context.usp_StopOver_Insert(_stopOver.Arrival_Date, _stopOver.Departure_Date, _stopOver.Id_Booking, _stopOver.Id_Stop_Over_Type).FirstOrDefault();
                return stopOverMapping.MapToStopOverDTO(stopOver);
            }
        }

        public StopOverDTO GetByBooking(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                StopOver stopOver = context.usp_StopOver_Get_idBooking(idBooking).FirstOrDefault();
                return stopOverMapping.MapToStopOverDTO(stopOver);
            }
        }

        public List<StopOverDTO> List(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<StopOver> stopOvers = context.usp_StopOver_List_idBooking(idBooking).ToList();
                return stopOverMapping.MapToListStopOverDTO(stopOvers);
            }
        }
    }
}
