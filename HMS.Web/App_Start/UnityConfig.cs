using HMS.Service.AffiliatedWithService;
using HMS.Service.AppointmentService;
using HMS.Service.BlockService;
using HMS.Service.DepartmentService;
using HMS.Service.MedicationService;
using HMS.Service.NurseService;
using HMS.Service.OnCallService;
using HMS.Service.PatientService;
using HMS.Service.PhysicianService;
using HMS.Service.PresrcibeService;
using HMS.Service.ProcedureService;
using HMS.Service.RoomService;
using HMS.Service.StayService;
using HMS.Service.TrainedInService;
using HMS.Service.UnderGoesService;
using Infrastructure.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HMS.Web.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IPhysicianService, PhysicianService>();
            container.RegisterType<IMedicationService, MedicationService>();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<INurseService, NurseService>();
            container.RegisterType<IPrescribeService, PrescribeService>();
            container.RegisterType<IAffiliatedWithService, AffiliatedWithService>();
            container.RegisterType<IOnCallService, OnCallService>();
            container.RegisterType<IBlockService, BlockService>();
            container.RegisterType<IProcedureService, ProcedureService>();
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<IStayService, StayService>();
            container.RegisterType<ITrainedInService, TrainedInService>();
            container.RegisterType<IUndergoService, UndergoService>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}