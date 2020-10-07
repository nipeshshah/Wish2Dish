CREATE PROCEDURE [dbo].[GenerateLabel]
    @ProductBatchId int = 0,
    @Weight decimal(18,2)
AS
        
    select c.CategoryName, p.Name, b.BatchNumber, b.BatchDate, @Weight as Qty, Ceiling(pb.MRP) as Rate, Ceiling((@Weight/p.Weight) * pb.MRP) as Amount from
    ProductBatch pb
    left join Batch b on pb.BatchId = b.Id
    left join Products p on pb.ProductId = p.Id
    left join Category c on p.CategoryId = c.Id
    where pb.Id = @ProductBatchId


RETURN 0

