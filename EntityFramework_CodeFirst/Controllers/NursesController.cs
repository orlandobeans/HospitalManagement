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
using Core.Repository;
using EntityFramework_CodeFirst.Core;

namespace EntityFramework_CodeFirst.Controllers
{
    public class NursesController : Controller
    {
        private readonly IRepository<Nurse> _repository;

        public NursesController(IRepository<Nurse> repository)
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

            var nursesQuery = from p in _repository.GetAll
                                   select new
                                   {
                                       p.EmployeeId,
                                       p.Name,
                                       p.Position,
                                       p.Registered,
                                       p.SSN
                                   };

            var loadResult = DataSourceLoader.Load(nursesQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var nurse = _repository.GetById(key);
            JsonConvert.PopulateObject(values, nurse);

            if (!TryValidateModel(nurse))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(nurse);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var nurse = new Nurse();
            JsonConvert.PopulateObject(values, nurse);

            if (!TryValidateModel(nurse))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.Insert(nurse);

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
