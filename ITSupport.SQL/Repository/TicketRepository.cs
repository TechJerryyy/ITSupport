using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.SQL.Repository
{
    public class TicketRepository : ITicketRepository
    {
        internal DataContext context;
        internal DbSet<Ticket> dbSet;
        internal DbSet<TicketStatusHistory> statusDbSet;
        internal DbSet<TicketAttachment> attachmentDbSet;
        internal DbSet<TicketComment> commentDbSet;
        public TicketRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Ticket>();
            this.statusDbSet = context.Set<TicketStatusHistory>();
            this.attachmentDbSet = context.Set<TicketAttachment>();
            this.commentDbSet = context.Set<TicketComment>();
        }

        public IQueryable<Ticket> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public Ticket Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(Ticket ticket)
        {
            dbSet.Add(ticket);
        }
        public void Delete(Guid Id)
        {
            var ticket = Find(Id);
            if (context.Entry(ticket).State == EntityState.Detached)
                dbSet.Attach(ticket);
            dbSet.Remove(ticket);

        }
        public void Update(Ticket ticket)
        {
            dbSet.Attach(ticket);
            context.Entry(ticket).State = EntityState.Modified;

        }
    }
}
