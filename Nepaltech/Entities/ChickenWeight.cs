using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class ChickenWeight:BaseEntity
    {
        public string BatchChickenId { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public DateTime DateEntry { get; set; }

        public virtual AddChickenInFarm BatchChicken { get; set; }
        public virtual BreedWeight BreedWeight { get; set; }

    }
}
