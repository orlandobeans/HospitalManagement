using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PrescribeService
{
   public interface IPrescribeService
    {
        IEnumerable<Prescribe> GetPrescribes();
        Prescribe GetPrescribe(long id);
        void InsertPrescribe(Prescribe prescribe);
        void UpdatePrescribe(Prescribe prescribe);
        void DeletePrescribe(long id);
        Prescribe Find(params object[] keyValues);
    }
}
