

using HMS.Core;
using Newtonsoft.Json;


using Service.NurseService;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class NursesController : Controller
    {
        private readonly INurseService _repository;

        public NursesController(INurseService repository)
        {
            _repository = repository;
        }
        const string ValidationErrorMessage = "The record cannot be saved due to a validation error";



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            loadOptions.PrimaryKey = new[] { "EmployeeId" };

            var nursesQuery = from p in _repository.GetNurses()
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
            var nurse = _repository.GetNurse(key);
            JsonConvert.PopulateObject(values, nurse);

            if (!TryValidateModel(nurse))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateNurse(nurse);
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

            _repository.InsertNurse(nurse);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteNurse(key);

            return new EmptyResult();
        }

    }
}
