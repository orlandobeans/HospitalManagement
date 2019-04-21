using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Web.Models
{
    public class AffiliatedWithViewModel
    {
        public int PhysicianId { get; set; }
        
        public int DepartmentId { get; set; }

        public bool PrimaryAffiliation { get; set; }

        public virtual Department Department1 { get; set; }

        public virtual Physician Physician1 { get; set; }
        public object PhysicianName { get; internal set; }
        public string DepartmentName { get; internal set; }
    }
}
