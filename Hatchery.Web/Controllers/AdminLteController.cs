using Nepaltech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLteMvc.Controllers
{
    /// <summary>
    /// This is an example controller using the AdminLTE NuGet package's CSHTML templates, CSS, and JavaScript
    /// You can delete these, or use them as handy references when building your own applications
    /// </summary>
    
    [Authorize]
    public class AdminLteController : Controller
    {
        private HatcheryDb db = new HatcheryDb();
        /// <summary>
        /// The home page of the AdminLTE demo dashboard, recreated in this new system
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The color page of the AdminLTE demo, demonstrating the AdminLte.Color enum and supporting methods
        /// </summary>
        /// <returns></returns>
        public ActionResult Colors()
        {
            return View();
        }

        //Added by Rohan
        public ActionResult Dashboard()
        {
            ViewBag.ActiveBatchCount = db.Batch.Count();

            int totalChicken = 0;
            foreach (var batch in db.Batch)
            {
                var ChickenCount = batch.TotalMale + batch.TotalFemale;
                totalChicken = ChickenCount + totalChicken;
            }
            ViewBag.totalChicken = totalChicken;

            int totalEggs = 0;
            foreach (var eggproduction in db.ChickenEggProductions)
            {
                var EggsCount = eggproduction.TotalEggs;
                totalEggs = EggsCount + totalEggs;
            }
            ViewBag.totalEggs = totalEggs;
            return View();
        }
    }
}