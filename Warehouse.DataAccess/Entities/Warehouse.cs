namespace Warehouse.DataAccess.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

	    public int Size { get; set; }

	    public bool HazardousProducts { get; set; }


        public Address Address { get; set; }
    }
}
