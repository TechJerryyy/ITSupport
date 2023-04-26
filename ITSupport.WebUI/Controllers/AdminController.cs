using ITSupport.Core.ViewModels;
using ITSupport.WebUI.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    [UserAuth]
    [PermissionActionFilter("ADMIN", CheckRights.PermissionOrder.IsView)]
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Selected = TempData["PageSelected"] as string;
            return View();
        }
    }
}