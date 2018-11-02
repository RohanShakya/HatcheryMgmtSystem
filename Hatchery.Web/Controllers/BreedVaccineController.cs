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
    public class BreedVaccineController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        Santosh santosh = null;
        public ActionResult GetAllVaccine([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {
                var breedvaccine = santosh.BreedVaccineList(id);
                return Json(breedvaccine.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
       // GET: BreedVaccine
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Create(string id)
        {
            var model = santosh.AddBreedVaccine(id);
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Vaccine");
            return PartialView(model);
        }

        public JsonResult GetCascadeBreeds()
        {
            return Json(db.Breeds.Select(c => new { Id = c.Id,BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeVaccines()
        {

            return Json(db.Vaccines.Select(c => new { Id = c.Id, VaccineName = c.VaccineName }), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(BreedVaccineModel model)
        {
            if (ModelState.IsValid)
            {
                var breedvaccine = db.BreedVaccines.Where(x => x.BreedId == model.BreedId && x.Age == model.Age && x.DateDeleted == null);
                if (breedvaccine.Count() != 0)
                {
                    ModelState.AddModelError("Age", "Breedvaccine already exists for this age");
                }else
                {
                    santosh.AddBreedVaccine(model);
                    //return RedirectToAction("Details","Breed",new { id=model.BreedId});
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Vaccine");
            var breeds = db.Breeds.Find(model.BreedId);
            model.Breed = breeds.Name;
            return PartialView(model);
        }

        public ActionResult Details(string id)
        {
            var model = santosh.DetailsBreedVaccine(id);
            //var model = db.AddChickenInFarm.Find(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var breedvaccine = db.BreedVaccines.Find(id);
            var model = santosh.EditBreedVaccine(id);
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name", breedvaccine.BreedId);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "VaccineName", breedvaccine.VaccineId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedVaccineModel model)
        {
            if (ModelState.IsValid)
            {
                var breedvaccine = db.BreedVaccines.Where(x => x.BreedId == model.BreedId && x.Age == model.Age  && x.DateDeleted == null);
                var breedvaccineId = breedvaccine.FirstOrDefault()?.Id.ToUpper();

                if (breedvaccineId != null && (breedvaccineId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Age", "Breedvaccine already exists for this age!");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }

                santosh.EditBreedVaccine(model);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "VaccineName");
            return PartialView();
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedVaccine model)
        {
            santosh.DeleteBreedVaccine(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            santosh = santosh ?? new Santosh(unitofwork);
        }

    }
}