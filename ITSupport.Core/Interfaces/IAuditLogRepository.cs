using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITSupport.Core.Interfaces
{
    public interface IAuditLogRepository
    {
        IQueryable<AuditLogs> Collection();
        void Commit();
        AuditLogs Find(Guid Id);
        void Insert(AuditLogs auditLogs);
        List<AuditLogViewModel> GetAuditLogs(bool IsException);
        AuditLogViewModel GetAuditLogById(Guid Id);
    }
}
