using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class StopOverTypeEngine : IStopOverTypeEngine
    {
        private StopOverTypeMapping stopOverTypeMapping;
        public StopOverTypeEngine()
        {
            stopOverTypeMapping = new StopOverTypeMapping();
        }

        public StopOverTypeDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                StopOverType stopOverType = context.usp_StopOverType_Get_id(id).FirstOrDefault();
                return stopOverTypeMapping.MapToStopOverTypeDTO(stopOverType);
            }
        }
    }
}
