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
    public class ChickenVaccineController : Controller
    {
        private HatcheryDb db = new HatcheryDb();

        FarmService farmservice = null;
        // GET: ChickenVaccine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChickenVaccine([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {

                var chickenVaccineList = farmservice.ChickenVaccineList(id);

                return Json(chickenVaccineList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public ActionResult Create(string id)

        {
            var model = farmservice.AddChickenVaccineByBatch(id);
            var batch = db.Batch.Find(id);
            model.BatchCode = batch.Code;
            model.Breed = batch.Breed.Name;
            model.ArrivalDate = batch.ArrivalDate;
            model.Age = (DateTime.Now - batch.ArrivalDate).Days;
            return View(model);
        }

      
        public JsonResult GetCascadeBreedVaccines(string breeds, string batchid)
        {
            var breedvaccines = db.BreedVaccines.AsQueryable();
            var chickenvaccines = db.ChickenVaccines.AsQueryable();
            if (breedvaccines != null)
            {
                breedvaccines = breedvaccines.Where(p => p.BreedId == breeds);
            }
               
            var vaccidgiven = db.ChickenVaccines.Where(x => x.BatchId == batchid).Select(x => x.VaccineId).Distinct().ToList();
            var breedvaccinesremaining = breedvaccines;
                        
            if (vaccidgiven != null)
            {
                breedvaccinesremaining = from bv in breedvaccines where !vaccidgiven.Contains(bv.VaccineId) select bv;
            }
            return Json(breedvaccinesremaining.Where(x=>x.DateDeleted==null).Select(p => new { Id = p.Vaccine.Id, VaccineName = p.Vaccine.VaccineName, Age = p.Age }), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(BatchChickenVaccineModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.ChickenVaccines)
                {
                    item.BatchId = model.BatchId;
                    item.VaccinationDate = model.VaccinationDate;
                    item.BreedId = model.BreedId;
                    item.ArrivalDate = model.ArrivalDate;
                    farmservice.AddChickenVaccine(item);
                }
               
                return RedirectToAction("Details", "Batch", new { id=model.BatchId });
                //return RedirectToAction("Index");
                //return Json(1, JsonRequestBehavior.AllowGet);
            }
            var m = farmservice.AddChickenVaccineByBatch(model.BatchId);
            return View(m);

        }

        public ActionResult Details(string id)
        {
           
            var model = farmservice.DetailsChickenVaccine(id);
            return View(model); 
        }

        public PartialViewResult Edit(string id)
        {
            ViewBag.NullId = false;
            ChickenVaccineModel model = new ChickenVaccineModel();

            if(id == "null")
            {
                ViewBag.NullId = true;
            }
            else
            {
                model = farmservice.EditChickenVaccine(id);
                //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenVaccineModel model)
        {
            if (ModelState.IsValid)
            {
                farmservice.EditChickenVaccine(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            var batch = db.Batch.Find(model.BatchId);
            return PartialView(batch);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(ChickenVaccine model)
        {
            farmservice.DeleteChickenVaccine(model);
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