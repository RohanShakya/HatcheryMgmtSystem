using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class Locations:BaseEntity
    {
        public string HatcheryFarmId{ get; set; }
        public string BuildingId { get; set; }
        public string Location { get; set; }

        public virtual HatcheryFarm HatcheryFarm { get; set; }
        public virtual Building Building { get; set; }
    }
}
