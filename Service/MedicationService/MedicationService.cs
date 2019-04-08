using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core;
using HMS.Infrastructure.Repository;

namespace Service.MedicationService
{
    public class MedicationService : IMedicationService
    {
        private IRepository<Medication> _medicationRepository;

        public MedicationService(IRepository<Medication> medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public void DeleteMedication(long id)
        {
            _medicationRepository.Delete(id);
        }

        public Medication GetMedication(long id)
        {
           return _medicationRepository.GetById(id);
        }

        public IEnumerable<Medication> GetMedications()
        {
            return _medicationRepository.GetAll;
        }

        public void InsertMedication(Medication medication)
        {
            _medicationRepository.Insert(medication);
        }

        public void UpdateMedication(Medication medication)
        {
            _medicationRepository.Update(medication);
        }
    }
}
