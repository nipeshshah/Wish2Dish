CREATE PROCEDURE [dbo].[CreateCustomer]
    @Name nvarchar(50),
    @ReferredBy int = null
AS  
    Insert into Customer (Name, ReferredBy) values (@Name, @ReferredBy)
RETURN @@Identity

