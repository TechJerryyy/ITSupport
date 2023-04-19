using ITSupport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    [UserAuth]
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            _ = TempData["PageSelected"] as string;
            return View();
        }
    }
}