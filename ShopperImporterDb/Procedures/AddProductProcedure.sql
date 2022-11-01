CREATE PROCEDURE [dbo].[AddProductProcedure]
    @code NVARCHAR(20),
	@barcode NCHAR(10),
	@unit NCHAR(100),
	@category NVARCHAR(150),
	@weight nchar(10),
	@name NVARCHAR(100),
	@shortDescription NVARCHAR(MAX),
	@description NVARCHAR(MAX),
	@price nchar(10),
	@image1 IMAGE,
	@image2 IMAGE,
	@image3 IMAGE,
	@image4 IMAGE,
	@image5 IMAGE,
	@image6 IMAGE,
	@seoTitle NVARCHAR(200),
	@seoDescription NVARCHAR(MAX),
	@seoKeyWords NVARCHAR(MAX),
	@seoUrl NVARCHAR(100)
AS
BEGIN TRAN AddProduct;
	INSERT INTO 
		[dbo].[Products](
			[Code],
			[Barcode],
			[Unit],
			[Category],
			[Weight],
			[Name],
			[ShortDescription],
			[Description],
			[Price],
			[Image1],
			[Image2],
			[Image3],
			[Image4],
			[Image5],
			[Image6],
			[SeoTitle],
			[SeoDescription],
			[SeoKeyWords],
			[SeoUrl]
		) 
		values(
			@code,
			@barcode,
			@unit,
			@category,
			@weight,
			@name,
			@shortDescription,
			@description,
			@price,
			@image1,
			@image2,
			@image3,
			@image4,
			@image5,
			@image6,
			@seoTitle,
			@seoDescription,
			@seoKeyWords,
			@seoUrl
		)
COMMIT TRAN AddProduct;
GO;
