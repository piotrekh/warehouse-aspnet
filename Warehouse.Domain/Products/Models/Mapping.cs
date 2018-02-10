using AutoMapper;
using Warehouse.Domain.Products.Commands;

namespace Warehouse.Domain.Products.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DataAccess.Entities.Product, Product>();
            CreateMap<CreateProduct, DataAccess.Entities.Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); //updated from db
        }
    }
}
