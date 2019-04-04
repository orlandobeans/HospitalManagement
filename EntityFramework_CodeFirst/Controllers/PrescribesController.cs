using Core.Repository;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class PrescribesController : Controller
    {
        private readonly IRepository<Prescribe> _repository;

        public PrescribesController(IRepository<Prescribe> repository)
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
            loadOptions.PrimaryKey = new[] { "Physician", "Patient","Medication","Date"};

            var prescribesQuery = from p in _repository.GetAll
                                    select new
                                    {
                                        p.Physician,
                                        p.Patient,
                                        p.Medication,
                                        p.Date,
                                        p.Appointment,
                                        p.Dose
                                    };

            var loadResult = DataSourceLoader.Load(prescribesQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var prescribe = _repository.Find(keyObj.Physician,keyObj.Patient, keyObj.Medication, keyObj.Date);
            JsonConvert.PopulateObject(values, prescribe);

            if (!TryValidateModel(prescribe))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(prescribe);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var prescribe = new Prescribe();
            JsonConvert.PopulateObject(values, prescribe);

            if (!TryValidateModel(prescribe))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.Insert(prescribe);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.Delete(key);

            return new EmptyResult();
        }
    }

    internal class CompositeKey
    {
        public int Physician { get; set; }
        public int Patient { get; set; }
        public int Medication { get; set; }
        public int Treatment { get; set; }
        public int Procedure { get; set; }
        public int Stay { get; set; }
        public int Department { get; set; }
        public DateTime Date { get; set; }
        public int Nurse { get; set; }
        public int BlockFloor { get; set; }
        public int BlockCode { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}