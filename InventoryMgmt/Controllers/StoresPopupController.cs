using InventoryMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMgmt.Controllers
{
    public class StoresPopupController : Controller
    {
        // GET: StoresPopup
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
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(string id)
        {
            ViewBag.StoreId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return RedirectToAction("Index");
        }
    }
}