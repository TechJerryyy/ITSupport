using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITSupport.Services.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _AuditLogRepository;
        public AuditLogService(IAuditLogRepository AuditLogRepository)
        {
            _AuditLogRepository = AuditLogRepository;
        }
        public string InsertAudit(string exception, int statusCode)
        {
            HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            RouteData routeData = urlHelper.RouteCollection.GetRouteData(currentContext);
            AuditLogs auditLogs = new AuditLogs();
            if (HttpContext.Current.Session["UserId"] != null)
            {
                auditLogs.UserId = (Guid)HttpContext.Current.Session["UserId"];
            }
            auditLogs.Id = Guid.NewGuid();
            auditLogs.ExecutionTime = DateTime.UtcNow;
            auditLogs.ExecutionDuration = DateTime.Now.Millisecond;
            auditLogs.ClientIpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            auditLogs.BrowserInfo = HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;
            auditLogs.HttpMethod = currentContext.Request.HttpMethod;
            auditLogs.Url = currentContext.Request.Url.ToString();
            auditLogs.HttpStatusCode = statusCode;
            auditLogs.Comments = "Controller: " + routeData.Values["controller"].ToString() + " || Action: " + routeData.Values["action"].ToString();
            auditLogs.Parameters = routeData.Values["id"].ToString();
            auditLogs.Headers = currentContext.Request.Headers.ToString();
            auditLogs.Exception = exception;
            _AuditLogRepository.Insert(auditLogs);
            _AuditLogRepository.Commit();
            return null;
        }
        public AuditLogViewModel GetActivityLogById(Guid Id)
        {
            return _AuditLogRepository.GetAuditLogById(Id);
        }
        public List<AuditLogViewModel> GetActivityLogs(bool IsException = false)
        {
            return _AuditLogRepository.GetAuditLogs(IsException);
        }
    }
}
