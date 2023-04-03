using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Models
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        //public string code { get; set; }
        [Required]
        public string Code { get; set; }

    }
}
