using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BreedEggModel
    {
 
        public string Id { get; set; }
   
        public string BreedId { get; set; }
        public string BreedTypeId { get; set; }
        public string BreedType { get; set; }
        [Required]
        public int TotalEggs { get; set; }
        [Required]
        public int AgeinWeeks { get; set; }
        [Required]
        public int HatchingEggs { get; set; }
        public DateTime DateCreated { get; set; }
        public string Breed { get; set; }

    }
}
