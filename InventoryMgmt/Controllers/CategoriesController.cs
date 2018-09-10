using InventoryMgmt.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMgmt.Controllers
{
    public class CategoriesController : Controller
    {


        public ActionResult Index(CategoryAddModel model)
        {

            return View(new CategoryAddModel()
            {
            });

        }

        public ActionResult Edit(string Code)
        {
            ViewBag.code = Code;
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryAddModel model)
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
    }
}