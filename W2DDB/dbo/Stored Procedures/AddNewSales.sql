CREATE PROCEDURE [dbo].[AddNewSales]
    @CustomerId      INT,
    @SDate           DATE,
    @InvNo           NVARCHAR (20),
    @DueAmount       DECIMAL (18, 2),
    @PaidAmount      DECIMAL (18, 2),
    @TotalBillAmount DECIMAL (18, 2)
AS
    INSERT INTO Sales (CustomerId, SDate, [Inv No], TotalBillAmount, PaidAmount, DueAmount)
    VALUES (@CustomerId, @SDate, @InvNo, @TotalBillAmount, @PaidAmount, @DueAmount)
RETURN @@IDENTITY

