using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PhysicianService
{
   public interface IPhysicianService
    {
        IEnumerable<Physician> GetPhysicians();
        Physician GetPhysician(long id);
        void InsertPhysician(Physician physician);
        void UpdatePhysician(Physician physician);
        void DeletePhysician(long id);
    }
}
