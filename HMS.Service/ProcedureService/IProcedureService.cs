using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.ProcedureService
{
    public interface IProcedureService
    {
        IEnumerable<Procedure> GetProcedures();
        Procedure GetProcedure(long id);
        void InsertProcedure(Procedure procedure);
        void UpdateProcedure(Procedure procedure);
        void DeleteProcedure(long id);
        Procedure Find(params object[] keyValues);
    }
}
