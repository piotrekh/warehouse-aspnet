using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Warehouses.Commands;
using Warehouse.Domain.Warehouses.Exceptions;
using Warehouse.Domain.Warehouses.Queries;

namespace Warehouse.Domain.Warehouses.CommandHandlers
{
    public class AddStockEventHandler : IRequestHandler<AddStockEvent>
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddStockEventHandler(WarehouseDbContext dbContext,
            IMapper mapper,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Handle(AddStockEvent message, CancellationToken cancellationToken)
        {
            var stockForDate = await _mediator.Send(new GetWarehouseStock()
            {
                WarehouseId = message.WarehouseId,
                CheckDate = message.EventDate
            });
            //check if we can export this amount of product
            if (message.EventType == EventTypes.Export)
            {
                var product = stockForDate.CurrentStock.SingleOrDefault(x => x.Product.Id == message.ProductId);
                if (product == null || product.Amount < message.ProductAmount)
                    throw new CannotExportStockException();
            }
            else if (message.EventType == EventTypes.Import)
            {
                //check if the warehouse accepts hazardous/non-hazardous products and if we have space for import
                var product = _dbContext.Products.Single(x => x.Id == message.ProductId);
                var warehouse = _dbContext.Warehouses.Single(x => x.Id == message.WarehouseId);                
                if (product.IsHazardous != warehouse.HazardousProducts || stockForDate.FreeSpace < product.UnitSize * message.ProductAmount)
                    throw new CannotImportStockException();
            }

            var entity = _mapper.Map<DataAccess.Entities.StockEvent>(message);
            _dbContext.StockEvents.Add(entity);
            _dbContext.SaveChanges();

            //we need to fix or remove snapshots that are no longer valid because of import/export
            //in the past - this could be done e.g. in a queue - or there could be such a requirement
            //in the system that imports/exports cannot be added after a snapshot has been made
            //(meaning that the user can only add them up to some time in the past, and e.g.
            //cannot add imports/exports to previous weeks, months, etc. but only to the current one)            
            var snapshots = _dbContext.StockSnapshots.Where(x => x.WarehouseId == message.WarehouseId && x.SnapshotDate > message.EventDate)
                .Include(x => x.Products)
                .ToList();
            if (snapshots.Any())
            {
                //let's remove the invalid snapshots for simplicity of this project
                _dbContext.StockSnapshots.RemoveRange(snapshots);
                _dbContext.SaveChanges();
            }
        }
    }
}
