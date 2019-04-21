

using HMS.Core;
using Newtonsoft.Json;


using Service.DepartmentService;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _repository;

        public DepartmentsController(IDepartmentService repository)
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
            loadOptions.PrimaryKey = new[] { "DepartmentId" };

            var departmentsQuery = from p in _repository.GetDepartments()
                                   select new
                                   {
                                       p.DepartmentId,
                                       p.Name,
                                       p.Head
                                   };

            var loadResult = DataSourceLoader.Load(departmentsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var department = _repository.GetDepartment(key);
            JsonConvert.PopulateObject(values, department);

            if (!TryValidateModel(department))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateDepartment(department);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var department = new Department();
            JsonConvert.PopulateObject(values, department);

            if (!TryValidateModel(department))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertDepartment(department);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteDepartment(key);

            return new EmptyResult();
        }


    }

}
