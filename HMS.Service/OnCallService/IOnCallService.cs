using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.OnCallService
{
    public interface IOnCallService
    {
        IEnumerable<On_Call> GetOnCalls();
        On_Call GetOnCall(long id);
        void InsertOnCall(On_Call patient);
        void UpdateOnCall(On_Call patient);
        void DeleteOnCall(long id);
        On_Call Find(params object[] keyValues);
    }
}
