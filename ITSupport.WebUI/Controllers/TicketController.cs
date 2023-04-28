using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.ActionFilters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        public TicketController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsView)]
        public ActionResult Create()
        {
            TicketViewModel ticket = new TicketViewModel();
            ticket.AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList();
            ticket.PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority);
            ticket.StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
            ticket.TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type);

            return View(ticket);
        }
        [HttpPost]
        public ActionResult Create(TicketViewModel model, HttpPostedFileBase file)
        {
            
            if (file != null)
            {
                model.Image = model.Id +"_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketImages//") + model.Image);
                model.AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList();
                model.PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority);
                model.StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
                model.TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type);
                var ticket = _ticketService.CreateTicket(model);
            }

            return RedirectToAction("Index", "Ticket");
        }
    }
}