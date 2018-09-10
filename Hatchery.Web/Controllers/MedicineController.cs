using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Nepaltech.Businesses;
using Nepaltech.Data;
using Nepaltech.Entities;
using Nepaltech.Models;
using Nepaltech.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hatchery.Web.Controllers
{
    public class MedicineController : Controller
    {
        private Nepaltech.Data.HatcheryDb db = new HatcheryDb();

        Santosh Santosh = null;

        public ActionResult GetMedicine([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var medicine = Santosh.BreedMedicineList();
                return Json(medicine.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        public PartialViewResult Create()
        {
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
           
          //  ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            return PartialView();
        }
        public JsonResult GetCascadeBreeds()
        {

            return Json(db.Breeds.Where(x=>x.DateDeleted==null).Select(c => new { Id = c.Id, BreedName = c.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                var medicine = db.Medicine.Where(x => x.MedicineName == model.MedicineName && x.DateDeleted == null);
                if (medicine.Count() != 0)
                {
                    ModelState.AddModelError("MedicineName", "The MedicineName already exists!");
                    return PartialView(model);
                }
             

                Santosh.AddMedicine(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");

            return PartialView();

        }
        public ActionResult Details(string id)
        {
            var model = Santosh.DetailsBreedMedicine(id);
            //var model = db.AddChickenInFarm.Find(id);
            return View(model);
        }

        public PartialViewResult Edit(string id)
        {
            var breedmedicine = db.Medicine.Find(id);
            var model = Santosh.EditMedicine(id);
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name", breedmedicine.BreedId);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                var medecine = db.Medicine.Where(x => x.MedicineName == model.MedicineName   && x.DateDeleted == null);

                var medecineId = medecine.FirstOrDefault()?.Id.ToUpper();

                if (medecineId != null && (medecineId != model.Id.ToUpper()))
                {
                    ModelState.AddModelError("MedicineName", "The MedicineName already exists!");

                    return PartialView(model);
                }
                Santosh.EditMedicine(model);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            //ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Name");
            return PartialView();
        }
        public PartialViewResult Delete(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Medicine model)
        {
            Santosh.DeleteMedicine(model);
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