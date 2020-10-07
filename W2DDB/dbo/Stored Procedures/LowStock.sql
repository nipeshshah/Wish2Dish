CREATE PROCEDURE [dbo].[LowStock]
AS
    SELECT Name,
        SUM(Stock/Weight) as Stock,
        SUM(PP * Stock/Weight) AS StockValue
    FROM ProductBatch
    LEFT JOIN Products ON ProductBatch.ProductId = Products.Id
    LEFT JOIN Batch ON ProductBatch.BatchId = Batch.Id
	Group By Name 
	Having SUM(Stock/Weight) < 0.250
RETURN 0

