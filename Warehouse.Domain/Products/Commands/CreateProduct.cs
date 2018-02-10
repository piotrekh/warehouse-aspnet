using MediatR;
using Warehouse.Domain.Products.Models;

namespace Warehouse.Domain.Products.Commands
{
    public class CreateProduct : IRequest<Product>
    {
        public string Name { get; set; }

        public string Unit { get; set; }

        public int UnitSize { get; set; }

        public bool IsHazardous { get; set; }
    }
}
