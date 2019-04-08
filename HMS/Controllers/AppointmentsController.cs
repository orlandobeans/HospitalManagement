using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using HMS.Core;
using HMS.Infrastructure.Repository;
using Service.AppointmentService;

namespace HMS.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _repository;

        public AppointmentsController(IAppointmentService repository)
        {
            _repository = repository;
        }
        const string ValidationErrorMessage = "The record cannot be saved due to a validation error";



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "AppointmentId" };

            var appointmentsQuery = from p in _repository.GetAppointments()
                              select new
                              {
                                  p.AppointmentId,
                                  p.Patient,
                                  p.PrepNurse,
                                  p.Physician,
                                  p.Start,
                                  p.EndDateDate,
                                  p.ExaminationRoom
                              };

            var loadResult = DataSourceLoader.Load(appointmentsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var appointment = _repository.GetAppointment(key);
            JsonConvert.PopulateObject(values, appointment);

            if (!TryValidateModel(appointment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateAppointment(appointment);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var appointment = new Appointment();
            JsonConvert.PopulateObject(values, appointment);

            if (!TryValidateModel(appointment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertAppointment(appointment);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteAppointment(key);

            return new EmptyResult();
        }
    }
}
