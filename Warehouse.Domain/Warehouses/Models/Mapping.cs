using AutoMapper;

namespace Warehouse.Domain.Warehouses.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DataAccess.Entities.Address, Address>();
            CreateMap<DataAccess.Entities.Warehouse, WarehouseInfo>();
        }
    }
}
