using System;

namespace Warehouse.DataAccess.Entities
{
    public class StockEvent
    {
        public int Id { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }


        public Warehouse Warehouse { get; set; }

        public Product Product { get; set; }
    }
}
