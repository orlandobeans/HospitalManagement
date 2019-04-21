using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.PatientService
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(long id);
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(long id);
    }
}
