using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
   public class VaccineModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="This is Required ")]
        public string VaccineName { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
