using AutoMapper;
using System.Reflection;

namespace Warehouse.UnitTests.TestDoubles
{
    public static class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                // Add all profiles in domain assembly
                cfg.AddProfiles(Assembly.GetAssembly(typeof(Domain.Warehouses.Models.Mapping)));
            });

            return mapperConfig.CreateMapper();
        }
    }
}
