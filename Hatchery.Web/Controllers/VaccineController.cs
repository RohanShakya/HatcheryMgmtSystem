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
    public class VaccineController : Controller
    {

        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();
        // GET: Farms
        Santosh Santosh = null;
        // GET: Vaccine
        public ActionResult Index()
        {
           // var vaccine = db.Vaccines.ToList();
            return View();
        }
        public ActionResult GetVaccine([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var Vaccine = Santosh.VaccineList();
                return Json(Vaccine.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Create(VaccineModel model)
        {
            if (ModelState.IsValid)
            {
                var vaccine = db.Vaccines.Where(x => x.VaccineName == model.VaccineName && x.DateDeleted == null);
                if (vaccine.Count() != 0)
                {
                    ModelState.AddModelError("VaccineName", "The VaccineName already exists!");
                    return PartialView(model);
                }
                Santosh.AddVaccine(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult Details(String id)
        {
         
            var model = Santosh.DetailsVaccine(id);
            return View(model);
        }
        public PartialViewResult Edit(string id)
        {
        
            var model = Santosh.EditVaccines(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(VaccineModel model)
        {
            if (ModelState.IsValid)
            {
                var vaccine = db.Vaccines.Where(x => x.VaccineName == model.VaccineName && x.DateDeleted == null);
                var vaccineId = vaccine.FirstOrDefault()?.Id.ToUpper();
                if (vaccineId != null && (vaccineId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("vaccineName", "The VaccineName already exists!");

                    return PartialView(model);
                }
                Santosh.EditVaccines(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return PartialView();
        }

        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Vaccine model)
        {
           
            Santosh.DeleteVaccine(model);
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