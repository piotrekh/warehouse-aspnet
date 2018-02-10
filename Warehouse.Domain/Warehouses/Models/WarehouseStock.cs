using System.Collections.Generic;

namespace Warehouse.Domain.Warehouses.Models
{
    public class WarehouseStock
    {
        public int MaxSize { get; set; }

        public int FreeSpace { get; set; }

        public List<Stock> CurrentStock { get; set; }
    }
}
