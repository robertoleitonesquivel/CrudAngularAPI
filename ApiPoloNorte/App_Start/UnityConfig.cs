using ApiPoloNorte.IRepostory;
using ApiPoloNorte.IService;
using ApiPoloNorte.Repository;
using ApiPoloNorte.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ApiPoloNorte
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<IClienteService, ClienteService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}