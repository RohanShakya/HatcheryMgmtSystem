using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Entities
{
    public class Feeds:BaseEntity
    {
        public string FeedName { get; set; }

        public float Price { get; set; }
    }
}
