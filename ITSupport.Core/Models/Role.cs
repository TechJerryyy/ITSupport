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
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
