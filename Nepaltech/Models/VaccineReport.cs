using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class VaccineReport
    {
        public string BatchId { get; set; }
        public string FarmId { get; set; }
        public string LocationId { get; set; }
        public string BreedId { get; set; }
        public string VaccineId { get; set; }
        public int Age { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime RecommendedDate { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string Breed { get; set; }
        public string VaccineName { get; set; } 


    }
}
