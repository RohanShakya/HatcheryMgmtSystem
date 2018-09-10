using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BatchShifting:BaseEntity
    {
        public string BatchLocationId { get; set; }
           
        public DateTime DateEntry { get; set; }
        public int TotalMalePrevious { get; set; }
        public int TotalFemalePrevious { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
       public virtual AddChickenInFarm BatchChicken { get; set; }
      

    }
}
