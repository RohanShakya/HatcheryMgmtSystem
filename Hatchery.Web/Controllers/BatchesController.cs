﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hatchery.Web.Controllers
{
    public class BatchesController : Controller
    {
        // GET: Batches
        public ActionResult Index()
        {
            return View();
        }
    }
}