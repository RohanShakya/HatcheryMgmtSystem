using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities.Interfaces
{
    public interface IBatchChicken
    {
         string Id { get; set; }
         string BatchId { get; set; }
         string FarmId { get; set; }
         string LocationId { get; set; }
         //string BreedId { get; set; }
         //DateTime ArrivalDate { get; set; }
         //string CountryId { get; set; }
         int TotalMale { get; set; }
         int TotalFemale { get; set; }
         DateTime DateCreated { get; set; }

         string BatchCode { get; set; }
         string FarmName { get; set; }
         string Location { get; set; }
         //string Breed { get; set; }
         //string Country { get; set; } 
       
    }
}
