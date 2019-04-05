
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.TrainedInService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class TrainedInsController : Controller
    {
        private readonly ITrainedInService _repository;

        public TrainedInsController(ITrainedInService repository)
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
            loadOptions.PrimaryKey = new[] { "Physician", "Treatment" };

            var trainedInsQuery = from p in _repository.GetTrainedIns()
                                  select new
                                  {
                                      p.Physician,
                                      p.Treatment,
                                      p.CertificationDate,
                                      p.CertificationExpires
                                  };

            var loadResult = DataSourceLoader.Load(trainedInsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var trainedIn = _repository.Find(keyObj.Physician, keyObj.Treatment);
            JsonConvert.PopulateObject(values, trainedIn);

            if (!TryValidateModel(trainedIn))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateTrainedIn(trainedIn);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var trainedIn = new Trained_In();
            JsonConvert.PopulateObject(values, trainedIn);

            if (!TryValidateModel(trainedIn))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertTrainedIn(trainedIn);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteTrainedIn(key);

            return new EmptyResult();
        }
    }
}