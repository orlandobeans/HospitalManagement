﻿using Core.Repository;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class UndergoesController : Controller
    {
        private readonly IRepository<Undergo> _repository;

        public UndergoesController(IRepository<Undergo> repository)
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
            loadOptions.PrimaryKey = new[] { "Patient", "Procedure", "Stay","Date" };

            var undergoesQuery = from p in _repository.GetAll
                              select new
                              {
                                  p.Patient,
                                  p.Procedure,
                                  p.Stay,
                                  p.Date,
                                  p.Physician,
                                  p.AssistingNurse
                              };

            var loadResult = DataSourceLoader.Load(undergoesQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var undergo = _repository.Find(keyObj.Patient, keyObj.Procedure, keyObj.Stay, keyObj.Date);
            JsonConvert.PopulateObject(values, undergo);

            if (!TryValidateModel(undergo))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(undergo);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var undergoe = new Undergo();
            JsonConvert.PopulateObject(values, undergoe);

            if (!TryValidateModel(undergoe))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.Insert(undergoe);

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