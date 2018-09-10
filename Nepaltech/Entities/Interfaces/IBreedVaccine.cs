using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities.Interfaces
{
     public interface IBreedVaccine
    {


          string Id { get; set; }
          string BreedId { get; set; }
        
          string VaccineId { get; set; }
          int Age { get; set; }
          DateTime DateCreated { get; set; }
          string Breed { get; set; }
          string Vaccine { get; set; }
    }          
}
