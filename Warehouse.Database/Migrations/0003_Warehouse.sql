CREATE TABLE dbo.Warehouse
(
	Id int IDENTITY(1, 1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	AddressId int NOT NULL,
	Size int NOT NULL,
	HazardousProducts bit NOT NULL,

	CONSTRAINT PK_Warehouse PRIMARY KEY (Id),
	CONSTRAINT FK_Warehouse_Address_AddressId FOREIGN KEY (AddressId) REFERENCES dbo.Address (Id)
)