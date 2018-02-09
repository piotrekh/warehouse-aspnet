using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class ProductConfig : EntityConfigurationBase<Product>
    {
        public override void Configure(EntityTypeConfiguration<Product> builder)
        {
            builder.ToTable("Product", "dbo");
        }
    }
}
