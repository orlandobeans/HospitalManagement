
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HMS.Core; using HMS.Infrastructure.Repository;
using Newtonsoft.Json;
using Service.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _repository;

        public RoomsController(IRoomService repository)
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
            loadOptions.PrimaryKey = new[] { "Number" };

            var roomsQuery = from p in _repository.GetRooms()
                                  select new
                                  {
                                      p.Number,
                                      p.Type,
                                      p.BlockFloor,
                                      p.BlockCode,
                                      p.Unavailable
                                  };

            var loadResult = DataSourceLoader.Load(roomsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

       

        [HttpPut]
        public ActionResult Put(string key, string values)
        {            
            var room = _repository.Find(key);
            JsonConvert.PopulateObject(values, room);

            if (!TryValidateModel(room))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateRoom(room);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var room = new Room();
            JsonConvert.PopulateObject(values, room);

            if (!TryValidateModel(room))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertRoom(room);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteRoom(key);

            return new EmptyResult();
        }
    }
}