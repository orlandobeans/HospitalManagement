
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HMS.Core; using HMS.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.BlockService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class BlocksController : Controller
    {
        private readonly IBlockService _repository;

        public BlocksController(IBlockService repository)
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

            var blocksQuery = from p in _repository.GetBlocks()
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
            _repository.UpdateBlock(block);
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

            _repository.InsertBlock(block);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteBlock(key);

            return new EmptyResult();
        }
    }
}