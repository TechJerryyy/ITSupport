using ITSupport.Core.Interfaces;
using ITSupport.Core.ViewModels;
using ITSupport.WebUI.ActionFilters;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ITSupport.WebUI.Controllers
{
    
    [UserAuth]
    public class AuditLogController : Controller
    {
        private readonly IAuditLogService _AuditLogService;
        public AuditLogController(IAuditLogService AuditLogService)
        {
            _AuditLogService = AuditLogService;
        }
        // GET: AuditLog
        [PermissionActionFilter("AL", CheckRights.PermissionOrder.IsView)]
        public ActionResult Index()
        {
            List<AuditLogViewModel> audit = _AuditLogService.GetActivityLogs(false);
            return View(audit);
        }
        public ActionResult GetAllActivityLogs([DataSourceRequest] DataSourceRequest request)
        {
            List<AuditLogViewModel> audit = _AuditLogService.GetActivityLogs();
            return Json(audit.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [PermissionActionFilter("EL", CheckRights.PermissionOrder.IsView)]
        public ActionResult ErrorLog(bool IsException = true)
        {
            List<AuditLogViewModel> audit = _AuditLogService.GetActivityLogs(IsException);
            return View(audit);
        }
        public ActionResult GetErrorLogs([DataSourceRequest] DataSourceRequest request, bool IsException = true)
        {
            List<AuditLogViewModel> audit = _AuditLogService.GetActivityLogs(IsException);
            return Json(audit.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [AuditLog()]
        public ActionResult Details(Guid Id)
        {
            AuditLogViewModel audit = _AuditLogService.GetActivityLogById(Id);
            return View(audit);
        }
    }
}