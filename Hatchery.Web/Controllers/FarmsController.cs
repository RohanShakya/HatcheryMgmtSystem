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
    public class FarmsController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();
        // GET: Farms
        FarmService farmservice = null;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFarms([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var farm = farmservice.FarmsList();
                return Json(farm.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FarmsModel model)
        {
            if (ModelState.IsValid)
            {
                var farm = db.HatcheryFarms.Where(x => x.Name == model.Name && x.DateDeleted == null);
                if (farm.Count() != 0)
                {
                    ModelState.AddModelError("Name","The farm name already exists!");
                    return PartialView(model);
                }
                //model.Id = db.HatcheryFarms.Max(x => x.Id) + 1;
                //db.HatcheryFarms.Add(model);
                farmservice.AddFarms(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            //var model = db.HatcheryFarms.Find(id);
            var model = farmservice.DetailsFarm(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            //var model = db.HatcheryFarms.Find(id);
            var model = farmservice.EditFarms(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(FarmsModel model)
        {
            if (ModelState.IsValid)
            {

                var farm = db.HatcheryFarms.Where(x => x.Name == model.Name && x.DateDeleted == null);
                var farmId = farm.FirstOrDefault()?.Id.ToUpper();

                if (farmId != null && (farmId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Name", "The farm name already exists!");

                    return PartialView(model);
                }

               
                 farmservice.EditFarms(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            return PartialView();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(HatcheryFarm model)
        {
            //var Id = db.AddChickenInFarm.Find(model.Id);
            //db.AddChickenInFarm.Remove(Id);
            //db.SaveChanges();
            farmservice.DeleteFarm(model);
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