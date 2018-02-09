using Autofac;
using AutoMapper;
using System.Reflection;

namespace Warehouse.Api.App_Start
{
    public class AutomapperConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            var config = CreateConfiguration();
            builder.RegisterInstance(config)
                .AsSelf()
                .SingleInstance();
            builder.Register<Mapper>(ctx => new Mapper(ctx.Resolve<MapperConfiguration>(), type => ctx.Resolve(type)))
                .As<IMapper>()
                .InstancePerRequest();
        }

        private static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in domain assembly
                cfg.AddProfiles(Assembly.GetAssembly(typeof(Domain.Warehouses.Models.Mapping)));
            });

            return config;
        }
    }
}