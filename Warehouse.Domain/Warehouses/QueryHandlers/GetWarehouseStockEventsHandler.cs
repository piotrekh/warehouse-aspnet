using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Warehouses.Models;
using Warehouse.Domain.Warehouses.Queries;

namespace Warehouse.Domain.Warehouses.QueryHandlers
{
    public class GetWarehouseStockEventsHandler : IRequestHandler<GetWarehouseStockEvents, ItemsResult<StockEvent>>
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWarehouseStockEventsHandler(WarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ItemsResult<StockEvent>> Handle(GetWarehouseStockEvents request, CancellationToken cancellationToken)
        {
            var entities = _dbContext.StockEvents.Where(x => x.WarehouseId == request.WarehouseId)
                .Include(x => x.Product)
                .OrderByDescending(x => x.EventDate)
                .ToList();
            var stockEvents = _mapper.Map<List<StockEvent>>(entities);
            var result = new ItemsResult<StockEvent>() { Items = stockEvents };
            return Task.FromResult(result);
        }
    }
}
