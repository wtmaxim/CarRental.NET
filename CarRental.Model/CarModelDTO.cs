using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class CarModelDTO
    {
        public int id { get; set; }
        public string Model { get; set; }
        public int? Places { get; set; }
        public string Energy { get; set; }
        public int id_Car_Make { get; set; }
        public virtual ICollection<CarDTO> Car { get; set; }
        public virtual CarMakeDTO CarMake { get; set; }
    }
}
