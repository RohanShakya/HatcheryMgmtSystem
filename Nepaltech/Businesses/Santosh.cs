using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using Nepaltech.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nepaltech.Models.ApiModels;
using System.Data.Entity;
using Nepaltech.Models;

namespace Nepaltech.Businesses
{
    //public interface IFarmService
    //{
    //    void AddChickenToFarm()
    //}

    public partial class Santosh
    {

        public IRepository<Breed> BreedManager { get; set; }
        public IRepository<Feeds> FeedManager { get; set; }
        public IRepository<BreedFeeds> BreedFeedManager { get; set; }
        public IRepository<Vaccine> VaccineManager { get; set; }
        public IRepository<Medicine> MedicineManager { get; set; }
        public IRepository<BreedVaccine> BreedVaccineManager { get; set; }
        public IRepository<ChickenFeeds> ChickenFeedManager { get; set; }
        public IRepository<AddChickenInFarm> AddChickenInFarmManager { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public Santosh(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BreedManager = unitOfWork.Repository<Breed>();
            VaccineManager = unitOfWork.Repository<Vaccine>();
            FeedManager = unitOfWork.Repository<Feeds>();
            ChickenFeedManager = unitOfWork.Repository<ChickenFeeds>();
            BreedVaccineManager = unitOfWork.Repository<BreedVaccine>();
            BreedFeedManager = unitOfWork.Repository<BreedFeeds>();
            AddChickenInFarmManager = unitOfWork.Repository<AddChickenInFarm>();
            MedicineManager = unitOfWork.Repository<Medicine>();

        }

        public object BreedListVaccine()
        {
            throw new NotImplementedException();

        }
        //---------------------------------------BreeedVaccine--------------------------------------------
        public List<BreedVaccineDataModel> BreedVaccineList(string breedId)
        {
            var entitieslist = BreedVaccineManager.GetAll().Where(x=>x.DateDeleted==null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BreedVaccineDataModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                Breed = x.Breed.Name,
                VaccineId = x.VaccineId,
                DateCreated = x.DateCreated,
                Age = x.Age,
                Vaccine = x.Vaccine.VaccineName,

                //  }).ToList();
            }).Where(x => x.BreedId == breedId).ToList();
            return dataList;
        }
        public BreedVaccineModel AddBreedVaccine(string id)
        {
            var entity = BreedManager.Find(id);
            BreedVaccineModel model = new BreedVaccineModel();
            model.BreedId = entity.Id;
            model.Breed = entity.Name;
            return model;

        }
        public void AddBreedVaccine(BreedVaccineModel model)
        {
            var entity = new BreedVaccine();
            entity.Id = Guid.NewGuid().ToString();
            entity.Age = model.Age;
            entity.BreedId = model.BreedId;
            entity.VaccineId = model.VaccineId;
            entity.DateCreated = DateTime.Now;
            BreedVaccineManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public BreedVaccine DetailsBreedVaccine(string id)
        {
            return BreedVaccineManager.Find(id);

        }

        public BreedVaccineModel EditBreedVaccine(string id)
        {
            var entity = BreedVaccineManager.Find(id);

            BreedVaccineModel model = new BreedVaccineModel();
            model.Id = entity.Id;
            model.BreedId = entity.BreedId;
            model.VaccineId = entity.VaccineId;
            model.Age = entity.Age;
            model.DateCreated = entity.DateCreated;

            return model;
        }

        public void EditBreedVaccine(BreedVaccineModel model)
        {
            var entity = new BreedVaccine();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.VaccineId = model.VaccineId;
            entity.DateCreated = model.DateCreated;
            entity.Age = model.Age;

            BreedVaccineManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }
        public void DeleteBreedVaccine(BreedVaccine bc)
        {
            var breedvaccine = BreedVaccineManager.Find(bc.Id);
            BreedVaccineManager.Delete(breedvaccine);
            _unitOfWork.DataContext.SaveChanges();
        }




        //---------------------------------------Vaccine--------------------------------------------

        public List<Vaccine> VaccineList()
        {
            return VaccineManager.GetAll().Where(x=>x.DateDeleted==null).ToList();
        }




        public void AddVaccine(VaccineModel model)
        {
            var entity = new Vaccine();
            entity.Id = Guid.NewGuid().ToString();
            entity.VaccineName = model.VaccineName;
            entity.DateCreated = DateTime.Now;

            VaccineManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void AddVaccine(Santosh model)
        {
            throw new NotImplementedException();
        }

        public Vaccine DetailsVaccine(String id)
        {
            return VaccineManager.Find(id);

        }

        public VaccineModel EditVaccines(String id)
        {
            var entity = VaccineManager.Find(id);

            VaccineModel vaccinemodel = new VaccineModel();
            vaccinemodel.Id = entity.Id;
            vaccinemodel.VaccineName = entity.VaccineName;



            return vaccinemodel;
        }

        public void EditVaccines(VaccineModel model)
        {
            var entity = new Vaccine();
            entity.Id = model.Id;
            entity.VaccineName = model.VaccineName;
            entity.DateCreated = DateTime.Now;
            VaccineManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void EditVaccines(FarmsModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteVaccine(Vaccine v)
        {
            var vaccine = VaccineManager.Find(v.Id);
            VaccineManager.Delete(vaccine);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------BreedFeeds--------------------------------------------
        public List<BreedFeedModel> BreedFeedsList(string breedId)
        {

            var entitieslist = BreedFeedManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new BreedFeedModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                FeedName = x.Feed.FeedName,
                BreedType=x.BreedType.BreedType,
                DateCreated = x.DateCreated,
                BreedName = x.Breed.Name,
                AgeFrom = x.AgeFrom,
                AgeTo = x.AgeTo,
                MaleQuantity = x.MaleQuantity,
                FemaleQuantity = x.FemaleQuantity,
                GenderId = x.GenderId

           // }).ToList();
           }).Where(x=>x.BreedId== breedId).ToList();
                return dataList;
        }

        public BreedFeedModel AddBreedFeed(string id)
        {
            var entity = BreedManager.Find(id);
            BreedFeedModel model = new BreedFeedModel();
            model.BreedId = entity.Id;
            model.Breed = entity.Name;
            return model;
        }


        public void AddBreedFeed(BreedFeedModel model)
        {
            var entity = new BreedFeeds();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.GenderId = model.GenderId;
            entity.FeedId = model.FeedId;
            entity.AgeFrom = model.AgeFrom;
            entity.AgeTo = model.AgeTo;
            entity.MaleQuantity = model.MaleQuantity;
            entity.FemaleQuantity = model.FemaleQuantity;
            entity.FeedName = model.FeedName;
            entity.DateCreated = DateTime.Now;
            BreedFeedManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }


        public BreedFeeds DetailsBreedFeeds(string id)
        {
            return BreedFeedManager.Find(id);

        }

        public BreedFeedModel EditBreedFeeds(string id)
        {
            var entity = BreedFeedManager.Find(id);

            BreedFeedModel breedfeedsmodel = new BreedFeedModel();
            breedfeedsmodel.Id = entity.Id;
            breedfeedsmodel.Breed = entity.Breed.Name;
          //  breedfeedsmodel.BreedName = entity.Breed.Name;
            breedfeedsmodel.BreedId = entity.BreedId;
            breedfeedsmodel.BreedTypeId = entity.BreedTypeId;
            breedfeedsmodel.BreedType = entity.BreedType.BreedType;
            breedfeedsmodel.FeedName = entity.Feed.FeedName;
            breedfeedsmodel.FeedId = entity.FeedId;
            breedfeedsmodel.AgeFrom = entity.AgeFrom;
            breedfeedsmodel.AgeTo = entity.AgeTo;
            breedfeedsmodel.GenderId = entity.GenderId;
            breedfeedsmodel.MaleQuantity = entity.MaleQuantity;
            breedfeedsmodel.FemaleQuantity = entity.FemaleQuantity;
            breedfeedsmodel.DateCreated = entity.DateCreated;

            return breedfeedsmodel;
        }

        public void EditBreedFeeds(BreedFeedModel model)
        {
            var entity = new BreedFeeds();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.BreedTypeId = model.BreedTypeId;
            entity.FeedName = model.FeedName;
            entity.FeedId = model.FeedId;
            entity.AgeFrom = model.AgeFrom;
            entity.AgeTo = model.AgeTo;
            entity.GenderId = model.GenderId;
            entity.MaleQuantity = model.MaleQuantity;
            entity.FemaleQuantity = model.FemaleQuantity;
            entity.DateCreated = model.DateCreated;
            BreedFeedManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }
        public void DeleteBreedFeeds(BreedFeeds bf)
        {
            var breedfeeds = BreedFeedManager.Find(bf.Id);
            BreedFeedManager.Delete(breedfeeds);
            _unitOfWork.DataContext.SaveChanges();
        }


        //---------------------------------------Feeds--------------------------------------------
        public List<Feeds> FeedList()
        {

            return FeedManager.GetAll().Where(x=>x.DateDeleted==null).ToList();
        }

        public void AddFeed(FeedModel model)
        {
            var entity = new Feeds();
            entity.Id = Guid.NewGuid().ToString();

            entity.FeedName = model.FeedName;
            entity.Price = model.Price;
            entity.DateCreated = DateTime.Now;

            FeedManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void AddFeed(Santosh model)
        {
            throw new NotImplementedException();
        }

        public Feeds DetailsFeed(String id)
        {
            return FeedManager.Find(id);

        }

        public FeedModel EditFeed(String id)
        {
            var entity = FeedManager.Find(id);

            FeedModel feedmodel = new FeedModel();
            feedmodel.Id = entity.Id;
            feedmodel.FeedName = entity.FeedName;
            feedmodel.Price = entity.Price;



            return feedmodel;
        }

        public void EditFeed(FeedModel model)
        {
            var entity = new Feeds();
            entity.Id = model.Id;
            entity.FeedName = model.FeedName;
            entity.Price = model.Price;
            entity.DateCreated = DateTime.Now;
            FeedManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }
        public void DeleteFeed(Feeds f)
        {
            var feed = FeedManager.Find(f.Id);
            FeedManager.Delete(feed);
            _unitOfWork.DataContext.SaveChanges();
        }
        // ------------------------------------------- Chicken Feed ---------------------------------------

        public List<ChickenFeedModel> ChickenFeedList(string batchId)
        {
            if (batchId == null)
                throw new ArgumentNullException(nameof(batchId));
            var entitieslist = ChickenFeedManager.GetAll().Where(x=>x.DateDeleted==null).Include(x => x.Feed).ToList();
            var datalist = entitieslist.Select(x => new ChickenFeedModel
            {
                Id = x.Id,
                BatchId=x.Batch.Id,
             
                LocationId = x.Location.Id,
                Location = x.Location.Location,
                FeedId = x.FeedId,
                Age = x.Age,
                DateEntry = x.DateEntry,
                MaleQuantity=x.MaleQuantity,
                FemaleQuantity=x.FemaleQuantity,
          //   BatchCode=x.Batch.Code,
                DateCreated = x.DateCreated,
                Feed = x.Feed.FeedName
           // }).ToList();
            }).Where(x=>x.BatchId==batchId).ToList();
            return datalist;
        }

        public BatchChickenFeedModel AddChickenFeedByBatch(string batchId)
        {
            var chickeninframs = AddChickenInFarmManager.GetAll().Where(x => x.BatchId == batchId).OrderBy(x=>x.Location.Location).ToList();
            BatchChickenFeedModel model = new BatchChickenFeedModel();
            model.ChickenFeeds = new List<ChickenFeedModel>();
            foreach (var entity in chickeninframs)
            {

                ChickenFeedModel chickenfeedmodel = new ChickenFeedModel();
                chickenfeedmodel.BatchId = entity.BatchId;
                chickenfeedmodel.FarmName = entity.Farm.Name;
                chickenfeedmodel.Location = entity.Location.Location;
                chickenfeedmodel.LocationId = entity.Location.Id;
         
              //  chickenfeedmodel.Breed = entity.Breed.Name;
             //   chickenfeedmodel.BreedId = entity.BreedId;
            //  chickenfeedmodel.BatchId = entity.BatchId;
                model.ChickenFeeds.Add(chickenfeedmodel);
                model.BreedId = entity.Batch.BreedId;
                model.BreedTypeId = entity.Batch.BreedTypeId;
                model.BatchCode = entity.Batch.Code;
                model.BatchId = entity.Batch.Id;
                model.ArrivalDate = entity.Batch.ArrivalDate;
                model.Age = (DateTime.Now - model.ArrivalDate).Days;
                //model.LocationId = entity.Location.Id;
            }
    
            return model;
            
        }

        public ChickenFeedModel AddChickenFeed(string id)
        {
            var entity = AddChickenInFarmManager.Find(id);

            ChickenFeedModel chickenfeedmodel = new ChickenFeedModel();
            chickenfeedmodel.BatchChickenId = entity.BatchId;
            chickenfeedmodel.FarmName = entity.Farm.Name;
            chickenfeedmodel.LocationId = entity.Location.Id;
            chickenfeedmodel.Location = entity.Location.Location;
          //  chickenfeedmodel.Breed = entity.Breed.Name;
           // chickenfeedmodel.BreedId = entity.BreedId;
            
            return chickenfeedmodel;
        }

        public void AddChickenFeed(ChickenFeedModel model)
        {
            var entity = new ChickenFeeds();
            entity.Id = Guid.NewGuid().ToString();
          //  entity.BatchChickenId = model.Id;
            entity.Age = model.Age;
            entity.BatchId = model.BatchId;
            entity.FeedId = model.FeedId;
            entity.LocationId = model.LocationId;
            entity.DateCreated = DateTime.Now;
            entity.DateEntry = model.DateEntry;
            entity.RecommendedDate = DateTime.Now;
           // entity.GenderId = model.GenderId;
            entity.MaleQuantity = model.MaleQuantity;
            entity.FemaleQuantity = model.FemaleQuantity;
            ChickenFeedManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public ChickenFeeds DetailsChickenFeed(string id)
        {
            return ChickenFeedManager.Find(id);

        }

        public ChickenFeedModel EditChickenFeed(string id)
        {
            var entity = ChickenFeedManager.Find(id);
          //  var batchChickenEntity = AddChickenInFarmManager.Find(batchChickenId);

            ChickenFeedModel chickenfeedmodel = new ChickenFeedModel();
            chickenfeedmodel.Id = entity.Id;
            chickenfeedmodel.BatchCode = entity.Batch.Code;
            chickenfeedmodel.BatchId = entity.BatchId;
            chickenfeedmodel.LocationId = entity.LocationId;
            chickenfeedmodel.BreedId = entity.Batch.BreedId;
            //   chickenfeedmodel.BatchChickenId = entity.BatchChickenId;
            //   chickenfeedmodel.BatchId = entity.BatchChicken.BatchId;
            // chickenfeedmodel.BreedId = batchChickenEntity.BreedId;
            //  chickenfeedmodel.FarmName = batchChickenEntity.Farm.Name;
            // chickenfeedmodel.Location = batchChickenEntity.Location.Location;
            //  chickenfeedmodel.Breed = batchChickenEntity.Breed.Name;
            chickenfeedmodel.Age = entity.Age;
            chickenfeedmodel.FeedId = entity.FeedId;
            chickenfeedmodel.MaleQuantity = entity.MaleQuantity;
            chickenfeedmodel.FemaleQuantity = entity.FemaleQuantity;
           // chickenfeedmodel.GenderId = entity.GenderId;
            chickenfeedmodel.DateCreated = entity.DateCreated;
            chickenfeedmodel.DateEntry = entity.DateEntry;

            return chickenfeedmodel;
        }

        public void EditChickenFeed(ChickenFeedModel model)
        {
            var entity = new ChickenFeeds();
            entity.Id = model.Id;
            entity.BatchId = model.BatchId;
            entity.LocationId = model.LocationId;
            //  entity.BatchChickenId = model.BatchChickenId;
            //entity.BatchChicken.BatchId = model.BatchId;
            entity.FeedId = model.FeedId;
            entity.Age = model.Age;
            //entity.GenderId = model.GenderId;
            entity.MaleQuantity = model.MaleQuantity;
            entity.FemaleQuantity = model.FemaleQuantity;
            entity.DateCreated = model.DateCreated;
            entity.DateEntry = model.DateEntry;
            entity.RecommendedDate = DateTime.Now;
            ChickenFeedManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public void DeleteChickenFeeds(ChickenFeeds cf)
        {
            var chickenfeeds = ChickenFeedManager.Find(cf.Id);
            ChickenFeedManager.Delete(chickenfeeds);
            _unitOfWork.DataContext.SaveChanges();
        }

        //---------------------------------------Medicine--------------------------------------------
        public List<MedicineModel> BreedMedicineList()
        {
            var entitieslist = MedicineManager.GetAll().Where(x => x.DateDeleted == null).Include(x => x.Breed).ToList();
            var dataList = entitieslist.Select(x => new MedicineModel
            {
                Id = x.Id,
                BreedId = x.BreedId,
                Breed = x.Breed.Name,
                MedicineName = x.MedicineName,
                DiseaseName=x.DiseaseName,
                RecomendedDoctor=x.RecomendedDoctor,
               
                Date = x.Date
             
                
             

            }).ToList();
            return dataList;
        }
        public MedicineModel AddMedicine(string id)
        {
            var entity =MedicineManager.Find(id);
            MedicineModel model = new MedicineModel();
            model.BreedId = entity.Id;
            model.Breed = entity.Breed.Name;
            return model;

        }
        public void AddMedicine(MedicineModel model)
        {
            var entity = new Medicine();
            entity.Id = Guid.NewGuid().ToString();
            entity.BreedId = model.BreedId;
            entity.MedicineName = model.MedicineName;
            entity.DiseaseName = model.DiseaseName;
            entity.RecomendedDoctor = model.RecomendedDoctor;
            entity.DateCreated = DateTime.Now;
            entity.Date= DateTime.Now;

            MedicineManager.Add(entity);
            _unitOfWork.DataContext.SaveChanges();
        }

        public Medicine DetailsBreedMedicine(string id)
        {
            return MedicineManager.Find(id);

        }
        public MedicineModel EditMedicine(String id)
        {
            var entity = MedicineManager.Find(id);

            MedicineModel medicinemodel = new MedicineModel();
            medicinemodel.Id = entity.Id;
            medicinemodel.BreedId = entity.BreedId;
            medicinemodel.Breed = entity.Breed.Name;
            medicinemodel.DiseaseName = entity.DiseaseName;
            medicinemodel.MedicineName = entity.MedicineName;
            medicinemodel.RecomendedDoctor = entity.RecomendedDoctor;
            medicinemodel.Date = entity.Date;
            medicinemodel.DateCreated = entity.DateCreated;
            return medicinemodel;
        }
        public void EditMedicine(MedicineModel model)
        {
            var entity = new Medicine();
            entity.Id = model.Id;
            entity.BreedId = model.BreedId;
            entity.DiseaseName = model.DiseaseName;
            entity.MedicineName = model.MedicineName;
            entity.RecomendedDoctor = model.RecomendedDoctor;
            entity.Date = model.Date;
            entity.DateCreated = model.DateCreated;
            MedicineManager.Update(entity);
            _unitOfWork.DataContext.SaveChanges();
        }


        public void DeleteMedicine(Medicine f)
        {
            var medicine = MedicineManager.Find(f.Id);
            MedicineManager.Delete(medicine);
            _unitOfWork.DataContext.SaveChanges();
        }


    }
}