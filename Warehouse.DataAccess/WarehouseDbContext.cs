using System.Data.Common;
using System.Data.Entity;
using Warehouse.DataAccess.EFHelpers;
using Warehouse.DataAccess.Entities;
using Warehouse.DataAccess.EntitiesConfig;

namespace Warehouse.DataAccess
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<StockEvent> StockEvents { get; set; }

        public DbSet<StockSnapshot> StockSnapshots { get; set; }

        public DbSet<StockSnapshotProduct> StockSnapshotProducts { get; set; }

        public DbSet<Entities.Warehouse> Warehouses { get; set; }

        public WarehouseDbContext() :base("WarehouseDb")
        {
        }

        public WarehouseDbContext(DbConnection connection) : base(connection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration<Address, AddressConfig>();
            modelBuilder.AddConfiguration<Product, ProductConfig>();
            modelBuilder.AddConfiguration<StockEvent, StockEventConfig>();
            modelBuilder.AddConfiguration<StockSnapshot, StockSnapshotConfig>();
            modelBuilder.AddConfiguration<StockSnapshotProduct, StockSnapshotProductConfig>();
            modelBuilder.AddConfiguration<Entities.Warehouse, WarehouseConfig>();
        }        
    }
}
