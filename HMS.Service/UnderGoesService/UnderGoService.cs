using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.UnderGoesService
{
    public class UndergoService : IUndergoService
    {
        private IRepository<Undergo> _undergoRepository;

        public UndergoService(IRepository<Undergo> undergoRepository)
        {
            _undergoRepository = undergoRepository;
        }

        public void DeleteUndergo(long id)
        {
            _undergoRepository.Delete(id);
        }

        public Undergo Find(params object[] keyValues)
        {
            return _undergoRepository.Find(keyValues);
        }

        public Undergo GetUndergo(long id)
        {
            return _undergoRepository.GetById(id);
        }

        public IEnumerable<Undergo> GetUndergos()
        {
            return _undergoRepository.GetAll;
        }

        public void InsertUndergo(Undergo undergo)
        {
            _undergoRepository.Insert(undergo);
        }

        public void UpdateUndergo(Undergo undergo)
        {
            _undergoRepository.Update(undergo);
        }
    }
}
