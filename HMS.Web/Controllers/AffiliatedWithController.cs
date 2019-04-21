using HMS.Core.Domain;
using HMS.Service.AffiliatedWithService;
using HMS.Service.DepartmentService;
using HMS.Service.PhysicianService;
using HMS.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class AffiliatedWithController : Controller
    {
        private readonly IAffiliatedWithService _repository;
        private readonly IDepartmentService _departmentService;
        private readonly IPhysicianService _physicianService;

        public AffiliatedWithController(IAffiliatedWithService repository, 
                                        IDepartmentService departmentService,
                                        IPhysicianService physicianService)
        {
            _repository = repository;
            _departmentService = departmentService;
            _physicianService = physicianService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var results = _repository.GetAffiliatedWiths().Select(x => new AffiliatedWithViewModel
            {
                PhysicianId = x.Physician,
                DepartmentId = x.Department,
                PhysicianName = x.Physician1.Name,
                DepartmentName = x.Department1.Name,
                PrimaryAffiliation = x.PrimaryAffiliation
            });

            return new JsonResult { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: /Patients/Save
        [HttpGet]
        [Route("{PhysicianId},{DepartmentId}")]
        public ActionResult AddOrEdit(int? PhysicianId, int? DepartmentId)
        {
            ViewBag.Department = _departmentService.GetDepartments().ToList();
            ViewBag.Physicians = _physicianService.GetPhysicians().ToList();

            var param = new object[] { PhysicianId, DepartmentId };
            var result = _repository.Find(param);

            if (param == null || result == null)
            {
                return View(new AffiliatedWithViewModel());
            }
          
            var viewModel = new AffiliatedWithViewModel
            {
                PhysicianId = result.Physician,
                DepartmentId = result.Department,
                PrimaryAffiliation = result.PrimaryAffiliation
            };

            return View(viewModel);

        }
           
        // POST: /Patients/Save
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(AffiliatedWithViewModel requestView)
        {
            ViewBag.Department = _departmentService.GetDepartments().ToList();
            ViewBag.Physicians = _physicianService.GetPhysicians().ToList();
            if (ModelState.IsValid)
            {
                var param = new object[] { requestView.PhysicianId, requestView.DepartmentId };
                var result = _repository.Find(param);
                var model = new Affiliated_With();

                
                if (result == null)
                {
                    model.Physician = requestView.PhysicianId;
                    model.Department = requestView.DepartmentId;
                    model.PrimaryAffiliation = requestView.PrimaryAffiliation;

                    _repository.InsertAffiliatedWith(model);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.PrimaryAffiliation = requestView.PrimaryAffiliation;

                    _repository.UpdateAffiliatedWith(result);
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }

                
                
            }

            return Json(new { success = false, message = "There was an error saving record" + requestView.PhysicianName + ", please try again." }, JsonRequestBehavior.AllowGet);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _repository.GetAffiliatedWith(id.Value);

            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            _repository.DeleteAffiliatedWith(id);
            return RedirectToAction("Index");
        }

    }


}