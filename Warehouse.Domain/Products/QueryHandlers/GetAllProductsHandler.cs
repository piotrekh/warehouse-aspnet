using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Products.Models;
using Warehouse.Domain.Products.Queries;

namespace Warehouse.Domain.Products.QueryHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ItemsResult<Product>>
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(WarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ItemsResult<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var entities = _dbContext.Products.ToList();
            var products = _mapper.Map<List<Product>>(entities);
            var result = new ItemsResult<Product>() { Items = products };
            return Task.FromResult(result);
        }
    }
}
