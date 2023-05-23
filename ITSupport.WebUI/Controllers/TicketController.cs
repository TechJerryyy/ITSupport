using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using ITSupport.Services.Services;
using ITSupport.WebUI.ActionFilters;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    [AuditLog()]
    [UserAuth]
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
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsView)]
        public ActionResult Index()
        {
            List<TicketViewModel> ticket = _ticketService.GetTicket().OrderByDescending(x => x.CreatedOn).ToList();
            return View(ticket);
        }
        public ActionResult GetTicket([DataSourceRequest] DataSourceRequest request)
        {
            List<TicketViewModel> ticket = _ticketService.GetTicket().ToList();
            return Json(ticket.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsInsert)]
        public ActionResult Create()
        {
            TicketViewModel ticket = new TicketViewModel
            {
                AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList(),
                PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority),
                StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status),
                TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type)
            };
            return View(ticket);
        }
        [HttpPost]
        public ActionResult Create(TicketViewModel model, HttpPostedFileBase file)
        {

            if (file != null)
            {
                model.Image = model.Id + "_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketImages//") + model.Image);
            }
            model.CreatedBy = (Guid)Session["UserId"];
            model.AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList();
            model.PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority);
            model.StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
            model.TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type);
            var ticket = _ticketService.CreateTicket(model);
            return RedirectToAction("Index", "Ticket");
        }
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsUpdate)]
        public ActionResult Edit(Guid Id)
        {
            TicketViewModel ticket = _ticketService.GetTicketById(Id);
            ticket.AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList();
            ticket.PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority);
            ticket.StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
            ticket.TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type);
            return View(ticket);
        }
        [HttpPost]
        public ActionResult Edit(TicketViewModel model, HttpPostedFileBase file)
        {

            if (file != null)
            {
                model.Image = model.Id + "_" + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//TicketImages//") + model.Image);

            }
            model.AssignToDropDown = _userService.GetUsers().Select(x => new DropDown { Id = x.Id, Name = x.Name }).ToList();
            model.PriorityDropDown = _ticketService.SetDropDown(Constants.ConfigName.Priority);
            model.StatusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
            model.TypeDropDown = _ticketService.SetDropDown(Constants.ConfigName.Type);
            var deleteAttachmentIds = Request.Params["hdnDeleteAttachmentId"];
            var ticket = _ticketService.EditTicket(model, deleteAttachmentIds);
            return RedirectToAction("Index", "Ticket");
        }
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsDelete)]
        [HttpPost]
        public ActionResult Delete(Guid Id)
        {
            _ticketService.DeleteTicket(Id);
            return RedirectToAction("Index", "Ticket");
        }
        public ActionResult StatusFilter()
        {
            var statusDropDown = _ticketService.SetDropDown(Constants.ConfigName.Status);
            return Json(statusDropDown, JsonRequestBehavior.AllowGet);
        }
        [PermissionActionFilter("TCKT", CheckRights.PermissionOrder.IsView)]
        public ActionResult Details(Guid Id)
        {
            TicketViewModel ticket = _ticketService.GetTicketById(Id);
            return View(ticket);
        }

        public ActionResult GetComments(Guid Id)
        {
            List<CommentViewModel> comments = _ticketService.GetComments(Id).ToList();
            return PartialView("CommentPartialView", comments);
        }
        [HttpPost]
        public ActionResult CreateComment(CommentViewModel data)
        {
            data.CreatedBy = (Guid)Session["UserId"];
            _ticketService.CreateComment(data);
            return Content("true");
        }
        [HttpPost]
        public ActionResult EditComment(CommentViewModel model)
        {
            _ticketService.EditComment(model);
            return Content("true");
        }
        [HttpPost]
        public ActionResult DeleteComment(Guid Id)
        {
            var comment = _ticketService.GetCommentById(Id);
            _ticketService.DeleteComment(comment);
            return Content("true");
        }
    }
}