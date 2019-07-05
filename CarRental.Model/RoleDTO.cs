using System.Collections.Generic;

namespace CarRental.Model
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<ActionDTO> Action { get; set; }
        public virtual ICollection<UserDTO> User { get; set; }
    }
}