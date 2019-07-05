using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class AdressEngine : IAdressEngine
    {
        private AddressMapping addressMapping;

        public AdressEngine()
        {
            addressMapping = new AddressMapping();
        }

        public List<AddressDTO> List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var adresses = context.usp_Adress_List().ToList();
                return addressMapping.MapToListAddressDTO(adresses);
            }
        }
    }
}
