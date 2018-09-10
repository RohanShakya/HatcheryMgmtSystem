using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BuildingsModel
    {
        public string Id { get; set; }
        public string FarmName { get; set; }
        public string FarmId { get; set; }
        [Required]
        public string Building { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
