CREATE PROCEDURE [dbo].[StockCosts]
AS
    ;WITH cte AS
	(
		SELECT CategoryName, Name, BatchDate, BatchNumber, PP, ROW_NUMBER() 
		OVER (PARTITION BY Name ORDER BY BatchDate DESC) AS rn
		FROM ProductBatch
		LEFT JOIN Products ON ProductBatch.ProductId = Products.Id
		LEFT JOIN Batch ON ProductBatch.BatchId = Batch.Id
		LEFT JOIN Category on Products.CategoryId = Category.Id
	)

	SELECT *
	FROM cte
	WHERE rn = 1
RETURN 0

