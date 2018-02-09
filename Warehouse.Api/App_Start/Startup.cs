using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(Warehouse.Api.App_Start.Startup))]
namespace Warehouse.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            WebApiConfig.Register(config);
            SwaggerConfig.Register(config);

            //------register autofac dependencies-------

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            MediatorConfig.Register(builder);
            AutomapperConfig.Register(builder);
            WarehouseDependencies.Register(builder);                      

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            //-------------------------------------------

            app.UseWebApi(config);
        }
    }
}
