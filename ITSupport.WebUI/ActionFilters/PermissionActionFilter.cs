using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITSupport.WebUI.ActionFilters
{
    public class PermissionActionFilter : ActionFilterAttribute
    {
        public string FormName;
        public readonly CheckRights.PermissionOrder _permissionOrder;
        public PermissionActionFilter(string form, CheckRights.PermissionOrder permissionOrder)
        {
            FormName = form;
            _permissionOrder = permissionOrder;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool accessCode = AccessCode.CheckAccess(FormName, _permissionOrder.ToString());
            if (accessCode == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"action", "Index" },
                    {"returnUrl", HttpContext.Current.Request.Url }
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}