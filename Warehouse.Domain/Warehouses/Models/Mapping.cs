using AutoMapper;
using Warehouse.Domain.Warehouses.Commands;

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

            CreateMap<AddStockEvent, DataAccess.Entities.StockEvent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Warehouse, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
