using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace Service.NurseService
{
    public class NurseService : INurseService
    {
        private IRepository<Nurse> _nurseRepository;

        public NurseService(IRepository<Nurse> nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public void DeleteNurse(long id)
        {
            _nurseRepository.Delete(id);
        }

        public Nurse GetNurse(long id)
        {
           return _nurseRepository.GetById(id);
        }

        public IEnumerable<Nurse> GetNurses()
        {
            return _nurseRepository.GetAll;
        }

        public void InsertNurse(Nurse nurse)
        {
            _nurseRepository.Insert(nurse);
        }

        public void UpdateNurse(Nurse nurse)
        {
            _nurseRepository.Update(nurse);
        }
    }
}
