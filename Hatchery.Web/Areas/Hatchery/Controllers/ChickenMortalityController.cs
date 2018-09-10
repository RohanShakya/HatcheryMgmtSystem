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
    public class ChickenMortalityController : Controller
    {
        //GET: ChickenMortality
        private HatcheryDb db = new HatcheryDb();
            Sunil sunil = null;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetChickenMortality([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var chickenmortality = sunil.ChickenMortalityList();

                return Json(chickenmortality.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
                public ActionResult Create(string id)
        {
            var model = sunil.AddChickenMortality(id);
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
        public ActionResult Create(ChickenMortalityModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.AddChickenMortality(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return View(model);

        }

        public ActionResult Details(string id)
        {
                        var model = sunil.DetailsChickenMortality(id);
            return View(model);
        }

        public PartialViewResult Edit(string id, string batchChickenId)
        {
            //var chickenVaccine = farmservice.ChickenVaccineManager.Find(id); 
            var model = sunil.EditChickenMortality(id, batchChickenId);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenMortalityModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.EditChickenMortality(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "AddChicken", new { id = model.BatchChickenId });
            }
            return PartialView();
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(ChickenMortality model)
        {
            sunil.DeleteChickenMortality(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
                protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            sunil = sunil ?? new Sunil(unitofwork);

        }
    }
}