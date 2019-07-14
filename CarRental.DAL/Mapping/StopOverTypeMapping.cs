using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class StopOverTypeMapping
    {
        public StopOverTypeDTO MapToStopOverTypeDTO(StopOverType stopOverType)
        {
            return new StopOverTypeDTO
            {
                Id = stopOverType.Id,
                Libelle = stopOverType.Libelle
            };
        }

        public List<StopOverTypeDTO> MapToListStopOverTypeDTO(List<StopOverType> stopOverTypes)
        {
            List<StopOverTypeDTO> retour = new List<StopOverTypeDTO>();

            foreach (StopOverType stopOverType in stopOverTypes)
            {
                StopOverTypeDTO newStopOverType = new StopOverTypeDTO
                {
                    Id = stopOverType.Id,
                    Libelle = stopOverType.Libelle
                };

                retour.Add(newStopOverType);
            }

            return retour;
        }
    }
}
