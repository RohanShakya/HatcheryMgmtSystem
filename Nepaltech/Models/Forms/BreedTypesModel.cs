using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BreedTypesModel
    {
        public string Id { get; set; }
        public string BreedId { get; set; }
        public string Breed { get; set; }
        [Required]
        public string BreedType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
