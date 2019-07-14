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
