using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class StockSnapshotProductConfig : EntityConfigurationBase<StockSnapshotProduct>
    {
        public override void Configure(EntityTypeConfiguration<StockSnapshotProduct> builder)
        {
            builder.ToTable("StockSnapshotProduct", "dbo");

            builder.HasRequired(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
