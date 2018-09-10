using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class ChickenFeeds:BaseEntity
    {
        
        public string BatchId { get; set; }
        public string LocationId { get; set; }
        public string FeedId { get; set; }

       
        public int Age { get; set; }
        public float MaleQuantity { get; set; }
        public float FemaleQuantity { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime RecommendedDate { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual Locations Location { get; set; }
        public virtual BreedFeeds BreedFeeds { get; set; }
        public virtual Feeds Feed { get; set; }
    }
}
