CREATE PROCEDURE [dbo].[AddPurchase]
    @productId int,
    @cost decimal(18,2),
    @MRP decimal(18,2) = null, 
    @batchId int,
    @stock decimal(18,3)
AS
    
    declare @Exp decimal(18,2)
    --declare @MRP decimal(18,2)
    declare @Prof decimal(18,2)
    declare @weight decimal(10,3)
    declare @stdweight decimal(10,3) = null

	select @weight = Weight, @stdweight = StandardWeight from Products Where Id = @productId

    SET @cost = @cost * @Weight / 1000
    SET @Exp = @cost * 10/100 + 30
    if(@MRP is null)
        SET @MRP = CEILING(@cost + (@cost * 20/100))
    SET @Prof = @MRP * 5/100 
    
    if(@stdweight is null)
        SET @stdweight = @weight

    Insert into ProductBatch (BatchId, ProductId, PP,Exp, MRP, Prof, Stock) 
    values (@batchId, @productId, @cost, @Exp, @MRP, @Prof, @stock) 

RETURN 0