using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.PresrcibeService
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
