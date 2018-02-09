using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Warehouses.Models;
using Warehouse.Domain.Warehouses.Queries;

namespace Warehouse.Api.Controllers
{
    [RoutePrefix("warehouses")]
    public class WarehousesController : ApiController
    {
        private readonly IMediator _mediator;

        public WarehousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ItemsResult<WarehouseInfo>> GetAllWarehouses()
        {
            var query = new GetAllWarehouses();
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
