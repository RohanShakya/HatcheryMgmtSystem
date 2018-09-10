using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
   public class Building:BaseEntity
    {
        public String Buildings { get; set; }
        public string HatcheryFarmId { get; set; }
        public virtual HatcheryFarm HatcheryFarm { get; set; }
    }
}
