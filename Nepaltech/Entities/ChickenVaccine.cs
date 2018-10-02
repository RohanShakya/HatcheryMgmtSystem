using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class ChickenVaccine:BaseEntity
    {
        public string BatchId { get; set; }
        public string AddChickenId { get; set; }
        public string LocationId { get; set; }
        public string VaccineId { get; set; }
        
        public int Age { get; set; }
        //public float Quantity { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime RecommendedDate { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual AddChickenInFarm AddChicken { get; set; }
        public virtual Locations Location { get; set; }
        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey("BreedVaccineId")]
        public virtual BreedVaccine BreedVaccine { get; set; }
        public virtual Vaccine Vaccine { get; set; }

    }
}
