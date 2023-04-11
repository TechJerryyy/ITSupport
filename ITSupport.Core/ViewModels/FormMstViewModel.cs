using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class FormMstViewModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string NavigateURL { get; set; }
        public Guid? ParentFormId { get; set; }
        [Required]
        public string ParentFormName { get; set; }
        [Required]
        public string FormAccessCode { get; set; }
        [Required]
        public int DisplayIndex { get; set; }
        public List<FormDropDown> FormDropDowns { get; set; }
    }
    public class FormDropDown
    {
        public Guid ParentFormId { get; set; }
        public string ParentFormName { get; set; }
    }
}
