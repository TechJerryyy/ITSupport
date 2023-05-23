using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ITSupport.SQL.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        internal DataContext context;
        internal DbSet<AuditLogs> dbSet;
        public AuditLogRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<AuditLogs>();
        }
        public IQueryable<AuditLogs> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public AuditLogs Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(AuditLogs auditLogs)
        {
            dbSet.Add(auditLogs);
        }
        public List<AuditLogViewModel> GetAuditLogs(bool IsException)
        {
            var audits = (from a in context.AuditLogs
                          join u in context.Users on a.UserId equals u.Id
                          orderby a.ExecutionTime descending
                          where (IsException && a.Exception!=null) || (!IsException && a.Exception == null)
                          select new AuditLogViewModel
                          {
                              Id = a.Id,
                              UserId = u.Id,
                              ExecutionTime = a.ExecutionTime,
                              ExecutionDuration = a.ExecutionDuration,
                              ClientIpAddress = a.ClientIpAddress,
                              BrowserInfo = a.BrowserInfo,
                              HttpMethod = a.HttpMethod,
                              Url = a.Url,
                              UserName = u.UserName,
                              HttpStatusCode = a.HttpStatusCode,
                              Comments = a.Comments,
                              Parameters = a.Parameters,
                              Exception = a.Exception,
                          }).ToList();
            return audits;
        }
    public AuditLogViewModel GetAuditLogById(Guid Id)
        {
            var audits = (from a in context.AuditLogs
                          join u in context.Users on a.UserId equals u.Id
                          where a.Id == Id
                          orderby a.ExecutionTime descending
                          select new AuditLogViewModel
                          {
                              Id = a.Id,
                              UserId = u.Id,
                              ExecutionTime = a.ExecutionTime,
                              ExecutionDuration = a.ExecutionDuration,
                              ClientIpAddress = a.ClientIpAddress,
                              BrowserInfo = a.BrowserInfo,
                              HttpMethod = a.HttpMethod,
                              Url = a.Url,
                              UserName = u.UserName,
                              HttpStatusCode = a.HttpStatusCode,
                              Comments = a.Comments,
                              Parameters = a.Parameters,
                              Exception = a.Exception,
                          }).FirstOrDefault();
            return audits;
        }
    }
}
