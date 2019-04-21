using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.MedicationService
{
    public interface IMedicationService
    {
        IEnumerable<Medication> GetMedications();
        Medication GetMedication(long id);
        void InsertMedication(Medication medication);
        void UpdateMedication(Medication medication);
        void DeleteMedication(long id);
    }
}
