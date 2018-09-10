using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    [Table("BatchChicken")]
    public class AddChickenInFarm:BaseEntity
    {
        public string BatchId { get; set; }
        public string FarmId { get; set; }
        public string BuildingId { get; set; }
        public string LocationId { get; set; }
        //public string BreedId { get; set; }
        //public DateTime ArrivalDate { get; set; }
        //public string CountryId { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public DateTime? ShiftedDate { get; set; }
        public string ParentId { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual HatcheryFarm Farm { get; set; }
        public virtual Building Building { get; set; }
        public virtual Locations Location { get; set; }
        //public virtual Breed Breed { get; set; }
        //public virtual Country Country { get; set; }
        
    }
}
