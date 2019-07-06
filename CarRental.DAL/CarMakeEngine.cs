using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class CarMakeEngine : ICarMakeEngine
    {
        private CarMakeMapping carMakeMapping;

        public CarMakeEngine()
        {
            carMakeMapping = new CarMakeMapping();
        }

        public CarMakeDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                CarMake carMake = context.usp_CarMake_Get_Id(id).FirstOrDefault();
                return carMakeMapping.MapToCarMakeDTO(carMake);
            }
        }
    }
}
