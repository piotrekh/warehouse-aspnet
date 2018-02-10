using AutoMapper;

namespace Warehouse.Domain.Products.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DataAccess.Entities.Product, Product>();
        }
    }
}
