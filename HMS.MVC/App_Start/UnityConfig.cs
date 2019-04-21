using HMS.Infrastructure.Repository;
using HMS.Service.Affiliated_WithService;
using HMS.Service.AffiliatedWithService;
using HMS.Service.AppointmentService;
using HMS.Service.BlockService;
using HMS.Service.DepartmentService;
using HMS.Service.MedicationService;
using HMS.Service.NurseService;
using HMS.Service.On_CallService;
using HMS.Service.OnCallService;
using HMS.Service.PatientService;
using HMS.Service.PhysicianService;
using HMS.Service.PrescribeService;
using HMS.Service.ProcedureService;
using HMS.Service.RoomService;
using HMS.Service.StayService;
using HMS.Service.TrainedInService;
using HMS.Service.UndergoService;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace HMS.MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

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