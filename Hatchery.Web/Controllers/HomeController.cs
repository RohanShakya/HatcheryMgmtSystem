
using Nepaltech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hatchery.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var db = new HatcheryDb();
            //db.HatcheryFarms.Where
            //db.HatcheryFarms.Add(new HatcheryFarm()
            //{
            //    Id="55",
            //    Address="jjjjdjjd"

            //});
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}