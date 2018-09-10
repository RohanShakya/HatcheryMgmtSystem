using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{

    public class BatchChickenEggProductionModel
    {
        public List<ChickenEggProductionModel> Chickeneggproduction { get; set; }
        public DateTime DateEntry { get; set; }
        public string BatchId { get; set; }
        public string BreedId { get; set; }
        public string BatchCode { get; set; }
        public string LocationId { get; set; }
        public string BreedName { get; set; }

    }
    public class ChickenEggProductionModel
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
        public string BatchCode { get; set; }
        public string BatchChickenId { get; set; }
        [Required(ErrorMessage = "Please enter TotalEggs.")]
        public int TotalEggs { get; set; }
        [Required]
        public int GoodEggs { get; set; }
        [Required]
        public int SpoiltEggs { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime DateCreated { get; set; }
        public string BreedName { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string LocationId { get; set; }
        public string Breed { get; set; }
        public string BreedId { get; set; }


    }
}
