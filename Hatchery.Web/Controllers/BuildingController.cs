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
    [Authorize]
    public class BuildingController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        Sunil sunil = null;
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBuildings([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var BuildingList = sunil.BuildingList();
                return Json(BuildingList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Create()
        {
            ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x => x.DateDeleted == null), "Id", "Name");
            return View();
        }

        public JsonResult GetCascadeFarms()
        {

            return Json(db.HatcheryFarms.Where(x => x.DateDeleted == null).Select(c => new { Id = c.Id, FarmName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(BuildingsModel model)
        {
            if (ModelState.IsValid)
            {
                var building = db.Building.Where(x => x.Buildings == model.Building && x.HatcheryFarm.Id == model.FarmId && x.DateDeleted == null);
                if (building.Count() != 0)
                {
                    ModelState.AddModelError("Building", "The Building already exists!");
                    return PartialView(model);
                }
                sunil.AddBuildings(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            //ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x => x.DateDeleted == null), "Id", "Name");
            return View(model);

        }

        public ActionResult Details(string id)
        {
            var model = sunil.DetailsBuildings(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var model = sunil.EditBuildings(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BuildingsModel model)
        {
            if (ModelState.IsValid)
            {
                var building = db.Building.Where(x => x.Buildings == model.Building && x.HatcheryFarm.Id == model.FarmId && x.DateDeleted == null);
                var buildingId = building.FirstOrDefault()?.Id.ToUpper();
                if (buildingId != null && (buildingId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Building", "The Building already exists!");

                    return PartialView(model);
                }
              
                sunil.EditBuildings(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Building model)
        {
            sunil.DeleteBuildings(model);
            return Json(1, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            sunil = sunil ?? new Sunil(unitofwork);

        }
    }
}