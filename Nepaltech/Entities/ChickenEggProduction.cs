using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class ChickenEggProduction:BaseEntity
    {
        public string BatchId { get; set; }
        public string LocationId { get; set; }
        public int TotalEggs { get; set; }
        public int GoodEggs { get; set; }
        public int SpoiltEggs { get; set; }
               public DateTime DateEntry { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual Locations Location { get; set; }
        public virtual AddChickenInFarm BatchChicken { get; set; }
        public virtual BreedMortality BreedMortality { get; set; }
    }
}
