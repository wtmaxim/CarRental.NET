using System.Linq;
using CarRental.Model;

namespace CarRental.DAL
{
    public class CarModelEngine : ICarModelEngine
    {
        private CarModelMapping carModelMapping;

        public CarModelEngine()
        {
            carModelMapping = new CarModelMapping();
        }

        public CarModelDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                CarModel carModel = context.usp_CarModel_Get_id(id).FirstOrDefault();
                return carModelMapping.MapToCarModelDTO(carModel);
            }
        }
    }
}
