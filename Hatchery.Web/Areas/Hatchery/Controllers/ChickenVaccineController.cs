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

        public PartialViewResult Create(string id)
        {
            var model = farmservice.AddChickenVaccine(id);
            return PartialView(model);
        }

      
        public JsonResult GetCascadeBreedVaccines(string breeds)
        {
            var breedvaccines = db.BreedVaccines.AsQueryable();

            if (breedvaccines != null)
            {
                breedvaccines = breedvaccines.Where(p => p.BreedId == breeds);
            }

            return Json(breedvaccines.Select(p => new { Id = p.Vaccine.Id, VaccineName = p.Vaccine.VaccineName }), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(ChickenVaccineModel model)
        {
            if (ModelState.IsValid)
            {
                farmservice.AddChickenVaccine(model);
                //return RedirectToAction("Details", "AddChicken", new { id=model.BatchChickenId });
                //return RedirectToAction("Index");
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return View(model);

        }

        public ActionResult Details(string id)
        {

            var model = farmservice.DetailsChickenVaccine(id);
            return View(model); 
        }

        public PartialViewResult Edit(string id, string batchChickenId)
        {
            //var chickenVaccine = farmservice.ChickenVaccineManager.Find(id); 
            var model = farmservice.EditChickenVaccine(id, batchChickenId);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
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
            return PartialView();
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