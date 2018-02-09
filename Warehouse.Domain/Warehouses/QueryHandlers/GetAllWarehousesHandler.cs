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
    public class GetAllWarehousesHandler : IRequestHandler<GetAllWarehouses, ItemsResult<WarehouseInfo>>
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllWarehousesHandler(WarehouseDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ItemsResult<WarehouseInfo>> Handle(GetAllWarehouses request, CancellationToken cancellationToken)
        {
            var entities = _dbContext.Warehouses
                .Include(x => x.Address)
                .ToList();

            var items = _mapper.Map<List<WarehouseInfo>>(entities);
            var result = new ItemsResult<WarehouseInfo>() { Items = items };
            return Task.FromResult(result);
        }
    }
}
