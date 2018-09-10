using Nepaltech.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.ApiModels
{
  public  class BreedVaccineDataModel:IBreedVaccine
    {

        public string Id { get; set; }
        public string BreedId { get; set; }
        public string VaccineId { get; set; }

        [Required(ErrorMessage="Age is required")]
        [Display(Name ="Starting Age Of Vaccination")]
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }
        public string Breed { get; set; }
        public string Vaccine { get; set; }
    }
}
