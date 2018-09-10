using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using InventoryMgmt.Models;

namespace InventoryMgmt.Controllers
{
    public class StoresController : Controller
    {
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddStoresModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Details(string Id)
        {
            ViewBag.StoreId = Id;
            return View();
        }

        public ActionResult Edit(string id)
        {
            //ViewBag.StoreId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {

            return View("Index");
            //return RedirectToAction("Details", new { id = Id });
        }

    }
}