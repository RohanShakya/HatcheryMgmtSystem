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
    public class ChickenEggproductionController : Controller
    {
        // GET: ChickenEggproduction
        private HatcheryDb db = new HatcheryDb();

        Sunil sunil = null;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetChickenEggProduction([DataSourceRequest]DataSourceRequest request,string id)
        {
            try
            {

                var chickeneggproduction = sunil.ChickenEggProductionList(id);

                return Json(chickeneggproduction.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public ActionResult Create(string id)
        {
            var model = sunil.AddChickenEggProductionByBatch(id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(BatchChickenEggProductionModel model)
        {
            if (ModelState.IsValid)
            {
                
                //SELECT t1.Name, SUM(t1.Salary + t2.Bonus) as Total From tb1 as t1, tb2 as t2 WHERE t1.Name = t2.Name group by t1.Name order by t1.Salary
               // var chickenegg = db.ChickenEggProductions.Select(x => x.TotalEggs = x.GoodEggs + x.SpoiltEggs);
                foreach (var item in model.Chickeneggproduction)
                {
                    item.BatchId = model.BatchId;
                    item.DateEntry = model.DateEntry;
                  
                    sunil.AddChickenEggProduction(item);
                
                }
              
                return RedirectToAction("Details", "Batch", new { id = model.BatchId });
            }
            var chickenegg = sunil.AddChickenEggProductionByBatch(model.BatchId);

            return View(chickenegg);
      
        }

        public ActionResult Details(string id)
        {

            var model = sunil.DetailsChickenEggProduction(id);
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            //var chickenVaccine = farmservice.ChickenVaccineManager.Find(id); 
            var model = sunil.EditChickenEggProduction(id);
            //ViewBag.VaccineId = new SelectList(db.Vaccines, "Id", "Name", chickenVaccine);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ChickenEggProductionModel model)
        {
            if (ModelState.IsValid)
            {
                sunil.EditChickenEggProduction(model);
                return Json(1, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Details", "AddChicken", new { id = model.BatchChickenId });
            }
            var chiceknegg = db.Breeds.Find(model.BreedId);
            model.Breed = chiceknegg.Name;
            return View();
        }
        public ActionResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(ChickenEggProduction model)
        {
            sunil.DeleteChickenEggProduction(model);
            return Json(1, JsonRequestBehavior.AllowGet);
           // return RedirectToAction("Details", "AddChicken", new { id = model.BatchId });
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var unitofwork = new UnitOfWork(new HatcheryDb());
            sunil = sunil ?? new Sunil(unitofwork);

        }
    }
}