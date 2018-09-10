using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BatchChickenFeedModel
    {
        public string BatchId { get; set; }
        public List<ChickenFeedModel> ChickenFeeds { get; set; }
        public string BreedId { get; set; }
        public string LocationId { get; set; }
        public string BatchCode { get; set; }
        public string Breed { get; set; }
        public string BreedTypeId { get; set; }
        public string BreedType { get; set; }
        public int Age { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DateEntry { get; set; }


    }
    public class ChickenFeedModel
    {

        public string Id { get; set; }
        public string BatchChickenId { get; set; }
        public string BatchId { get; set; }
        public string BatchCode { get; set; }
        public string BreedId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string FeedId { get; set; }
        public DateTime DateEntry { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public float MaleQuantity { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public float FemaleQuantity { get; set; }
        public DateTime DateCreated { get; set; }
        public string BreedName { get; set; }
        public string FarmName { get; set; }
        public string Breed { get; set; }
        public string Feed { get; set; }
        public string Location { get; set; }
        public string LocationId { get; set; }

    }
}
