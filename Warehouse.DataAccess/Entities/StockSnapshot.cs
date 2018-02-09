using System;
using System.Collections.Generic;

namespace Warehouse.DataAccess.Entities
{
    public class StockSnapshot
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public DateTime SnapshotDate { get; set; }


        public Warehouse Warehouse { get; set; }

        public ICollection<StockSnapshotProduct> Products { get; set; }
    }
}
