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
    public class BreedFeedController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        Santosh santosh = null;
        public ActionResult GetFeeds([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {
                var breedFeed = santosh.BreedFeedsList(id);

                return Json(breedFeed.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Create(string id)
        {
            var model = santosh.AddBreedFeed(id);
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            //ViewBag.FeedId = new SelectList(db.Feeds, "Id", "FeedName");
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
        public JsonResult GetCascadeFeed()
        {

            return Json(db.Feeds.Select(c => new { Id = c.Id, FeedName = c.FeedName }), JsonRequestBehavior.AllowGet);
        }
      
        [HttpPost]
        public ActionResult Create(BreedFeedModel model)
        {
            if (ModelState.IsValid)
            {

                var breedfeed = db.BreedFeeds.Where(x => x.BreedTypeId == model.BreedTypeId && x.FeedName==model.FeedName &&x.Age==model.Age && x.DateDeleted == null);
                if (breedfeed.Count() != 0)
                {
                    ModelState.AddModelError("FeedId", "The Feed already exists!");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }

                santosh.AddBreedFeed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
               // return RedirectToAction("Details", "Breed", new { id = model.BreedId });
            }
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            //ViewBag.FeedId = new SelectList(db.Feeds, "Id", "FeedName");
            var breed = db.Breeds.Find(model.BreedId);
            model.Breed = breed.Name;
            return PartialView(model);

        }
       
        public ActionResult Details(string id)
        {
            var model = santosh.DetailsBreedFeeds(id);
            return View(model);
        }
        public PartialViewResult Edit(string id)
        {
            var breedfeed = santosh.BreedFeedManager.Find(id);
            var model = santosh.EditBreedFeeds(id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(BreedFeedModel model)
        {
            if (ModelState.IsValid)
            {
                var breedfeed = db.BreedFeeds.Where(x => x.BreedTypeId == model.BreedTypeId && x.FeedName == model.FeedName && x.Age == model.Age && x.DateDeleted == null);
                var dbId = breedfeed.FirstOrDefault()?.Id.ToUpper();

                if (dbId != null && (dbId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("FeedId", "The Feed already exists!");
                    var breeds = db.Breeds.Find(model.BreedId);
                    model.Breed = breeds.Name;
                    return PartialView(model);
                }
                //var breedfeed = db.BreedFeeds.Where(x => x.BreedTypeId == model.BreedTypeId && x.FeedName == model.FeedName  && x.Age==model.Age && x.DateDeleted == null);
                //if (breedfeed.Count() != 0)
                //{
                //    ModelState.AddModelError("FeedId", "The Feed already exists!");
                //    var breeds = db.Breeds.Find(model.BreedId);
                //    model.Breed = breeds.Name;
                //    return PartialView(model);
                //}

                santosh.EditBreedFeeds(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            ViewBag.FeedId = new SelectList(db.Feeds, "Id", "FeedName");
            var breed = db.Breeds.Find(model.BreedId);
            model.BreedName = breed.Name;
            return PartialView(model);
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(BreedFeeds model)
        {
            santosh.DeleteBreedFeeds(model);
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