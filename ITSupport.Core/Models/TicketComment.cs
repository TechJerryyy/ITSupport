﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.Core.Models
{
    public class TicketComment : BaseEntity
    {
        public Guid TicketId { get; set; }
        public string Comment { get; set; }
    }
}