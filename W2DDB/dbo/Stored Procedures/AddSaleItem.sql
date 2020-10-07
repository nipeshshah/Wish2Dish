CREATE PROCEDURE [dbo].[AddSaleItem]
    @ProductBatchId int = 0,
    @CustId int,
    @Weight decimal (18,3)
AS
    --Declare @ProductBatchId int
    --Declare @CustId int
    --Declare @Weight decimal (18,3)

    --SET @ProductBatchId = 7
    --SET @Weight = 100

    select p.Name, b.BatchNumber, b.BatchDate, @Weight as Qty, Ceiling(pb.MRP) as Rate, Ceiling((@Weight/p.Weight) * pb.MRP) as Amount from
    ProductBatch pb
    left join Batch b on pb.BatchId = b.Id
    left join Products p on pb.ProductId = p.Id
    where pb.Id = @ProductBatchId
RETURN 0

