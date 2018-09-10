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

        public JsonResult GetCascadeFarms()
        {

            return Json(db.HatcheryFarms.Where(x=>x.DateDeleted==null).Select(c => new { Id = c.Id, FarmName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeLocations(string FarmId)
        {
            var locations = db.Locations.AsQueryable().Where(x=>x.DateDeleted==null);

            if (locations != null)
            {
                locations = locations.Where(p => p.HatcheryFarmId == FarmId);
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
            if (ModelState.IsValid)
            {
                farmservice.AddChickenToFarm(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            //ViewBag.farmId = new SelectList(db.HatcheryFarms, "Id", "Name");
            //ViewBag.locationId = new SelectList(db.Locations, "Id", "Location");
            ViewBag.breedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
            return View();
            
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
            ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name", batchChicken.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AddChickenInFarmModel model)
        {
            if (ModelState.IsValid)
            {
                farmservice.EditChickenInFarm(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
            return PartialView();
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