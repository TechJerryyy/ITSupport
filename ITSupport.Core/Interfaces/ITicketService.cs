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
        Ticket CreateTicket(TicketViewModel model);
        List<DropDown> SetDropDown(string ConfigName);
        List<TicketViewModel> GetTicket();
        TicketViewModel GetTicketById(Guid Id);
        Ticket EditTicket(TicketViewModel model, string deleteAttachmentIds);
        void DeleteTicket(Guid Id);
        TicketComment CreateComment(CommentViewModel model);
        List<CommentViewModel> GetComments(Guid Id);
        void DeleteComment(CommentViewModel model);
        CommentViewModel GetCommentById(Guid Id);
        void EditComment(CommentViewModel model);
    }
}
