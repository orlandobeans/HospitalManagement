using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProcedureService
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
