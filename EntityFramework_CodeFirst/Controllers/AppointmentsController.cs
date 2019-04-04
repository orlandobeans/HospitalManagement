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
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace EntityFramework_CodeFirst.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IRepository<Appointment> _repository;

        public AppointmentsController(IRepository<Appointment> repository)
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

            var appointmentsQuery = from p in _repository.GetAll
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
            var appointment = _repository.GetById(key);
            JsonConvert.PopulateObject(values, appointment);

            if (!TryValidateModel(appointment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(appointment);
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

            _repository.Insert(appointment);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.Delete(key);

            return new EmptyResult();
        }
    }
}
