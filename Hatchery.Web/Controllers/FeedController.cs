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
    public class FeedController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();
       
        Santosh Santosh = null;
       
        public ActionResult GetFeeds([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var feed = Santosh.FeedList();
                return Json(feed.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FeedModel model)
        {
            if (ModelState.IsValid)
            {
                var feed = db.Feeds.Where(x => x.FeedName == model.FeedName && x.DateDeleted == null);
                if (feed.Count() != 0)
                {
                    ModelState.AddModelError("FeedName", "The Feedname already exists!");
                    return PartialView(model);
                }
                Santosh.AddFeed(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Details(String id)
        {
           
            var model = Santosh.DetailsFeed(id);
            return View(model);
        }
        public PartialViewResult Edit(string id)
        {
            var model = Santosh.EditFeed(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(FeedModel model)
        {
            if (ModelState.IsValid)
            {

                var feed = db.Feeds.Where(x => x.FeedName == model.FeedName && x.DateDeleted == null);
                var feedId = feed.FirstOrDefault()?.Id.ToUpper();

                if (feedId != null && (feedId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("FeedName", "The Feedname already exists!");

                    return PartialView(model);
                }
              
                             Santosh.EditFeed(model);
                return Json(1,JsonRequestBehavior.AllowGet);
            }
            return PartialView();
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Feeds model)
        {
            Santosh.DeleteFeed(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            Santosh = Santosh ?? new Santosh(unitofwork);

        }
    }
}