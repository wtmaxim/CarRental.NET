using CarRental.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DAL
{
    public class RoleMapping
    {
        public List<RoleDTO> MapToListRoleDTO(ICollection<Role> roles)
        {
            List<RoleDTO> retour = new List<RoleDTO>();
            foreach (Role role in roles)
            {
                RoleDTO newRole = new RoleDTO
                {
                    Id = role.Id,
                    Libelle = role.Libelle
                };
                retour.Add(newRole);
            }
            return retour;
        }
    }
}