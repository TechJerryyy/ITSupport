using ITSupport.Core.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace ITSupport.WebUI.ActionFilters
{
    public class AuditLog : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logs = DependencyResolver.Current.GetService<IAuditLogService>();
            logs.InsertAudit(null, HttpContext.Current.Response.StatusCode);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var Error = DependencyResolver.Current.GetService<IAuditLogService>();
            if (filterContext.Exception != null)
            {
                var statusCode = new HttpException(null, filterContext.Exception).GetHttpCode();
                Error.InsertAudit(filterContext.Exception.Message, statusCode);
            }
        }
    }
}