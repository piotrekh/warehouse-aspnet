using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class WarehouseConfig : EntityConfigurationBase<Entities.Warehouse>
    {
        public override void Configure(EntityTypeConfiguration<Entities.Warehouse> builder)
        {
            builder.ToTable("Warehouse", "dbo");

            builder.HasRequired(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);
        }
    }
}
