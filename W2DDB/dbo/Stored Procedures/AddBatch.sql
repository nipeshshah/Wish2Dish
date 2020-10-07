CREATE PROCEDURE [dbo].[AddBatch]
    @BatchNumber nvarchar(50), 
    @BatchDate date
AS
    INSERT INTO Batch (BatchNumber, BatchDate) Values(@BatchNumber, @BatchDate)
RETURN 0

