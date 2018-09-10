using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models
{
  public class FeedReport
    {
        public string BatchChickenId { get; set; }
        public string FarmId { get; set; }
        public string LocationId { get; set; }
        public string BreedId { get; set; }
        public string FeedId { get; set; }
        public string Age { get; set; }
        public string GenderId { get; set; }
        public DateTime DateEntry { get; set; }
        public string RecommendedQuantity { get; set; }
        public string ActualQuantity { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string BreedName { get; set; }
        public string FeedName { get; set; }
    }
}
