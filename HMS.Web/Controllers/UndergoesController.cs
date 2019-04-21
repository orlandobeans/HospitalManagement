




using HMS.Core;
using Newtonsoft.Json;
using Service.UndergoService;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UndergoesController : Controller
    {
        private readonly IUndergoService _repository;

        public UndergoesController(IUndergoService repository)
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
            loadOptions.PrimaryKey = new[] { "Patient", "Procedure", "Stay", "Date" };

            var undergoesQuery = from p in _repository.GetUndergos()
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
            _repository.UpdateUndergo(undergo);
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

            _repository.InsertUndergo(undergoe);

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int key)
        {
            _repository.DeleteUndergo(key);

            return new EmptyResult();
        }
    }
}