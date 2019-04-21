using HMS.Service.AppointmentService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Web.Controllers.Tests
{
    [TestClass()]
    public class AppointmentsControllerTests
    {
        private readonly IAppointmentService _appointmentsService;
        public AppointmentsControllerTests(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }
        [TestMethod()]
        public void GetTest()
        {
            var r = _appointmentsService.GetAppointments();

            Assert.Fail();
        }
    }
}