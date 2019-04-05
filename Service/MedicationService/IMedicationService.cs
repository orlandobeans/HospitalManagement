using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MedicationService
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
