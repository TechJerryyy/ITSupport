﻿using ITSupport.WebUI.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    [AuditLog()]
    [UserAuth]
    public class HomeController : Controller
    {
        [PermissionActionFilter("HM", CheckRights.PermissionOrder.IsView)]
        public ActionResult Index()
        {
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