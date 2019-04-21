using HMS.Core.Domain;
using Infrastructure.Repository;
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
            ChartData(_repository.GetAll.ToList());
            return View();
        }


        public ActionResult ChartData(List<Appointment> d)
        {
            //var appointments = d as Appointment[] ?? d.ToArray();
            var month = from item in d
                        where item.EndDateDate.Year == DateTime.Today.Year
                        orderby item.EndDateDate
                        group item by new { month = item.EndDateDate.Month } into g
                        select new
                        {
                            Month = g.Key.month,
                            Count = g.Count()
                        };
            var currentMonth = from item in d
                               where item.EndDateDate.Month == DateTime.Today.Month && item.EndDateDate.Year == DateTime.Today.Year
                               select new
                               {
                                   AppointmentMonth = item.AppointmentId
                               };

            var currentDay = from item in d
                             where item.EndDateDate.Day == DateTime.Today.Day &&
                                  item.EndDateDate.Month == DateTime.Today.Month &&
                                  item.EndDateDate.Year == DateTime.Today.Year
                             select new
                             {
                                 AppointmentToday = item.AppointmentId
                             };


            var patient = from item in d
                          where item.EndDateDate.Year == DateTime.Today.Year
                          select new
                          {
                              AppointmentYear = item.AppointmentId
                          };

            ViewBag.ChartData = month.Select(x => new int[] { x.Month, x.Count });
            ViewBag.AppointmentCount = patient.Select(x => new { x.AppointmentYear }).Count();
            ViewBag.AppointmentYearlyPercent = Convert.ToDouble(patient.Select(x => new { x.AppointmentYear }).Count() / (500.00 * 12) * (100.00)).ToString("0.##");
            ViewBag.AppointmentMonthCount = currentMonth.Select(x => new { x.AppointmentMonth }).Count();
            ViewBag.PercentageMonthly = Convert.ToDouble(currentMonth.Select(x => new { x.AppointmentMonth }).Count() / 500.00 * (100.00)).ToString("0.##");
            ViewBag.AppointmentDayCount = currentDay.Select(x => new { x.AppointmentToday }).Count();

            return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

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