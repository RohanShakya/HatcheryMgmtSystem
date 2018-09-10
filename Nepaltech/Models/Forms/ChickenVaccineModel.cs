using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BatchChickenVaccineModel
    {
        public string BatchId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public List<ChickenVaccineModel> ChickenVaccines { get; set; }
        public string BreedId { get; set; }
        public string Breed { get; set; }
        public string BatchCode { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Age { get; set; }
    }

    public class ChickenVaccineModel
    {
        public string Id { get; set; }
        public string BatchChickenId { get; set; }
        public string BatchId { get; set; }
        public string BatchCode { get; set; }
        //public DateTime DateEntry { get; set; }

        public string BreedId { get; set; }
        [Required(ErrorMessage ="Please select the vaccine!")]
        public string VaccineId { get; set; }
        public string LocationId { get; set; }
        public int Age { get; set; }
        //public float Quantity { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime RecommendedDate { get; set; }
        public DateTime DateCreated { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string Breed { get; set; }
        public string VaccineName { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
