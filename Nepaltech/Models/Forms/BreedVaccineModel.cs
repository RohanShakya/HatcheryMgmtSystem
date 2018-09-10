using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BreedVaccineModel
    {
        public string Id { get; set; }

        public string Breed { get; set; }
        public string BreedId { get; set; }
      
        public string Vaccine { get; set; }
        [Required(ErrorMessage = "Vaccine must be selected ")]
        public string VaccineId { get; set; }
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
