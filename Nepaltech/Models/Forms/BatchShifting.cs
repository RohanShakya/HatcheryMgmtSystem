using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class BatchShiftingChickenModel
    {
             public List<BatchShiftingModel> batchshifting { get; set; }
        public DateTime DateEntry { get; set; }
        public string BatchId { get; set; }
        public string BreedId { get; set; }
        public string BatchCode { get; set; }

    }

    public class BatchShiftingModel
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
        public string BatchCode { get; set; }
        public string BatchLocationId { get; set; }
        public int TotalMalePrevious { get; set; }
        //public string BatchChickenId { get; set; }
        public DateTime DateEntry { get; set; }
        public int TotalFemalePrevious { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public DateTime DateCreated { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
        public string Breed { get; set; }
        public string BreedId { get; set; }


    }
}
