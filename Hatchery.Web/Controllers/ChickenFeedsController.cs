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
    public class ChickenFeedsController : Controller
    {
        private HatcheryDb db = new HatcheryDb();

        Santosh santosh = null;
    
      
        public ActionResult GetChickenFeed([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {

                var chickenFeedList = santosh.ChickenFeedList(id);

                return Json(chickenFeedList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public ActionResult Index()
        {
            HatcheryDb db = new HatcheryDb();


            ViewBag.BreedFeeds = new SelectList(db.BreedFeeds, "FeedId", "MaleQuantity","FeamleQuantity");
            return View();
        }
        public ActionResult Create(string id)
        {
            var model = santosh.AddChickenFeedByBatch(id);
            var batch = db.Batch.Find(id);
            model.Breed = batch.Breed.Name;
            model.BreedType = batch.BreedType.BreedType;
            model.Age = (DateTime.Now - model.ArrivalDate).Days;
            return View(model);
        }


     
        //public JsonResult GetCascadeBreedFeed(string breeds)
        //{
        //    var breedfeed = db.BreedFeeds.AsQueryable();

        //    if (breedfeed != null)
        //    {
        //        breedfeed = breedfeed.Where(p => p.BreedId == breeds);
        //    }

        //    return Json(breedfeed.Select(p => new { Id = p.Feed.Id, FeedName = p.Feed.FeedName }), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetCascadeBreedFeed(string breeds)
        {
            var breedfeed = db.BreedFeeds.AsQueryable();

            if (breedfeed != null)
            {
                breedfeed = breedfeed.Where(p => p.BreedId == breeds);
            }

            return Json(breedfeed.Select(p => new { Id = p.Feed.Id, FeedName = p.Feed.FeedName }), JsonRequestBehavior.AllowGet);
        }
        


        public JsonResult GetCascadeBreedFeedQuantity(string feedid, string breedid)
        {
            var breedfeed = db.BreedFeeds.AsQueryable();

            if (breedfeed != null)
            {
                breedfeed = breedfeed.Where(p => p.FeedId == feedid && p.BreedId == breedid);
            }

            return Json(breedfeed.Select(p => new { Id = p.Id, MaleQuantity = p.MaleQuantity, FemaleQuantity = p.FemaleQuantity }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(BatchChickenFeedModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.ChickenFeeds)
                {
                   
                    item.DateEntry = model.DateEntry;
                    item.BatchId = model.BatchId;
                    santosh.AddChickenFeed(item);
                }

                return RedirectToAction("Details","Batch",new { id=model.BatchId});
            }
            var chickenfeeds = santosh.AddChickenFeedByBatch(model.BatchId );
            return View(chickenfeeds);

        }
        public ActionResult Details(string id)
        {

            var model = santosh.DetailsChickenFeed(id);
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            var model = santosh.EditChickenFeed(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenFeedModel model)
        {
            if (ModelState.IsValid)
            {
                santosh.EditChickenFeed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            var batch = db.Batch.Find(model.BatchId);
            return PartialView(batch);
        }
        public ActionResult Delete(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ChickenFeeds model)
        {
            santosh.DeleteChickenFeeds(model);
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