using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Nepaltech.Businesses;
using Nepaltech.Data;
using Nepaltech.Entities;
using Nepaltech.Models.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hatchery.Web.Controllers
{

    public class BatchController : Controller
    {
        private HatcheryDb db = new HatcheryDb();

        FarmService farmservice = null;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAllBatch([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var farm = farmservice.ListBatch();

                return Json(farm.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        public JsonResult GetCascadeBreeds()
        {

            return Json(db.Breeds.Where(x => x.DateDeleted == null).Select(c => new { Id = c.Id, BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeBreedTypes(string BreedId)
        {
            var breedtypes = db.BreedTypes.AsQueryable().Where(x => x.DateDeleted == null);

            if (breedtypes != null)
            {
                breedtypes = breedtypes.Where(p => p.BreedId == BreedId);
            }

            return Json(breedtypes.Select(p => new { Id = p.Id, BreedType = p.BreedType }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeCountries()
        {

            return Json(db.Country.Where(x => x.DateDeleted == null).Select(c => new { Id = c.Id, CountryName = c.CountryName }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(BatchModel model)
        {
            if (ModelState.IsValid)
            {
                var batch = db.Batch.Where(x => x.Code == model.Code && x.DateDeleted == null);
                if(batch.Count() != 0)
                {
                    ModelState.AddModelError("Code","The Batch Code already exists!");
                    return PartialView(model);
                }
                else if(model.DeadMale > model.TotalMale)
                {
                    ModelState.AddModelError("DeadMale", "Impossible entry detected!");
                    return PartialView(model);
                }
                else if (model.DeadFemale > model.TotalFemale)
                {
                    ModelState.AddModelError("DeadFemale", "Impossible entry detected!");
                    return PartialView(model);
                }
                else
                {
                    farmservice.AddBatch(model);
                    return Json(1, JsonRequestBehavior.AllowGet);
                }

                //if (batch.Count() == 0 && model.DeadMale < model.TotalMale && model.DeadFemale < model.TotalFemale)
                //{
                //    farmservice.AddBatch(model);
                //    return Json(1, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return PartialView();
                //}

                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.breedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
                return PartialView();
            }

        }

        public ActionResult Details(string id)
        {
            var model = farmservice.DetailsBatch(id);
            //model.Age = (DateTime.Now - model.ArrivalDate).Days;
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var batch = db.Batch.Find(id);
            var model = farmservice.EditBatch(id);
            //ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name", batch.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BatchModel model)
        {
            if (ModelState.IsValid)
            {
                var batch = db.Batch.Where(x => x.Code == model.Code && x.DateDeleted == null);
                var dbId = batch.FirstOrDefault()?.Id.ToUpper();

                if (dbId !=null && (dbId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Code", "The batch code already exists!");
                    return PartialView(model);
                }

                if (model.DeadMale < model.TotalMale && model.DeadFemale < model.TotalFemale)
                {
                    farmservice.EditBatch(model);
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return PartialView(model);
                }

                //return RedirectToAction("Index");
            }
            //ViewBag.BreedId = new SelectList(db.Breeds.Where(x => x.DateDeleted == null), "Id", "Name");
            return PartialView(model);
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Batch batch)
        {
            farmservice.DeleteBatch(batch);
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