using MediatR;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Products.Models;

namespace Warehouse.Domain.Products.Queries
{
    public class GetAllProducts : IRequest<ItemsResult<Product>>
    {
    }
}
