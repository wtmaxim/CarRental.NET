using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class StopOverAddressEngine : IStopOverAddressEngine
    {
        private StopOverAddressMapping stopOverAddressMapping;

        public StopOverAddressEngine()
        {
            stopOverAddressMapping = new StopOverAddressMapping();
        }

        public StopOverAddressDTO Get(int idStopOver)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                StopOverAddress stopOverAddress = context.usp_StopOverAddress_Get_idStopOver(idStopOver).FirstOrDefault();
                return stopOverAddressMapping.MapToStopOverAddressDTO(stopOverAddress);
            }
        }
    }
}
