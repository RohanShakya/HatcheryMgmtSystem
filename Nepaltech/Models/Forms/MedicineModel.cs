using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nepaltech.Models.Forms
{
    public class MedicineModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is Required ")]
        public string BreedId { get; set; }
        public string Breed { get; set; }
        [Required(ErrorMessage = "This field is Required ")]
        public string MedicineName { get; set; }
        [Required(ErrorMessage = "This field is Required ")]
        public string DiseaseName { get; set; }
        [Required(ErrorMessage = "This field is Required ")]
        public string RecomendedDoctor { get; set; }

        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
