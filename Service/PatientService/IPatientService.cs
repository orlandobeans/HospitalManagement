using HMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
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
