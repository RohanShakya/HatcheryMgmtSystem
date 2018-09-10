using Nepaltech.Entities;
using Nepaltech.Models.ApiModels;
using Nepaltech.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Helper
{
   public class MappingHelper
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(x =>
            {

                x.CreateMap<BreedVaccine, BreedVaccineDataModel>();
                x.CreateMap<BreedMortality, BreedMortalityModel>();
                x.CreateMap<BreedEggProductions, BreedEggModel>();

            });
        }
    }
}
