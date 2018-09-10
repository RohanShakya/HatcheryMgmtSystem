using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Nepaltech.Businesses;
using Nepaltech.Data;
using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hatchery.Web.Controllers
{
    public class LocationController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        FarmService farmservice = null;
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLocations([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var locationList = farmservice.LocationsList();
                return Json(locationList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Create()
        {
            ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x=>x.DateDeleted==null), "Id", "Name");
            return View();
        }

        public JsonResult GetCascadeFarms()
        {

            return Json(db.HatcheryFarms.Where(x => x.DateDeleted == null).Select(c => new { Id = c.Id, FarmName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeBuildings(string FarmId)
        {
            var buildings = db.Building.AsQueryable().Where(x => x.DateDeleted == null);

            if (buildings != null)
            {
                buildings = buildings.Where(p => p.HatcheryFarmId == FarmId);
            }

            return Json(buildings.Select(p => new { Id = p.Id, BuildingName = p.Buildings }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(LocationsModel model)
        {
            if (ModelState.IsValid)
            {
                var location = db.Locations.Where(x => x.Location == model.Location && x.HatcheryFarm.Id == model.FarmId
                        && x.Building.Id == model.BuildingId && x.DateDeleted == null);
                if (location.Count() != 0)
                {
                    ModelState.AddModelError("Location", "The Room already exists!");
                    return PartialView(model);
                }
                farmservice.AddLocation(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            //ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x => x.DateDeleted == null), "Id", "Name");
            return View();

        }

        public ActionResult Details(string id)
        {
            var model = farmservice.DetailsLocation(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var model = farmservice.EditLocation(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(LocationsModel model)
        {
            if (ModelState.IsValid)
            {

                var location = db.Locations.Where(x => x.Location == model.Location && x.HatcheryFarm.Id == model.FarmId && x.Building.Id == model.BuildingId && x.DateDeleted == null);

                var locationId = location.FirstOrDefault()?.Id.ToUpper();

                if (locationId != null && (locationId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Location", "The Room already exists!");

                    return PartialView(model);
                }
             
             
                farmservice.EditLocation(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Locations model)
        {
            farmservice.DeleteLocation(model);
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