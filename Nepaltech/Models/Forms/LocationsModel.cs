using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class LocationsModel
    {
        public string Id { get; set; }
        public string FarmName { get; set; }
        [Required]
        public string FarmId { get; set; }
        public string Building { get; set; }
        [Required]
        public string BuildingId { get; set; }
        [Required][Display(Name = "Room")]
        public string Location { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
