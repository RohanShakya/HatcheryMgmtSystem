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
    public class BreedEggProductionController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();
        // GET: BreedEggProductions
        Sunil mortalities;


        public ActionResult GetBreedEggProduction([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {
                var mortality = mortalities.BreedEggProductionList(id);
                return Json(mortality.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        // GET: BreedEggProduction
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Create(string id)
        {

            var model = mortalities.AddBreedEggProduction(id);
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
        public ActionResult Create(BreedEggModel model)
        {
            if (ModelState.IsValid)
            {

                var breedeggs = db.BreedEggProductions.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks == model.AgeinWeeks && x.DateDeleted == null);
                if (breedeggs.Count() != 0)
                {
                    ModelState.AddModelError("AgeinWeeks", "BreedEggproduction already exists for this age");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }
                //model.Id = db.BreedEggProductions.Max(x => x.Id) + 1;
                //db.BreedEggProductions.Add(model);

                mortalities.AddBreedEggProduction(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
            }


            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");

            var breedegg = db.Breeds.Find(model.BreedId);
            model.Breed = breedegg.Name;
            return View(model);
        }
        public ActionResult Details(string id)
        {
            //var model = db.BreedMortalities.Find(id);
            var model = mortalities.DetailsBreedEggProduction(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            //var model = db.BreedMortalities.Find(id);
            var breedeggproduct = db.BreedEggProductions.Find(id);
            var model = mortalities.EditBreedEggProduction(id);
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name", breedeggproduct.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedEggModel model)
        {
            if (ModelState.IsValid)
            { 
                var breedeggs = db.BreedEggProductions.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks == model.AgeinWeeks &&x.DateDeleted==null);
            var dbId = breedeggs.FirstOrDefault()?.Id.ToUpper();

            if (dbId != null && (dbId != model.Id.ToUpper()))
            {
                ModelState.AddModelError("AgeinWeeks", "BreedEggproduction already exists for this age");
                    var breeds = db.Breeds.Find(model.BreedId);
                          model.Breed = breeds.Name;
                    return PartialView(model);
            }
            //{
            //    var breedeggs = db.BreedEggProductions.Where(x => x.BreedTypeId == model.BreedTypeId && x.AgeinWeeks==model.AgeinWeeks && x.DateDeleted == null);
            //    if (breedeggs.Count() != 0)
            //    {
            //        ModelState.AddModelError("AgeinWeeks", "The AgeinWeeks already exists!");
            //        var breeds = db.Breeds.Find(model.BreedId);
            //        model.Breed = breeds.Name;
            //        return PartialView(model);
            //    }
            //db.Entry(model).State = EntityState.Modified;
            //db.SaveChanges();
            mortalities.EditBreedEggProduction(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            var breedegg = db.Breeds.Find(model.BreedId);
            model.Breed = breedegg.Name;
            return PartialView(model);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedEggProductions model)
        {
            mortalities.DeleteBreedEggProduction(model);
            return Json(1, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            mortalities = mortalities ?? new Sunil(unitofwork);

        }
    }
}