using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core;
using HMS.Infrastructure.Repository;
using Service.AffiliatedWithService;

namespace Service.Affiliated_WithService
{
    public class AffiliatedWithService : IAffiliatedWithService
    {
        private IRepository<Affiliated_With> _affiliatedWithRepository;

        public AffiliatedWithService(IRepository<Affiliated_With> affiliatedWithRepository)
        {
            _affiliatedWithRepository = affiliatedWithRepository;
        }

        public void DeleteAffiliatedWith(long id)
        {
            _affiliatedWithRepository.Delete(id);
        }

        public Affiliated_With GetAffiliatedWith(long id)
        {
           return _affiliatedWithRepository.GetById(id);
        }

        public IEnumerable<Affiliated_With> GetAffiliatedWiths()
        {
            return _affiliatedWithRepository.GetAll;
        }

        public void InsertAffiliatedWith(Affiliated_With affiliatedWith)
        {
            _affiliatedWithRepository.Insert(affiliatedWith);
        }

        public void UpdateAffiliatedWith(Affiliated_With affiliatedWith)
        {
            _affiliatedWithRepository.Update(affiliatedWith);
        }

        public virtual Affiliated_With Find(params object[] keyValues)
        {
           return _affiliatedWithRepository.Find(keyValues);
        }
    }
}
