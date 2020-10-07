
CREATE PROCEDURE [dbo].[GetProductBatches]
AS
BEGIN
	SELECT pb.Id
		,CONCAT (
			p.[Name]
			,' ( '
			,b.BatchNumber
			,' ) Rs. '
			,cast(ROUND(pb.MRP / p.Weight * p.StandardWeight, 0, 1) as DECIMAL(9,2))
			,'/- per '
			,p.StandardWeight
			) AS [Name],
			pb.MRP,
			p.Weight
	FROM ProductBatch pb
	LEFT JOIN Products p ON pb.ProductId = p.Id
	LEFT JOIN Batch b ON pb.BatchId = b.Id
	WHERE Stock > 0
END
