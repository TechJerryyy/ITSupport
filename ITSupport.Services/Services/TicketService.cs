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
        public TicketService(ITicketRepository ticketRepository, ICommonLookupService commonLookupService, IRepository<TicketAttachment> ticketAttachmentRepository)
        {
            _ticketRepository = ticketRepository;
            _commonLookupService = commonLookupService;
            _ticketAttachmentRepository = ticketAttachmentRepository;
        }
        public Ticket CreateTicket(TicketViewModel model)
        {
            Ticket ticket = new Ticket();
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.AssignTo = model.AssignTo;
            ticket.TypeId = model.TypeId;
            ticket.PriorityId = model.PriorityId;
            ticket.StatusId = model.StatusId;
            ticket.Id = model.Id;

            _ticketRepository.Insert(ticket);
            _ticketRepository.Commit();


            TicketAttachment attachment = new TicketAttachment
            {
                TicketId = ticket.Id,
                FileName = model.Image,

            };
            _ticketAttachmentRepository.Insert(attachment);
            _ticketAttachmentRepository.Commit();
            return ticket;
        }
        //public Ticket GetTicketById(Guid Id)
        //{
        //    return _ticketRepository.Collection().Where(x=>x.Id == Id && !x.IsDeleted).FirstOrDefault();
        //}
        public List<DropDown> SetDropDown(string ConfigName)
        {
           return _commonLookupService.GetCommonLookupsByName(ConfigName).Select(x=> new DropDown { Id = x.Id, Name = x.ConfigKey}).ToList();
        }
    }
}
