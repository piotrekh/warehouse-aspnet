using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;

namespace Warehouse.DataAccess.EntitiesConfig
{
    internal class AddressConfig : EntityConfigurationBase<Address>
    {
        public override void Configure(EntityTypeConfiguration<Address> builder)
        {
            builder.ToTable("Address", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
