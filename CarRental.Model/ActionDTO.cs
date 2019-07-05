using System.Collections.Generic;

namespace CarRental.Model
{
    public class ActionDTO
    {
        public string Libelle { get; set; }
        public int Id { get; set; }
        public virtual ICollection<RoleDTO> Role { get; set; }
    }
}