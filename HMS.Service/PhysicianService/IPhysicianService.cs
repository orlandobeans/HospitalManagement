using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.PhysicianService
{
    public interface IPhysicianService
    {
        IEnumerable<Physician> GetPhysicians();
        Physician GetPhysician(long id);
        void InsertPhysician(Physician physician);
        void UpdatePhysician(Physician physician);
        void DeletePhysician(long id);
    }
}
