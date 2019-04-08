
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HMS.Core; using HMS.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.ProcedureService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class ProceduresController : Controller
    {
        private readonly IProcedureService _repository;

        public ProceduresController(IProcedureService repository)
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
            loadOptions.PrimaryKey = new[] { "Code"};

            var proceduresQuery = from p in _repository.GetProcedures()
                                  select new
                                  {
                                      p.Code,
                                      p.Name,
                                      p.Cost
                                  };

            var loadResult = DataSourceLoader.Load(proceduresQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var procedure = _repository.Find(keyObj.Physician, keyObj.Patient, keyObj.Medication, keyObj.Date);
            JsonConvert.PopulateObject(values, procedure);

            if (!TryValidateModel(procedure))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateProcedure(procedure);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var procedure = new Procedure();
            JsonConvert.PopulateObject(values, procedure);

            if (!TryValidateModel(procedure))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertProcedure(procedure);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteProcedure(key);

            return new EmptyResult();
        }
    }
}