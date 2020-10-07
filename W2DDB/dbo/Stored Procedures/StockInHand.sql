CREATE PROCEDURE [dbo].[StockInHand]
    @IsBatchWise bit = 0
AS
    if(@IsBatchWise = 0)
    BEGIN
        SELECT Name, BatchDate, BatchNumber,
            SUM(Stock/Weight) as Stock,
            SUM(PP * Stock/Weight) AS StockValue
        FROM ProductBatch
        LEFT JOIN Products ON ProductBatch.ProductId = Products.Id
        LEFT JOIN Batch ON ProductBatch.BatchId = Batch.Id
        Where Stock > 0
		Group By Name, BatchNumber, BatchDate
    END
    ELSE
    BEGIN
        SELECT Name,
            SUM(Stock/Weight) as Stock,
            SUM(PP * Stock/Weight) AS StockValue
        FROM ProductBatch
        LEFT JOIN Products ON ProductBatch.ProductId = Products.Id
        LEFT JOIN Batch ON ProductBatch.BatchId = Batch.Id
        Where Stock > 0
        Group By Name
    END
RETURN 0

