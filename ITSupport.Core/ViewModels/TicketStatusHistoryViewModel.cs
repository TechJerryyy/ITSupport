using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class TicketStatusHistoryViewModel : BaseEntity
    {
        public Guid TicketId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public string StatusChangedByName { get; set; }
    }
}
