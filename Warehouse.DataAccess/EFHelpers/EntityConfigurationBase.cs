using System.Data.Entity.ModelConfiguration;

namespace Warehouse.DataAccess.EFHelpers
{
    internal abstract class EntityConfigurationBase<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeConfiguration<TEntity> builder);
    }
}
