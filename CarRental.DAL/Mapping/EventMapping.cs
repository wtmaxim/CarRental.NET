using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL.Mapping
{
    public class EventMapping
    {
        public EventMapping()
        {

        }

        public List<EventDTO> MapToListEventDTO(List<Event> events)
        {
            List<EventDTO> retour = new List<EventDTO>();

            foreach (Event _event in events)
            {
                EventDTO newEvent = new EventDTO
                {
                    End_Date = _event.End_Date,
                    Id = _event.Id,
                    Libelle = _event.Libelle,
                    Licence_Plate = _event.Licence_Plate,
                    Start_Date = _event.Start_Date
                };

                retour.Add(newEvent);
            }

            return retour;
        }
    }
}
