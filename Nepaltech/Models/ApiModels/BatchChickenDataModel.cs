using Nepaltech.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.ApiModels
{
    public class BatchChickenDataModel : IBatchChicken
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
        public string FarmId { get; set; }
        public string BuildingId { get; set; }
        public string LocationId { get; set; }
        //public string BreedId { get; set; }
        //public DateTime ArrivalDate { get; set; }
        //public string CountryId { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public DateTime DateCreated { get; set; }

        public string BatchCode { get; set; }
        public string FarmName { get; set; }
        public string BuildingName { get; set; }
        public string Location { get; set; }
        //public string Breed{ get; set; }
        //public string Country { get; set; }
        
    }
}
