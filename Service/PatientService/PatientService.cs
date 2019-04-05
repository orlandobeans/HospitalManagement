using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace Service.PatientService
{
    public class PatientService : IPatientService
    {
        private IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void DeletePatient(long id)
        {
            _patientRepository.Delete(id);
        }

        public Patient GetPatient(long id)
        {
           return _patientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _patientRepository.GetAll;
        }

        public void InsertPatient(Patient patient)
        {
            _patientRepository.Insert(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            _patientRepository.Update(patient);
        }
    }
}
