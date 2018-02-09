CREATE TABLE dbo.Product
(
	Id int IDENTITY(1, 1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Unit nvarchar(20) NOT NULL,
	UnitSize int NOT NULL,
	IsHazardous bit NOT NULL,

	CONSTRAINT PK_Product PRIMARY KEY (Id)
)