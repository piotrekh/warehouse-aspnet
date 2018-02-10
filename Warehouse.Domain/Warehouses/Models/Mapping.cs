using AutoMapper;

namespace Warehouse.Domain.Warehouses.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DataAccess.Entities.Address, Address>();
            CreateMap<DataAccess.Entities.Warehouse, WarehouseInfo>();
            CreateMap<DataAccess.Entities.StockSnapshotProduct, Stock>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.ProductAmount))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
        }
    }
}
