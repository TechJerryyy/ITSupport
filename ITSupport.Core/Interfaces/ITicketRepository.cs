using ITSupport.Core.Models;
using System;
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

    }
}