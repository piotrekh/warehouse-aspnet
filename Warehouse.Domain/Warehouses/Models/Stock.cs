using Warehouse.Domain.Products.Models;

namespace Warehouse.Domain.Warehouses.Models
{
    public class Stock
    {
        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}
