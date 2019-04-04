
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework_CodeFirst.Controllers
{
    public class BlocksController : Controller
    {
        private readonly IRepository<Block> _repository;

        public BlocksController(IRepository<Block> repository)
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
            loadOptions.PrimaryKey = new[] { "Floor", "Code" };

            var blocksQuery = from p in _repository.GetAll
                                       select new
                                       {
                                           p.Floor,
                                           p.Code
                                       };

            var loadResult = DataSourceLoader.Load(blocksQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(string key, string values)
        {

            var keyObj = JsonConvert.DeserializeObject<CompositeKey>(key);
            var block = _repository.Find(keyObj.BlockFloor, keyObj.BlockCode);
            JsonConvert.PopulateObject(values, block);

            if (!TryValidateModel(block))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.Update(block);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var block = new Block();
            JsonConvert.PopulateObject(values, block);

            if (!TryValidateModel(block))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.Insert(block);

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