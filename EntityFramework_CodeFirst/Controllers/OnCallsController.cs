
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.OnCallService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class OnCallsController : Controller
    {
        private readonly IOnCallService _repository;

        public OnCallsController(IOnCallService repository)
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
            loadOptions.PrimaryKey = new[] { "Nurse", "BlockFloor", "BlockCode", "Start", "End" };

            var onCallsQuery = from p in _repository.GetOnCalls()
                                       select new
                                       {
                                           p.Nurse,
                                           p.BlockFloor,
                                           p.BlockCode,
                                           p.Start,
                                           p.End
                                       };

            var loadResult = DataSourceLoader.Load(onCallsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var onCall = _repository.Find(keyObj.Nurse, keyObj.BlockFloor, keyObj.BlockCode, keyObj.Start, keyObj.End);
            JsonConvert.PopulateObject(values, onCall);

            if (!TryValidateModel(onCall))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateOnCall(onCall);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var onCall = new On_Call();
            JsonConvert.PopulateObject(values, onCall);

            if (!TryValidateModel(onCall))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertOnCall(onCall);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteOnCall(key);

            return new EmptyResult();
        }
    }
}