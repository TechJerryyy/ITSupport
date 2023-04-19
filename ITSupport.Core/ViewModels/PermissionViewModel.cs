using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class PermissionViewModel 
    {
        [Required]
        public Guid FormId { get; set; }
        [Required]
        public bool View { get; set; }
        [Required]
        public bool Insert { get; set; }
        [Required]
        public bool Update { get; set; }
        [Required]
        public bool Delete { get; set; }
        [Required]
        public string FormName { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}
