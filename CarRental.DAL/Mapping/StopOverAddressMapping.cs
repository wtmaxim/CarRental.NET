using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL
{
    public class StopOverAddressMapping
    {
        
        public StopOverAddressDTO MapToStopOverAddressDTO(StopOverAddress stopOverAddress)
        {
            return new StopOverAddressDTO
            {
                id_Address = stopOverAddress.id_Address,
                Id_Stop_Over = stopOverAddress.Id_Stop_Over,
                is_Departure = stopOverAddress.is_Departure
            };
        }

        public List<StopOverAddressDTO> MapToListStopOverAddressDTO(List<StopOverAddress> stopOverAddresses)
        {
            List<StopOverAddressDTO> retour = new List<StopOverAddressDTO>();

            foreach (StopOverAddress stopOverAddress in stopOverAddresses)
            {
                StopOverAddressDTO newStopOverAddress = new StopOverAddressDTO
                {
                    id_Address = stopOverAddress.id_Address,
                    Id_Stop_Over = stopOverAddress.Id_Stop_Over,
                    is_Departure = stopOverAddress.is_Departure
                };

                retour.Add(newStopOverAddress);
            }

            return retour;
        }
    }
}