using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
public  class FeedModel
    {
        public string Id { get; set; }
       
        [Required(ErrorMessage = "This is Required ")]
        public string FeedName { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "This is Required ")]
        public float Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
