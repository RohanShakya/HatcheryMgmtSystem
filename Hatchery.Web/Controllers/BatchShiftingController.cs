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
    public class BatchShiftingController : Controller
    {
        private HatcheryDb db = new HatcheryDb();

        Sunil sunil = null;
        // GET: BatchShifting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBatchShifting([DataSourceRequest]DataSourceRequest request, string id)
        {
            try
            {
                var batchshifting = sunil.BatchShiftingList(id);

                return Json(batchshifting.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }



        public ActionResult Create(string id)
        {                        var model = sunil.AddBatchShiftingByBatch(id);
            return View(model);
        }
        //public JsonResult GetCascadeTotalChicken(string breeds)
        //{
        //    var breedvaccines = db.BreedVaccines.AsQueryable();

        //    if (breedvaccines != null)
        //    {
        //        breedvaccines = breedvaccines.Where(p => p.BreedId == breeds);
        //    }

        //    return Json(breedvaccines.Select(p => new { Id = p.Vaccine.Id, VaccineName = p.Vaccine.VaccineName }), JsonRequestBehavior.AllowGet);
        //}



        [HttpPost]
        public ActionResult Create(BatchShiftingChickenModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.batchshifting)
                {
                    //item.BatchId = model.BatchId;
                    item.DateEntry = model.DateEntry;

                    sunil.AddBatchShifting(item);
                }

                //return RedirectToAction("Details", "AddChicken", new { id=model.BatchChickenId });
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public ActionResult Details(string id)
        {
            var model = sunil.DetailsBatchShifting(id);
            return View(model);
        }

        public ActionResult Edit(string id, string batchId)
        {
            //var chickenVaccine = farmservice.ChickenVaccineManager.Find(id); 
            var model = sunil.EditBatchShifting(id, batchId);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BatchShiftingModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.EditBatchShifting(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "AddChicken", new { id = model.BatchChickenId });
            }
            return PartialView();
        }
        public ActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(BatchShifting model)
        {
            sunil.DeleteBatchShifting(model);
            return RedirectToAction("Index");
            //return Json(1, JsonRequestBehavior.AllowGet);
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            sunil = sunil ?? new Sunil(unitofwork);

        }
    }
}