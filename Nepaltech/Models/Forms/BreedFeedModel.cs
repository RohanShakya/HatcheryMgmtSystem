using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
   public class BreedFeedModel
    {
        public string Id { get; set; }
      
        public string BreedId { get; set; }
        [Required(ErrorMessage = "Feed must be selected ")]
        public string FeedId { get; set; }
        [Required]
        public string BreedTypeId { get; set; }
        public string BreedType { get; set; }
        public string Breed { get; set; }
        public string BreedName { get; set; }
       
        public string FeedName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required(ErrorMessage = "This is Required ")]
        public float MaleQuantity { get; set; }
        [Required(ErrorMessage = "This is Required ")]
        public float FemaleQuantity { get; set; }
        public string GenderId { get; set; }
        public string  Gender { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
