using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Models
{
    public class FormMst : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string NavigateURL { get; set; }
        public Guid? ParentFormID { get; set; }
        [Required]
        public string FormAccessCode { get; set; }
        [Required]
        public int DisplayIndex { get; set; }
    }
}
