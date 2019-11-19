using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class AddressMapping
    {
        public AddressMapping()
        {

        }

        public AddressDTO MapToAdddressDTO(Address address)
        {
            if (address != null)
            {
                return new AddressDTO
                {
                    Id = address.id,
                    Administrative_Area = address.Administrative_Area,
                    Country = address.Country,
                    Locality = address.Locality,
                    Name = address.Name,
                    Postal_Code = address.Postal_Code,
                    Route = address.Route,
                    Street_Number = address.Street_Number
                };
            }
            else
            {
                return new AddressDTO();
            }
        }

        public List<AddressDTO> MapToListAddressDTO(List<Address> adresses)
        {
            List<AddressDTO> retour = new List<AddressDTO>();

            foreach (Address address in adresses)
            {
                AddressDTO newAdress = new AddressDTO
                {
                    Id = address.id,
                    Administrative_Area = address.Administrative_Area,
                    Country = address.Country,
                    Locality = address.Locality,
                    Name = address.Name,
                    Postal_Code = address.Postal_Code,
                    Route = address.Route,
                    Street_Number = address.Street_Number
                };

                retour.Add(newAdress);
            }

            return retour;
        }
    }
}
