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
using System.Data.Common;

namespace Hatchery.Web.Controllers
{

    public class BreedMortalityController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();
        // GET: BreedMortalities
        Sunil mortalities ;

        public ActionResult GetBreedMortality([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {
                var mortality = mortalities.BreedMortalityList(id);
                return Json(mortality.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult Index()
        {
            //var BreedMortalities = db.BreedMortalities.ToList();
            return View();
        }


        public PartialViewResult Create(string id)
        {
            var model = mortalities.AddBreedMortality(id);
             ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            return PartialView(model);
        }
        public JsonResult GetCascadeBreeds()
        {

            return Json(db.Breeds.Select(c => new { Id = c.Id, BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCascadeBreedType(string breeds)
        {
            {
                var breedtypes = db.BreedTypes.AsQueryable();

                if (breedtypes != null)
                {
                    breedtypes = breedtypes.Where(p => p.BreedId == breeds);
                }

                return Json(breedtypes.Where(x => x.DateDeleted == null).Select(p => new { Id = p.Id, BreedTypeName = p.BreedType }), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(BreedMortalityModel model)
        {
            if (ModelState.IsValid)
            {
                var breedeggs = db.BreedMortalities.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks==model.AgeinWeeks && x.DateDeleted == null);
                if (breedeggs.Count() != 0)
                {
                    ModelState.AddModelError("AgeinWeeks", "BreedMortality already exists for this age");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }

                //model.Id = db.BreedMortalities.Max(x => x.Id) + 1;
                //db.BreedMortalities.Add(model);

                mortalities.AddBreedMortality(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
                //return RedirectToAction("Index");
            }


            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");

            var breedmortality = db.Breeds.Find(model.BreedId);
            model.Breed = breedmortality.Name;
            return View(model);
            
        }

        public ActionResult Details(string id)
        {
            //var model = db.BreedMortalities.Find(id);
            var model = mortalities.DetailsBreedMortality(id);
            return View(model);
        }
          
        public PartialViewResult Edit(string id)
        {
            //var model = db.BreedMortalities.Find(id);
            var breedmortality = db.BreedMortalities.Find(id);
            var model = mortalities.EditBreedMortality(id);
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name",breedmortality.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedMortalityModel model)
        {
            if (ModelState.IsValid)
            {
                var breedmortaliy= db.BreedMortalities.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks == model.AgeinWeeks && x.DateDeleted == null);
                var breedmortalityId = breedmortaliy.FirstOrDefault()?.Id.ToUpper();

                if (breedmortalityId != null && (breedmortalityId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("AgeinWeeks", "The AgeinWeeks already exists!");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }

                //var breedeggs = db.BreedMortalities.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks==model.AgeinWeeks && x.AgeinWeeks==model.AgeinWeeks&& x.DateDeleted == null);
                //if (breedeggs.Count() != 0)
                //{
                //    ModelState.AddModelError("AgeinWeeks", "The AgeinWeeks already exists!");
                //    var breeds = db.Breeds.Find(model.BreedId);
                //    model.Breed = breeds.Name;
                //    return PartialView(model);
                //}
                //db.Entry(model).State = EntityState.Modified;
                //db.SaveChanges();
                mortalities.EditBreedMortality(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");

            var breedmortality = db.Breeds.Find(model.BreedId);
            model.Breed = breedmortality.Name;
            return PartialView(model);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedMortality model)
        {
               mortalities.DeleteBreedMortality(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            mortalities = mortalities ?? new Sunil(unitofwork);

        }
    }
}
