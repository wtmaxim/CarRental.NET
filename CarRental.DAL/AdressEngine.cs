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

        public AddressDTO GetAddress(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                Address address = context.usp_Address_GetAddress(idBooking).FirstOrDefault();
                return addressMapping.MapToAdddressDTO(address);
            }
        }

        public AddressDTO GetAddress(int idBooking, byte isDeparture)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                Address address = context.usp_Address_Get_idBooking_isDeparture(idBooking, isDeparture).FirstOrDefault();
                return addressMapping.MapToAdddressDTO(address);
            }
        }
    }
}
