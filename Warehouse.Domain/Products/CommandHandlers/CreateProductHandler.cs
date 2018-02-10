using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Products.Commands;
using Warehouse.Domain.Products.Models;

namespace Warehouse.Domain.Products.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private WarehouseDbContext _dbContext;
        private IMapper _mapper;

        public CreateProductHandler(WarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DataAccess.Entities.Product>(request);
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();

            var product = _mapper.Map<Product>(entity);
            return Task.FromResult(product);
        }
    }
}
