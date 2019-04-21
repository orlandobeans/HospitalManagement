

using HMS.Core;
using Newtonsoft.Json;


using Service.MedicationService;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly IMedicationService _repository;

        public MedicationsController(IMedicationService repository)
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
            loadOptions.PrimaryKey = new[] { "Code" };

            var medicationsQuery = from p in _repository.GetMedications()
                                   select new
                                   {
                                       p.Code,
                                       p.Name,
                                       p.Brand,
                                       p.Description
                                   };

            var loadResult = DataSourceLoader.Load(medicationsQuery, loadOptions);
            return Content(JsonConvert.SerializeObject(loadResult), "application/json");
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var medication = _repository.GetMedication(key);
            JsonConvert.PopulateObject(values, medication);

            if (!TryValidateModel(medication))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }
            _repository.UpdateMedication(medication);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Post(string values)
        {
            var medication = new Medication();
            JsonConvert.PopulateObject(values, medication);

            if (!TryValidateModel(medication))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ValidationErrorMessage);
            }

            _repository.InsertMedication(medication);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteMedication(key);

            return new EmptyResult();
        }
    }
}
