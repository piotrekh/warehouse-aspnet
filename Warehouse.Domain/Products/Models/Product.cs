namespace Warehouse.Domain.Products.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public int UnitSize { get; set; }

        public bool IsHazardous { get; set; }
    }
}
