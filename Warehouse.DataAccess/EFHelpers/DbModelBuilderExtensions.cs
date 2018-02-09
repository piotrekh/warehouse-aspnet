using System;
using System.Data.Entity;

namespace Warehouse.DataAccess.EFHelpers
{
    internal static class DbModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity, TConfig>(this DbModelBuilder modelBuilder)
            where TEntity : class
            where TConfig : EntityConfigurationBase<TEntity>
        {
            TConfig config = Activator.CreateInstance<TConfig>();
            var entityConfigBuilder = modelBuilder.Entity<TEntity>();
            config.Configure(entityConfigBuilder);
        }
    }
}
