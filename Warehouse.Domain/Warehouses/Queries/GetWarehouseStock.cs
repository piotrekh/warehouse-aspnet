using MediatR;
using Warehouse.Domain.Warehouses.Models;

namespace Warehouse.Domain.Warehouses.Queries
{
    public class GetWarehouseStock : IRequest<WarehouseStock>
    {
        public int WarehouseId { get; set; }
    }
}
