using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class WarehouseConfig : EntityConfigurationBase<Entities.Warehouse>
    {
        public override void Configure(EntityTypeConfiguration<Entities.Warehouse> builder)
        {
            builder.ToTable("Warehouse", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.HasRequired(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);
        }
    }
}
