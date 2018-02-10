SET IDENTITY_INSERT dbo.Product ON

INSERT INTO dbo.Product (Id, Name, Unit, UnitSize, IsHazardous)
VALUES
	(1, 'Apples', 'kilogram', 2, 0),
	(2, 'Milk', 'litre', 1, 0),
	(3, 'Paint', 'litre', 1, 1),
	(4, 'Fireworks', 'pack', 3, 1)

SET IDENTITY_INSERT dbo.Product OFF

------------------------------------------

SET IDENTITY_INSERT dbo.Address ON

INSERT INTO dbo.Address (Id, Country, City,	Street,	PostalCode)
VALUES
	(1, 'Poland', 'Warsaw', 'Test 1/2', '12345'),
	(2, 'United Kingdom', 'London', 'Test 2/3', '23456'),
	(3, 'Norway', 'Oslo', 'Test 3/4', '34567')

SET IDENTITY_INSERT dbo.Address OFF

-------------------------------------------

SET IDENTITY_INSERT dbo.Warehouse ON

INSERT INTO dbo.Warehouse (Id, Name, AddressId,	Size, HazardousProducts)
VALUES
	(1, 'Poland (stock events)', 1, 100, 0),
	(2, 'UK (hazardous, snapshots)', 2, 150, 1),
	(3, 'Norway (small, non-hazardous)', 3, 5, 0)

SET IDENTITY_INSERT dbo.Warehouse OFF

-------------------------------------------

SET IDENTITY_INSERT dbo.StockEvent ON

INSERT INTO dbo.StockEvent (Id,	EventType, EventDate, WarehouseId, ProductId, ProductAmount)
VALUES
	--pl
	(1, 'import', '2018-02-07 12:00', 1, 1, 50),
	(2, 'export', '2018-02-08 15:00', 1, 1, 25),
	(3, 'import', '2018-02-08 16:00', 1, 2, 40),
	--uk
	(4, 'import', '2018-02-01 11:00', 2, 3, 20),
	(5, 'import', '2018-02-02 12:00', 2, 3, 10),
	(6, 'import', '2018-02-03 13:00', 2, 4, 15),
	(7, 'export', '2018-02-05 14:00', 2, 3, 15),
	(8, 'import', '2018-02-07 15:00', 2, 4, 5)

SET IDENTITY_INSERT dbo.StockEvent OFF

--------------------------------------------

SET IDENTITY_INSERT dbo.StockSnapshot ON

INSERT INTO dbo.StockSnapshot (Id, WarehouseId, SnapshotDate)
VALUES
	(1, 2, '2018-02-04 03:00'),
	(2, 2, '2018-02-06 03:00')

SET IDENTITY_INSERT dbo.StockSnapshot OFF

--------------------------------------------

SET IDENTITY_INSERT dbo.StockSnapshotProduct ON

INSERT INTO dbo.StockSnapshotProduct (Id, StockSnapshotId, ProductId, ProductAmount)
VALUES
	(1, 1, 3, 30),
	(2, 1, 4, 15),
	(3, 2, 3, 15),
	(4, 2, 4, 15)

SET IDENTITY_INSERT dbo.StockSnapshotProduct OFF