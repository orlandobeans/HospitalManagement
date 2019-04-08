
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HMS.Core;
using Newtonsoft.Json;
using Service.AffiliatedWithService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class AffiliatedWithController : Controller
    {
        private readonly IAffiliatedWithService _repository;

        public AffiliatedWithController(IAffiliatedWithService repository)
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
            loadOptions.PrimaryKey = new[] { "Physician", "Department" };

            var affiliatedWithsQuery = from p in _repository.GetAffiliatedWiths()
                                  select new
                                  {
                                      p.Physician,
                                      p.Department,
                                      p.PrimaryAffiliation
                                  };

            var loadResult = DataSourceLoader.Load(affiliatedWithsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var affiliatedWith = _repository.Find(keyObj.Physician, keyObj.Department);
            affiliatedWith.UpdatedDate = DateTime.Now;

            JsonConvert.PopulateObject(values, affiliatedWith);

            if (!TryValidateModel(affiliatedWith))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateAffiliatedWith(affiliatedWith);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var affiliatedWith = new Affiliated_With();
            affiliatedWith.CreatedDate = DateTime.Now;

            JsonConvert.PopulateObject(values, affiliatedWith);

            if (!TryValidateModel(affiliatedWith))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertAffiliatedWith(affiliatedWith);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteAffiliatedWith(key);

            return new EmptyResult();
        }
    }

 
}