using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Kosmos.ProcesserServer.DbContext;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Kosmos.ProcesserServer
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AppDbContext>().SingleInstance();
            builder.RegisterType<HttpClient>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}