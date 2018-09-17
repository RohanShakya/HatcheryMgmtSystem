using Nepaltech.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nepaltech.Models.Forms
{
    public class BatchModel
    {
        public string Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string BreedId { get; set; }
        [Required]
        public string BreedTypeId { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        public int Age { get; set; }
        [Required]
        public string CountryId { get; set; }
        [Required]
        public int TotalMale { get; set; }
        [Required]
        public int TotalFemale { get; set; }
        [Required]
        public int DeadMale { get; set; }
        [Required]
        public int DeadFemale { get; set; }
        [Required]
        public int TotalCost { get; set; }
        public bool Closed { get; set; }
        public int PlacedMale { get; set; }
        public int PlacedFemale { get; set; }
        public DateTime DateCreated { get; set; }
        

        public string Breed { get; set; }
        public string BreedType { get; set; }
        public string Country { get; set; } 

    }
}