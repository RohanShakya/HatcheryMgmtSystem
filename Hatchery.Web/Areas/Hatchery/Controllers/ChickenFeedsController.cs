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
    
      
        public ActionResult GetChickenFeed([DataSourceRequest]DataSourceRequest request)
        {
            try
            {

                var chickenFeedList = santosh.ChickenFeedList();

                return Json(chickenFeedList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
            var model = santosh.AddChickenFeed(id);
            return PartialView(model);
        }


        public JsonResult GetCascadeBreedFeed(string breeds)
        {
            var breedfeed = db.BreedFeeds.AsQueryable();

            if (breedfeed != null)
            {
                breedfeed = breedfeed.Where(p => p.BreedId == breeds);
            }

            return Json(breedfeed.Select(p => new { Id = p.Feed.Id, FeedName = p.Feed.FeedName }), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(ChickenFeedModel model)
        {
            if (ModelState.IsValid)
            {
                santosh.AddChickenFeed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return PartialView(model);

        }
        public ActionResult Details(string id)
        {

            var model = santosh.DetailsChickenFeed(id);
            return View(model);
        }
        public PartialViewResult Edit(string id, string batchChickenId)
        {
            var model = santosh.EditChickenFeed(id, batchChickenId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenFeedModel model)
        {
            if (ModelState.IsValid)
            {
                santosh.EditChickenFeed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return PartialView();
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
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