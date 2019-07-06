using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class CarMakeDTO
    {
        public int id { get; set; }
        public string Make { get; set; }
        public virtual ICollection<CarModelDTO> CarModel { get; set; }
    }
}
