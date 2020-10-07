--CategoryName	Name	BatchNumber	Qty	Amount
--Dry Fruits	American Almond	1	250 Grams	Rs.192/-
CREATE PROCEDURE [dbo].[CreatePrintingList]
AS
--    select c.CategoryName, p.Name, b.BatchNumber, 
--case 
--when pb.StandardWeight >= 1000 then
--    concat(CONVERT(DOUBLE PRECISION, pb.StandardWeight/1000),' Kg')
--when pb.StandardWeight <= 1000 then
--    CONCAT(CONVERT(DOUBLE PRECISION, pb.StandardWeight), ' Grams')
--end as Qty,
--CONCAT('Rs.', Ceiling(pb.MRP/pb.Weight*pb.StandardWeight),'/-') as Amount from 
--    ProductBatch pb
--    left join Batch b on pb.BatchId = b.Id
--    left join Products p on pb.ProductId = p.Id
--	left join Category c on p.CategoryId = c.Id

    ;WITH cte AS
	(
SELECT 
--		c.CategoryName, p.Name, b.BatchNumber, 
case 
when StandardWeight >= 1000 then
    concat(CONVERT(DOUBLE PRECISION, StandardWeight/1000),' Kg')
when StandardWeight <= 1000 then
    CONCAT(CONVERT(DOUBLE PRECISION, StandardWeight), ' Grams')
end as Qty,
CONCAT('Rs.', Ceiling(MRP/Weight*StandardWeight),'/-') as Amount, 
CategoryName, Name, BatchDate, BatchNumber, PP, ROW_NUMBER() 
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

