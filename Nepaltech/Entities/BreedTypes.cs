using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BreedTypes:BaseEntity
    {
        public string BreedId{ get; set; }

        public string BreedType { get; set; }

        public virtual Breed Breed { get; set; }
    }
}
