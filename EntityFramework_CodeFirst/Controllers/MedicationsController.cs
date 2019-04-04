using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFramework_CodeFirst;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;

using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace EntityFramework_CodeFirst.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly IRepository<Medication> _repository;

        public MedicationsController(IRepository<Medication> repository)
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
            loadOptions.PrimaryKey = new[] { "Code" };

            var medicationsQuery = from p in _repository.GetAll
                                   select new
                              {
                                  p.Code,
                                  p.Name,
                                  p.Brand,
                                  p.Description
                              };

            var loadResult = DataSourceLoader.Load(medicationsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var medication = _repository.GetById(key);
            JsonConvert.PopulateObject(values, medication);

            if (!TryValidateModel(medication))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(medication);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var medication = new Medication();
            JsonConvert.PopulateObject(values, medication);

            if (!TryValidateModel(medication))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.Insert(medication);

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
