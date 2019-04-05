using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UndergoService
{
   public interface IUndergoService
    {
        IEnumerable<Undergo> GetUndergos();
        Undergo GetUndergo(long id);
        void InsertUndergo(Undergo stay);
        void UpdateUndergo(Undergo stay);
        void DeleteUndergo(long id);
        Undergo Find(params object[] keyValues);
    }
}
