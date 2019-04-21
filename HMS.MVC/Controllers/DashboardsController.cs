using HMS.Core;
using HMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly IRepository<Appointment> _repository;

        public DashboardsController(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public ActionResult Dashboard_1()
        {
            return View();
        }

        public ActionResult Dashboard_2()
        {
            //ChartData(_repository.GetAll.ToList());
            return View();
        }


        //public ActionResult ChartData(List<Appointment> d)
        //{
        //    //var appointments = d as Appointment[] ?? d.ToArray();
        //    var month = from item in d
        //                where item.EndDateDate.Year == DateTime.Today.Year
        //                orderby item.EndDateDate
        //                group item by new { month = item.EndDateDate.Month } into g                          
        //                select new
        //        {
        //            Month = g.Key.month,
        //            Count = g.Count()
        //        };
            

        //    ViewBag.ChartData =  month.Select(x => new int[]{x.Month, x.Count });
        //    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public ActionResult Dashboard_3()
        {
            return View();
        }
        
        public ActionResult Dashboard_4()
        {
            return View();
        }
        
        public ActionResult Dashboard_4_1()
        {
            return View();
        }

        public ActionResult Dashboard_5()
        {
            return View();
        }

    }
}