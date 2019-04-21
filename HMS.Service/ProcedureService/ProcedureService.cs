using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.ProcedureService
{
    public class ProcedureService : IProcedureService
    {
        private IRepository<Procedure> _procedureRepository;

        public ProcedureService(IRepository<Procedure> procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public void DeleteProcedure(long id)
        {
            _procedureRepository.Delete(id);
        }

        public Procedure Find(params object[] keyValues)
        {
            return _procedureRepository.Find(keyValues);
        }

        public Procedure GetProcedure(long id)
        {
            return _procedureRepository.GetById(id);
        }

        public IEnumerable<Procedure> GetProcedures()
        {
            return _procedureRepository.GetAll;
        }

        public void InsertProcedure(Procedure procedure)
        {
            _procedureRepository.Insert(procedure);
        }

        public void UpdateProcedure(Procedure procedure)
        {
            _procedureRepository.Update(procedure);
        }
    }
}
