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
    public class BreedWeightController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        FarmService farmservice = null;


        public ActionResult GetBreedWeight([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var breedWeight = farmservice.BreedWeightList();

                return Json(breedWeight.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: BreedWeight
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Create(string id)
        {
            var model = farmservice.AddBreedWeight(id);
            return PartialView(model);
        }

        //public JsonResult GetCascadeBreeds()
        //{

        //    return Json(db.Breeds.Select(c => new { Id = c.Id, BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        //}

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
        public ActionResult Create(BreedWeightModel model)
        {
            if (ModelState.IsValid)
            {
                var breedweight = db.BreedWeights.Where(x => x.BreedTypeId == model.BreedTypeId && x.Age == model.Age && x.DateDeleted == null);
                if (breedweight.Count() != 0)
                {
                    ModelState.AddModelError("Age", "The Breed Weight for this age already exists!");
                    return PartialView(model);
                }
                farmservice.AddBreedWeight(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
            }
            var breed = db.Breeds.Find(model.BreedId);
            model.BreedName = breed.Name;
            return View(model);

        }

        public ActionResult Details(string id)
        {
            var model = farmservice.DetailsBreedWeight(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var model = farmservice.EditBreedWeight(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedWeightModel model)
        {
            if (ModelState.IsValid)
            {
                var breedweight = db.BreedWeights.Where(x => x.BreedTypeId == model.BreedTypeId && x.Age == model.Age && x.DateDeleted == null);
                var breedweightId = breedweight.FirstOrDefault()?.Id.ToUpper();

                if (breedweightId != null && (breedweightId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Age", "The Breed Weight for this age already exists!");
                    return PartialView(model);
                }
                else
                {
                    farmservice.EditBreedWeight(model);
                    return Json(1, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("Details", "Breed", new { id = model.BreedId });
                }
            }
            var breed = db.Breeds.Find(model.BreedId);
            model.BreedName = breed.Name;
            return PartialView(model);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedWeight model)
        {
            farmservice.DeleteBreedWeight(model);
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