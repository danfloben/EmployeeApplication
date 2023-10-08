using EmployeeApplication.Business.Interface;
using EmployeeApplication.Business;
using System.Web.Http;
using Unity;
using EmployeeApplication.Models;

namespace EmployeeApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeServices, EmployeeServices>();
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                 new { id = RouteParameter.Optional }
            );
        }
    }
}