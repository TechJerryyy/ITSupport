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
        public Guid AssignTo { get; set; }
        public List<DropDown> TypeDropDown { get; set; }
        public Guid TypeId { get; set; }
        public List<DropDown> PriorityDropDown { get; set; }
        public Guid PriorityId { get; set; }
        public List<DropDown> StatusDropDown { get; set; }
        public Guid StatusId { get; set; }
        public string Image { get; set; }
    }
}
