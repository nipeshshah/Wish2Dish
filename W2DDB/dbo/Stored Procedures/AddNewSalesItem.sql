CREATE PROCEDURE [dbo].[AddNewSalesItem]
    @SalesId int,  
    @ProductBatchId int, 
    @Quantity decimal(18,3)
AS

    Declare @ProductId int 
    Declare @Rate decimal(18,2)
    Declare @Amount decimal(18,2)
    Declare @StandardWeight decimal(18,2)
    Declare @customerId int
    Declare @fromCustomerId int
    Declare @PrAm decimal(18,2)
    DECLARE @CNAME NVARCHAR(50)

	Select @ProductId = ProductId from ProductBatch where Id = @ProductBatchId

    select @Rate = Ceiling(pb.MRP),
        @Amount = Ceiling((@Quantity/p.Weight) * pb.MRP),
        @StandardWeight = p.Weight,
        @PrAm = pb.Prof/(p.Weight/@Quantity)
        from 
        ProductBatch pb
        left join Batch b on pb.BatchId = b.Id
        left join Products p on pb.ProductId = p.Id
    where pb.Id = @ProductBatchId

    select @customerId = CustomerId from Sales where Id = @SalesId
    SET @fromCustomerId = @customerId
    Select @CNAME = Name from Customer where Id = @fromCustomerId

    INSERT INTO SalesInventory (SalesId, ProductBatchId, ProductId, Rate, Quantity, Amount)
    VALUES(@SalesId, @ProductBatchId, @ProductId, @Rate, @Quantity, @Amount)

    Update Sales Set TotalBillAmount = ISNULL(TotalBillAmount,0) + @Amount, DueAmount = ISNULL(DueAmount,0) + @Amount where Id = @SalesId

    Update ProductBatch set Stock = Stock - @Quantity Where Id = @ProductBatchId

    DECLARE @cnt INT = 0;

	Insert into Points (Description, CustomerId, ProductBatchId, Points, Status, TransactionTime)
    Values (CONCAT('L',(@cnt+1), '-', @customerId,'-',@CNAME), @fromCustomerId, @ProductBatchId, @PrAm * 10/100                                                                                  
		,'PENDING', GETDATE())
    
    Declare @ProfitPercentage decimal(18,2)
    WHILE @cnt < 10
    BEGIN
       Select @customerId = ReferredBy from Customer where Id = @customerId
        if(@customerId is null)
            break;
       
	   if(@cnt =  0 or @cnt = 1)
			SET @ProfitPercentage = 15
		else if(@cnt = 2 or @cnt = 3 or @cnt = 4 or @cnt = 5)
			SET @ProfitPercentage = 10
		else if(@cnt = 6 or @cnt = 7 or @cnt = 8 or @cnt = 9)
			SET @ProfitPercentage = 5

       Insert into Commissions (Description, FromCustomer, ToCustomer, ProductBatchId, Level, Amount, SalesBillId, Status, Date)
       Values (CONCAT('L',(@cnt+1), '-', @customerId,'-',@CNAME), @fromCustomerId, @customerId, 
	   @ProductBatchId, @cnt+1, @PrAm * @ProfitPercentage/100,@SalesId,'PENDING', GETDATE())
       
       --
       --Print CONCAT('L',(@cnt+1), '-', @customerId,'-',@CNAME)
       SET @cnt = @cnt + 1;
    END;

RETURN @@IDENTITY