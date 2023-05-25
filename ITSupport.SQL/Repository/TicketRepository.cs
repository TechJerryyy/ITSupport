using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITSupport.SQL.Repository
{
    public class TicketRepository : ITicketRepository
    {
        internal DataContext context;
        internal DbSet<Ticket> dbSet;

        public TicketRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Ticket>();
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
        public List<TicketViewModel> GetTicket()
        {
            if (HttpContext.Current.Session["RoleCode"].ToString() == "SA" || HttpContext.Current.Session["RoleCode"].ToString() == "ADM")
            {
                var ticket = (from t in context.Ticket.Where(x => !x.IsDeleted).AsEnumerable()
                              join u in context.Users on t.AssignTo equals u.Id
                              join ct in context.CommonLookups on t.TypeId equals ct.Id
                              join cp in context.CommonLookups on t.PriorityId equals cp.Id
                              join cs in context.CommonLookups on t.StatusId equals cs.Id
                              where !t.IsDeleted
                              select new TicketViewModel
                              {
                                  Id = t.Id,
                                  AssignTo = u.Id,
                                  TypeId = ct.Id,
                                  PriorityId = cp.Id,
                                  StatusId = cs.Id,
                                  Description = t.Description,
                                  Assigned = u.Name,
                                  Type = ct.ConfigKey,
                                  Priority = cp.ConfigKey,
                                  Status = cs.ConfigKey,
                                  Title = t.Title,
                                  IsActive = t.IsActive,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByName = u.Name,
                              });
                var result = (from t in ticket
                              join at in context.TicketAttachment.Where(x => !x.IsDeleted) on t.Id equals at.TicketId into fdata
                              from tf in fdata.DefaultIfEmpty()
                              group tf by t into g
                              select new TicketViewModel
                              {
                                  Id = g.Key.Id,
                                  AssignTo = g.Key.AssignTo,
                                  TypeId = g.Key.TypeId,
                                  PriorityId = g.Key.PriorityId,
                                  StatusId = g.Key.StatusId,
                                  Description = g.Key.Description,
                                  Assigned = g.Key.Assigned,
                                  Type = g.Key.Type,
                                  Priority = g.Key.Priority,
                                  Status = g.Key.Status,
                                  Title = g.Key.Title,
                                  IsActive = g.Key.IsActive,
                                  CreatedBy = g.Key.CreatedBy,
                                  CreatedByName = g.Key.CreatedByName,
                                  AttachmentCount = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.Count() : 0,
                                  MultiAttachment = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.ToList() : null
                              }).ToList();
                return result;
            }
            else
            {
                var ticket = (from t in context.Ticket.Where(x => !x.IsDeleted).AsEnumerable()
                              join u in context.Users on t.AssignTo equals u.Id
                              join ct in context.CommonLookups on t.TypeId equals ct.Id
                              join cp in context.CommonLookups on t.PriorityId equals cp.Id
                              join cs in context.CommonLookups on t.StatusId equals cs.Id
                              where !t.IsDeleted && t.CreatedBy.ToString() == HttpContext.Current.Session["UserId"].ToString()
                              select new TicketViewModel
                              {
                                  Id = t.Id,
                                  AssignTo = u.Id,
                                  TypeId = ct.Id,
                                  PriorityId = cp.Id,
                                  StatusId = cs.Id,
                                  Description = t.Description,
                                  Assigned = u.Name,
                                  Type = ct.ConfigKey,
                                  Priority = cp.ConfigKey,
                                  Status = cs.ConfigKey,
                                  Title = t.Title,
                                  IsActive = t.IsActive,
                                  CreatedBy = t.CreatedBy,
                                  CreatedByName = u.Name,
                              });
                var result = (from t in ticket
                              join at in context.TicketAttachment.Where(x => !x.IsDeleted) on t.Id equals at.TicketId into fdata
                              from tf in fdata.DefaultIfEmpty()
                              group tf by t into g
                              select new TicketViewModel
                              {
                                  Id = g.Key.Id,
                                  AssignTo = g.Key.AssignTo,
                                  TypeId = g.Key.TypeId,
                                  PriorityId = g.Key.PriorityId,
                                  StatusId = g.Key.StatusId,
                                  Description = g.Key.Description,
                                  Assigned = g.Key.Assigned,
                                  Type = g.Key.Type,
                                  Priority = g.Key.Priority,
                                  Status = g.Key.Status,
                                  Title = g.Key.Title,
                                  IsActive = g.Key.IsActive,
                                  CreatedBy = g.Key.CreatedBy,
                                  CreatedByName = g.Key.CreatedByName,
                                  AttachmentCount = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.Count() : 0,
                                  MultiAttachment = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.ToList() : null
                              }).ToList();
                return result;
            }

        }
        public TicketViewModel GetTicketById(Guid Id)
        {
            var ticket = (from t in context.Ticket
                          join ur in context.Users.Where(x => !x.IsDeleted) on t.CreatedBy equals ur.Id
                          join u in context.Users on t.AssignTo equals u.Id
                          join ct in context.CommonLookups on t.TypeId equals ct.Id
                          join cp in context.CommonLookups on t.PriorityId equals cp.Id
                          join cs in context.CommonLookups on t.StatusId equals cs.Id
                          where !t.IsDeleted && t.Id == Id
                          select new TicketViewModel
                          {
                              Id = t.Id,
                              AssignTo = u.Id,
                              TypeId = ct.Id,
                              PriorityId = cp.Id,
                              StatusId = cs.Id,
                              Description = t.Description,
                              Assigned = u.Name,
                              Type = ct.ConfigKey,
                              Priority = cp.ConfigKey,
                              Status = cs.ConfigKey,
                              Title = t.Title,
                              CreatedOn = t.CreatedOn,
                              CreatedBy = ur.Id,
                              CreatedByName = ur.UserName,
                              IsActive = t.IsActive,
                          }).AsEnumerable();

            var data = (from t in ticket
                        join at in context.TicketAttachment.Where(x => !x.IsDeleted) on t.Id equals at.TicketId into fdata
                        from tf in fdata.DefaultIfEmpty()
                        group tf by t into g
                        select new TicketViewModel
                        {
                            Id = g.Key.Id,
                            AssignTo = g.Key.AssignTo,
                            TypeId = g.Key.TypeId,
                            PriorityId = g.Key.PriorityId,
                            StatusId = g.Key.StatusId,
                            Description = g.Key.Description,
                            Assigned = g.Key.Assigned,
                            Type = g.Key.Type,
                            Priority = g.Key.Priority,
                            Status = g.Key.Status,
                            Title = g.Key.Title,
                            CreatedOn = g.Key.CreatedOn,
                            CreatedBy = g.Key.CreatedBy,
                            CreatedByName = g.Key.CreatedByName,
                            IsActive = g.Key.IsActive,
                            AttachmentCount = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.Count() : 0,
                            MultiAttachment = g.Where(x => x != null && x.FileName != null && !x.IsDeleted).Any() ? g.ToList() : null
                        }).FirstOrDefault();
            return data;
        }
        public List<CommentViewModel> GetComments(Guid Id)
        {
            var comments = (from c in context.TicketComment
                            join t in context.Ticket on c.TicketId equals t.Id
                            join u in context.Users on c.CreatedBy equals u.Id
                            orderby c.CreatedOn ascending
                            where !c.IsDeleted && c.TicketId == Id
                            select new CommentViewModel
                            {
                                Id = c.Id,
                                TicketId = c.TicketId,
                                Comment = c.Comment,
                                CreatedOn = c.CreatedOn,
                                CreatedBy = u.Id,
                                CreatedByName = u.UserName,
                            }).ToList();
            return comments;
        }
        public CommentViewModel GetCommentById(Guid Id)
        {
            var comments = (from c in context.TicketComment
                            join t in context.Ticket on c.TicketId equals t.Id
                            join u in context.Users on c.CreatedBy equals u.Id
                            where !c.IsDeleted && c.Id == Id
                            select new CommentViewModel
                            {
                                Id = c.Id,
                                TicketId = c.TicketId,
                                Comment = c.Comment,
                                CreatedOn = c.CreatedOn,
                                CreatedBy = u.Id,
                                CreatedByName = u.UserName,
                            }).FirstOrDefault();
            return comments;
        }
        public List<TicketStatusHistoryViewModel> GetStatusHistoryById(Guid Id)
        {
            var statusChanges = (from s in context.TicketStatusHistory
                            join t in context.Ticket on s.TicketId equals t.Id
                            join u in context.Users on s.CreatedBy equals u.Id
                            orderby s.CreatedOn ascending
                            where !s.IsDeleted && s.TicketId == Id
                            select new TicketStatusHistoryViewModel
                            {
                                Id = s.Id,
                                OldStatus = s.OldStatus,
                                NewStatus = s.NewStatus,
                                CreatedOn = s.CreatedOn,
                                CreatedBy = u.Id,
                                StatusChangedByName = u.UserName,
                            }).ToList();
            return statusChanges;
        }
    }
}
