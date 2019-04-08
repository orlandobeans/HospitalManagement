
using HMS.Core;
using HMS.Infrastructure.Repository;
using Service.Affiliated_WithService;
using Service.AffiliatedWithService;
using Service.AppointmentService;
using Service.BlockService;
using Service.DepartmentService;
using Service.MedicationService;
using Service.NurseService;
using Service.On_CallService;
using Service.OnCallService;
using Service.PatientService;
using Service.PhysicianService;
using Service.PrescribeService;
using Service.ProcedureService;
using Service.RoomService;
using Service.StayService;
using Service.TrainedInService;
using Service.UndergoService;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HMS
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
            container.RegisterType<IMedicationService, MedicationService> ();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<INurseService, NurseService>();
            container.RegisterType<IPrescribeService, PrescribeService>();
            container.RegisterType<IAffiliatedWithService, AffiliatedWithService>();
            container.RegisterType<IOnCallService, OnCallService>();
            container.RegisterType<IBlockService, BlockService>();
            container.RegisterType<IProcedureService, ProcedureService> ();
            container.RegisterType<IRoomService, RoomService> ();
            container.RegisterType<IStayService, StayService> ();
            container.RegisterType<ITrainedInService, TrainedInService> ();
            container.RegisterType<IUndergoService, UndergoService> ();
            container.RegisterType(typeof(IRepository<>),typeof(Repository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}