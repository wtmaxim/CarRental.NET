using CarRental.Model;
using System.Linq;

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

        public void Insert(StopOverAddressDTO stopOverAddress)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_StopOverAddress_Insert(stopOverAddress.id_Address, stopOverAddress.Id_Stop_Over, stopOverAddress.is_Departure);
            }
        }
    }
}
