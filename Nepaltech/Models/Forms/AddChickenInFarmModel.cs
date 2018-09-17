using Nepaltech.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nepaltech.Models.Forms
{
    public class AddChickenInFarmModel: IBatchChicken
    {
        public string Id { get; set; }
        [Required]
        public string BatchId { get; set; }
        [Required]
        [Display(Name ="Farm Name")]
        public string FarmId { get; set; }
     
        public string BuildingId { get; set; }
        [Required]
        public string LocationId { get; set; }
        [Required]
        public int TotalMale { get; set; }
        [Required]
        public int TotalFemale { get; set; }
        public DateTime DateCreated { get; set; }
        
        public string BatchCode { get; set; }
        public string FarmName { get; set; }
        public string BuildingName { get; set; }
        public string Location { get; set; }

        public int PlacedMalePrevious { get; set; }
        public int PlacedFemalePrevious { get; set; }

    }
    public class BatchShiftModel: AddChickenInFarmModel
    {
        public string PreviousBuildingId { get; set; }
        public string PreviousLocationId { get; set; }
        public string PreviousBuilding { get; set; }
        public string PreviousLocation { get; set; }
        public int PreviousMale { get; set; }
        public int PreviousFemale { get; set; }
        public DateTime? ShiftedDate { get; set; }
        public string ParentId { get; set; }
    }
}