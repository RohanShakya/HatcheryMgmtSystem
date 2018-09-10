using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMgmt.Models
{
    public class AddStoresModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
    }
}