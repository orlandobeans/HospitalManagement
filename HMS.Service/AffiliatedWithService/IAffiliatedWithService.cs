using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.AffiliatedWithService
{
    public interface IAffiliatedWithService
    {
        IEnumerable<Affiliated_With> GetAffiliatedWiths();
        Affiliated_With GetAffiliatedWith(long id);
        void InsertAffiliatedWith(Affiliated_With patient);
        void UpdateAffiliatedWith(Affiliated_With patient);
        void DeleteAffiliatedWith(long id);

        Affiliated_With Find(params object[] keyValues);
    }
}
