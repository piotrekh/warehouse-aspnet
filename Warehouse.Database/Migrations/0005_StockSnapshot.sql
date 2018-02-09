CREATE TABLE dbo.StockSnapshot
(
	Id int IDENTITY(1, 1) NOT NULL,	
	WarehouseId int NOT NULL,
	SnapshotDate datetime2(0) NOT NULL,

	CONSTRAINT PK_StockSnapshot PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_StockSnapshot_Warehouse_WarehouseId FOREIGN KEY (WarehouseId) REFERENCES dbo.Warehouse (Id)
)

CREATE CLUSTERED INDEX IX_StockSnapshot_WarehouseId_SnapshotDate ON dbo.StockSnapshot (WarehouseId, SnapshotDate) 