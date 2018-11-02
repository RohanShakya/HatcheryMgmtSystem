using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using Nepaltech.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nepaltech.Models.ApiModels;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace Nepaltech.Businesses
{
    //public interface IFarmService
    //{
    //    void AddChickenToFarm()
    //}
    
    public partial class FarmService
    {
        public IRepository<BreedChicken> BreedChickenManager { get; set; }
        public IRepository<HatcheryFarm> HatcheryFarmManager { get; set; }
        public IRepository<Locations> LocationManager { get; set; }
        public IRepository<Breed> BreedManager { get; set; }
        public IRepository<BreedTypes> BreedTypesManager { get; set; }
        public IRepository<Country> CountryManager { get; set; }
        public IRepository<Batch> BatchManager { get; set; }
        public IRepository<AddChickenInFarm> AddChickenInFarmManager { get; set; }
        public IRepository<Vaccine> VaccineManager { get; set; }
        public IRepository<ChickenVaccine> ChickenVaccineManager { get; set; }
        public IRepository<BreedVaccine> BreedVaccineManager { get; set; }
        public IRepository<BreedWeight> BreedWeightManager { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public FarmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BreedChickenManager = unitOfWork.Repository<BreedChicken>();
            HatcheryFarmManager = unitOfWork.Repository<HatcheryFarm>();
            LocationManager = unitOfWork.Repository<Locations>();
            BreedManager = unitOfWork.Repository<Breed>();
            BreedTypesManager = unitOfWork.Repository<BreedTypes>();
            CountryManager = unitOfWork.Repository<Country>();
            BatchManager = unitOfWork.Repository<Batch>();
            AddChickenInFarmManager = unitOfWork.Repository<AddChickenInFarm>();
            ChickenVaccineManager = unitOfWork.Repository<ChickenVaccine>();
            BreedVaccineManager = unitOfWork.Repository<BreedVaccine>();
            BreedWeightManager = unitOfWork.Repository<BreedWeight>();

        }
      

        //---------------------------------------Farms--------------------------------------------
        public List<HatcheryFarm> FarmsList()
        {
            return HatcheryFarmManager.GetAll().Where(x=>x.DateDeleted == null).ToList();
        }

        public void AddFarms(FarmsModel model)
        {
            var entity = new HatcheryFarm();
            entity.Id = Guid.NewGuid().ToString();
            entity.Name = model.Name;
            entity.DateCreated = DateTime.Now;
            HatcheryFarmManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public HatcheryFarm DetailsFarm(string id)
        {
            return HatcheryFarmManager.Find(id);

        }

        public FarmsModel EditFarms(string id)
        {
            var entity = HatcheryFarmManager.Find(id);

            FarmsModel farmsmodel = new FarmsModel();
            farmsmodel.Id = entity.Id;
            farmsmodel.Name = entity.Name;
            farmsmodel.DateCreated = entity.DateCreated;


            return farmsmodel; 
        }

        public void EditFarms(FarmsModel model)
        {
            var entity = new HatcheryFarm();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.DateCreated = model.DateCreated;
            HatcheryFarmManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteFarm(HatcheryFarm farm)
        {
            var hatcheryFarm = HatcheryFarmManager.Find(farm.Id);
            HatcheryFarmManager.Delete(hatcheryFarm);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------Locations--------------------------------------------
        public List<LocationsModel> LocationsList()
        {

            var entitieslist = LocationManager.GetAll().Include(x => x.HatcheryFarm).Where(x => x.DateDeleted == null).ToList();
            var dataList = entitieslist.Select(x => new LocationsModel
            {
                Id = x.Id,
                FarmId = x.HatcheryFarmId,
                BuildingId = x.BuildingId,
                Location = x.Location,
                DateCreated = x.DateCreated,
                FarmName = x.HatcheryFarm.Name,
                Building = x.Building.Buildings

            }).ToList();
            return dataList;
        }

        public void AddLocation(LocationsModel model)
        {
            var entity = new Locations();
            entity.Id = Guid.NewGuid().ToString();
            entity.HatcheryFarmId = model.FarmId;
            entity.BuildingId = model.BuildingId;
            entity.Location = model.Location;
            entity.DateCreated = DateTime.Now;
            LocationManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Locations DetailsLocation(string id)
        {
            return LocationManager.Find(id);

        }

        public LocationsModel EditLocation(string id)
        {
            var entity = LocationManager.Find(id);

            LocationsModel locationsmodel = new LocationsModel();
            locationsmodel.Id = entity.Id;
            locationsmodel.Location = entity.Location;
            locationsmodel.FarmId = entity.HatcheryFarmId;
            locationsmodel.BuildingId = entity.BuildingId;
            locationsmodel.DateCreated = entity.DateCreated;

            return locationsmodel;
        }

        public void EditLocation(LocationsModel model)
        {
            var entity = new Locations();
            entity.Id = model.Id;
            entity.Location = model.Location;
            entity.HatcheryFarmId = model.FarmId;
            entity.BuildingId = model.BuildingId;
            entity.DateCreated = model.DateCreated;
            LocationManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteLocation(Locations loc)
        {
            var location = LocationManager.Find(loc.Id);
            LocationManager.Delete(location);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------Breed--------------------------------------------
        public List<Breed> BreedsList()
        {
            return BreedManager.GetAll().Where(x=>x.DateDeleted==null).ToList();
        }

        public void AddBreed(BreedsModel model)
        {
            var entity = new Breed();
            entity.Id = Guid.NewGuid().ToString();
            entity.Name = model.Name;
            entity.DateCreated = DateTime.Now;
            BreedManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Breed DetailsBreed(string id)
        {
            return BreedManager.Find(id);

        }

        public BreedsModel EditBreed(string id)
        {
            var entity = BreedManager.Find(id);

            BreedsModel breedsmodel = new BreedsModel();
            breedsmodel.Id = entity.Id;
            breedsmodel.Name = entity.Name;
            breedsmodel.DateCreated = entity.DateCreated;
            return breedsmodel;
        }

        public void EditBreed(BreedsModel model)
        {
            var entity = new Breed();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.DateCreated = model.DateCreated;
            BreedManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBreed(Breed b)
        {
            var breed = BreedManager.Find(b.Id);
            BreedManager.Delete(breed);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------BreedTypes--------------------------------------------
        public List<BreedTypesModel> BreedTypeList()
        {

            var entitieslist = BreedTypesManager.GetAll().Include(x => x.Breed).Where(x => x.DateDeleted == null).ToList();
            var dataList = entitieslist.Select(x => new BreedTypesModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                Breed = x.Breed.Name,
                BreedType = x.BreedType,
                DateCreated = x.DateCreated

            }).ToList();
            return dataList;
        }

        public void AddBreedType(BreedTypesModel model)
        {
            var entity = new BreedTypes();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.BreedType = model.BreedType;
            entity.DateCreated = DateTime.Now;
            BreedTypesManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        //public Locations DetailsLocation(string id)
        //{
        //    return LocationManager.Find(id);

        //}

        public BreedTypesModel EditBreedType(string id)
        {
            var entity = BreedTypesManager.Find(id);

            BreedTypesModel breedtypemodel = new BreedTypesModel();
            breedtypemodel.Id = entity.Id;
            breedtypemodel.BreedType = entity.BreedType;
            breedtypemodel.BreedId = entity.BreedId;
            breedtypemodel.DateCreated = entity.DateCreated;

            return breedtypemodel;
        }

        public void EditBreedType(BreedTypesModel model)
        {
            var entity = new BreedTypes();
            entity.Id = model.Id;
            entity.BreedType = model.BreedType;
            entity.BreedId = model.BreedId;
            entity.DateCreated = model.DateCreated;
            BreedTypesManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBreedType(BreedTypes bt)
        {
            var breedtype = BreedTypesManager.Find(bt.Id);
            BreedTypesManager.Delete(breedtype);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------Country --------------------------------------------
        public List<Country> CountriesList()
        {
            return CountryManager.GetAll().Where(x=>x.DateDeleted==null).ToList();
        }

        public void AddCountry(CountryModel model)
        {
            var entity = new Country();
            entity.Id = Guid.NewGuid().ToString();
            entity.CountryName = model.CountryName;
            entity.DateCreated = DateTime.Now;
            CountryManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Country DetailsCountry(string id)
        {
            return CountryManager.Find(id);

        }

        public CountryModel EditCountry(string id)
        {
            var entity = CountryManager.Find(id);

            CountryModel countrymodel = new CountryModel();
            countrymodel.Id = entity.Id;
            countrymodel.CountryName = entity.CountryName;
            countrymodel.DateCreated = entity.DateCreated;
            
            return countrymodel;
        }

        public void EditCountry(CountryModel model)
        {
            var entity = new Country();
            entity.Id = model.Id;
            entity.CountryName = model.CountryName;
            entity.DateCreated = model.DateCreated;
            CountryManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteCountry(Country c)
        {
            var country = CountryManager.Find(c.Id);
            CountryManager.Delete(country);
            _unitOfWork.DataContext.SaveChanges();
        }

        //------------------------------------------ Batch ---------------------------------------------------
        public List<BatchModel> ListBatch()
        {
            var entitieslist = BatchManager.GetAll().Where(x => x.DateDeleted == null && x.Closed == false).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BatchModel
            {
                Id = x.Id,
                Code = x.Code,
                BreedId = x.BreedId,
                BreedTypeId = x.BreedTypeId,
                CountryId = x.CountryId,
                ArrivalDate = x.ArrivalDate,
                Age = x.Age,
                DateCreated = x.DateCreated,
                TotalMale = x.TotalMale,
                TotalFemale = x.TotalFemale,
                DeadMale = x.DeadMale,
                DeadFemale = x.DeadFemale,
                TotalCost = x.TotalCost,
                Breed = x.Breed.Name,
                BreedType = x.BreedType.BreedType,
                Country = x.Country.CountryName

            }).ToList();
            return dataList;
        }
        
        public void AddBatch(BatchModel model)
        {
            var entity = new Batch();
            entity.Id = Guid.NewGuid().ToString();
            entity.Code = model.Code;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.CountryId = model.CountryId;
            entity.ArrivalDate = model.ArrivalDate;
            entity.Age = (DateTime.Now - model.ArrivalDate).Days;
            entity.TotalMale = model.TotalMale;
            entity.TotalFemale = model.TotalFemale;
            entity.DeadMale = model.DeadMale;
            entity.DeadFemale = model.DeadFemale;
            entity.TotalCost = model.TotalCost;
            entity.DateCreated = DateTime.Now;
            entity.PlacedMale = 0;
            entity.PlacedFemale = 0;
            BatchManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Batch DetailsBatch(string id)
        {
            return BatchManager.Find(id);

        }

        public BatchModel EditBatch(string id)
        {
            var entity = BatchManager.Find(id);

            BatchModel model = new BatchModel();
            model.Id = entity.Id;
            model.Code = entity.Code;
            model.BreedId = entity.BreedId;
            model.BreedTypeId = entity.BreedTypeId;
            model.CountryId = entity.CountryId;
            model.ArrivalDate = entity.ArrivalDate;
            model.TotalMale = entity.TotalMale;
            model.TotalFemale = entity.TotalFemale;
            model.DeadMale = entity.DeadMale;
            model.DeadFemale = entity.DeadFemale;
            model.TotalCost = entity.TotalCost;
            model.DateCreated = entity.DateCreated;

            return model;
        }

        public void EditBatch(BatchModel model)
        {
            var entity = new Batch();
            entity.Id = model.Id;
            entity.Code = model.Code;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.CountryId = model.CountryId;
            entity.ArrivalDate = model.ArrivalDate;
            entity.DateCreated = model.DateCreated;
            entity.TotalMale = model.TotalMale;
            entity.TotalFemale = model.TotalFemale;
            entity.DeadMale = model.DeadMale;
            entity.DeadFemale = model.DeadFemale;
            entity.TotalCost = model.TotalCost;
            entity.Closed = model.Closed;
            BatchManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBatch(Batch batch)
        {
            var b = BatchManager.Find(batch.Id);
            BatchManager.Delete(b);
            _unitOfWork.DataContext.SaveChanges();
        }

        //------------------------------------------ AddChickenInFarm ---------------------------------------------------
        public List<BatchChickenDataModel> ListChickensInFarm()
        {
            var entitieslist = AddChickenInFarmManager.GetAll().Where(x=>x.DateDeleted==null && x.Batch.Closed==false).Include(x => x.Farm).Include(x => x.Location).Include(x => x.Batch).ToList();
            var dataList = entitieslist.Select(x => new BatchChickenDataModel
            {
                Id = x.Id,
                BatchId = x.BatchId,
                FarmId = x.FarmId,
                BuildingId=x.BuildingId,
                  LocationId = x.LocationId,
                //BreedId = x.BreedId,
                //CountryId = x.CountryId,
                //ArrivalDate = x.ArrivalDate,
                DateCreated = x.DateCreated,
                TotalMale = x.TotalMale,
                TotalFemale = x.TotalFemale,
                FarmName = x.Farm.Name,
                BuildingName=x.Building.Buildings,
               
                Location = x.Location.Location,
                BatchCode = x.Batch.Code
                //Breed = x.Breed.Name,
                //Country = x.Country.CountryName

            }).ToList();
            return dataList;
        }


        public int AddChickenToFarm(AddChickenInFarmModel model)
        {
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<AddChickenInFarmModel, AddChickenInFarm>();

            //});

            //var entity = Mapper.Map<AddChickenInFarm>(model);
            //new AddChickenInFarm();

            var batchId = model.BatchId;
            var batch = BatchManager.Find(batchId);
            var placedMale = batch.PlacedMale;
            var placedFemale = batch.PlacedFemale;

            var entity = new AddChickenInFarm();
            entity.Id = Guid.NewGuid().ToString();
            entity.BatchId = model.BatchId;
            entity.FarmId = model.FarmId;
            entity.BuildingId = model.BuildingId;
            entity.LocationId = model.LocationId;
            //entity.BreedId = model.BreedId;
            //entity.CountryId = model.CountryId;
            //entity.ArrivalDate = model.ArrivalDate;
            entity.TotalMale = model.TotalMale;
            entity.TotalFemale = model.TotalFemale;
            entity.DateCreated = DateTime.Now;

            batch.PlacedMale = placedMale + entity.TotalMale;
            batch.PlacedFemale = placedFemale + entity.TotalFemale;

            if(batch.PlacedMale > batch.TotalMale && batch.PlacedFemale > batch.TotalFemale){
                return 3;
            }else if(batch.PlacedMale > batch.TotalMale)
            {
                return 1;
            }else if(batch.PlacedFemale > batch.TotalFemale)
            {
                return 2;
            }else
            {
                AddChickenInFarmManager.Update(entity);
                _unitOfWork.DataContext.SaveChanges();
                return 0;
            }

        }

        public void AddFarms(HatcheryFarm model)
        {
            throw new NotImplementedException();
        }

        public AddChickenInFarm DetailsChickenInFarm(string id)
        {
            //var entity = new AddChickenInFarm();
            //var breedId = entity.BreedId;
            //var breedVaccineList = BreedVaccineManager.GetAll().ToList();
            //var newbreedVaccineList = breedVaccineList.Where(x => x.Id == breedId);
            return AddChickenInFarmManager.Find(id);

        }

        public AddChickenInFarmModel EditChickenInFarm(string id)
        {
            var entity = AddChickenInFarmManager.Find(id);

            AddChickenInFarmModel model = new AddChickenInFarmModel();
            model.Id = entity.Id;
            model.BatchId = entity.BatchId;
            model.FarmId = entity.FarmId;
            model.BuildingId = entity.BuildingId;
            model.LocationId = entity.LocationId;
            //model.BreedId = entity.BreedId;
            //model.CountryId = entity.CountryId;
            //model.ArrivalDate = entity.ArrivalDate;
            model.TotalMale = entity.TotalMale;
            model.TotalFemale = entity.TotalFemale;
            model.DateCreated = entity.DateCreated;

            model.PlacedMalePrevious = model.TotalMale;
            model.PlacedFemalePrevious = model.TotalFemale;
            model.ShiftedDate = entity.ShiftedDate;
            model.ParentId = entity.ParentId;

            return model;
        }

        public int EditChickenInFarm(AddChickenInFarmModel model)
        {
            var batchId = model.BatchId;
            var batch = BatchManager.Find(batchId);
            var placedMale = batch.PlacedMale - model.PlacedMalePrevious;
            var placedFemale = batch.PlacedFemale - model.PlacedFemalePrevious;

            var entity = new AddChickenInFarm();
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.FarmId = model.FarmId;
            entity.BuildingId = model.BuildingId;
            entity.LocationId = model.LocationId;
            //entity.BreedId = model.BreedId;
            //entity.CountryId = model.CountryId;
            //entity.ArrivalDate = model.ArrivalDate;
            entity.DateCreated = model.DateCreated;
            entity.TotalMale = model.TotalMale;
            entity.TotalFemale = model.TotalFemale;
            entity.ShiftedDate = model.ShiftedDate;
            entity.ParentId = model.ParentId;

            batch.PlacedMale = placedMale + entity.TotalMale;
            batch.PlacedFemale = placedFemale + entity.TotalFemale;

            if (batch.PlacedMale > batch.TotalMale && batch.PlacedFemale > batch.TotalFemale)
            {
                return 3;
            }else if (batch.PlacedMale > batch.TotalMale)
            {
                return 1;
            }
            else if (batch.PlacedFemale > batch.TotalFemale)
            {
                return 2;
            }
            else
            {
                AddChickenInFarmManager.Update(entity);
                _unitOfWork.DataContext.SaveChanges();
                return 0;
            }
        }

        public BatchShiftModel ShiftChickenToFarm(string id)
        {
            var entity = AddChickenInFarmManager.Find(id);

            BatchShiftModel model = new BatchShiftModel();
            model.Id = entity.Id;
            model.BatchId = entity.BatchId;
            model.BatchCode = entity.Batch.Code;
            model.FarmId = entity.FarmId;
            model.BuildingId = entity.BuildingId;
            model.LocationId = entity.LocationId;
            model.TotalMale = entity.TotalMale;
            model.TotalFemale = entity.TotalFemale;
            model.DateCreated = entity.DateCreated;
            model.ParentId = entity.ParentId;
            return model;
        }

        public void ShiftChickenToFarm(BatchShiftModel model)
        {
            //edit original record
            var entity = new AddChickenInFarm();
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.FarmId = model.FarmId;
            entity.BuildingId = model.PreviousBuildingId;
            entity.LocationId = model.PreviousLocationId;
            entity.DateCreated = DateTime.Now;
            entity.TotalMale = model.PreviousMale - model.TotalMale;
            entity.TotalFemale = model.PreviousFemale - model.TotalFemale;
            entity.ShiftedDate = model.ShiftedDate;
            entity.ParentId = model.ParentId;
            AddChickenInFarmManager.Update(entity);

            //delete original record
            //var batchChicken = AddChickenInFarmManager.Find(model.Id);
            //AddChickenInFarmManager.Delete(batchChicken);

            //add new record in new room
            var shiftentity = new AddChickenInFarm();
            shiftentity.Id = Guid.NewGuid().ToString();
            shiftentity.BatchId = model.BatchId;
            shiftentity.FarmId = model.FarmId;
            shiftentity.BuildingId = model.BuildingId;
            shiftentity.LocationId = model.LocationId;
            shiftentity.TotalMale = model.TotalMale;
            shiftentity.TotalFemale = model.TotalFemale;
            shiftentity.DateCreated = DateTime.Now;
            shiftentity.ShiftedDate = model.ShiftedDate;
            shiftentity.ParentId = model.Id;
            AddChickenInFarmManager.Add(shiftentity);

            //add new record in previous room
            //var shiftentityPrevious = new AddChickenInFarm();
            //shiftentityPrevious.Id = Guid.NewGuid().ToString();
            //shiftentityPrevious.BatchId = model.BatchId;
            //shiftentityPrevious.FarmId = model.FarmId;
            //shiftentityPrevious.BuildingId = model.PreviousBuildingId;
            //shiftentityPrevious.LocationId = model.PreviousLocationId;
            //shiftentityPrevious.TotalMale = model.PreviousMale - model.TotalMale;
            //shiftentityPrevious.TotalFemale = model.PreviousFemale - model.TotalFemale;
            //shiftentityPrevious.DateCreated = DateTime.Now;
            //shiftentityPrevious.ShiftedDate = model.ShiftedDate;
            //shiftentityPrevious.ParentId = model.Id;
            //AddChickenInFarmManager.Add(shiftentityPrevious);
            //_unitOfWork.DataContext.SaveChanges();

            //add chicken vaccine
            var chickenvaccinee = ChickenVaccineManager.GetAll().Where(x => x.AddChickenId == entity.Id).ToList().OrderByDescending(x => x.VaccinationDate);
            var chickenvaccine = ChickenVaccineManager.GetAll().Where(x=>x.AddChickenId == entity.Id).ToList().OrderByDescending(x => x.VaccinationDate).FirstOrDefault();
            if(chickenvaccine != null)
            {
                var cv = new ChickenVaccine();
                cv.Id = Guid.NewGuid().ToString();
                cv.BatchId = chickenvaccine.BatchId;
                cv.LocationId = shiftentity.LocationId;
                cv.Age = chickenvaccine.Age;
                cv.VaccineId = chickenvaccine.VaccineId;
                cv.VaccinationDate = chickenvaccine.VaccinationDate;
                cv.RecommendedDate = chickenvaccine.RecommendedDate;
                cv.DateCreated = DateTime.Now;
                //cv.AddChickenId = chickenvaccine.AddChickenId;
                ChickenVaccineManager.Add(cv);
            }
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteChickenInFarm(AddChickenInFarm batch)
        {
            var batchChicken = AddChickenInFarmManager.Find(batch.Id);
            AddChickenInFarmManager.Delete(batchChicken);
            _unitOfWork.DataContext.SaveChanges();
        }

        // ------------------------------------------- Chicken Vaccine ---------------------------------------

        public List<ChickenVaccineModel> ChickenVaccineList(string batchId)
        {
            if (batchId == null)
                throw new ArgumentNullException(nameof(batchId));
            //var entitieslist = ChickenVaccineManager.GetAll().Include(x => x.BreedVaccine).Include(x=>x.BreedVaccine.Vaccine).ToList();
            var entitieslist = ChickenVaccineManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.Vaccine).ToList();
            var datalist = entitieslist.Select(x => new ChickenVaccineModel
            {
                Id = x.Id,
                BatchId = x.Batch.Id,
                AddChickenId = x.AddChickenId,
                LocationId = x.Location.Id,
                Location = x.Location.Location,
                VaccineId = x.VaccineId,
                VaccineName = x.Vaccine.VaccineName,
                Age = x.Age,
                VaccinationDate = x.VaccinationDate,
                RecommendedDate = x.RecommendedDate,
                DateCreated = x.DateCreated
            }).Where(x => x.BatchId == batchId).ToList();

            //displaying chicken vaccines after add chicken shift
            //var cvShiftedEntities = AddChickenInFarmManager.GetAll().ToList().Join(ChickenVaccineManager.GetAll().ToList(), ac => ac.ParentId,
            // cv => cv.AddChickenId, (ac, cv) => new ChickenVaccineModel
            // {
            //     LocationId = ac.LocationId,
            //     Location = ac.Location.Location,
            //     VaccineId = cv.VaccineId,
            //     VaccineName = cv.Vaccine.VaccineName,
            //     VaccinationDate = cv.VaccinationDate,
            //     RecommendedDate = cv.RecommendedDate
            // }).ToList();
            //datalist = datalist.Union(cvShiftedEntities).ToList();
            return datalist;
        }

        public List<ChickenVaccineModel> ChickenVaccineListByBatchId(string batchChickenId)
        {
            if (batchChickenId == null)
                throw new ArgumentNullException(nameof(batchChickenId));
            //var entitieslist = ChickenVaccineManager.GetAll().Include(x => x.BreedVaccine).Include(x=>x.BreedVaccine.Vaccine).ToList();
            var entitieslist = ChickenVaccineManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.Vaccine).ToList();
            var datalist = entitieslist.Select(x => new ChickenVaccineModel
            {
                Id = x.Id,
                //BatchChickenId = x.BatchChickenId,
                //BatchId = x.BatchChicken.BatchId,
                //BreedVaccineId = x.BreedVaccineId,
                VaccineId = x.VaccineId,
                Age = x.Age,
                VaccinationDate = x.VaccinationDate,
                RecommendedDate = x.RecommendedDate,
                DateCreated = x.DateCreated,
                VaccineName = x.Vaccine.VaccineName,
                //VaccineName = x.BreedVaccine.Vaccine.VaccineName
                // }).ToList();
            }).Where(x => x.BatchId == batchChickenId).ToList();
            return datalist;
        }

        //public List<ChickenVaccine> ChickenVaccineList()
        //{
        //     return ChickenVaccineManager.GetAll().ToList();
        //}

        public ChickenVaccineModel AddChickenVaccine(string id)
        {
            var entity = AddChickenInFarmManager.Find(id);

            ChickenVaccineModel chickenVaccineModel = new ChickenVaccineModel();
            //chickenVaccineModel.Id = entity.Id;
            chickenVaccineModel.BatchChickenId = entity.BatchId;
            chickenVaccineModel.FarmName = entity.Farm.Name;
            chickenVaccineModel.Location = entity.Location.Location;
            //chickenVaccineModel.Breed = entity.Breed.Name;
            //chickenVaccineModel.BreedId = entity.BreedId;
            //chickenVaccineModel.ArrivalDate = entity.ArrivalDate;
            return chickenVaccineModel;
        }

        public BatchChickenVaccineModel AddChickenVaccineByBatch(string batchId)
        {
            var chickeninframs = AddChickenInFarmManager.GetAll().Where(x=>x.DateDeleted==null).Where(x => x.BatchId == batchId).OrderBy(x=>x.Location.Location).ToList();
            BatchChickenVaccineModel model = new BatchChickenVaccineModel();
            model.ChickenVaccines = new List<ChickenVaccineModel>();
            foreach (var entity in chickeninframs)
            {

                ChickenVaccineModel chickenVaccineModel = new ChickenVaccineModel();
                //chickenVaccineModel.Id = entity.Id;
                chickenVaccineModel.BatchId = entity.BatchId;
                chickenVaccineModel.AddChickenId = entity.Id;
                chickenVaccineModel.FarmName = entity.Farm.Name;
                chickenVaccineModel.Location = entity.Location.Location;
                chickenVaccineModel.LocationId = entity.Location.Id;
                //chickenVaccineModel.Breed = entity.Breed.Name;
                //chickenVaccineModel.BreedId = entity.BreedId;
                //chickenVaccineModel.ArrivalDate = entity.ArrivalDate;
                model.ChickenVaccines.Add(chickenVaccineModel);
                model.BreedId = entity.Batch.BreedId;
                model.Breed = entity.Batch.Breed.Name;
                model.BatchId = entity.Batch.Id;
                model.BatchCode = entity.Batch.Code;
                model.ArrivalDate = entity.Batch.ArrivalDate;
                model.Age = (DateTime.Now - model.ArrivalDate).Days;
            }

            return model;
        }

        public void AddChickenVaccine(ChickenVaccineModel model)
        {
            var entity = new ChickenVaccine();
            entity.Id = Guid.NewGuid().ToString();
            entity.BatchId = model.BatchId;
            entity.AddChickenId = model.AddChickenId;
            entity.LocationId = model.LocationId;
            entity.Age = model.Age;
            entity.VaccineId = model.VaccineId;
            //entity.BreedVaccineId = model.BreedVaccineId;
            entity.VaccinationDate = model.VaccinationDate;
            entity.DateCreated = DateTime.Now;
            entity.RecommendedDate = DateTime.Now;

            //Calculating recommended date
            string BreedId = model.BreedId;
            DateTime ArrivalDate = model.ArrivalDate;
            var breedVaccine = BreedVaccineManager.GetAll().Where(x => x.BreedId == BreedId && x.VaccineId == entity.VaccineId);
            int breedVaccineAge = breedVaccine.Select(x => x.Age).Single();
            entity.RecommendedDate = ArrivalDate.AddDays(breedVaccineAge);
            
            ChickenVaccineManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public ChickenVaccine DetailsChickenVaccine(string id)
        {
            return ChickenVaccineManager.Find(id);

        }

        public ChickenVaccineModel EditChickenVaccine(string id)
        {
            var entity = ChickenVaccineManager.Find(id);
            //var batchChickenEntity = AddChickenInFarmManager.Find(batchChickenId);

            ChickenVaccineModel chickenVaccineModel = new ChickenVaccineModel();
            chickenVaccineModel.Id = entity.Id;
            chickenVaccineModel.BatchId = entity.BatchId;
            chickenVaccineModel.AddChickenId = entity.AddChickenId;
            chickenVaccineModel.LocationId = entity.LocationId;
            chickenVaccineModel.BatchCode = entity.Batch.Code;
            chickenVaccineModel.BreedId = entity.Batch.BreedId;
            //chickenVaccineModel.BatchId = entity.BatchChicken.BatchId;
            //chickenVaccineModel.BreedId = batchChickenEntity.BreedId;
            //chickenVaccineModel.FarmName = batchChickenEntity.Farm.Name;
            //chickenVaccineModel.Location = batchChickenEntity.Location.Location;
            //chickenVaccineModel.Age = entity.Age;
            chickenVaccineModel.VaccineId = entity.VaccineId;
            chickenVaccineModel.VaccinationDate = entity.VaccinationDate;
            chickenVaccineModel.RecommendedDate = entity.RecommendedDate;
            chickenVaccineModel.DateCreated = entity.DateCreated;

            return chickenVaccineModel;
        }

        public void EditChickenVaccine(ChickenVaccineModel model)
        {
            var entity = new ChickenVaccine();
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.AddChickenId = model.AddChickenId;
            entity.LocationId = model.LocationId;
            entity.VaccineId = model.VaccineId;
            entity.VaccinationDate = model.VaccinationDate;
            entity.RecommendedDate = model.RecommendedDate;
            entity.DateCreated = model.DateCreated;
            ChickenVaccineManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteChickenVaccine(ChickenVaccine cv)
        {
            var chickenVaccine = ChickenVaccineManager.Find(cv.Id);
            ChickenVaccineManager.Delete(chickenVaccine);
            _unitOfWork.DataContext.SaveChanges();
        }

        // ------------------------------------------- Breed Weight ---------------------------------------

        public List<BreedWeightModel> BreedWeightList()
        {
            var entitieslist = BreedWeightManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BreedWeightModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                BreedName = x.Breed.Name,
                BreedType = x.BreedType.BreedType,
                Weight = x.Weight,
                Age = x.Age,
                DateCreated = x.DateCreated

            }).ToList();
            return dataList;
        }

        public BreedWeightModel AddBreedWeight(string id)
        {
            var entity = BreedManager.Find(id);
            BreedWeightModel model = new BreedWeightModel();
            model.BreedId = entity.Id;
            model.BreedName = entity.Name;
            return model;

        }
        public void AddBreedWeight(BreedWeightModel model)
        {
            var entity = new BreedWeight();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.Age = model.Age;
            entity.Weight = model.Weight;
            entity.DateCreated = DateTime.Now;
            BreedWeightManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public BreedWeight DetailsBreedWeight(string id)
        {
            return BreedWeightManager.Find(id);

        }

        public BreedWeightModel EditBreedWeight(string id)
        {
            var entity = BreedWeightManager.Find(id);

            BreedWeightModel model = new BreedWeightModel();
            model.Id = entity.Id;
            model.BreedId = entity.BreedId;
            model.BreedName = entity.Breed.Name;
            model.BreedTypeId = entity.BreedTypeId;
            model.Age = entity.Age;
            model.Weight = entity.Weight;
            model.DateCreated = entity.DateCreated;

            return model;
        }

        public void EditBreedWeight(BreedWeightModel model)
        {
            var entity = new BreedWeight();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.Age = model.Age;
            entity.Weight = model.Weight;
            entity.DateCreated = model.DateCreated;

            BreedWeightManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteBreedWeight(BreedWeight bw)
        {
            var breedWeight = BreedWeightManager.Find(bw.Id);
            BreedWeightManager.Delete(breedWeight);
            _unitOfWork.DataContext.SaveChanges();
        }

    }
}