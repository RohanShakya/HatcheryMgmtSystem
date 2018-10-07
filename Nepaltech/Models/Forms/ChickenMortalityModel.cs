using Nepaltech.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BatchChickenMortalityModel
    {
        public List<ChickenMortalityModel> Chickenmortality { get; set; }
        public string BatchCode { get; set; }
        public DateTime DateEntry { get; set; }
        public string BatchId { get; set; }
        public string BreedId { get; set; }
        public string Breed { get; set; }
        public string BreedTypeId { get; set; }
        public string BreedType { get; set; }
        public int Age { get; set; }
        public DateTime ArrivalDate { get; set; }
    }

    public class ChickenMortalityModel
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
       
        public string BatchCode { get; set; }
        [Required]
        public int MortalityPercentage { get; set; }
        public string BatchChickenId { get; set; }
        public DateTime DateEntry { get; set; }
        [Required]
        public int DeadChickenMale { get; set; }
        [Required]
        public int DeadChickenFemale { get; set; }

        public DateTime DateCreated { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string LocationId { get; set; }
        public string Breed { get; set; }
        public string BreedId { get; set; }


    }
}
