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
    public class ChickenEggproductionController : Controller
    {
        // GET: ChickenEggproduction
        private HatcheryDb db = new HatcheryDb();

        Sunil sunil = null;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetChickenEggProduction([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var chickeneggproduction = sunil.ChickenEggProductionList();

                return Json(chickeneggproduction.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public ActionResult Create(string id)
        {
            var model = sunil.AddChickenEggProduction(id);
            return View(model);
        }


        //public JsonResult GetCascadeBreedVaccines(string breeds)
        //{
        //    var breedvaccines = db.BreedVaccines.AsQueryable();

        //    if (breedvaccines != null)
        //    {
        //        breedvaccines = breedvaccines.Where(p => p.BreedId == breeds);
        //    }

        //    return Json(breedvaccines.Select(p => new { Id = p.Vaccine.Id, VaccineName = p.Vaccine.VaccineName }), JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public ActionResult Create(ChickenEggProductionModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.AddChickenEggProduction(model);
              return RedirectToAction("Details", "AddChicken", new { id = model.Id });
            }
            return View(model);

        }

        public ActionResult Details(string id)
        {

            var model = sunil.DetailsChickenEggProduction(id);
            return View(model);
        }

        public ActionResult Edit(string id, string batchChickenId)
        {
            //var chickenVaccine = farmservice.ChickenVaccineManager.Find(id); 
            var model = sunil.EditChickenEggProduction(id, batchChickenId);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenEggProductionModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.EditChickenEggProduction(model);
                return RedirectToAction("Details", "AddChicken", new { id = model.BatchChickenId });
            }
            return View();
        }
        public ActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ChickenEggProduction model)
        {
            sunil.DeleteChickenEggProduction(model);
            return RedirectToAction("Details", "AddChicken", new { id = model.BatchChickenId });
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            sunil = sunil ?? new Sunil(unitofwork);

        }
    }
}