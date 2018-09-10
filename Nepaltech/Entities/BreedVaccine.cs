using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BreedVaccine:BaseEntity
    {
      
        public string BreedId { get; set; }
       
        public string VaccineId { get; set; }
       
        public int Age { get; set; }

        public virtual Breed Breed { get; set; }

        public virtual Vaccine Vaccine{ get; set; }



    }
}
