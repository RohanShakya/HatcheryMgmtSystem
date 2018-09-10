using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BreedChicken:BaseEntity
    {
        public string BreedId { get; set; }

        public virtual Breed Breed { get; set; }

    }
}
