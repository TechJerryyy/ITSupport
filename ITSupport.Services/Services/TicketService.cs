using ITSupport.Core.Interfaces;
using ITSupport.Core.Models;
using ITSupport.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICommonLookupService _commonLookupService;
        private readonly IRepository<TicketAttachment> _ticketAttachmentRepository;
        private readonly IRepository<TicketComment> _ticketCommentRepository;
        public TicketService(ITicketRepository ticketRepository, ICommonLookupService commonLookupService, IRepository<TicketAttachment> ticketAttachmentRepository, IRepository<TicketComment> ticketCommentRepository)
        {
            _ticketRepository = ticketRepository;
            _commonLookupService = commonLookupService;
            _ticketAttachmentRepository = ticketAttachmentRepository;
            _ticketCommentRepository = ticketCommentRepository;
        }
        public Ticket CreateTicket(TicketViewModel model)
        {
            Ticket ticket = new Ticket
            {
                Title = model.Title,
                Description = model.Description,
                AssignTo = model.AssignTo,
                TypeId = model.TypeId,
                PriorityId = model.PriorityId,
                StatusId = model.StatusId,
                Id = model.Id,
                CreatedOn = DateTime.Now,
                CreatedBy = model.CreatedBy,
            };

            _ticketRepository.Insert(ticket);
            _ticketRepository.Commit();

            if (model.Image != null)
            {
                TicketAttachment attachment = new TicketAttachment
                {
                    TicketId = ticket.Id,
                    FileName = model.Image,

                };
                _ticketAttachmentRepository.Insert(attachment);
                _ticketAttachmentRepository.Commit();
            }
            return ticket;
        }
        public Ticket EditTicket(TicketViewModel model, string deleteAttachmentIds)
        {
            var ticket = _ticketRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.AssignTo = model.AssignTo;
            ticket.TypeId = model.TypeId;
            ticket.PriorityId = model.PriorityId;
            ticket.StatusId = model.StatusId;
            ticket.Id = model.Id;
            ticket.UpdatedOn = model.UpdatedOn;
            _ticketRepository.Update(ticket);
            _ticketRepository.Commit();

            if (model.Image != null)
            {
                TicketAttachment attachment = new TicketAttachment
                {
                    TicketId = ticket.Id,
                    FileName = model.Image,
                    UpdatedOn = model.UpdatedOn,
                    Id = Guid.NewGuid(),
                };
                _ticketAttachmentRepository.Insert(attachment);
                _ticketAttachmentRepository.Commit();
            }
            if(!string.IsNullOrEmpty(deleteAttachmentIds))
            {
                string[] attachIds = deleteAttachmentIds.Split(',');
                if (attachIds != null && attachIds.Length > 0)
                {
                    foreach (var item in attachIds)
                    {
                        var res = _ticketAttachmentRepository.Collection().Where(x => x.Id.ToString() == item).FirstOrDefault();
                        res.IsDeleted = true;
                        _ticketAttachmentRepository.Update(res);
                        _ticketAttachmentRepository.Commit();
                    }
                }
            }
            return ticket;
        }
        public List<TicketViewModel> GetTicket()
        {
            return _ticketRepository.GetTicket();
        }
        public TicketViewModel GetTicketById(Guid Id)
        {
            return _ticketRepository.GetTicketById(Id);
        }
        public List<DropDown> SetDropDown(string ConfigName)
        {
            return _commonLookupService.GetCommonLookupsByName(ConfigName).Select(x => new DropDown { Id = x.Id, Name = x.ConfigKey }).ToList();
        }
        public void DeleteTicket(Guid Id)
        {
            var res = _ticketRepository.Find(Id);
            res.IsDeleted = true;
            _ticketRepository.Update(res);
            _ticketRepository.Commit();
        }
        public TicketComment CreateComment(CommentViewModel model)
        {
            TicketComment comment = new TicketComment
            {
                TicketId = model.TicketId,
                Comment = model.Comment,
                CreatedOn = DateTime.Now,
                CreatedBy = model.CreatedBy,
            };
            _ticketCommentRepository.Insert(comment);
            _ticketCommentRepository.Commit();
            return comment;
        }
        public List<CommentViewModel> GetComments(Guid Id)
        {
            return _ticketRepository.GetComments(Id);
        }
        public void DeleteComment(CommentViewModel model)
        {
            var res = _ticketCommentRepository.Collection().Where(x=> x.Id == model.Id).FirstOrDefault();
            res.IsDeleted = true;
            _ticketCommentRepository.Update(res);
            _ticketCommentRepository.Commit();
        }
        public void EditComment(CommentViewModel model)
        {
            var res = _ticketCommentRepository.Collection().Where(x=> x.Id == model.Id).FirstOrDefault();
            res.Comment = model.Comment;
            res.UpdatedOn = DateTime.Now;
            _ticketCommentRepository.Update(res);
            _ticketCommentRepository.Commit();
        }
        public CommentViewModel GetCommentById(Guid Id)
        {
            return _ticketRepository.GetCommentById(Id);
        }
    }
}
