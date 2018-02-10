namespace Warehouse.DataAccess.Entities
{
    public class StockSnapshotProduct
    {
        public int Id { get; set; }

        public int StockSnapshotId { get; set; }

        public int ProductId { get; set; }

	    public string ProductName { get; set; }

        public string ProductUnit { get; set; }

        public int ProductUnitSize { get; set; }

	    public bool ProductIsHazardous { get; set; }

        public int ProductAmount { get; set; }


        public StockSnapshot Snapshot { get; set; }
    }
}
