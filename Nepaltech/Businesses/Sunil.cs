using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using Nepaltech.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Data.Entity;
using Nepaltech.Models;

namespace Nepaltech.Businesses
{
    public partial class Sunil
    {
        public IRepository<BreedMortality> BreedMortalityData { get; set; }
        public IRepository<BreedEggProductions> BreedEggProductionManager { get; set; }
        public IRepository<Breed> BreedManager { get; set; }
        public IRepository<ChickenMortality> ChickenMortalityManager { get; set; }
        public IRepository<AddChickenInFarm> AddChickenInFarmManager { get; set; }
        public IRepository<Country> CountryManager { get; set; }
        public IRepository<ChickenEggProduction> ChickenEggProductionManager { get; set; }
        public IRepository<Building> BuildingManager { get; set; }
      //  public IRepository<BatchShifting> BatchShiftingManager { get; set; }


        private readonly IUnitOfWork _unitOfWork;

        public Sunil(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BreedMortalityData = unitOfWork.Repository<BreedMortality>();
            BreedEggProductionManager = unitOfWork.Repository<BreedEggProductions>();
            BreedManager = unitOfWork.Repository<Breed>();
            ChickenMortalityManager = unitOfWork.Repository<ChickenMortality>();
            AddChickenInFarmManager = unitOfWork.Repository<AddChickenInFarm>();
            CountryManager = unitOfWork.Repository<Country>();
            ChickenEggProductionManager = unitOfWork.Repository<ChickenEggProduction>();
            BuildingManager = unitOfWork.Repository<Building>();
           // BatchShiftingManager = unitOfWork.Repository<BatchShifting>();

        }

        public List<BreedMortalityModel> BreedMortalityList(string breedId)
        {
            var entitieslist = BreedMortalityData.GetAll().Where(x=>x.DateDeleted==null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BreedMortalityModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                BreedType = x.BreedType.BreedType,
                MortalityPercentage = x.MortalityPercentage,
                DateCreated = x.DateCreated,
                Breed = x.Breed.Name,
                AgeinWeeks = x.AgeinWeeks
           }).Where(x => x.BreedId == breedId).ToList();
            // }).ToList();
            return dataList;
        }
        public BreedMortalityModel AddBreedMortality(string id)
        {
            var entity = BreedManager.Find(id);
            BreedMortalityModel model = new BreedMortalityModel();
            model.BreedId = entity.Id;
            model.Breed = entity.Name;
            return model;

        }
        public void AddBreedMortality(BreedMortalityModel model)
        {
            var entity = new BreedMortality();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.MortalityPercentage = model.MortalityPercentage;
            entity.AgeinWeeks = model.AgeinWeeks;
            entity.DateCreated = DateTime.Now;

            BreedMortalityData.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public BreedMortality DetailsBreedMortality(string id)
        {
            return BreedMortalityData.Find(id);

        }

        public BreedMortalityModel EditBreedMortality(string id)
        {
            var entity = BreedMortalityData.Find(id);
            BreedMortalityModel mortality = new BreedMortalityModel();
            mortality.Id = entity.Id;
            mortality.BreedId = entity.BreedId;
            mortality.Breed = entity.Breed.Name;
            mortality.BreedTypeId = entity.BreedTypeId;
            mortality.BreedType = entity.BreedType.BreedType;
            mortality.MortalityPercentage = entity.MortalityPercentage;
                    mortality.AgeinWeeks = entity.AgeinWeeks;
            mortality.DateCreated = entity.DateCreated;
             return mortality;
        }

        public void EditBreedMortality(BreedMortalityModel model)
        {
            var entity = new BreedMortality();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.MortalityPercentage = model.MortalityPercentage;
                    entity.AgeinWeeks = model.AgeinWeeks;
            entity.DateCreated = model.DateCreated;
            BreedMortalityData.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBreedMortality(BreedMortality m)
        {
            var mortality = BreedMortalityData.Find(m.Id);
            BreedMortalityData.Delete(mortality);
            _unitOfWork.DataContext.SaveChanges();
        }

        //-----------------------------BreedEggproduction----------------------------->
        public List<BreedEggModel> BreedEggProductionList(string breedId)
        {
            var entitieslist = BreedEggProductionManager.GetAll().Where(x=>x.DateDeleted==null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BreedEggModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                BreedType = x.BreedType.BreedType,
                TotalEggs =x.TotalEggs,
                 AgeinWeeks=x.AgeinWeeks,
                 HatchingEggs=x.HatchingEggs,            
                Breed = x.Breed.Name,
                DateCreated=x.DateCreated

            }).Where(x => x.BreedId == breedId).ToList();
           //  }).ToList();
            return dataList;
        }
        public BreedEggModel AddBreedEggProduction(string id)
        {
            var entity = BreedManager.Find(id);
            BreedEggModel model = new BreedEggModel();
            model.BreedId = entity.Id;
            model.Breed = entity.Name;
            return model;

        }
        public void AddBreedEggProduction(BreedEggModel model)
        {
            var entity = new BreedEggProductions();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.TotalEggs = model.TotalEggs;
            entity.AgeinWeeks = model.AgeinWeeks;
            entity.HatchingEggs = model.HatchingEggs;
            entity.DateCreated = DateTime.Now;
            BreedEggProductionManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }
        public BreedEggProductions DetailsBreedEggProduction(string id)
        {
            return BreedEggProductionManager.Find(id);

        }

        public BreedEggModel EditBreedEggProduction(string id)
        {
            var entity = BreedEggProductionManager.Find(id);
                    BreedEggModel Eggproduction = new BreedEggModel();
            Eggproduction.Id = entity.Id;
            Eggproduction.BreedId = entity.BreedId;
            Eggproduction.BreedTypeId = entity.BreedTypeId;
            Eggproduction.Breed = entity.Breed.Name;
            Eggproduction.TotalEggs = entity.TotalEggs;
            Eggproduction.AgeinWeeks = entity.AgeinWeeks;
            Eggproduction.HatchingEggs = entity.HatchingEggs;
            Eggproduction.DateCreated = entity.DateCreated;
            return Eggproduction;
        }

        public void EditBreedEggProduction(BreedEggModel model)
        {
            var entity = new BreedEggProductions();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.TotalEggs = model.TotalEggs;
            entity.AgeinWeeks = model.AgeinWeeks;
            entity.HatchingEggs = model.HatchingEggs;
            entity.DateCreated = model.DateCreated;
            BreedEggProductionManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBreedEggProduction(BreedEggProductions n)
        {
            var Eggproduct = BreedEggProductionManager.Find(n.Id);
            BreedEggProductionManager.Delete(Eggproduct);
            _unitOfWork.DataContext.SaveChanges();
        }
        //====================ChickenMortality=====================>

        public List<ChickenMortalityModel> ChickenMortalityList(string batchId)
        {
          
            var entitieslist = ChickenMortalityManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.BreedMortality).ToList();
            var datalist = entitieslist.Select(x => new ChickenMortalityModel
            {
                Id = x.Id,
                // BatchChickenId = x.BatchChickenId,
                BatchId = x.Batch.Id,
                LocationId = x.Location.Id,
                Location = x.Location.Location,
                // AgeinWeeks = x.AgeinWeeks,
                DeadChickenMale = x.DeadChickenMale,
                DeadChickenFemale = x.DeadChickenFemale,
                MortalityPercentage=x.MortalityPercentage,
                DateCreated = x.DateCreated,
                DateEntry = x.DateEntry,
                          }).Where(x => x.BatchId == batchId).ToList();
                     return datalist;
        }
        public List<ChickenMortalityModel> ChickenMortalityListByBatchId(string batchChickenId)
        {
          
            var entitieslist = ChickenMortalityManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.BreedMortality).ToList();
            var datalist = entitieslist.Select(x => new ChickenMortalityModel
            {
                Id = x.Id,
                //BatchChickenId = x.BatchChickenId,
                //BatchId = x.BatchChicken.BatchId,
                // AgeinWeeks = x.AgeinWeeks,
                DeadChickenMale = x.DeadChickenMale,
                DeadChickenFemale = x.DeadChickenFemale,
                MortalityPercentage = x.MortalityPercentage,
                DateCreated = x.DateCreated,
                DateEntry = x.DateEntry,
            }).Where(x => x.BatchId == batchChickenId).ToList();
            return datalist;
        }



        public ChickenMortalityModel AddChickenMortality(string id)
        {
            var entity = AddChickenInFarmManager.Find(id);

            ChickenMortalityModel chickenmortalitymodel = new ChickenMortalityModel();
            //chickenVaccineModel.Id = entity.Id;
            chickenmortalitymodel.BatchId = entity.BatchId;

            chickenmortalitymodel.FarmName = entity.Farm.Name;
            chickenmortalitymodel.Location = entity.Location.Location;
            //chickenmortalitymodel.Breed = entity.Breed.Name;
            //chickenmortalitymodel.BreedId = entity.BreedId;
           // chickenmortalitymodel.BatchId = entity.BatchId;
            //int breedVaccineAge = 2;
            //chickenVaccineModel.RecommendedDate = entity.ArrivalDate.AddDays(breedVaccineAge);
            return chickenmortalitymodel;
        }
        public BatchChickenMortalityModel AddChickenMortalityByBatch(string batchId)
        {
            var chickeninfarms = AddChickenInFarmManager.GetAll().Where(x => x.BatchId == batchId).ToList();
            BatchChickenMortalityModel model = new BatchChickenMortalityModel();
            model.Chickenmortality = new List<ChickenMortalityModel>();
            foreach (var entity in chickeninfarms)
            {

                ChickenMortalityModel chickenmortalitymodel = new ChickenMortalityModel();
                //chickenVaccineModel.Id = entity.Id;
                //chickenmortalitymodel.BatchChickenId = entity.BatchId;
                chickenmortalitymodel.BatchId = entity.BatchId;
                chickenmortalitymodel.FarmName = entity.Farm.Name;
                chickenmortalitymodel.Location = entity.Location.Location;
                chickenmortalitymodel.LocationId = entity.Location.Id;
                // chickenmortalitymodel.Breed = entity.Breed.Name;
                //chickenmortalitymodel.BreedId = entity.BreedId;
                //chickenmortalitymodel.BatchId = entity.BatchId;

                model.Chickenmortality.Add(chickenmortalitymodel);
                //model.Chickenmortality = entity.LocationId;
               // model.BreedId = entity.Batch.BreedId;
                model.BatchId = entity.Batch.Id;
                model.BatchCode = entity.Batch.Code;
                model.LocationId = entity.Location.Id;
                
            }
            return model;
        }

        public void AddChickenMortality(ChickenMortalityModel model)
        {
            var entity = new ChickenMortality();
            entity.Id = Guid.NewGuid().ToString();
            // entity.BatchChickenId = model.Id;
            entity.BatchId = model.BatchId;
            entity.LocationId = model.LocationId;
            entity.MortalityPercentage = model.MortalityPercentage;
            entity.DateEntry = model.DateEntry;
            entity.DeadChickenMale = model.DeadChickenMale;
            entity.DeadChickenFemale = model.DeadChickenFemale;
             entity.DateCreated = DateTime.Now;
                        //var breedVaccine = ChickenEggProductionManager.GetAll().Where(x => x.BreedId == BreedId && x.BreedMortality == entity.BreedMortalityId);
            //int breedVaccineAge = breedVaccine.Select(x => x.Age).Single();
           // entity.RecommendedDate = ArrivalDate.AddDays(breedVaccineAge);
            ChickenMortalityManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }
      
        public ChickenMortality DetailsChickenMortality(string id)
        {
            return ChickenMortalityManager.Find(id);

        }

        public ChickenMortalityModel EditChickenMortality(string id)
        {
            var entity = ChickenMortalityManager.Find(id);
           // var batchChickenEntity = AddChickenInFarmManager.Find(batchChickenId);

            ChickenMortalityModel chickenmortalitymodel = new ChickenMortalityModel();
            chickenmortalitymodel.Id = entity.Id;
            chickenmortalitymodel.BatchId = entity.BatchId;
            chickenmortalitymodel.LocationId = entity.LocationId;
            chickenmortalitymodel.BatchCode = entity.Batch.Code;
            chickenmortalitymodel.BreedId = entity.Batch.BreedId;
           // chickenmortalitymodel.BatchId = entity.BatchChicken.BatchId;
            //chickenmortalitymodel.BreedId = batchChickenEntity.BreedId;
            //chickenmortalitymodel.FarmName = batchChickenEntity.Farm.Name;
           // chickenmortalitymodel.Location = batchChickenEntity.Location.Location;
           // chickenmortalitymodel.Breed = batchChickenEntity.Breed.Name;
            chickenmortalitymodel.MortalityPercentage = entity.MortalityPercentage;
            chickenmortalitymodel.DeadChickenMale = entity.DeadChickenMale;
            chickenmortalitymodel.DeadChickenFemale = entity.DeadChickenFemale;
            chickenmortalitymodel.DateEntry = entity.DateEntry;
                        chickenmortalitymodel.DateCreated = entity.DateCreated;

            return chickenmortalitymodel;
        }

        public void EditChickenMortality(ChickenMortalityModel model)
        {
            var entity = new ChickenMortality();
            entity.Id = model.Id;
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.LocationId = model.LocationId;
            //entity.BatchChickenId = model.BatchChickenId;
            entity.MortalityPercentage = model.MortalityPercentage;
            entity.DeadChickenMale = model.DeadChickenMale;
            entity.DeadChickenFemale = model.DeadChickenFemale;
            entity.DateCreated = model.DateCreated;
            entity.DateEntry = model.DateEntry;
            ChickenMortalityManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteChickenMortality(ChickenMortality cm)
        {
            var chickenmortality = ChickenMortalityManager.Find(cm.Id);
            ChickenMortalityManager.Delete(chickenmortality);
            _unitOfWork.DataContext.SaveChanges();
        }
  


//...............................ChickenEggProduction..................>>
public List<ChickenEggProductionModel> ChickenEggProductionList(string batchId)
{
  
    var entitieslist = ChickenEggProductionManager.GetAll().Where(x => x.DateDeleted == null);
            var datalist = entitieslist.Select(x => new ChickenEggProductionModel
            {
                Id = x.Id,
                // BatchChickenId = x.BatchChickenId,
                BatchId = x.Batch.Id,
                LocationId = x.Location.Id,
                Location=x.Location.Location,
            
                //AgeinWeeks = x.AgeinWeeks,
                TotalEggs = x.TotalEggs,
                GoodEggs = x.GoodEggs,
                SpoiltEggs = x.SpoiltEggs,
                DateCreated = x.DateCreated,
            }).Where(x => x.BatchId == batchId).ToList();
            return datalist;

     
}

public ChickenEggProductionModel AddChickenEggProduction(string id)
{
    var entity = AddChickenInFarmManager.Find(id);

            ChickenEggProductionModel chickeneggproductionmodel = new ChickenEggProductionModel();
            //chickenVaccineModel.Id = entity.Id;
            chickeneggproductionmodel.BatchChickenId = entity.BatchId;
                        chickeneggproductionmodel.FarmName = entity.Farm.Name;
            chickeneggproductionmodel.Location = entity.Location.Location;
           // chickeneggproductionmodel.Breed = entity.Breed.Name;
            //chickeneggproductionmodel.BreedId = entity.BreedId;
    //int breedVaccineAge = 2;
    //chickenVaccineModel.RecommendedDate = entity.ArrivalDate.AddDays(breedVaccineAge);
    return chickeneggproductionmodel;
}

        public BatchChickenEggProductionModel AddChickenEggProductionByBatch(string batchId)
        {
            var chickeninfarms = AddChickenInFarmManager.GetAll().Where(x => x.BatchId == batchId).ToList();
            BatchChickenEggProductionModel model = new BatchChickenEggProductionModel();
            model.Chickeneggproduction = new List<ChickenEggProductionModel>();
            foreach (var entity in chickeninfarms)
            {

                ChickenEggProductionModel chickeneggproductionmodel = new ChickenEggProductionModel();
                chickeneggproductionmodel.BatchId = entity.BatchId;
                chickeneggproductionmodel.FarmName = entity.Farm.Name;
                chickeneggproductionmodel.Location = entity.Location.Location;
                chickeneggproductionmodel.LocationId = entity.Location.Id;
                // chickenmortalitymodel.Breed = entity.Breed.Name;
                //chickenmortalitymodel.BreedId = entity.BreedId;
               // chickeneggproductionmodel.BatchId = entity.BatchId;
                model.Chickeneggproduction.Add(chickeneggproductionmodel);
                model.BatchId = entity.Batch.Id;
                model.BatchCode = entity.Batch.Code;
                model.LocationId = entity.Location.Id;
            }
            return model;
        }
        //SELECT t1.Name, SUM(t1.Salary + t2.Bonus) as Total From tb1 as t1, tb2 as t2 WHERE t1.Name = t2.Name group by t1.Name order by t1.Salary
        public void AddChickenEggProduction(ChickenEggProductionModel model)
        {
    var entity = new ChickenEggProduction();
    entity.Id = Guid.NewGuid().ToString();
            // entity.BatchChickenId = model.Id;
            //entity.AgeinWeeks = model.AgeinWeeks;
            entity.BatchId = model.BatchId;
            entity.LocationId = model.LocationId;
            entity.TotalEggs = model.TotalEggs;
    entity.GoodEggs = model.GoodEggs;
            entity.SpoiltEggs = model.SpoiltEggs;
            entity.DateEntry = model.DateEntry;
    entity.DateCreated = DateTime.Now;
    ChickenEggProductionManager.Add(entity);
    _unitOfWork.DataContext.SaveChanges();
}

public ChickenEggProduction DetailsChickenEggProduction(string id)
{
    return ChickenEggProductionManager.Find(id);

}

public ChickenEggProductionModel EditChickenEggProduction(string id)
{
    var entity = ChickenEggProductionManager.Find(id);
    //var batchChickenEntity = AddChickenInFarmManager.Find(batchChickenId);

            ChickenEggProductionModel chickeneggproductionmodel = new ChickenEggProductionModel();
            chickeneggproductionmodel.Id = entity.Id;
            chickeneggproductionmodel.BatchId = entity.BatchId;
            chickeneggproductionmodel.LocationId = entity.LocationId;
            chickeneggproductionmodel.BatchCode = entity.Batch.Code;
            //chickeneggproductionmodel.BreedId = batchChickenEntity.BreedId;
           //  chickeneggproductionmodel.FarmName = batchChickenEntity.Farm.Name;
           // chickeneggproductionmodel.Location = batchChickenEntity.Location.Location;
            //chickeneggproductionmodel.Breed = batchChickenEntity.Breed.Name;
            //chickeneggproductionmodel.AgeinWeeks = entity.AgeinWeeks;
           
            chickeneggproductionmodel.TotalEggs = entity.TotalEggs;
            chickeneggproductionmodel.GoodEggs = entity.GoodEggs;
            chickeneggproductionmodel.SpoiltEggs = entity.SpoiltEggs;
            chickeneggproductionmodel.DateEntry = entity.DateEntry;
            chickeneggproductionmodel.DateCreated = entity.DateCreated;

    return chickeneggproductionmodel;
}

        public void EditChickenEggProduction(ChickenEggProductionModel model)
        {
            var entity = new ChickenEggProduction();
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.LocationId = model.LocationId;
            entity.TotalEggs = model.TotalEggs;
            entity.GoodEggs = model.GoodEggs;
            entity.SpoiltEggs = model.SpoiltEggs;
            entity.DateCreated = model.DateCreated;
            entity.DateEntry = model.DateEntry;
            ChickenEggProductionManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteChickenEggProduction(ChickenEggProduction cm)
{
    var chickeneggproduction = ChickenEggProductionManager.Find(cm.Id);
    ChickenEggProductionManager.Delete(chickeneggproduction);
    _unitOfWork.DataContext.SaveChanges();
}

        //----------------Building------------------>>

        public List<BuildingsModel> BuildingList()
        {

            var entitieslist = BuildingManager.GetAll().Include(x => x.HatcheryFarm).Where(x => x.DateDeleted == null).ToList();
            var dataList = entitieslist.Select(x => new BuildingsModel
            {
                Id = x.Id,
                FarmId = x.HatcheryFarmId,
                Building = x.Buildings,
                DateCreated = x.DateCreated,
                FarmName = x.HatcheryFarm.Name

            }).ToList();
            return dataList;
        }

        public void AddBuildings(BuildingsModel model)
        {
            var entity = new Building();
            entity.Id = Guid.NewGuid().ToString();
            entity.HatcheryFarmId = model.FarmId;
            entity.Buildings = model.Building;
            entity.DateCreated = DateTime.Now;
            BuildingManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Building DetailsBuildings(string id)
        {
            return BuildingManager.Find(id);

        }

        public BuildingsModel EditBuildings(string id)
        {
            var entity = BuildingManager.Find(id);

            BuildingsModel buildingsmodel = new BuildingsModel();
            buildingsmodel.Id = entity.Id;
            buildingsmodel.Building = entity.Buildings;
            buildingsmodel.FarmId = entity.HatcheryFarmId;
            buildingsmodel.DateCreated = entity.DateCreated;

            return buildingsmodel;
        }

        public void EditBuildings(BuildingsModel model)
        {
            var entity = new Building();
            entity.Id = model.Id;
            entity.Buildings = model.Building;
            entity.HatcheryFarmId = model.FarmId;
            entity.DateCreated = model.DateCreated;
            BuildingManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBuildings(Building loc)
        {
            var building = BuildingManager.Find(loc.Id);
            BuildingManager.Delete(building);
            _unitOfWork.DataContext.SaveChanges();
        }

        //public List<MortalityReportModel> MortalityList()
        //{

        //    Var q = (from pd in _unitOfWork.Repository<ChickenMortality>().GetAll()
        //             join od in _unitOfWork.Repository<BreedMortality>().GetAll()  on pd.Id equals od.BreedId
        //             orderby od.BreedId
        //             select new MortalityReportModel
        //             {
        //                BreedId=
        //             }).ToList();





        //====================BatchShifting===========================>>>>>


        //public List<BatchShiftingModel> BatchShiftingList(string batchId)
        //{
        //    //var entitieslist = ChickenVaccineManager.GetAll().Include(x => x.BreedVaccine).Include(x=>x.BreedVaccine.Vaccine).ToList();
        //    var entitieslist = BatchShiftingManager.GetAll().Where(x => x.DateDeleted == null);
        //    var datalist = entitieslist.Select(x => new BatchShiftingModel
        //    {
        //        Id = x.Id,
        //       // BatchChickenId = x.BatchChickenId,
        //        BatchId = x.BatchChicken.BatchId,
        //        BatchLocationId=x.BatchLocationId,
        //        // AgeinWeeks = x.AgeinWeeks,
        //        TotalFemalePrevious = x.TotalFemalePrevious,
        //        TotalMalePrevious = x.TotalMalePrevious,
        //        TotalMale = x.TotalMale,
        //        TotalFemale=x.TotalFemale,
        //        DateCreated = x.DateCreated,
        //        DateEntry = x.DateEntry,
        //        //VaccineName = x.Vaccine.VaccineName,
        //        //VaccineName = x.BreedVaccine.Vaccine.VaccineName
        //    }).Where(x => x.BatchId == batchId).ToList();
        //    //}).Where(x => x.BatchId == "B-2074-1").ToList();
        //    return datalist;
        //}

        ////public List<ChickenVaccine> ChickenVaccineList()
        ////{
        ////     return ChickenVaccineManager.GetAll().ToList();
        ////}

        //public BatchShiftingModel AddBatchShifting(string id)
        //{
        //    var entity = AddChickenInFarmManager.Find(id);

        //    BatchShiftingModel batchshiftingmodel = new BatchShiftingModel();
        //    //chickenVaccineModel.Id = entity.Id;
        //    //chickenmortalitymodel.BatchChickenId = entity.BatchId;

        //    batchshiftingmodel.FarmName = entity.Farm.Name;
        //    batchshiftingmodel.Location = entity.Location.Location;
        //    batchshiftingmodel.TotalMalePrevious = entity.TotalMale;
        //    batchshiftingmodel.TotalFemalePrevious = entity.TotalFemale;
        //    //chickenmortalitymodel.Breed = entity.Breed.Name;
        //    //chickenmortalitymodel.BreedId = entity.BreedId;
        //    batchshiftingmodel.BatchId = entity.BatchId;
        //    //int breedVaccineAge = 2;
        //    //chickenVaccineModel.RecommendedDate = entity.ArrivalDate.AddDays(breedVaccineAge);
        //    return batchshiftingmodel;
        //}

        //public BatchShiftingChickenModel AddBatchShiftingByBatch(string batchId)
        //{
        //    var chickeninfarms = AddChickenInFarmManager.GetAll().Where(x => x.BatchId == batchId).ToList();
        //    BatchShiftingChickenModel model = new BatchShiftingChickenModel();
        //    model.batchshifting = new List<BatchShiftingModel>();
        //    foreach (var entity in chickeninfarms)
        //    {

        //        BatchShiftingModel batchshiftingmodel = new BatchShiftingModel();
        //        //chickenVaccineModel.Id = entity.Id;
        //        //chickenmortalitymodel.BatchChickenId = entity.BatchId;
        //        batchshiftingmodel.FarmName = entity.Farm.Name;
        //        batchshiftingmodel.Location = entity.Location.Location;
        //        batchshiftingmodel.TotalMalePrevious = entity.TotalMale;
        //        batchshiftingmodel.TotalFemalePrevious = entity.TotalFemale;
        //        // chickenmortalitymodel.Breed = entity.Breed.Name;
        //        //chickenmortalitymodel.BreedId = entity.BreedId;
        //        batchshiftingmodel.BatchId = entity.BatchId;

        //        model.batchshifting.Add(batchshiftingmodel);
        //        model.BreedId = entity.Batch.BreedId;
        //        model.BatchCode = entity.Batch.Code;
        //    }
        //    return model;
        //}

        //public void AddBatchShifting(BatchShiftingModel model)
        //{
        //    var entity = new BatchShifting();
        //    entity.Id = Guid.NewGuid().ToString();
        //    entity.BatchLocationId = model.Id;
        //    //entity.TotalMalePrevious = model.TotalMalePrevious;
        //    //entity.TotalFemalePrevious = model.TotalFemalePrevious;
        //    entity.TotalMale = model.TotalMale;
        //    entity.TotalFemale = model.TotalFemale;
        //    entity.DateCreated = DateTime.Now;
        //    BatchShiftingManager.Add(entity);
        //    _unitOfWork.DataContext.SaveChanges();
        //}

        //public BatchShifting DetailsBatchShifting(string id)
        //{
        //    return BatchShiftingManager.Find(id);

        //}

        //public BatchShiftingModel EditBatchShifting(string id, string batchId)
        //{
        //    var entity = BatchShiftingManager.Find(id);
        //    var batchChickenEntity = AddChickenInFarmManager.Find(batchId);

        //    BatchShiftingModel batchshiftingmodel = new BatchShiftingModel();
        //    batchshiftingmodel.Id = entity.Id;
        //    batchshiftingmodel.BatchId = entity.BatchChicken.BatchId;
        //    //chickenmortalitymodel.BreedId = batchChickenEntity.BreedId;
        //    batchshiftingmodel.FarmName = batchChickenEntity.Farm.Name;
        //    batchshiftingmodel.Location = batchChickenEntity.Location.Location;
        //    // chickenmortalitymodel.Breed = batchChickenEntity.Breed.Name;
        //    batchshiftingmodel.TotalMalePrevious = entity.TotalMalePrevious;
        //    batchshiftingmodel.TotalFemalePrevious = entity.TotalFemalePrevious;
        //    batchshiftingmodel.TotalMale = entity.TotalMale;
        //    batchshiftingmodel.TotalFemale = entity.TotalFemale;
        //    batchshiftingmodel.DateEntry = entity.DateEntry;
        //    batchshiftingmodel.DateCreated = entity.DateCreated;

        //    return batchshiftingmodel;
        //}

        //public void EditBatchShifting(BatchShiftingModel model)
        //{
        //    var entity = new BatchShifting();
        //    entity.Id = model.Id;
        //    entity.TotalMalePrevious = model.TotalMalePrevious;
        //    entity.TotalFemalePrevious = model.TotalFemalePrevious;
        //    entity.TotalMale = model.TotalMale;
        //    entity.TotalFemale = model.TotalFemale;
        //    entity.DateCreated = model.DateCreated;
        //    entity.DateEntry = model.DateEntry;
        //    BatchShiftingManager.Update(entity);
        //    _unitOfWork.DataContext.SaveChanges();
        //}

        //public void DeleteBatchShifting(BatchShifting bs)
        //{
        //    var batchshifting = BatchShiftingManager.Find(bs.Id);
        //    BatchShiftingManager.Delete(batchshifting);
        //    _unitOfWork.DataContext.SaveChanges();
        //}
    }
}

