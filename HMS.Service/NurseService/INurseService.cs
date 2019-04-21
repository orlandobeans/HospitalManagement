using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.NurseService
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
