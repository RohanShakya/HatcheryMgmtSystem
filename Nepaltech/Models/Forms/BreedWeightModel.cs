using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
   public class BreedWeightModel
    {
        public string Id { get; set; }
        public string BreedId { get; set; }
        public string BreedName { get; set; }
        [Required]
        public string BreedTypeId { get; set; }
        public string BreedType { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public float Weight { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
