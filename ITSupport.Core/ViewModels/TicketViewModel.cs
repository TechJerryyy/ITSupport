using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITSupport.Core.ViewModels
{
    public class TicketViewModel : BaseEntity
    {
        [Required(ErrorMessage ="Ticket name required!...")]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DropDown> AssignToDropDown { get; set; }
        [Required(ErrorMessage = "Please select value.")]
        public Guid AssignTo { get; set; }
        public List<DropDown> TypeDropDown { get; set; }
        [Required(ErrorMessage = "Please select value.")]
        public Guid TypeId { get; set; }
        public List<DropDown> PriorityDropDown { get; set; }
        [Required(ErrorMessage = "Please select value.")]
        public Guid PriorityId { get; set; }
        public List<DropDown> StatusDropDown { get; set; }
        [Required(ErrorMessage = "Please select value.")]
        public Guid StatusId { get; set; }
        public string Image { get; set; }
        public string Assigned { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }
        public List<TicketAttachment> MultiAttachment { get; set; }
        public int AttachmentCount { get; set; }
        public string CreatedByName { get; set; }     
    }
}