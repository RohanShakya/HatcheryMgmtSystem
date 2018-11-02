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
    public class CountryController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();

        FarmService farmservice = null;

        // GET: Country
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetCountries([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var farm = farmservice.CountriesList();
                return Json(farm.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var country = db.Country.Where(x => x.CountryName == model.CountryName && x.DateDeleted == null);
                if (country.Count() != 0)
                {
                    ModelState.AddModelError("CountryName", "The CountryName already exists!");
                    return PartialView(model);
                }
                farmservice.AddCountry(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            var model = farmservice.DetailsCountry(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var model = farmservice.EditCountry(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(CountryModel model)
        {
            if (ModelState.IsValid)
            {


                var country = db.Country.Where(x => x.CountryName == model.CountryName && x.DateDeleted == null);
                var countryId = country.FirstOrDefault()?.Id.ToUpper();

                if (countryId != null && (countryId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("CountryName", "The CountryName already exists!");
                  
                    return PartialView(model);
                }
               
              
                farmservice.EditCountry(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return PartialView();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Country model)
        {
            farmservice.DeleteCountry(model);
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