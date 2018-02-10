using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class StockEventConfig : EntityConfigurationBase<StockEvent>
    {
        public override void Configure(EntityTypeConfiguration<StockEvent> builder)
        {
            builder.ToTable("StockEvent", "dbo");

            builder.HasRequired(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId);

            builder.HasRequired(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
