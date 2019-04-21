using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private IRepository<Appointment> _appointmentRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void DeleteAppointment(long id)
        {
            _appointmentRepository.Delete(id);
        }

        public Appointment GetAppointment(long id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepository.GetAll;
        }

        public void InsertAppointment(Appointment appointment)
        {
            _appointmentRepository.Insert(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }
    }
}
