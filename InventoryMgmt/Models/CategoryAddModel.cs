using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMgmt.Models
{
    public class CategoryAddModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Should between 5 charaters to 100 characters")]
        [Display(Name = "Description")]
        [StringLength(maximumLength: 100,MinimumLength = 5)]
        public string Description { get; set; }
     
    }
}