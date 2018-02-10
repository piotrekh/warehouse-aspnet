CREATE TABLE dbo.StockEvent
(
	Id int IDENTITY(1, 1) NOT NULL,
	EventType varchar(20) NOT NULL,
	EventDate datetime2(0) NOT NULL,
	WarehouseId int NOT NULL,
	ProductId int NOT NULL,
	ProductName nvarchar(100) NOT NULL,
	ProductUnit nvarchar(20) NOT NULL,
	ProductUnitSize int NOT NULL,
	ProductIsHazardous bit NOT NULL,
	ProductAmount int NOT NULL,

	CONSTRAINT PK_StockEvent PRIMARY KEY (Id),
	CONSTRAINT FK_StockEvent_Product_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Product (Id),
	CONSTRAINT FK_StockEvent_Warehouse_WarehouseId FOREIGN KEY (WarehouseId) REFERENCES dbo.Warehouse (Id)
)