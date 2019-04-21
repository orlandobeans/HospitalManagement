using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.AppointmentService
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
