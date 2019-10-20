using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;
using System.Linq;

namespace CarRental.DAL
{
    public class StatusEngine : IStatusEngine
    {
        private StatusMapping statusMapping;

        public StatusEngine()
        {
            statusMapping = new StatusMapping();
        }

        public StatusDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                Status status = context.usp_Status_Get(id).FirstOrDefault();
                return statusMapping.MapToStatusDTO(status);
            }
        }
    }
}
