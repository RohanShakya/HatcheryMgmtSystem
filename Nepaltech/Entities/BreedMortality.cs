using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BreedMortality:BaseEntity
    {
    
        public string BreedId { get; set; }
        public string BreedTypeId { get; set; }
        public int MortalityPercentage { get; set; }
         public int AgeinWeeks { get; set; }
          public virtual Breed Breed { get; set; }
        public virtual BreedTypes BreedType { get; set; }

    }
}
