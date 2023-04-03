using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role Name is Required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Role Code is Required")]
        public string Code { get; set; }
        public Guid? Id { get; set; }
    }
}
