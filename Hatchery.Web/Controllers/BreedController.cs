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
    public class BreedController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        FarmService farmservice = null;
        // GET: Breed
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBreeds([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var breedList = farmservice.BreedsList();
                return Json(breedList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BreedsModel model)
        {
            if (ModelState.IsValid)
            {
                var breed = db.Breeds.Where(x => x.Name == model.Name && x.DateDeleted == null);
                if (breed.Count() != 0)
                {
                    ModelState.AddModelError("Name", "The Breed Name already exists!");
                    return PartialView(model);
                }
                farmservice.AddBreed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            var model = farmservice.DetailsBreed(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var model = farmservice.EditBreed(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(BreedsModel model)
        {
            if (ModelState.IsValid)
            {
                var breed = db.Breeds.Where(x => x.Name == model.Name && x.DateDeleted == null);
                var breedId = breed.FirstOrDefault()?.Id.ToUpper();
                if (breedId != null && (breedId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("Name", "The Breed Name already exists!");

                    return PartialView(model);
                }
               
                farmservice.EditBreed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return PartialView();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Breed model)
        {
            farmservice.DeleteBreed(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            farmservice = farmservice ?? new FarmService(unitofwork);

        }
    }
}