using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Warehouses.Commands;
using Warehouse.Domain.Warehouses.Exceptions;
using Warehouse.Domain.Warehouses.Models;
using Warehouse.Domain.Warehouses.Queries;

namespace Warehouse.Api.Controllers
{
    [RoutePrefix("api/warehouses")]
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
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{id}/stock")]
        public async Task<WarehouseStock> GetCurrentWarehouseStock(int id)
        {
            var query = new GetWarehouseStock()
            {
                WarehouseId = id,
                CheckDate = DateTime.UtcNow
            };
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{id}/stock_events")]
        public async Task<ItemsResult<StockEvent>> GetWarehouseStockEvents(int id)
        {
            var query = new GetWarehouseStockEvents()
            {
                WarehouseId = id
            };
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("{id}/stock_events")]
        public async Task<IHttpActionResult> AddStockEvent(int id, [FromBody] AddStockEvent command)
        {
            command.WarehouseId = id;
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch(CannotExportStockException)
            {
                return BadRequest("Cannot export stock");
            }
            catch(CannotImportStockException)
            {
                return BadRequest("Cannot import stock");
            }
        }
    }
}
