using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BreedsModel
    {
        public string Id { get; set; }

        [Display(Name ="Breed Name")]
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
