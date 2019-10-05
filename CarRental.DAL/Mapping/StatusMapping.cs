using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL.Mapping
{
    public class StatusMapping
    {
        public StatusDTO MapToStatusDTO(Status status)
        {
            return new StatusDTO
            {
                Id = status.Id,
                Libelle = status.Libelle
            };
        }

        public List<StatusDTO> MapToListStatusDTO(List<Status> statuses)
        {
            List<StatusDTO> retour = new List<StatusDTO>();

            foreach (Status status in statuses)
            {
                StatusDTO newStatus = new StatusDTO
                {
                    Id = status.Id,
                    Libelle = status.Libelle
                };

                retour.Add(newStatus);
            }

            return retour;
        }
    }
}
