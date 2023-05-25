using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITSupport.Core.Interfaces
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> Collection();
        void Commit();
        Ticket Find(Guid Id);
        void Insert(Ticket ticket);
        void Delete(Guid Id);
        void Update(Ticket ticket);
        List<TicketViewModel> GetTicket();
        TicketViewModel GetTicketById(Guid Id);
        List<CommentViewModel> GetComments(Guid Id);
        CommentViewModel GetCommentById(Guid Id);
        List<TicketStatusHistoryViewModel> GetStatusHistoryById(Guid Id);
    }
}