using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class CommentViewModel : BaseEntity
    {
        public Guid TicketId { get; set; }
        [Required]
        public string Comment { get; set; }
        public string CreatedByName { get; set; }
    }
}
