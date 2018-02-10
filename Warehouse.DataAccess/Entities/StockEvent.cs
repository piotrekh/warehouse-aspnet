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

	    public string ProductName { get; set; }

        public string ProductUnit { get; set; }

        public int ProductUnitSize { get; set; }

	    public bool ProductIsHazardous { get; set; }

        public int ProductAmount { get; set; }


        public Warehouse Warehouse { get; set; }
    }
}
