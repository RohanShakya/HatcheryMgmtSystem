using Nepaltech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models
{
    public class MortalityReportModel
    {
        public string BreedId { get; set; }
        public string FarmId { get; set; }
        public string LocationId { get; set; }
        public string BatchId { get; set; }
        public string BreedMortalityId { get; set; }
        public string FarmName { get; set; }
        public string Location { get; set; }
        public string Breed { get; set; }
        public int AgeinWeeks { get; set; }
        public DateTime DateEntry { get; set; }
        public int RemainingChicken { get; set; }
        public int RecommendedMortality { get; set; }
        public int TotalNumberofBreed { get; set; }
        public int NumberofMale { get; set; }
        public int NumberofFemale { get; set; }
        public string DeadMale { get; set; }
        public string DeadFemale { get; set; }
        public int MortalityPercentage { get; set; }

    }
}

 