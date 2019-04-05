using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AffiliatedWithService
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
