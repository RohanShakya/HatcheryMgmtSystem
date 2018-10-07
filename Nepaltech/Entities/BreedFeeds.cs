using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class BreedFeeds:BaseEntity
    {
        
        public string BreedId { get; set; }
        public string FeedId { get; set; }
        public string BreedTypeId { get; set; }
        public string FeedName { get; set; }
        public string GenderId { get; set; }
        public string Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public float MaleQuantity { get; set; }
        public float FemaleQuantity { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual BreedTypes BreedType { get; set; }
        public virtual Feeds Feed { get; set; }

    }
}
