using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class HatcheryFarm:BaseEntity
    {
        
        [Display(Name ="Farm Name")]
        public string  Name { get; set; }
      

        //public DateTime? DateDeleted { get; set; }
    }
}
