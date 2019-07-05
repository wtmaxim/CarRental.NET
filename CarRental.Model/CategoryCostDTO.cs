using System.Collections.Generic;

namespace CarRental.Model
{
    public class CategoryCostDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<CostDTO> Cost { get; set; }
    }
}