using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StayService
{
   public interface IStayService
    {
        IEnumerable<Stay> GetStays();
        Stay GetStay(long id);
        void InsertStay(Stay stay);
        void UpdateStay(Stay stay);
        void DeleteStay(long id);
        Stay Find(params object[] keyValues);
    }
}
