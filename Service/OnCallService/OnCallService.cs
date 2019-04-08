using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core;
using HMS.Infrastructure.Repository;
using Service.OnCallService;

namespace Service.On_CallService
{
    public class OnCallService : IOnCallService
    {
        private IRepository<On_Call> _onCallRepository;

        public OnCallService(IRepository<On_Call> onCallRepository)
        {
            _onCallRepository = onCallRepository;
        }

        public void DeleteOnCall(long id)
        {
            _onCallRepository.Delete(id);
        }

        public On_Call Find(params object[] keyValues)
        {
            return _onCallRepository.Find(keyValues);
        }

        public On_Call GetOnCall(long id)
        {
           return _onCallRepository.GetById(id);
        }

        public IEnumerable<On_Call> GetOnCalls()
        {
            return _onCallRepository.GetAll;
        }

        public void InsertOnCall(On_Call onCall)
        {
            _onCallRepository.Insert(onCall);
        }

        public void UpdateOnCall(On_Call onCall)
        {
            _onCallRepository.Update(onCall);
        }
    }
}
