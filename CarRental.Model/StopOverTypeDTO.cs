using System.Collections.Generic;

namespace CarRental.Model
{
    public class StopOverTypeDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<StopOverDTO> StopOver { get; set; }
    }
}