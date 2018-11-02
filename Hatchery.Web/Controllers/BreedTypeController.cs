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
    public class BreedTypeController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        FarmService farmservice = null;
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBreedTypes([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var breedTypeList = farmservice.BreedTypeList();
                return Json(breedTypeList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Create()
        {
            //ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x=>x.DateDeleted==null), "Id", "Name");
            return View();
        }

        public JsonResult GetCascadeBreeds()
        {

            return Json(db.Breeds.Where(x => x.DateDeleted == null).Select(c => new { Id = c.Id, BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(BreedTypesModel model)
        {
            if (ModelState.IsValid)
            {
                var breedtype = db.BreedTypes.Where(x => x.BreedType == model.BreedType && x.DateDeleted == null);
                if (breedtype.Count() != 0)
                {
                    ModelState.AddModelError("BreedType", "The BreedType already exists!");
                    return PartialView(model);
                }
                farmservice.AddBreedType(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            //ViewBag.FarmId = new SelectList(db.HatcheryFarms.Where(x => x.DateDeleted == null), "Id", "Name");
            return View();
            
        }

        //public ActionResult Details(string id)
        //{
        //    var model = farmservice.DetailsLocation(id);
        //    return View(model);
        //}

        public PartialViewResult Edit(string id)
        {
            var model = farmservice.EditBreedType(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedTypesModel model)
        {
            if (ModelState.IsValid)
            {

                var breedtype = db.BreedTypes.Where(x => x.BreedType == model.BreedType && x.DateDeleted == null);
                var breedtypeId = breedtype.FirstOrDefault()?.Id.ToUpper();
                if (breedtypeId != null && (breedtypeId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("BreedType", "The BreedType already exists!");

                    return PartialView(model);
                }

                farmservice.EditBreedType(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedTypes model)
        {
            farmservice.DeleteBreedType(model);
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