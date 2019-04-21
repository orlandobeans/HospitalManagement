using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.UnderGoesService
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
