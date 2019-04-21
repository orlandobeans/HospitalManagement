using Newtonsoft.Json;
using HMS.Service.AffiliatedWithService;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HMS.Core;
using HMS.MVC.Models;
using System.Collections;
using System.Collections.Generic;
using Syncfusion.EJ2.Base;
using AutoMapper;
using System.Web.Http;

namespace HMS.Web.Controllers
{
    public class AffiliatedWithController : Controller
    {
        private readonly IAffiliatedWithService _repository;

        public AffiliatedWithController(IAffiliatedWithService repository)
        {
            _repository = repository;
        }
        const string ValidationErrorMessage = "The record cannot be saved due to a validation error";

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Get(DataManagerRequest dm)
        {
            var DataSource = _repository.GetAffiliatedWiths()
                .Select(x => new AffiliatedWithViewModel
                {
                    PhysicianId = x.Physician,
                    PhysicianName = x.Physician1.Name,
                    DepartmentName = x.Department1.Name,
                    DepartmentId = x.Department,
                    PrimaryAffiliation = x.PrimaryAffiliation

                });

            DataOperations operation = new DataOperations();
            List<string> str = new List<string>();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<AffiliatedWithViewModel>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }

            ViewBag.physician = DataSource;
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);

        }

        
        public ActionResult Insert(AffiliatedWithViewModel value)
        {
            var result = new Affiliated_With
            {
                Physician = value.PhysicianId,
                Department = value.DepartmentId,
                PrimaryAffiliation = value.PrimaryAffiliation
            };

            _repository.InsertAffiliatedWith(result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Update(AffiliatedWithViewModel value)
        {
            var result = new Affiliated_With
            {
                Physician = value.PhysicianId,
                Physician1 = value.Physician,
                Department = value.DepartmentId,  
                Department1 = value.Department,
                PrimaryAffiliation = value.PrimaryAffiliation
            };

            _repository.UpdateAffiliatedWith(result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Delete(int key)
        {
            _repository.DeleteAffiliatedWith(key);
            return new EmptyResult();
        }
        
    }
    public class EditParams
    {
        //Paging Params
        public int skip { get; set; }
        public int take { get; set; }

        //Grid Action Params
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public Affiliated_With value { get; set; }

        //Batch Edit Params
        public IEnumerable<Affiliated_With> added { get; set; }
        public IEnumerable<Affiliated_With> changed { get; set; }
        public IEnumerable<Affiliated_With> deleted { get; set; }
    }

}