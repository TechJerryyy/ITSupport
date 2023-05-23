using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace ITSupport.Core.Interfaces
{
    public interface IAuditLogService
    {
        string InsertAudit(string exception, int statusCode);
        AuditLogViewModel GetActivityLogById(Guid Id);
        List<AuditLogViewModel> GetActivityLogs(bool IsException = false);
    }
}
