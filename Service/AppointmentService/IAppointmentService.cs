using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AppointmentService
{
   public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointment(long id);
        void InsertAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(long id);
    }
}
