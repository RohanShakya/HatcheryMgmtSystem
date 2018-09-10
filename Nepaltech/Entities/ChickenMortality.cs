using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class ChickenMortality:BaseEntity
    {
        public string BatchId { get; set; }
        public string LocationId { get; set; }
        public DateTime DateEntry { get; set; }
        public int MortalityPercentage { get; set; }

        public int DeadChickenMale { get; set; }
        public int DeadChickenFemale { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual Locations Location { get; set; }
        public virtual AddChickenInFarm BatchChicken { get; set; }
        public virtual BreedMortality BreedMortality { get; set; }

    }
}
