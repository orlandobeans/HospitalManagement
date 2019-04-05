
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.StayService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class StaysController : Controller
    {
        private readonly IStayService _repository;

        public StaysController(IStayService repository)
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
            loadOptions.PrimaryKey = new[] { "StayId" };

            var staysQuery = from p in _repository.GetStays()
                                  select new
                                  {
                                      p.StayId,
                                      p.Patient,
                                      p.Room,
                                      p.Start,
                                      p.EndDateDate
                                  };

            var loadResult = DataSourceLoader.Load(staysQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {
            var stay = _repository.Find(key);
            JsonConvert.PopulateObject(values, stay);

            if (!TryValidateModel(stay))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateStay(stay);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var stay = new Stay();
            JsonConvert.PopulateObject(values, stay);

            if (!TryValidateModel(stay))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertStay(stay);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteStay(key);

            return new EmptyResult();
        }
    }
}