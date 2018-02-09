using Autofac;
using System.Linq;
using System.Reflection;
using Warehouse.DataAccess;
using Warehouse.Domain.Warehouses.Queries;

namespace Warehouse.Api.App_Start
{
    public class WarehouseDependencies
    {
        public static void Register(ContainerBuilder builder)
        {
            //dbcontext
            builder.RegisterType<WarehouseDbContext>()
                .AsSelf()
                .InstancePerRequest();

            //CQRS objects
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(GetAllWarehouses)))
                .Where(x => x.FullName.Contains("QueryHandlers")
                        || x.FullName.Contains("CommandHandlers"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}