﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.Core
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
