CREATE TABLE dbo.StockSnapshotProduct
(
	Id int IDENTITY(1, 1) NOT NULL,	
	StockSnapshotId int NOT NULL,
	ProductId int NOT NULL,
	ProductName nvarchar(100) NOT NULL,
	ProductUnit nvarchar(20) NOT NULL,
	ProductUnitSize int NOT NULL,
	ProductIsHazardous bit NOT NULL,
	ProductAmount int NOT NULL,

	CONSTRAINT PK_StockSnapshotProduct PRIMARY KEY (Id),
	CONSTRAINT FK_StockSnapshotProduct_Product_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Product (Id),
	CONSTRAINT FK_StockSnapshotProduct_StockSnapshot_StockSnapshotId FOREIGN KEY (StockSnapshotId) REFERENCES dbo.StockSnapshot (Id)
)
