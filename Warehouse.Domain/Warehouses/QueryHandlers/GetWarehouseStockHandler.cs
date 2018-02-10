using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Products.Models;
using Warehouse.Domain.Warehouses.Models;
using Warehouse.Domain.Warehouses.Queries;
using Entities = Warehouse.DataAccess.Entities;

namespace Warehouse.Domain.Warehouses.QueryHandlers
{
    public class GetWarehouseStockHandler : IRequestHandler<GetWarehouseStock, WarehouseStock>
    {
        private readonly WarehouseDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWarehouseStockHandler(WarehouseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public Task<WarehouseStock> Handle(GetWarehouseStock request, CancellationToken cancellationToken)
        {
            WarehouseStock stock = new WarehouseStock();
            stock.CurrentStock = new List<Stock>();
            stock.MaxSize = _dbContext.Warehouses.Single(x => x.Id == request.WarehouseId).Size;

            //get the most recent snapshot if any
            Entities.StockSnapshot snapshot = _dbContext.StockSnapshots.Where(x => x.WarehouseId == request.WarehouseId)
                .Include(x => x.Products)
                .Include("Products.Product")
                .OrderByDescending(x => x.SnapshotDate)
                .FirstOrDefault();

            //add snapshot products to current stock
            if (snapshot != null && snapshot.Products != null && snapshot.Products.Any())
                stock.CurrentStock = _mapper.Map<List<Stock>>(snapshot.Products);

            //get any stock imports/exports not included in the recent snapshot
            List<Entities.StockEvent> stockEvents = null;
            if (snapshot == null)
                stockEvents = _dbContext.StockEvents.Where(x => x.WarehouseId == request.WarehouseId)
                    .Include(x => x.Product)
                    .ToList();
            else
                stockEvents = _dbContext.StockEvents.Where(x => x.WarehouseId == request.WarehouseId && x.EventDate > snapshot.SnapshotDate)
                    .Include(x => x.Product)
                    .ToList();

            //add the imports/export not included in snapshot to the recent stock
            if (stockEvents != null && stockEvents.Any())
            {
                var eventsGroupedByProduct = stockEvents.GroupBy(x => x.ProductId);
                foreach (var productEvents in eventsGroupedByProduct)
                {
                    //calculate the amount of product stock
                    int productAmount = productEvents.Aggregate(0, (amount, stockEvent) => amount + ProductAmountToInt(stockEvent));

                    if (productAmount != 0)
                    {
                        //add to the stock or insert product
                        var productStock = stock.CurrentStock.FirstOrDefault(x => x.Product.Id == productEvents.Key);
                        if (productStock == null)
                        {
                            var product = _mapper.Map<Product>(productEvents.First().Product);
                            stock.CurrentStock.Add(new Stock()
                            {
                                Amount = productAmount,
                                Product = product
                            });
                        }
                        else
                        {
                            productStock.Amount += productAmount;
                        }
                    }
                }
            }

            stock.FreeSpace = stock.MaxSize - stock.CurrentStock.Sum(x => x.Amount * x.Product.UnitSize);

            return Task.FromResult(stock);
        }

        /// <summary>
        /// Returns negative amount for EventType == "export" and positive for "import"
        /// </summary>
        /// <param name="stockEvent"></param>
        /// <returns></returns>
        private int ProductAmountToInt(Entities.StockEvent stockEvent)
        {
            if (stockEvent.EventType == EventTypes.Import)
                return stockEvent.ProductAmount;
            else if (stockEvent.EventType == EventTypes.Export)
                return -stockEvent.ProductAmount;
            else
                return 0;
        }
    }
}
