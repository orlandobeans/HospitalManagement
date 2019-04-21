using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.StayService
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
