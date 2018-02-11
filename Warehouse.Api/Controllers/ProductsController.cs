using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Products.Models;
using Warehouse.Domain.Products.Queries;

namespace Warehouse.Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseType(typeof(ItemsResult<Product>))]
        public async Task<ItemsResult<Product>> GetAllProducts()
        {
            var query = new GetAllProducts();
            return await _mediator.Send(query);
        }
    }
}
