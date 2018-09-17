using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class Batch:BaseEntity
    {
        public string Code { get; set; }
        public string CountryId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Age { get; set; }
        public string BreedId { get; set; }
        public string BreedTypeId { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public int DeadMale { get; set; }
        public int DeadFemale { get; set; }
        public int TotalCost { get; set; }
        public bool Closed { get; set; }
        public int PlacedMale { get; set; }
        public int PlacedFemale { get; set; }

        public virtual Country Country { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual BreedTypes BreedType { get; set; } 
    }
}
