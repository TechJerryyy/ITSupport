using ITSupport.Core.Interfaces;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.ActionFilters;
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
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        
        public HomeController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }
        [PermissionActionFilter("HM", CheckRights.PermissionOrder.IsView)]
        public ActionResult Index()
        {
            var tickets = _ticketService.GetTicket().ToList();
            ViewBag.TotalTicket = tickets.Count();
            ViewBag.New = tickets.Where(x => x.Status == "New").Count();
            ViewBag.Pending = tickets.Where(x => x.Status == "Pending").Count();
            ViewBag.Assigned = tickets.Where(x => x.Status == "Assigned").Count();
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