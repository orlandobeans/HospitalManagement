using HMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.NurseService
{
   public interface INurseService
    {
        IEnumerable<Nurse> GetNurses();
        Nurse GetNurse(long id);
        void InsertNurse(Nurse nurse);
        void UpdateNurse(Nurse nurse);
        void DeleteNurse(long id);
    }
}
