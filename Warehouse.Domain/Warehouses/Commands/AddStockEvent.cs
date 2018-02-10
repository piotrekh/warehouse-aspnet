using MediatR;
using System;

namespace Warehouse.Domain.Warehouses.Commands
{
    public class AddStockEvent : IRequest
    {
        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public int ProductAmount { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }
    }
}
