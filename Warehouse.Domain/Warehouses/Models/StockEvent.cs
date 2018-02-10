using System;
using Warehouse.Domain.Products.Models;

namespace Warehouse.Domain.Warehouses.Models
{
    public class StockEvent
    {
        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public int ProductAmount { get; set; }
        
        public Product Product { get; set; }
    }
}
