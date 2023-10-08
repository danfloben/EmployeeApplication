using EmployeeApplication.Business;
using EmployeeApplication.Business.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EmployeeApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IEmployeeServices, EmployeeServices>();
        }
    }
}