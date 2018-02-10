namespace Warehouse.DataAccess.Entities
{
    public class StockSnapshotProduct
    {
        public int Id { get; set; }

        public int StockSnapshotId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }


        public StockSnapshot Snapshot { get; set; }

        public Product Product { get; set; }
    }
}
