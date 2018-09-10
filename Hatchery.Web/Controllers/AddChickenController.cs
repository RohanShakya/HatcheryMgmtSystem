using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Nepaltech.Businesses;
using Nepaltech.Data;
using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hatchery.Web.Controllers
{

    public class AddChickenController : Controller
    {
        private HatcheryDb db = new HatcheryDb();

        FarmService farmservice = null;
        public ActionResult Index()
       { 
            return View();
        }

        
        public ActionResult GetAllFarms([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var farm =farmservice.ListChickensInFarm();

                return Json(farm.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public PartialViewResult Create()
        {
            //ViewBag.FarmId = new SelectList(db.HatcheryFarms, "Id", "Name");
            //ViewBag.locationId = new SelectList(db.Locations, "Id", "Location");
            ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
            return PartialView();
        }

        public JsonResult GetCascadeBatch()
        {

            return Json(db.Batch.Where(x => x.DateDeleted == null && x.Closed==false).Select(c => new { Id = c.Id, BatchCode = c.Code, RoomsCount = db.AddChickenInFarm.Where(x=>x.BatchId == c.Id && x.DateDeleted == null).Count() }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeFarms()
        {

            return Json(db.HatcheryFarms.Where(x=>x.DateDeleted==null).Select(c => new { Id = c.Id, FarmName = c.Name }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCascadeBuilding(string FarmId)
        {
            var buildings = db.Building.AsQueryable().Where(x => x.DateDeleted == null);

            if (buildings != null)
            {
                buildings = buildings.Where(p => p.HatcheryFarmId == FarmId);
            }

            return Json(buildings.Select(p => new { Id = p.Id, BuildingName = p.Buildings }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCascadeLocations(string BuildingId)
        {
            var locations = db.Locations.AsQueryable().Where(x=>x.DateDeleted==null);

            if (locations != null)
            {
                locations = locations.Where(p => p.BuildingId == BuildingId);
            }

            return Json(locations.Select(p => new { Id = p.Id, LocationName = p.Location }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeCountries()
        {

            return Json(db.Country.Where(x=>x.DateDeleted==null).Select(c => new { Id = c.Id, CountryName = c.CountryName }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(AddChickenInFarmModel model)
        {
            //model.LocationId = "61d0c1fb-2245-471d-9d90-e4266215764f";
            if (ModelState.IsValid)
            {
                var chickenInFarms = db.AddChickenInFarm.Where(x => x.LocationId == model.LocationId && x.FarmId == model.FarmId && x.DateDeleted == null
                && x.Batch.Closed == false);
                if (chickenInFarms.Count() == 0)
                {
                    var a = farmservice.AddChickenToFarm(model);

                    if (a == 0)
                    {
                        ModelState.AddModelError("BatchId", "Invalid number of chicken in the batch.");
                        return PartialView();
                    }
                    return Json(1, JsonRequestBehavior.AllowGet);
                }else
                {
                    ModelState.AddModelError("LocationId","You have already added chicken to this room");
                    
                    return PartialView();
                }
               
                //return RedirectToAction("Index");
            }
            //ViewBag.farmId = new SelectList(db.HatcheryFarms, "Id", "Name");
            //ViewBag.locationId = new SelectList(db.Locations, "Id", "Location");
            else
            {
                ViewBag.breedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
                return PartialView();
            }
           
        }

        public ActionResult Details(string id)
        {

            var model = farmservice.DetailsChickenInFarm(id);
            //var model = db.AddChickenInFarm.Find(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var batchChicken = db.AddChickenInFarm.Find(id);
            var model = farmservice.EditChickenInFarm(id);
            //ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name", batchChicken.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AddChickenInFarmModel model)
        {
            if (ModelState.IsValid)
            {
                var locations = db.AddChickenInFarm.Where(x => x.LocationId == model.LocationId && x.FarmId == model.FarmId && x.DateDeleted == null);
                var AddChickenId = locations.FirstOrDefault()?.Id.ToUpper();
                if (AddChickenId != null && (AddChickenId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("LocationId", "You have already added chicken to this room");
                    return PartialView(model);
                }
                farmservice.EditChickenInFarm(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                
                //return RedirectToAction("Index");
            }
            else
            {
                return PartialView(model);
            }
            //ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
           
        }

        public PartialViewResult Shift(string id)
        {
            var batchChicken = db.AddChickenInFarm.Find(id);
            var model = farmservice.ShiftChickenToFarm(id);
            model.PreviousMale = batchChicken.TotalMale;
            model.PreviousFemale = batchChicken.TotalFemale;
            model.PreviousBuildingId = batchChicken.BuildingId;
            model.PreviousLocationId = batchChicken.LocationId;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Shift(BatchShiftModel model)
        {
            if (ModelState.IsValid)
            {
                //farmservice.ShiftChickenToFarm(model);
                //return Json(1, JsonRequestBehavior.AllowGet);

                var chickenInFarms = db.AddChickenInFarm.Where(x => x.LocationId == model.LocationId && x.FarmId == model.FarmId && x.DateDeleted == null);
                var AddChickenId = chickenInFarms.FirstOrDefault()?.Id.ToUpper();
                //if (AddChickenId != null && (AddChickenId == model.Id.ToUpper()))
                if (AddChickenId != null)
                {
                    ModelState.AddModelError("LocationId", "You have already added chicken to this room");
                    //model.BatchCode = 
                    return PartialView(model);
                }
                farmservice.ShiftChickenToFarm(model);
                return Json(1, JsonRequestBehavior.AllowGet);

            }
            else
            {
                //ViewBag.breedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
                return PartialView(model);
            }

        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(AddChickenInFarm batch)
        {
            farmservice.DeleteChickenInFarm(batch);
            return Json(1, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            farmservice = farmservice ?? new FarmService(unitofwork);

        }
    }
}