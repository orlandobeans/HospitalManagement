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
using Newtonsoft.Json;
using DevExtreme.AspNet.Data;

using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using Service.PhysicianService;

namespace EntityFramework_CodeFirst.Controllers
{
    public class PhysiciansController : Controller
    {
        private readonly IPhysicianService _repository;

        public PhysiciansController(IPhysicianService repository)
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
            loadOptions.PrimaryKey = new[] { "EmployeeId" };

            var physiciansQuery = from p in _repository.GetPhysicians()
                                  select new
                                {
                                    p.EmployeeId,
                                    p.Name,
                                    p.Position,
                                    p.SSN
                                };

            var loadResult = DataSourceLoader.Load(physiciansQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var physician = _repository.GetPhysician(key);
            JsonConvert.PopulateObject(values, physician);

            if (!TryValidateModel(physician))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdatePhysician(physician);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var physician = new Physician();
            JsonConvert.PopulateObject(values, physician);

            if (!TryValidateModel(physician))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertPhysician(physician);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeletePhysician(key);

            return new EmptyResult();
        }

    }
}
