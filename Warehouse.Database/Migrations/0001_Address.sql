CREATE TABLE dbo.Address
(
	Id int IDENTITY(1, 1) NOT NULL,
	Country nvarchar(100) NOT NULL,
	City nvarchar(100) NOT NULL,
	Street nvarchar(100) NOT NULL,
	PostalCode nvarchar(10) NOT NULL,

	CONSTRAINT PK_Address PRIMARY KEY (Id)
)