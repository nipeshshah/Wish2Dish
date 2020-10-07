CREATE PROCEDURE [dbo].[AddProduct]
	@CategoryId int,
	@Name nvarchar(50),
    @GujaratiName nvarchar(50),
	@HindiName nvarchar(50),
    @Image nvarchar(50) = '',
	@Weight decimal(10,3),
	@StdWeight decimal(10,3)
AS
    
    insert into Products (Name, Image, Gujarati, Hindi, CategoryId, Weight, StandardWeight) 
	Values (@Name, @Image, @GujaratiName, @HindiName, @CategoryId, @Weight, @StdWeight)

RETURN 0

select * from Products