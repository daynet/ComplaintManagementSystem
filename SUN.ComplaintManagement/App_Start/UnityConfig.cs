using Authentication.Auth;
using cbt.Interface.CBT;
using cbt.repository.CBT;
using SUN.Business.Entity.Model;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SUN.ComplaintManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DataContext, DataContext>();
            container.RegisterType<IComplaintRepository, ComplaintRepository>();
            container.RegisterType<IComplaintResponseRepository, ComplaintResponseRepository>();
            container.RegisterType<IComplaintTypeRepository, ComplaintTypeRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<ILoginActivityRepository, LoginActivityRepository>();
            container.RegisterType<IRatingRepository, RatingRepository>();
            container.RegisterType<ISecurityManager, SecurityManager>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();



            // register all your components with the container here
            // it is NOT necessary to register your controllers




            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}