using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL
{
    public class StopOverMapping
    {
        public StopOverDTO MapToStopOverDTO(StopOver stopOver)
        {
            if (stopOver != null)
            {
                return new StopOverDTO
                {
                    Arrival_Date = stopOver.Arrival_Date,
                    Departure_Date = stopOver.Departure_Date,
                    Id = stopOver.Id,
                    Id_Booking = stopOver.Id_Booking,
                    Id_Stop_Over_Type = stopOver.Id_Stop_Over_Type

                };
            } else
            {
                return new StopOverDTO();
            }
            
        }

        public List<StopOverDTO> MapToListStopOverDTO(List<StopOver> stopOvers)
        {
            List<StopOverDTO> retour = new List<StopOverDTO>();

            foreach (StopOver stopOver in stopOvers)
            {
                StopOverDTO newStopOver = new StopOverDTO
                {
                    Arrival_Date = stopOver.Arrival_Date,
                    Departure_Date = stopOver.Departure_Date,
                    Id = stopOver.Id,
                    Id_Booking = stopOver.Id_Booking,
                    Id_Stop_Over_Type = stopOver.Id_Stop_Over_Type
                };

                retour.Add(newStopOver);
            }

            return retour;
        }
    }
}