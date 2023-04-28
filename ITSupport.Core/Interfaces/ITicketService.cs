using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Interfaces
{
    public interface ITicketService
    {
        //Ticket GetTicketById(Guid Id);
        Ticket CreateTicket(TicketViewModel model);
        List<DropDown> SetDropDown(string ConfigName);
    }
}
