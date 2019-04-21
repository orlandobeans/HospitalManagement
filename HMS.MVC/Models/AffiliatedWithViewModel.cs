using HMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.MVC.Models
{
    public class AffiliatedWithViewModel
    {
        public int PhysicianId { get; set; }
        
        public int DepartmentId { get; set; }

        public bool PrimaryAffiliation { get; set; }

        public Department Department { get; set; }

        public Physician Physician { get; set; }
        public string PhysicianName { get; internal set; }
        public string DepartmentName { get; internal set; }
    }
}