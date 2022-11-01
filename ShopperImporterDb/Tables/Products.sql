CREATE TABLE [dbo].[Products]
(
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
	[Code] NVARCHAR(20),
	[Barcode] NCHAR(10),
	[Unit] NCHAR(100),
	[Category] NVARCHAR(150),
	[Weight] NCHAR(10),
	[Name] NVARCHAR(100),
	[ShortDescription] NVARCHAR(MAX),
	[Description] NVARCHAR(MAX),
	[Price] NCHAR(10),
	[Image1] IMAGE,
	[Image2] IMAGE,
	[Image3] IMAGE,
	[Image4] IMAGE,
	[Image5] IMAGE,
	[Image6] IMAGE,
	[SeoTitle] NVARCHAR(200),
	[SeoDescription] NVARCHAR(MAX),
	[SeoKeyWords] NVARCHAR(MAX),
	[SeoUrl] NVARCHAR(100)
)
