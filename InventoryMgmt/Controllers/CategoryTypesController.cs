using InventoryMgmt.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMgmt.Controllers
{
    public class CategoryTypesController : Controller
    {
        // GET: CategoryTypes
        public ActionResult Index()
        {
            CategoryTypeViewModel model = new CategoryTypeViewModel();
            return View(model);
        //return View(new CategoryTypeViewModel()
        //{
        //    Name = "Jack Daniels",
        //    Description="It's an American whisky"

        //}
        //);



    }



    public DataSourceResult ReadCategoryTypes([DataSourceRequest]DataSourceRequest request)
        {
            var list = new List<CategoryTypeViewModel>()
            {
                new CategoryTypeViewModel() { Id="1",Name="Electronics & Electricals",Description=""}

            };

            return list.ToDataSourceResult(request);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(CategoryTypeViewModel model)
        {
            
            return RedirectToAction("Index");
            
        }
        public ActionResult Edit(string id)
        {
            ViewBag.ItemCategoryId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
           
            return View();
        }
    }
}


