using MediatR;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Warehouses.Models;

namespace Warehouse.Domain.Warehouses.Queries
{
    public class GetWarehouseStockEvents : IRequest<ItemsResult<StockEvent>>
    {
        public int WarehouseId { get; set; }
    }
}
