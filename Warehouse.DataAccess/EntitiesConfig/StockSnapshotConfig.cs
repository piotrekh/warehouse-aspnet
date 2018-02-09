using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class StockSnapshotConfig : EntityConfigurationBase<StockSnapshot>
    {
        public override void Configure(EntityTypeConfiguration<StockSnapshot> builder)
        {
            builder.ToTable("StockSnapshot", "dbo");

            builder.HasRequired(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId);

            builder.HasMany(x => x.Products)
                .WithRequired(y => y.Snapshot)
                .HasForeignKey(x => x.StockSnapshotId);
        }
    }
}
