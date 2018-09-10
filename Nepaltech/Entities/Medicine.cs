using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
   public class Medicine:BaseEntity
    {
        public string MedicineName { get; set; }
        public string DiseaseName { get; set; }
        public string RecomendedDoctor { get; set; }
        public string BreedId { get; set; }
        public DateTime Date { get; set; }

        public virtual Breed Breed { get; set; }
    }
}
