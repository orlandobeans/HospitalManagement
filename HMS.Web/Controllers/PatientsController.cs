



using HMS.Core;
using Newtonsoft.Json;
using Service.PatientService;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _repository;

        public PatientsController(IPatientService repository)
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
            loadOptions.PrimaryKey = new[] { "SSN" };

            var patientsQuery = from p in _repository.GetPatients()
                                select new
                                {
                                    p.SSN,
                                    p.Name,
                                    p.Address,
                                    p.Phone,
                                    p.InsuranceId,
                                    p.PCP
                                };

            var loadResult = DataSourceLoader.Load(patientsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var patient = _repository.GetPatient(key);
            JsonConvert.PopulateObject(values, patient);

            if (!TryValidateModel(patient))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.UpdatePatient(patient);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var patient = new Patient();
            JsonConvert.PopulateObject(values, patient);

            if (!TryValidateModel(patient))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertPatient(patient);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeletePatient(key);

            return new EmptyResult();
        }


    }
}
