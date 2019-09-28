using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;


namespace CarRental.DAL.Mapping
{
    public class ActionMapping
    {
        public ActionDTO MapToActionDTO(Action action)
        {
            if (action != null)
            {
                return new ActionDTO
                {
                    Id = action.Id,
                    Libelle = action.Libelle
                };
            }
            else
                return null;
        }
        public List<ActionDTO> MapToListActionDTO(List<Action> actions)
        {
            return (from Action a in actions
                    let action = new ActionDTO
                    { Id = a.Id, Libelle = a.Libelle }
                    select action).ToList();
        }
    }
}
