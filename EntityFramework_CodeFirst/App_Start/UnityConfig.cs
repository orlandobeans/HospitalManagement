
using EntityFramework_CodeFirst.Core; using EntityFramework_CodeFirst.Infrastructure.Repository;
using EntityFramework_CodeFirst.Infrastructure.Repository;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EntityFramework_CodeFirst
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
            container.RegisterType<IRepository<Patient>, Repository<Patient>>();
            container.RegisterType<IRepository<Physician>, Repository<Physician>>();
            container.RegisterType<IRepository<Medication>, Repository<Medication>>();
            container.RegisterType<IRepository<Appointment>, Repository<Appointment>>();
            container.RegisterType<IRepository<Department>, Repository<Department>>();
            container.RegisterType<IRepository<Nurse>, Repository<Nurse>>();
            container.RegisterType<IRepository<Prescribe>, Repository<Prescribe>>();
            container.RegisterType<IRepository<Affiliated_With>, Repository<Affiliated_With>>();
            container.RegisterType<IRepository<On_Call>, Repository<On_Call>>();
            container.RegisterType<IRepository<Block>, Repository<Block>>();
            container.RegisterType<IRepository<Procedure>, Repository<Procedure>>();
            container.RegisterType<IRepository<Room>, Repository<Room>>();
            container.RegisterType<IRepository<Stay>, Repository<Stay>>();
            container.RegisterType<IRepository<Trained_In>, Repository<Trained_In>>();
            container.RegisterType<IRepository<Undergo>, Repository<Undergo>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}