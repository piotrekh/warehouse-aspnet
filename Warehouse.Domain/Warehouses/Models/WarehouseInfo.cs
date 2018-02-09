namespace Warehouse.Domain.Warehouses.Models
{
    public class WarehouseInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public bool HazardousProducts { get; set; }

        public Address Address { get; set; }
    }
}
